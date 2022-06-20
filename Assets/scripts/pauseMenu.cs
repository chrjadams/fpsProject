using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (!pauseMenuUI.activeSelf && isPaused)) {
           // if (isPaused)
           //     resume();

            //else 
                pause();
            
        }
    }

    public void resume() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void loadMenu() {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Debug.Log("Game is exited.");
        Application.Quit();
    }

    void pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }




}
