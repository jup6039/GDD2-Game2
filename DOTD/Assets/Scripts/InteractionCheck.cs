using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionCheck : MonoBehaviour {

    // Fields
    // List of GameObjects to store other character to check for interaction with
    public List<GameObject> characters;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) || Input.GetButtonDown("A"))
		{
			foreach(GameObject c in characters)
			{
				if(CheckCollision(gameObject, c))
				{
				if(c.name == "SupermanJones")
				{
					SceneManager.LoadScene("Interaction");
				}
				}
			}
		}
	}

	bool CheckCollision(GameObject object1, GameObject object2)
    {
        if (((object1.GetComponent<SpriteRenderer>().bounds.center.x + object1.GetComponent<SpriteRenderer>().bounds.extents.x) > (object2.GetComponent<SpriteRenderer>().bounds.center.x - object2.GetComponent<SpriteRenderer>().bounds.extents.x))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.x - object1.GetComponent<SpriteRenderer>().bounds.extents.x) < (object2.GetComponent<SpriteRenderer>().bounds.center.x + object2.GetComponent<SpriteRenderer>().bounds.extents.x))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.y + object1.GetComponent<SpriteRenderer>().bounds.extents.y) > (object2.GetComponent<SpriteRenderer>().bounds.center.y - object2.GetComponent<SpriteRenderer>().bounds.extents.y))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.y - object1.GetComponent<SpriteRenderer>().bounds.extents.y) < (object2.GetComponent<SpriteRenderer>().bounds.center.y + object2.GetComponent<SpriteRenderer>().bounds.extents.y)))
        { return true; }
        else
        { return false; }
    }
}
