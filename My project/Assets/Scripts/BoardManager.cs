using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // By default last row + 1 of the board
    public int spawnRow;
    public int columns;
    // Initial time interval for generating new alien decreases th
    public float timeInterval;
    public AlienDistribution alienDistribution;

    // Start is called before the first frame update
    void Start() {
        timeInterval = LevelManager.GetNextSpawnInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInterval <= 0) {
            SpawnAlien();
            timeInterval = LevelManager.GetNextSpawnInterval();
        } else {
            timeInterval -= Time.deltaTime;
        }
    }

    void SpawnAlien() {
        int ticket = Random.Range(0, 100);
        GameObject selectedAlien = alienDistribution.GetSelectedAlien(ticket);
        int spawnColumn = Random.Range(0, columns);
        Instantiate(selectedAlien, new Vector3(spawnColumn, spawnRow, 0), Quaternion.identity);
    }
}
