using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaySwapSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckClick();
    }

    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A"))
        {
            SceneManager.LoadScene("TownMap");
        }
    }

    void OnGUI()
    {
        //Give it a large font
        GUI.skin.label.fontSize = 180;

        //Draw it in the center of the screen (subtractions are taking into account the size of the object itself
        GUI.Label(new Rect(Screen.width/2 - 200, Screen.height/2 - 150, 500, 350), "Day " + TownSceneHandler.day);
    }
}
