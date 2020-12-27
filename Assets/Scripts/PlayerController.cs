using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float horizontalInput;
    
    private float speed = 20f;
    private float xRange = 15f;
    private float _nextProjectileTs = 0f;
    private float _projectileDelay = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        // keep the player in bounds
        Vector3 location = transform.position;
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, location.y, location.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, location.y, location.z);
        }

        // Spawn projectiles when spacebar is pressed, throttled by _nextSpawnTs
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextProjectileTs)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            _nextProjectileTs = Time.time + _projectileDelay;
        }
    }
}
