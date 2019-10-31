using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSceneHandler : MonoBehaviour
{
    public static string gender = "female";
    public static int day = 1;
    public static int interactionsLeft = 2;
    public static int interactionsPerDay = 2;

    public GameObject playerObject;
    private Sprite playerSprite;
    public Sprite maleSprite;
    public Sprite femaleSprite;
    //public RuntimeAnimatorController maleWalk;
    //public RuntimeAnimatorController femaleWalk;
    // Cut animation for now

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = playerObject.GetComponent<SpriteRenderer>().sprite;

        if (gender == "male")
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = maleSprite;
            //playerObject.GetComponent<Animator>().runtimeAnimatorController = maleWalk;
        }
        else
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = femaleSprite;
            //playerObject.GetComponent<Animator>().runtimeAnimatorController = femaleWalk;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
