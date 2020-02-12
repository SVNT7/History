using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



        Camera.GetComponent<TurningScript>().enabled = true;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Camera.GetComponent<TurningScript>().enabled = false;

    }

    public void BackToMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Camera.GetComponent<TurningScript>().enabled = true;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
