using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 0.1f;
    Rigidbody2D rb;

    float playerSpeed = 10; //speed player moves
    float turnSpeed = 100; // speed player turns
    bool shouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(shouldMove);
        if (shouldMove)
        {
            MoveForward(); // Player Movement
            TurnRightAndLeft(); //Player Turning
        } else
        {
            //transform.Translate(new Vector3(0, 0, 0));
            if (Input.GetKey("up"))
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
            } else if (Input.GetKey("down"))
            {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            }
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, speed, 0);
        //    if((transform.position.y + gameObject.GetComponent<SpriteRenderer>().bounds.extents.y) >= GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.y)
        //        transform.position -= new Vector3(0, speed, 0);
        //        rb.AddForce(transform.up *1.0f);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= new Vector3(0, speed, 0);
        //    if((transform.position.y - gameObject.GetComponent<SpriteRenderer>().bounds.extents.y) <= -GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.y)
        //        transform.position += new Vector3(0, speed, 0);
        //    rb.AddForce(-transform.up * 1.0f);

        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= new Vector3(speed, 0, 0);
        //    gameObject.GetComponent<SpriteRenderer>().flipX = false;
        //    if((transform.position.x - gameObject.GetComponent<SpriteRenderer>().bounds.extents.x) <= -GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.x)
        //        transform.position += new Vector3(speed, 0, 0);
        //    rb.AddForce(-transform.right * 1.0f);

        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(speed, 0, 0);
        //    gameObject.GetComponent<SpriteRenderer>().flipX = true;
        //    if((transform.position.x + gameObject.GetComponent<SpriteRenderer>().bounds.extents.x) >= GameObject.Find("Cover").GetComponent<SpriteRenderer>().bounds.extents.x)
        //        transform.position -= new Vector3(speed, 0, 0);
        //    rb.AddForce(transform.right * 1.0f);
        //}

        //if (Input.anyKey == false)
        //{
        //    rb.AddForce(transform.right * 0f);
        //}

    }

    void MoveForward()
    {

        if (Input.GetKey(KeyCode.W))//Press up arrow key to move forward on the Y AXIS
        {
            //transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            //rb.AddForce(transform.up * 1.0f,ForceMode2D.Impulse);
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.AddForce(transform.up * 0);
        }

        if (Input.GetKey(KeyCode.S))//Press down arrow key to move down on the Y AXIS
        {
            //transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
           rb.AddForce(-transform.up * 1.0f);

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.AddForce(transform.up * 0);
        }


    }

    void TurnRightAndLeft()
    {

        if (Input.GetKey(KeyCode.D)) //Right arrow key to turn right
        {
            //transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
                 rb.AddForce(transform.right * 1.0f); 

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.AddForce(transform.right * 0);
        }
        if (Input.GetKey(KeyCode.A))//Left arrow key to turn left
        {
            //transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            rb.AddForce(-transform.right * 1.0f);

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.AddForce(transform.up * 0);
        }


    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Wall")  // or if(gameObject.CompareTag("YourWallTag"))
    //    {// there might be a problem here due to Unity's box collision sometimes getting stuck 
    //       shouldMove = false;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    shouldMove = true;
    //}
}
