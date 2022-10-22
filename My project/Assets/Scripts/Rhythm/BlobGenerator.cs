using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobGenerator : MonoBehaviour
{
    public Vector3 spawnPoint;
    public float timeInterval;
    // Introduce some irregularity to blob intervals
    public float uncertainty;
    public LevelManager levelManager;
    // Rhythm blob (Cytus, 太鼓達人)
    public GameObject blob;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNextInterval();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInterval <= 0) {
            // Debug.Log("Generating new blob");
            Instantiate(blob, spawnPoint, Quaternion.identity);
            GenerateNextInterval();
        } else {
            timeInterval -= Time.deltaTime;
        }
    }
    
    private void GenerateNextInterval() {
        float meanInterval = levelManager.GetNextSpawnInterval();
        timeInterval = Random.Range(meanInterval * (1 - uncertainty), meanInterval * (1 + uncertainty));
    }
}
