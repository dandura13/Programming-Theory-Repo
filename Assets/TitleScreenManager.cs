using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    private bool canStart;
    private GameObject StartButton;
    public GameObject GameManager;
    public GameObject TextBox;
    public string name;
    private GameObject TitleManager;
    public GameManager MainManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        canStart = false;
        TitleManager = GameObject.Find("Title Screen Manager");
        GameManager.SetActive(false);
        name = "Player";
        TextBox = GameObject.Find("/Title Screen Manager/Canvas/Name Entry");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckName()
    {
        if (TextBox.GetComponent<TMP_InputField>().text.Length > 15)
        {
            name = "Bob";
            canStart = true;
            Debug.Log("Name is too long. Default name set.");
        }
        else
        {
            name = TextBox.GetComponent<TMP_InputField>().text;
            canStart = true;
            Debug.Log("Name set successfully.");
        }
    }

    void StartGame()
    {
        if (canStart)
        {
            GameManager.SetActive(true);
            MainManagerScript.StartGame();
            TitleManager.SetActive(false);
        }
    }
}

