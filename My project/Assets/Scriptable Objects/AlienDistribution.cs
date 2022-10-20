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
