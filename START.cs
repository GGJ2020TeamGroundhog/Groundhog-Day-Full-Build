using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour
{
    public string SceneToLoad;

    public void LoadGame()
    {
        SceneManager.LoadScene("HubLevel");

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
 
    }
}

