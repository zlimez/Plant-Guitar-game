using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // By default last row + 1 of the board
    public int spawnRow;
    public float[] columns;
    public float timeInterval;
    public AlienDistribution alienDistribution;
    public Timer timer;

    public static bool isRightHalf(float y) {
        return y >= 0;
    }

    void Start() {
        alienDistribution = LevelManager.alienDistribution;
        Timer.StartTimer();
        timeInterval = timer.GetNextSpawnInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInterval <= 0) {
            SpawnAlien();
            timeInterval = timer.GetNextSpawnInterval();
            // Debug.Log("Spawn interval: " + timeInterval);
        } else {
            timeInterval -= Time.deltaTime;
        }
    }

    void SpawnAlien() {
        int ticket = Random.Range(0, 100);
        GameObject selectedAlien = alienDistribution.GetSelectedAlien(ticket);
        float spawnColumn = columns[Random.Range(0, columns.Length)];
        Instantiate(selectedAlien, new Vector3(spawnColumn, spawnRow, 0), Quaternion.identity);
    }
}
