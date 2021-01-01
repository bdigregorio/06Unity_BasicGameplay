using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBounds = 35f;
    private float _bottomBounds = -10f;

    private void Update()
    {
        // Check if the object has travelled beyond the vertical bounds
        if (transform.position.z > _topBounds)
        {
            Destroy(gameObject);
        } else if (transform.position.z < _bottomBounds)
        {
            Debug.Log("Game over!");
            Destroy(gameObject);
        }
    }
}
