using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use when changing scenes with a script
using UnityEngine.SceneManagement;

public class PreGameMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
