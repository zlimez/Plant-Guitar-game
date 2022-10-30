using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(menuName="String")]
public class Strings : ScriptableObject
{
    public Notes note;
    public AudioClip clip;
    public Sprite image;
    public Sprite icon;
    public GameEvent NotePlayed;

    // Every string has a unique note less future aesthetic consideration where multiple visually distinct strings play same note
    public override bool Equals(object other) {
        if ((other == null) || ! this.GetType().Equals(other.GetType())) {
            return false;
        } else {
            Strings otherString = (Strings) other;
            return this.note == otherString.note;
        }
    }

    public override int GetHashCode() {
        return note.GetHashCode();
    }
}
