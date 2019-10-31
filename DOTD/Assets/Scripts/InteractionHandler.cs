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
    public GameObject threebutton1;                          // holds the first choice button
    public GameObject threebutton2;                          // holds the second choice button
    public GameObject threebutton3;                          // holds the second choice button
    private Text choice1;                               // text for button1
    private Text choice2;                               // text for button2
    private Text Tchoice1;                               // text for tbutton1
    private Text Tchoice2;                               // text for tbutton2
    private Text Tchoice3;                               // text for tbutton3

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
    public Button tb1;
    public Button tb2;
    public Button tb3;

    public float halfWidth1;
    public float halfWidth2;

    public float buttonX1;
    public float buttonX2;

    // static variables
    public static string character = "";               // holds the character you are interacting with
    static Dictionary<string, int> interactionScene = new Dictionary<string, int>();    // holds the scene that character is currently in
    static Dictionary<string, int> friendshipMeter = new Dictionary<string, int>();
    static bool dicInit = false;
    static bool friendDicInit2 = false;

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

        tb1 = threebutton1.GetComponent<Button>();
        tb2 = threebutton2.GetComponent<Button>();
        tb3 = threebutton3.GetComponent<Button>();

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
        if (!friendDicInit2)
        {
            interactionScene.Add("superman", 0);
            interactionScene.Add("naruto", 0);
            interactionScene.Add("shelly", 0);
            interactionScene.Add("cindy", 0);

            friendDicInit2 = true;
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
                switch (scene)
                {
                    case 0:
                        line = 1;
                        break;
                    case 1:
                        line = 15;
                        break;
                    case 2:
                        line = 60;
                        break;
                    case 3:
                        if (friendshipMeter["cindy"] >= 20)
                        {
                            line = 137;
                        }
                        else
                        {
                            line = 195;
                        }
                        break;
                    case 4:
                        if (friendshipMeter["cindy"] >= 20)
                        {
                            line = 218;
                        }
                        else
                        {
                            line = 259;
                        }
                        break;
                    case 5:
                        if (friendshipMeter["cindy"] >= 100)
                        {
                            line = 292;
                        }
                        else if (friendshipMeter["cindy"] >= 20)
                        {
                            line = 299;
                        }
                        else
                        {
                            line = 303;
                        }
                        break;
                }
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
            //if (TownSceneHandler.day == 1)
            //{
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
            //}
            /*else if (TownSceneHandler.day == 2)
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

            }*/
        }

        //----------------CINDY ROUTES--------------------

        if (character == "cindy")
        {
            switch (scene)
            {
                case 0:
                    switch (line)
                    {
                        case 4:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 5:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 6:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 7:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 9:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 10:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 11:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 13:
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
                case 1:
                    switch (line)
                    {
                        case 16:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 17:
                            text.text = dialogue[line];
                            nameText.text = "Player";
                            CheckClick();
                            break;
                        case 18:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 20:
                            text.text = dialogue[line];
                            nameText.text = "Annelius";
                            CheckClick();
                            break;
                        case 22:
                            text.text = dialogue[line];
                            nameText.text = "Cindy";
                            CheckClick();
                            break;
                        case 23:
                            text.text = dialogue[line];
                            nameText.text = "Annelius";
                            CheckClick();
                            break;
                        case 25:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Agree with Cindy";
                            //b2.SetActive(true);
                            choice2.text = "Say Nothing";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(26, 45);
                            break;
                        case 26:
                            text.text = dialogue[line];
                            nameText.text = "Annelius";
                            CheckClick();
                            break;
                        case 29:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about Annelius";
                            //b2.SetActive(true);
                            choice2.text = "Ask about trick or treating";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(30, 39);
                            break;
                        case 47:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about Annelius";
                            //b2.SetActive(true);
                            choice2.text = "Ask about trick or treating";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(48, 54);
                            break;
                        case 37:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(2);
                            break;
                        case 43:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(2);
                            break;
                        case 52:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(2);
                            break;
                        case 58:
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
                case 2:
                    switch (line)
                    {
                        case 64:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about Halloween";
                            //b2.SetActive(true);
                            choice2.text = "Ask about plans for the day";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(65, 74);
                            break;
                        case 73:
                            line = 83;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 82:
                            line = 83;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 86:
                            nameText.text = "";
                            tb1.gameObject.SetActive(true);
                            tb2.gameObject.SetActive(true);
                            tb3.gameObject.SetActive(true);
                            text.text = " ";
                            Tchoice1.text = "Ask about family";
                            //b2.SetActive(true);
                            Tchoice2.text = "Ask about house";
                            Tchoice3.text = "Ask about wealth";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(87, 99, 113);
                            break;
                        case 92:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask what's wrong";
                            //b2.SetActive(true);
                            choice2.text = "Change the subject";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(93, 96);
                            break;
                        case 103:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask if it gets lonely";
                            //b2.SetActive(true);
                            choice2.text = "Ask if she's snuck away to play video games before";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(104, 108);
                            break;
                        case 119:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Poke fun at her story";
                            //b2.SetActive(true);
                            choice2.text = "Take the story seriously";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(120, 125);
                            break;
                        case 94:
                            friendshipMeter["cindy"] += 5;
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 97:
                            friendshipMeter["cindy"] += 10;
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 107:
                            friendshipMeter["cindy"] += 15;
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 111:
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 123:
                            friendshipMeter["cindy"] += 5;
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 128:
                            line = 130;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                        case 134:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(3);
                            break;
                        default:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                    }
                    break;
                case 3:
                    switch (line)
                    {
                        case 147:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Stand up for Cindy";
                            //b2.SetActive(true);
                            choice2.text = "Stand up for Yourself";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(148, 174);
                            break;
                        case 154:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about her parents";
                            //b2.SetActive(true);
                            choice2.text = "Ask about Annelius";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(155, 165);
                            break;
                        case 178:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about Annelius";
                            //b2.SetActive(true);
                            choice2.text = "Ask about Halloween";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(179, 188);
                            break;
                        case 163:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(4);
                            break;
                        case 172:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(4);
                            break;
                        case 186:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(4);
                            break;
                        case 193:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(4);
                            break;
                        case 215:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(4);
                            break;
                        default:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                    }
                    break;
                case 4:
                    switch (line)
                    {
                        case 223:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Ask about Festival";
                            //b2.SetActive(true);
                            choice2.text = "Ask about parents";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(224, 229);
                            break;
                        case 228:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Are you really going to let your parents control your life?";
                            //b2.SetActive(true);
                            choice2.text = "Fair enough. They are your parents after all.";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(241, 251);
                            break;
                        case 238:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Are you really going to let your parents control your life?";
                            //b2.SetActive(true);
                            choice2.text = "Fair enough. They are your parents after all.";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(241, 251);
                            break;
                        case 257:
                            friendshipMeter["cindy"] = 25;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 242:
                            friendshipMeter["cindy"] = 100;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 262:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Go along with Annelius";
                            //b2.SetActive(true);
                            choice2.text = "Warn Cindy";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(263, 282);
                            break;
                        case 268:
                            nameText.text = "";
                            b1.gameObject.SetActive(true);
                            b2.gameObject.SetActive(true);
                            text.text = " ";
                            choice1.text = "Hit the bucket";
                            //b2.SetActive(true);
                            choice2.text = "Stop the prank";
                            Debug.Log(buttonX1);
                            Debug.Log(buttonX2);
                            CheckChoiceSelect(269, 276);
                            break;
                        case 289:
                            friendshipMeter["cindy"] = 25;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 280:
                            friendshipMeter["cindy"] = 25;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 274:
                            friendshipMeter["cindy"] = 0;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        default:
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckClick();
                            break;
                    }
                    break;
                case 5:
                    switch (line)
                    {
                        case 296:
                            friendshipMeter["cindy"] = 100;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 300:
                            friendshipMeter["cindy"] = 100;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
                            break;
                        case 304:
                            friendshipMeter["cindy"] = 100;
                            text.text = dialogue[line];
                            nameText.text = "";
                            CheckSceneEnd(5);
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

    void CheckChoiceSelect(int _choice1, int _choice2, int _choice3)
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

        tb1.onClick.AddListener(delegate { JumpToDialogue(_choice1); });
        tb2.onClick.AddListener(delegate { JumpToDialogue(_choice2); });
        tb3.onClick.AddListener(delegate { JumpToDialogue(_choice3); });
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
