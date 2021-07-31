using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use when changing scenes with a script
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
