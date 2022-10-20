using System.Collections;
using System.Collections.Generic;
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
}
