using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float nextDogTime = 0f;
    private const float NextDogDelay = 0.35f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time > nextDogTime && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextDogTime = Time.time + NextDogDelay;
        }
    }
}
