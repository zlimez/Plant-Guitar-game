using System;
using UnityEngine;

[CreateAssetMenu(menuName="Weakness")]
public class Weakness : ScriptableObject
{
    // Major and minor weakness here are redundant, just for visualization purposes.
    // Effective determination is based on the event listeners attached to an alien.
    public Chords majorWeakness;
    public float majorHealthDeduction;
    public Chords minorWeakness;
    public float minorHealthDeduction;

    public override int GetHashCode() {
        return HashCode.Combine(majorWeakness, minorWeakness, majorHealthDeduction, minorHealthDeduction);
    }

    public override bool Equals(System.Object other) {
        if ((other == null) || ! this.GetType().Equals(other.GetType())) {
            return false;
        } else {
            Weakness otherWeakness = (Weakness) other;
            return this.majorWeakness == otherWeakness.majorWeakness && this.minorWeakness == otherWeakness.minorWeakness 
                    && this.majorHealthDeduction == otherWeakness.majorHealthDeduction && this.minorHealthDeduction == otherWeakness.minorHealthDeduction;
        }
    }

    public override string ToString()
    {
        return String.Format("Main: {0} ({1}), Minor: {2} ({3})", majorWeakness, majorHealthDeduction, minorWeakness, minorHealthDeduction);
    }
}
