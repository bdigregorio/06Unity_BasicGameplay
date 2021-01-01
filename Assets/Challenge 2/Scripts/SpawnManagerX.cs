using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    
    private const float StartDelay = 1.0f;
    private const float MinSpawnTime = 1f;
    private const float MaxSpawnTime = 4f; 

    private const float SpawnLimitXLeft = -22;
    private const float SpawnLimitXRight = 7;
    private const float SpawnPosY = 30;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(SpawnRandomBall), StartDelay);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall ()
    {
        var randomBallPrefab = ballPrefabs[Random.Range(0, 3)];
        Vector3 randomSpawnPos = new Vector3(Random.Range(SpawnLimitXLeft, SpawnLimitXRight), SpawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(randomBallPrefab, randomSpawnPos, randomBallPrefab.transform.rotation);
        
        // calculate next random spawn
        var nextSpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
        Invoke(nameof(SpawnRandomBall), nextSpawnTime);
    }

}
