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
            if((transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.extents.y) >= GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.y)
                transform.position -= new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed, 0);
            if((transform.position.y - gameObject.GetComponent<SpriteRenderer>().bounds.extents.y) <= -GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.y)
                transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if((transform.position.x - gameObject.GetComponent<SpriteRenderer>().bounds.extents.x) <= -GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.x)
                transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            if((transform.position.x + gameObject.GetComponent<SpriteRenderer>().bounds.extents.x) >= GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.x)
                transform.position -= new Vector3(speed, 0, 0);
        }
        /*else
        {
            // Xbox controller input
            transform.position += new Vector3(
                Input.GetAxis("Horizontal") / 10,
                Input.GetAxis("Vertical") / 10,
                0);
        }*/
    }
}
