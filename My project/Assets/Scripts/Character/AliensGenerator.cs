using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensGenerator
{
    // Order same as that in @code Notes
    public static List<WrappedAlien>[] mainWeaknessBuckets = new List<WrappedAlien>[12];
    public static List<WrappedAlien>[] minorWeaknessBuckets = new List<WrappedAlien>[12];

    //Should only be called once
    public static void BucketAlienByNotes(GameObject[] aliens) {
        for (int i = 0; i < mainWeaknessBuckets.Length; i++) {
            mainWeaknessBuckets[i] = new List<WrappedAlien>();
            minorWeaknessBuckets[i] = new List<WrappedAlien>();
        }

        for (int i = 0; i < aliens.Length; i++) {
            WrappedAlien wrappedAlien = new WrappedAlien(aliens[i]);
            // Debug.Log("Wrapped alien " + wrappedAlien);
            Chords majorWeakness = wrappedAlien.weakness.majorWeakness;
            mainWeaknessBuckets[Utilities.NotesToIndex(majorWeakness.rootNote)].Add(wrappedAlien);
            mainWeaknessBuckets[Utilities.NotesToIndex(majorWeakness.thirdNote)].Add(wrappedAlien);
            mainWeaknessBuckets[Utilities.NotesToIndex(majorWeakness.fifthNote)].Add(wrappedAlien);
            Chords minorWeakness = wrappedAlien.weakness.minorWeakness;
            minorWeaknessBuckets[Utilities.NotesToIndex(minorWeakness.rootNote)].Add(wrappedAlien);
            minorWeaknessBuckets[Utilities.NotesToIndex(minorWeakness.thirdNote)].Add(wrappedAlien);
            minorWeaknessBuckets[Utilities.NotesToIndex(minorWeakness.fifthNote)].Add(wrappedAlien);
        }
    }

    // Find an alien whose major/minor weakness chord contains at least @param numOfNotesNeeded notes 
    // out of the given set of candidate notes which is not one of chords contained in the @param repitition set.
    public static GameObject GetAlienWithConstraints(int numOfNotesNeeded, HashSet<Notes> candidateNotes, bool isMajor, HashSet<Weakness> repitition) {
        List<WrappedAlien>[] traversedBuckets = isMajor ? mainWeaknessBuckets : minorWeaknessBuckets;
        List<GameObject> candidateAliens = new List<GameObject>();
        HashSet<WrappedAlien> traversedAliens = new HashSet<WrappedAlien>();
        foreach (Notes note in candidateNotes) {
            // Debug.Log("Current note " + note);
            int noteIndex = Utilities.NotesToIndex(note);
            foreach (WrappedAlien wrappedAlien in traversedBuckets[noteIndex]) {
                traversedAliens.Add(wrappedAlien);
                int sharedNotesCount;
                if (isMajor) {
                    sharedNotesCount = ++wrappedAlien.mainSharedNotesCount;
                } else {
                    sharedNotesCount = ++wrappedAlien.minorSharedNotesCount;
                }
                
                // Can only occur once per alien, safe from causing repitition in candidateAliens
                if (sharedNotesCount == numOfNotesNeeded) {
                    if (!repitition.Contains(wrappedAlien.weakness)) {
                        candidateAliens.Add(wrappedAlien.alien);
                    }
                }
            }
        }

        //Reset all the alien counters for next use
        foreach (WrappedAlien wrappedAlien in traversedAliens) {
            wrappedAlien.Reset();
        }

        if (candidateAliens.Count == 0) {
            Debug.Log("No candidate found");
        }

        return candidateAliens[UnityEngine.Random.Range(0, candidateAliens.Count)];
    }

    public class WrappedAlien {
        public GameObject alien;
        public Weakness weakness;
        public int mainSharedNotesCount;
        public int minorSharedNotesCount;
        public WrappedAlien(GameObject alien) {
            this.alien = alien;
            this.mainSharedNotesCount = 0;
            this.minorSharedNotesCount = 0;
            this.weakness = alien.GetComponent<Alien>().weakness;
        }

        public void Reset() {
            this.mainSharedNotesCount = 0;
            this.minorSharedNotesCount = 0;
        }

        public override string ToString()
        {
            return weakness.ToString();
        }

        public override int GetHashCode()
        {
            return weakness.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if ((other == null) || ! this.GetType().Equals(other.GetType())) {
                return false;
            }
            WrappedAlien otherWrappedAlien = (WrappedAlien) other;
            return weakness.Equals(otherWrappedAlien.weakness);
        }
    }
}
