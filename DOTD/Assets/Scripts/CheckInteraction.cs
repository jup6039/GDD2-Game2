using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteraction : MonoBehaviour {

    // Fields
    // List of GameObjects to store other character to check for interaction with
    public List<GameObject> characters;
    public GameObject superman;
    public GameObject naruto;
    public GameObject cindy;
    public GameObject shelly;

	// Use this for initialization
	//void Start () {
        /*switch (InteractionHandler.character)
        {
            case "":
                break;
            case "superman":
                superman.SetActive() = false;
                break;
            case "cindy":
                break;
            case "shelly":
                break;
            case "naruto":
                break;
        }*/
	//}
	
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
                        //If the last recorded character in the interaction scene isn't superman, proceed. Otherwise, nothing will happen
                        // so the player can't interact with him twice in one day
                        if(InteractionHandler.character != "superman")
                        {
                            //Set the character in InteractionHandler to be superman
                            InteractionHandler.character = "superman";

                            //Load Scene
					        SceneManager.LoadScene("Interaction");
                        }
				    }
                    else if (c.name == "CindyUmbrella")
                    {
                        //If the last recorded character in the interaction scene isn't cindy, proceed. Otherwise, nothing will happen
                        // so the player can't interact with her twice in one day
                        if(InteractionHandler.character != "cindy")
                        {
                            //Set the character in InteractionHandler to be cindy
                            InteractionHandler.character = "cindy";

                            //Load Scene
					        SceneManager.LoadScene("Interaction");
                        }
                    }
                    else if (c.name == "NarutoJones")
                    {
                        //If the last recorded character in the interaction scene isn't naruto, proceed. Otherwise, nothing will happen
                        // so the player can't interact with him twice in one day
                        if(InteractionHandler.character != "naruto")
                        {
                            //Set the character in InteractionHandler to be naruto
                            InteractionHandler.character = "naruto";

                            //Load Scene
					        SceneManager.LoadScene("Interaction");
                        }
                    }
                    else if (c.name == "ShellyTonne")
                    {
                        //If the last recorded character in the interaction scene isn't shelly, proceed. Otherwise, nothing will happen
                        // so the player can't interact with her twice in one day
                        if(InteractionHandler.character != "shelly")
                        {
                            //Set the character in InteractionHandler to be shelly
                            InteractionHandler.character = "shelly";

                            //Load Scene
					        SceneManager.LoadScene("Interaction");
                        }
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
