using System;
using UnityEngine;

public class AlienDistribution
{
    // From alien with highest spawn probability to lowest
    public GameObject[] aliens;
    public float[] distribution;

    public AlienDistribution(GameObject[] aliens, float[] distribution) {
        this.aliens = aliens;
        this.distribution = distribution;
    }

    public string[] GenReport() {
        string[] reports = new string[aliens.Length];
        for (int i = 0; i < reports.Length; i++) {
            Alien alienMeta = aliens[i].GetComponent<Alien>();
            // Two main aliens
            if (i < 2) {
                reports[i] = String.Format("Main threat Alien {0}\n"
                        + "Main Weakness: {1}\n"
                        + "Minor Weakness: {2}\n"
                        , alienMeta.alienCodeName, alienMeta.weakness.majorWeakness.name, alienMeta.weakness.minorWeakness.name);
            } else {
                reports[i] = String.Format("Minor threat Alien {0}\n"
                        + "Main Weakness: {1}\n"
                        + "Minor Weakness: {2}\n"
                        , alienMeta.alienCodeName, alienMeta.weakness.majorWeakness.name, alienMeta.weakness.minorWeakness.name);
            }
        }
        return reports;
    }

    public Sprite[] GetAlienImages() {
        Sprite[] images = new Sprite[aliens.Length];
        for (int i = 0; i < images.Length; i++) {
            images[i] = aliens[i].GetComponentInChildren<SpriteRenderer>().sprite;
        }

        return images;
    }

    public GameObject GetSelectedAlien(int ticket) {
        // Binary search 
        int start = 0;
        int end = distribution.Length;
        while (start <= end) {
            int mid = (start + end) / 2;
            if (ticket <= distribution[mid] && (mid == 0 || ticket > distribution[mid - 1])) {
                return aliens[mid];
            } else if (ticket < distribution[mid]) {
                end = mid;
            } else {
                start = mid + 1;
            }
        }
        Debug.LogError("Alien should be selected already.");
        return aliens[start];
    }
}
