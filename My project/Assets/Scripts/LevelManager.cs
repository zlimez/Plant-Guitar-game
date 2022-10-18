using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static bool TIMER_START;
    public static Chords CHORD_PLAYED;
    public static int ALIEN_TYPES_PER_LEVEL = 4;
    public static float LEVEL_DURATION = 240;
    public static float INITIAL_SPAWN_INTERVAL = 2;
    public static float CLIMAX_SPAWN_INTERVAL = 0.2f;
    private static float TIME_PASSED = 0;
    // All alien variation prefabs
    public GameObject[] aliens;

    public AlienDistribution generateAlienDistribution() {
        // Need to ensure all aliens can be defeated
        // 2 main enemies 2 minor enemies 2 main enemies will have similar major weakness chord of which two notes
        // in the chords will be shared hence only at most 4 notes are required to cover for both. Minor enemies will
        // at least have two of the notes in their minor weakness chord already present in the union set of notes for
        // the two main enemies main weakness chords. Hence 6 strings in the guitar set will always be sufficient.
        // Build the corresponding data structure above.
        
        return new AlienDistribution(null, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (TIMER_START) {
            TIME_PASSED += Time.deltaTime;
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

    public static float GetNextSpawnInterval() {
        // Interpolate the two intervals according to time passed in the level
        if (TIME_PASSED <= LEVEL_DURATION / 2) {
            return INITIAL_SPAWN_INTERVAL - (INITIAL_SPAWN_INTERVAL - CLIMAX_SPAWN_INTERVAL) * (TIME_PASSED / (LEVEL_DURATION / 2));
        } else {
            return CLIMAX_SPAWN_INTERVAL + (INITIAL_SPAWN_INTERVAL - CLIMAX_SPAWN_INTERVAL) * (TIME_PASSED - (LEVEL_DURATION / 2)) / (LEVEL_DURATION / 2);
        }
       
    }
}
