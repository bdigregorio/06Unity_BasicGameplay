using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float horizontalInput;
    private Transform _playerTransform;
    private float _nextAllowedProjectileTs = 0f;

    private const float Speed = 20f;
    private const float XRange = 15f;
    private const float ProjectileDelay = 0.2f;
    private const float ProjectileOffset = 1.25f;

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        (_playerTransform = transform).Translate(horizontalInput * Speed * Time.deltaTime * Vector3.right);

        var playerPosition = _playerTransform.position;
        KeepPlayerInBounds(playerPosition);
        SpawnProjectiles(playerPosition);
    }

    private void KeepPlayerInBounds(Vector3 playerPosition)
    {
        // Place player at horizontal bounds if they have moved outside of it
        if (playerPosition.x < -XRange)
        {
            transform.position = new Vector3(-XRange, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > XRange)
        {
            transform.position = new Vector3(XRange, playerPosition.y, playerPosition.z);
        }
    }

    private void SpawnProjectiles(Vector3 playerPosition)
    {
        // Create a projectile if the spacebar is pressed and the delay has passsed
        if (Time.time > _nextAllowedProjectileTs && Input.GetKey(KeyCode.Space))
        {
            var projectilePosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + ProjectileOffset);
            Instantiate(projectilePrefab, projectilePosition, projectilePrefab.transform.rotation);
            _nextAllowedProjectileTs = Time.time + ProjectileDelay;
        }
    }
}
