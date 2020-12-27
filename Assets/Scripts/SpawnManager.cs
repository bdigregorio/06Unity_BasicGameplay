using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    
    private const float SpawnDelay = 0.5f;
    private float _nextSpawnTs = 0f;
    private float _spawnRangeX = 20f;
    private float _spawnPosZ = 20f;
    private readonly Quaternion _animalRotation = new Quaternion(0, 90, 0, 0);
    
    void Update()
    {
        // when 'S' is pressed, throttled by nextSpawnTs
        if (Time.time >= _nextSpawnTs)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            float spawnPosX = Random.Range(-_spawnRangeX, _spawnRangeX);
            Vector3 spawnPosition = new Vector3(spawnPosX, 0, _spawnPosZ);
            
            // create a new animal at top of screen
            Instantiate(animalPrefabs[animalIndex], spawnPosition, _animalRotation);
            
            // update timestamp for the earliest allowed next spawn
            _nextSpawnTs = Time.time + SpawnDelay;
        }
    }
}
