using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        else
        {
            // Xbox controller input
            transform.position += new Vector3(
                Input.GetAxis("Horizontal") / 10,
                Input.GetAxis("Vertical") / 10,
                0);
        }
    }
}
