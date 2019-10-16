using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterObject : MonoBehaviour
{
    public GameObject player;
    public float interactionRadius;
    private SpriteRenderer renderer;
    

    // Start is called before the first frame update
    void Start()
    {
        interactionRadius = 2;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.color = Color.white;
        //Check if the player's x value is close enough to this object to be in range
        if (player.transform.position.x < transform.position.x + interactionRadius && player.transform.position.x > transform.position.x - interactionRadius)
        {
            //Check if the player's y value is close enough to this object to be in range
            if(player.transform.position.y < transform.position.y + interactionRadius && player.transform.position.y > transform.position.y - interactionRadius)
            {
                //If in range, allow player to interact
                if(Input.GetKey(KeyCode.Space))
                {
                    renderer.color = Color.red;
                    //SceneManager.LoadScene("Interaction", LoadSceneMode.Additive);
                }
            }
        }
        
    }
}
