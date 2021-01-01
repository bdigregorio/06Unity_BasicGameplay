using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private const float SpawnStartDelay = 1.5f;
    private const float SpawnInterval = 2f;
    private float _spawnRangeX = 15f;
    private float _spawnPosZ = 20f;
    private readonly Quaternion _animalRotation = new Quaternion(0, 90, 0, 0);

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), SpawnStartDelay, SpawnInterval);
    }

    private void SpawnRandomAnimal()
    {
            var randomAnimalIndex = Random.Range(0, animalPrefabs.Length);
            var randomPosX = Random.Range(-_spawnRangeX, _spawnRangeX);
            var spawnPosition = new Vector3(randomPosX, 0, _spawnPosZ);
            
            // create a new animal at top of screen
            Instantiate(animalPrefabs[randomAnimalIndex], spawnPosition, _animalRotation);
    }
}
