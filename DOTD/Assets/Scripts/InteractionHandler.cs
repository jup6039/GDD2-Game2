using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionHandler : MonoBehaviour
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

    public List<string> dialogue;                       // List of dialogue lines (this one is superman)
    public List<string> dialogueShelly;
    public List<string> dialogueNaruto;
    public List<string> dialogueCindy;
    private int line;                                   // number of dialogue

    public Button b1;
    public Button b2;

    public float halfWidth1;
    public float halfWidth2;

    public float buttonX1;
    public float buttonX2;

    // static variables
    public static string character = "";               // holds the character you are interacting with
    static Dictionary<string, int> interactionScene = new Dictionary<string, int>();    // holds the scene that character is currently in
    static bool dicInit = false;

    private int scene = 1;                              // holds the current scene of the interaction

    // sprite changing variables
    public GameObject characterObject;
    public GameObject playerObject;
    public Sprite playerMale;
    public Sprite playerFemale;
    public Sprite superman;
    public Sprite shelly;
    public Sprite naruto;
    public Sprite cindy;

    // Start is called before the first frame update
    void Start()
    {
        // get button widths
        /*buttonWidth1 = button1.GetComponent<RectTransform>().rect.width;
        buttonWidth2 = button2.GetComponent<RectTransform>().rect.width;
        halfWidth1 = buttonWidth1 / 2;
        halfWidth2 = buttonWidth2 / 2;*/
        b1 = button1.GetComponent<Button>();
        b2 = button2.GetComponent<Button>();

        // get button x pos
        buttonX1 = button1.GetComponent<RectTransform>().rect.x;
        buttonX2 = button2.GetComponent<RectTransform>().rect.x;

        // set up dictionary
        if (!dicInit)
        {
            interactionScene.Add("superman", 0);
            interactionScene.Add("naruto", 0);
            interactionScene.Add("shelly", 0);
            interactionScene.Add("cindy", 0);

            dicInit = true;
        }

        // get text
        text = dialogueObject.GetComponent<Text>();
        text.text = dialogue[0];

        nameText = nameObject.GetComponent<Text>();
        nameText.text = "";

        // get choices
        choice1 = button1.GetComponentInChildren<Text>();
        choice2 = button2.GetComponentInChildren<Text>();

        // initialize scene
        scene = interactionScene[character];

        

        // initialize player sprite
        if (TownSceneHandler.gender == "male")
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = playerMale;
        }
        else
        {
            playerObject.GetComponent<SpriteRenderer>().sprite = playerFemale;
        }

        // initialize other character sprite
        switch (character)
        {
            case "superman":
                characterObject.GetComponent<SpriteRenderer>().sprite = superman;
                // initialize line var
                switch (scene)
                {
                    case 0:
                        line = 30;
                        break;
                    case 1:
                        line = 0;
                        break;
                    case 2:
                        line = 32;
                        break;
                    case 3:
                        line = 34;
                        break;
                    case 4:
                        line = 36;
                        break;
                    case 5:
                        line = 38;
                        break;
                }
                break;
            case "shelly":
                characterObject.GetComponent<SpriteRenderer>().sprite = shelly;
                break;
            case "naruto":
                characterObject.GetComponent<SpriteRenderer>().sprite = naruto;
                break;
            case "cindy":
                characterObject.GetComponent<SpriteRenderer>().sprite = cindy;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //interactionScene.TryGetValue(character, out scene);

        //-----------SUPERMAN ROUTES------------
        if (character == "superman")
        {
            if (TownSceneHandler.day == 1)
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
                                b1.gameObject.SetActive(true);
                                b2.gameObject.SetActive(true);
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
                                b1.gameObject.SetActive(true);
                                b2.gameObject.SetActive(true);
                                //button1.SetActive(true);
                                text.text = " ";
                                choice1.text = "Ask why he's obviously lying to you.";
                                //button2.SetActive(true);
                                choice2.text = "He's obviously lying, but maybe you shouldn't push it. Talk about something else.";
                                Debug.Log(buttonX1);
                                Debug.Log(buttonX2);
                                CheckChoiceSelect(8, 15);
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
                                CheckSceneEnd(2);
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
                                CheckSceneEnd(2);
                                break;
                            case 22:
                                nameText.text = "";
                                b1.gameObject.SetActive(true);
                                b2.gameObject.SetActive(true);
                                text.text = " ";
                                choice1.text = "Comment on how good of a brother Superman is.";
                                //b2.SetActive(true);
                                choice2.text = "Ask about Superman's Halloween costume.";
                                Debug.Log(buttonX1);
                                Debug.Log(buttonX2);
                                CheckChoiceSelect(23, 26);
                                break;
                            case 24:
                                text.text = dialogue[line];
                                nameText.text = "";
                                CheckSceneEnd(2);
                                break;
                            case 28:
                                text.text = dialogue[line];
                                nameText.text = "";
                                CheckSceneEnd(2);
                                break;
                            default:
                                text.text = dialogue[line];
                                nameText.text = "";
                                CheckClick();
                                break;
                        }
                        break;

                    case 0:
                        switch(line)
                        {
                            case 35:
                                text.text = dialogue[line];
                                nameText.text = "Superman Jones";
                                CheckClick();
                                break;
                            case 36:
                                text.text = dialogue[line];
                                nameText.text = "Player";
                                CheckClick();
                                break;
                            case 37:
                                text.text = dialogue[line];
                                nameText.text = "Superman Jones";
                                CheckClick();
                                break;
                            case 40:
                                text.text = dialogue[line];
                                nameText.text = "Player";
                                CheckClick();
                                break;
                            case 41:
                                text.text = dialogue[line];
                                nameText.text = "Superman Jones";
                                CheckClick();
                                break;
                            case 43:
                                text.text = dialogue[line];
                                nameText.text = "";
                                CheckSceneEnd(1);
                                break;
                            default:
                                text.text = dialogue[line];
                                nameText.text = "";
                                CheckClick();
                                break;
                        }
                        break;

                    case 2:
                        switch (line)
                        {

                        }
                        break;

                    case 3:
                        switch (line)
                        {

                        }
                        break;

                    case 4:
                        switch (line)
                        {

                        }
                        break;

                    case 5:
                        switch (line)
                        {

                        }
                        break;
                }
            }
            else if (TownSceneHandler.day == 2)
            {

            }
            else if (TownSceneHandler.day == 3)
            {

            }
            else if (TownSceneHandler.day == 4)
            {

            }
            else if (TownSceneHandler.day == 5)
            {

            }
        }

        //----------------CINDY ROUTES--------------------

        if (character == "cindy")
        {
            if (TownSceneHandler.day == 1)
            {
                CheckSceneEnd(2);
            }
            else if (TownSceneHandler.day == 2)
            {

            }
            else if (TownSceneHandler.day == 3)
            {

            }
            else if (TownSceneHandler.day == 4)
            {

            }
            else if (TownSceneHandler.day == 5)
            {

            }
        }

        //-----------------NARUTO ROUTES-------------------

        if (character == "naruto")
        {
            if (TownSceneHandler.day == 1)
            {
                CheckSceneEnd(2);
            }
            else if (TownSceneHandler.day == 2)
            {

            }
            else if (TownSceneHandler.day == 3)
            {

            }
            else if (TownSceneHandler.day == 4)
            {

            }
            else if (TownSceneHandler.day == 5)
            {

            }
        }

        //-------------------SHELLY ROUTES------------------

        if (character == "shelly")
        {
            if (TownSceneHandler.day == 1)
            {
                CheckSceneEnd(2);
            }
            else if (TownSceneHandler.day == 2)
            {

            }
            else if (TownSceneHandler.day == 3)
            {

            }
            else if (TownSceneHandler.day == 4)
            {

            }
            else if (TownSceneHandler.day == 5)
            {

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
        /*if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("X"))
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
        }*/

        b1.onClick.AddListener(delegate { JumpToDialogue(_choice1); });
        b2.onClick.AddListener(delegate { JumpToDialogue(_choice2); });
    }

    void JumpToDialogue(int _line)
    {
        line = _line;
        choice1.text = "";
        choice2.text = "";
        b1.gameObject.SetActive(false);
        b2.gameObject.SetActive(false);
    }

    void CheckSceneEnd(int _nextScene)
    {
        interactionScene[character] = _nextScene;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A"))
        {

            interactionScene[character] += 1;

            //Remove 1 from player's remaining interactions
            TownSceneHandler.interactionsLeft = TownSceneHandler.interactionsLeft - 1;

            //If player's remaining interactions are 0, go to the next day and reset their amount of interactions
            if(TownSceneHandler.interactionsLeft == 0)
            {
                TownSceneHandler.day = TownSceneHandler.day + 1;
                TownSceneHandler.interactionsLeft = TownSceneHandler.interactionsPerDay;

                //Set character to an empty string so you can interact with the same person you last interacted with on a previous day
                character = "";

                //Swap Day
                SceneManager.LoadScene("DaySwapScene");
            }
            else
            {    
            //Load TownMap
            SceneManager.LoadScene("TownMap");
            }
        }
    }
}
