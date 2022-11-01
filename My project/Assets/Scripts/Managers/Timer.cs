using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static bool TIMER_START;
    private static float TIME_PASSED = 0;
    public float levelDuration = 120;
    public float initialSpawnInterval = 2;
    public float climaxSpawnInterval = 0.5f;
    public GameEvent levelComplete;

    void Start() {
        ResetTimer();
    }

    // Start is called before the first frame update
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
