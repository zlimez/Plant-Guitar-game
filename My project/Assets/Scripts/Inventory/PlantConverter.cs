using System;
using UnityEngine;

public class PlantConverter : MonoBehaviour
{
    // Assume base D#3 note maps to 60N
    public static double Eb3Tension = 60;
    public static int scaleInterval = 12;
    public static double logBase = 2;
    // D#3 first note in the array, lowest in frequency
    public Strings[] strings;
    
    public Strings ConvertPlantToString(Plant plant) {
        double frequencyRatio = Math.Sqrt(plant.tension / Eb3Tension);
        // For now plant tension >= 120N will cause IndexOutofBoundsException
        int index = (int) Math.Round(Math.Log(frequencyRatio) / Math.Log(logBase) * scaleInterval);
        Debug.Log("Frequency ratio " + frequencyRatio + " index " + index);
        return strings[index];
    }
}
