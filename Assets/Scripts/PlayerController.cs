using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    private float xRange = 15f;
    
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
    }
}
