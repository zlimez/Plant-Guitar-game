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
    public float[] mainAlienDistRange = new float[] {30f, 40f};
    public float[] minAlienDistRange = new float[] {10.0f, 20.0f};

    public AlienDistribution generateAlienDistribution() {
        // Need to ensure all aliens can be defeated
        // 2 main enemies 2 minor enemies 2 main enemies will have similar major weakness chord of which two notes
        // in the chords will be shared hence only at most 4 notes are required to cover for both. Minor enemies will
        // at least have two of the notes in their minor weakness chord already present in the union set of notes for
        // the two main enemies main weakness chords. Hence 6 strings in the guitar set will always be sufficient.
        // Build the corresponding data structure above.
        GameObject[] levelAliens = new GameObject[4];
        float[] levelAliensDistribution = new float[4];
        AliensGenerator.BucketAlienByNotes(aliens);
        HashSet<Notes> usedNotes = new HashSet<Notes>();
        HashSet<Weakness> addedAliens = new HashSet<Weakness>();

        GameObject firstAlien = aliens[Random.Range(0, aliens.Length)];
        levelAliens[0] = firstAlien;
        levelAliensDistribution[0] = Random.Range(mainAlienDistRange[0], mainAlienDistRange[1]);
        helper(usedNotes, addedAliens, firstAlien, true);
        Debug.Log("First alien " + firstAlien.GetComponent<Alien>());
        GameObject secondAlien = AliensGenerator.GetAlienWithConstraints(2, usedNotes, true, addedAliens);
        levelAliens[1] = secondAlien;
        levelAliensDistribution[1] = levelAliensDistribution[0] + Random.Range(mainAlienDistRange[0], mainAlienDistRange[1]);
        helper(usedNotes, addedAliens, secondAlien, true);
        Debug.Log("Second alien " + secondAlien.GetComponent<Alien>());
        GameObject thirdAlien = AliensGenerator.GetAlienWithConstraints(2, usedNotes, false, addedAliens);
        levelAliens[2] = thirdAlien;
        levelAliensDistribution[2] = levelAliensDistribution[1] + Random.Range(minAlienDistRange[0], minAlienDistRange[1]);
        helper(usedNotes, addedAliens, thirdAlien, false);
        Debug.Log("Third alien " + thirdAlien.GetComponent<Alien>());
        GameObject fourthAlien = AliensGenerator.GetAlienWithConstraints(2, usedNotes, false, addedAliens);
        levelAliens[3] = fourthAlien;
        // Last one not ensured to be in the minor range ranges from 0 to 30
        levelAliensDistribution[3] = 100f;
        Debug.Log("Fourth alien " + fourthAlien.GetComponent<Alien>());
        Debug.Log("Distribution: " + levelAliensDistribution[0] + " " + levelAliensDistribution[1] + " " + levelAliensDistribution[2] + " " + levelAliensDistribution[3]);
        
        // Dummy 
        return new AlienDistribution(levelAliens, levelAliensDistribution);
    }

    private void helper(HashSet<Notes> usedNotes, HashSet<Weakness> addedAliens, GameObject alien, bool isMajor) {
        Alien alienLogic = alien.GetComponent<Alien>();
        addedAliens.Add(alienLogic.weakness);
        Chords weakness = isMajor ? alienLogic.weakness.majorWeakness : alienLogic.weakness.minorWeakness;
        usedNotes.Add(weakness.rootNote);
        usedNotes.Add(weakness.thirdNote);
        usedNotes.Add(weakness.fifthNote);
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
