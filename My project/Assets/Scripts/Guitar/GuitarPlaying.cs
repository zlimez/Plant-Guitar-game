using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlaying : Guitar
{
    // These two fields serve to bridge dictionary and unity inspector
    public Chords[] chords;
    public GameEvent[] chordEvents;
    // All valid chords and the respective event they trigger when played
    private Dictionary<Chords, GameEvent> chordEventMapper = new Dictionary<Chords, GameEvent>();
    // Keeps the most recent three notes played
    public Queue<Notes> notesPlayed = new Queue<Notes>();
    public Queue<double> notesTimeSig = new Queue<double>();
    // First and last note of a chord must be played within the time frame to be considered as a chord
    public float timeFrame;

    void Awake() {
        for (int i = 0; i < chords.Length; i++) {
            chordEventMapper[chords[i]] = chordEvents[i];
        }
    }

    void Start() {
        // Result of building the guitar in assembly stage
        this.strings = GameManager.instance.strings;
        for (int i = 0; i < strings.Length; i++) {
            stringObjects[i].GetComponent<StringPlucker>().AssignString(strings[i]);
        }
    }

    // Overrides Update() in Guitar to detect chords
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayString(0);
            ParseNewNote(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            PlayString(1);
            ParseNewNote(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            PlayString(2);
            ParseNewNote(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            PlayString(3);
            ParseNewNote(3);
        } 
        
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            PlayString(4);
            ParseNewNote(4);
        } 
        
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            PlayString(5);
            ParseNewNote(5);
        }
    }

    // Problem with current implementation: Once player plays a note that does not belong to a chord he 
    // must wait for the corresponding timeframe to expire to start a new chord.
    public void ParseNewNote(int index) {
        if (notesPlayed.Count == 3) {
            // Ensure queue length <= 3
            notesPlayed.Dequeue();
            notesTimeSig.Dequeue();
        }
        double timeStamp = Utilities.GetTimeStamp();
        Notes newNote = strings[index].note;
        notesPlayed.Enqueue(newNote);
        notesTimeSig.Enqueue(timeStamp);
        if (notesPlayed.Count > 1 && timeStamp - notesTimeSig.Peek() >= timeFrame) {
            // Notes span exceeded allowed duration
            notesPlayed.Dequeue();
            notesTimeSig.Dequeue();
        } else if (notesPlayed.Count == 3) {
            DetermineChord();
        }
    }

    public void DetermineChord() {
        // From the notes played in the last interval determine the chord played an emit the corresponding event
        List<Notes> sortedNotes = new List<Notes>(notesPlayed.ToArray());
        sortedNotes.Sort();
        Chords rawChord = Chords.Of(sortedNotes[0], sortedNotes[1], sortedNotes[2]);
        // Debug.Log(sortedNotes[0] + " " + sortedNotes[1] + " " + sortedNotes[2]);
        if (chordEventMapper.ContainsKey(rawChord)) {
            chordEventMapper[rawChord].TriggerEvent();
            notesPlayed.Clear();
            notesTimeSig.Clear();
        } else {
            // Only remove oldest note from the queue if the current trio is invalid
            notesPlayed.Dequeue();
            notesTimeSig.Dequeue();
            Debug.Log("Invalid chord played");
        }
    }
}
