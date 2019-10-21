using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Public Variables

     // local variables
    public GameObject button1;                          // holds the first choice button
    public GameObject button2;                          // holds the second choice button
    private Text choice1;                               // text for button1
    private Text choice2;                               // text for button2

    public GameObject dialogueObject;                   // holds the dialogue object, to edit the text
    private Text text;                                  // holds the text object in the dialogueObject var

    public GameObject nameObject;                       // holds the name object, to edit the text
    private Text nameText;                              // holds the text object in the nameObject var

    public List<string> dialogue;                       // List of dialogue lines
    private int line;                                   // number of dialogue

    public float buttonWidth1;
    public float buttonWidth2;

    public float halfWidth1;
    public float halfWidth2;

    public float buttonX1;
    public float buttonX2;

    // static variables
    static string character = "superman";               // holds the character you are interacting with
    static Dictionary<string, int> interactionScene;    // holds the scene that character is currently in

    private int scene = 1;

    // Start is called before the first frame update
    void Start()
    {
        // get button widths
        buttonWidth1 = button1.GetComponent<RectTransform>().rect.width;
        buttonWidth2 = button2.GetComponent<RectTransform>().rect.width;
        halfWidth1 = buttonWidth1 / 2;
        halfWidth2 = buttonWidth2 / 2;

        // get button x pos
        //buttonX1 = button1.GetComponent<RectTransform>().rect.x;
        //buttonX2 = button2.GetComponent<RectTransform>().rect.x;

        // get text
        text = dialogueObject.GetComponent<Text>();
        text.text = dialogue[0];

        nameText = nameObject.GetComponent<Text>();
        nameText.text = "";

        // get choices
        choice1 = button1.GetComponentInChildren<Text>();
        choice2 = button2.GetComponentInChildren<Text>();

        // set up dictionary
        /*interactionScene.Add("superman", 1);
        interactionScene.Add("naruto", 1);
        interactionScene.Add("shelly", 1);
        interactionScene.Add("Cindy", 1);*/

        // initialize line var
        line = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //interactionScene.TryGetValue(character, out scene);
        if (character == "superman")
        {
            switch (scene)
            {
                case 1:
                    switch (line)
                    {
                        case 2:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 3:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 4:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 5:
                            nameText.text = "";
                            //button1.SetActive(true);
                            text.text = " ";
                            choice1.text = "Point out the plastic bag Superman is failing to hide.";
                            //button2.SetActive(true);
                            choice2.text = "Ask how Naruto is doing.";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(6, 21);
                            break;
                        case 7:
                            nameText.text = "";
                            //button1.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask why he's obviously lying to you.";
                            //button2.SetActive(true);
                            choice2.text = "He's obviously lying, but maybe you shouldn't push it. Talk about something else.";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(7, 15);
                            break;
                        case 9:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 10:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 12:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 13:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd();
                            break;
                        case 15:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 16:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 17:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 18:
                            text.text = dialogue[line];
                            nameText.text = "Superman Jones";
                            CheckClick();
                            break;
                        case 19:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd();
                            break;
                        case 22:
                            nameText.text = "";
                            //button1.SetActive(true);
                            text.text = " ";
                            choice1.text = "Comment on how good of a brother Superman is.";
                            //button2.SetActive(true);
                            choice2.text = "Ask about Superman's Halloween costume.";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(23, 26);
                            break;
                        case 24:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd();
                            break;
                        case 28:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd();
                            break;
                        default:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                    }
                    break;
            }
        }
    }

    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A"))
        {
            line++;
            Debug.Log(line);
            Debug.Log(text.text);
        }
    }

    void CheckChoiceSelect(int _choice1, int _choice2)
    {
        //if (Input.GetMouseButtonDown(0) && (Input.mousePosition.x > (buttonX1 - halfWidth1) || Input.mousePosition.x < (buttonX1 + halfWidth1)))
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("X"))
        {
            line = _choice1;

            choice1.text = "";
            choice2.text = "";
            nameText.text = "Superman Jones";
        }
        //else if (Input.GetMouseButtonDown(0) && (Input.mousePosition.x > (buttonX2 - halfWidth2) || Input.mousePosition.x < (buttonX2 + halfWidth2)))
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("B"))
        {
            line = _choice2;

            choice1.text = "";
            choice2.text = "";
            nameText.text = "Superman Jones";
        }

        /*button1.SetActive(false);
        button2.SetActive(false);*/
    }

    void CheckSceneEnd()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A"))
        {
            SceneManager.LoadScene("TownMap");
        }
    }
}
