using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneHandler : MonoBehaviour
{
    public static string gender = "female";

    public GameObject playerObject;
    private Sprite playerSprite;
    public Sprite maleSprite;
    public Sprite femaleSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = playerObject.GetComponent<SpriteRenderer>().sprite;

        if (gender == "male")
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = maleSprite;
        }
        else
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = femaleSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
