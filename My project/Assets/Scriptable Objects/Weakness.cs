using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Weakness")]
public class Weakness : ScriptableObject
{
    public Chords majorWeakness;
    public float majorHealthDeduction;
    public Chords minorWeakness;
    public float minorHealthDeduction;
}
