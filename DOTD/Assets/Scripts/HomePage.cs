using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public Button maleButton;
    public Button femaleButton;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maleButton.onClick.AddListener(delegate { ChangeGender("male"); });
        femaleButton.onClick.AddListener(delegate { ChangeGender("female"); });
        startButton.onClick.AddListener(ChangeScene);

        Debug.Log(TownSceneHandler.gender);
    }

    void ChangeGender(string _gender)
    {
        TownSceneHandler.gender = _gender;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("TownMap");
    }
}
