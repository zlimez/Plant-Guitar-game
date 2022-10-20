using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All the meta info about the level is stored here
public class LevelManager : MonoBehaviour
{
    public static bool TIMER_START;
    public static Chords CHORD_PLAYED;
    private static float TIME_PASSED = 0;
    public int alienTypes = 4;
    public float levelDuration = 240;
    public float initialSpawnInterval = 2;
    public float climaxSpawnInterval = 0.2f;
    // Survival based
    public GameEvent levelComplete;
    // All alien variation prefabs
    public GameObject[] aliens;

    public AlienDistribution generateAlienDistribution() {
        // Need to ensure all aliens can be defeated
        // 2 main enemies 2 minor enemies 2 main enemies will have similar major weakness chord of which two notes
        // in the chords will be shared hence only at most 4 notes are required to cover for both. Minor enemies will
        // at least have two of the notes in their minor weakness chord already present in the union set of notes for
        // the two main enemies main weakness chords. Hence 6 strings in the guitar set will always be sufficient.
        // Build the corresponding data structure above.
        
        // Dummy 
        return new AlienDistribution(new GameObject[] {aliens[0], aliens[1], aliens[2], aliens[3]}, new float[] {25, 50, 75, 100});
    }

    // Update is called once per frame
    void Update()
    {
        if (TIME_PASSED >= levelDuration) {
            // Level ended
            StopTimer();
            levelComplete.TriggerEvent();
        } else {
            if (TIMER_START) {
                TIME_PASSED += Time.deltaTime;
            }
        }
    }

    public static void StartTimer() {
        TIMER_START = true;
    }

    public static void StopTimer() {
        TIMER_START = false;
    }

    public static void ResetTimer() {
        TIME_PASSED = 0;
    }

    public float GetNextSpawnInterval() {
        // Interpolate the two intervals according to time passed in the level
        if (TIME_PASSED <= levelDuration / 2) {
            return initialSpawnInterval - (initialSpawnInterval - climaxSpawnInterval) * (TIME_PASSED / (levelDuration / 2));
        } else {
            return climaxSpawnInterval + (initialSpawnInterval - climaxSpawnInterval) * (TIME_PASSED - (levelDuration / 2)) / (levelDuration / 2);
        }
       
    }
}
