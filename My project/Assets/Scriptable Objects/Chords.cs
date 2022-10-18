using UnityEngine;

[CreateAssetMenu(menuName = "Chord")]
public class Chords : ScriptableObject
{ 
    public Notes rootNote;
    public Notes thirdNote;
    public Notes fifthNote;

    public Chords(Notes rootNote, Notes thirdNote, Notes fifthNote) {
        this.rootNote = rootNote;
        this.thirdNote = thirdNote;
        this.fifthNote = fifthNote;
    }

    public override int GetHashCode() {
        // This is to support Chord finding with notes in @code Guitar
        return rootNote.GetHashCode() + thirdNote.GetHashCode() + fifthNote.GetHashCode();
    }
}
