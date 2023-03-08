using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    private bool canStart;
    public string name;
    public GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        canStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NameEntered()
    {
        canStart=CheckName();
    }
    private bool CheckName()
    {
        for(int a =0; a < name.Length; a++)
        {
            if ((name.Substring(a, a + 1).ToUpper()).Equals(name.Substring(a, a + 1).ToLower()) && !(name.Substring(a, a + 1).Equals(" ")));
            {
                return false;
            }
        }
        return true;
    }
    public void StartGame()
    {
        if (canStart)
        {
            Debug.Log("Started!");
            // do whatever is needed to activate the game
        }
    }
}

