using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private const float SpawnLimitXLeft = -22;
    private const float SpawnLimitXRight = 7;
    private const float SpawnPosY = 30;

    private const float StartDelay = 1.0f;
    private const float SpawnInterval = 4.0f;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomBall), StartDelay, SpawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall ()
    {
        var randomBallIndex = Random.Range(0, 3);
        var spawnPosX = Random.Range(SpawnLimitXLeft, SpawnLimitXRight);
        
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(spawnPosX, SpawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBallIndex], spawnPos, Quaternion.identity);
    }

}
