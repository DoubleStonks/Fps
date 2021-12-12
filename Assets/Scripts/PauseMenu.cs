using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPause;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject Crosshair;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        IsPause = false;
        Time.timeScale = 1;
        GameObject.FindObjectOfType<PlayerMove>().canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Crosshair.SetActive(true);
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        IsPause = true;
        Time.timeScale = 0;
        GameObject.FindObjectOfType<PlayerMove>().canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Crosshair.SetActive(false);
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
