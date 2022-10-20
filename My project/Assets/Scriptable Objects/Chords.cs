using UnityEngine;

[CreateAssetMenu(menuName = "Chord")]
public class Chords : ScriptableObject
{ 
    public Notes rootNote;
    public Notes thirdNote;
    public Notes fifthNote;

    public void Init(Notes rootNote, Notes thirdNote, Notes fifthNote) {
        this.rootNote = rootNote;
        this.thirdNote = thirdNote;
        this.fifthNote = fifthNote;
    }

    // Factory method to create Chords instance to support DetermineChord() method in @code GuitarPlaying
    public static Chords Of(Notes rootNote, Notes thirdNote, Notes fifthNote) {
        Chords chord = ScriptableObject.CreateInstance<Chords>();
        chord.Init(rootNote, thirdNote, fifthNote);
        return chord;
    }

    public override int GetHashCode() {
        // This is to support Chord finding with notes in @code Guitar
        return rootNote.GetHashCode() + thirdNote.GetHashCode() + fifthNote.GetHashCode();
    }

    public override bool Equals(System.Object other) {
        if ((other == null) || ! this.GetType().Equals(other.GetType())) {
            return false;
        } else {
            Chords otherChord = (Chords) other;
            return this.rootNote == otherChord.rootNote && this.thirdNote == otherChord.thirdNote && this.fifthNote == otherChord.fifthNote;
        }
    }
}
