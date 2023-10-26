using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public void PauseGame()
    {
        // Activate the pause menu, making it visible.
        pauseMenu.SetActive(true);
        // Set the game's time scale to zero, effectively pausing the game.
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        // Deactivate the pause menu to hide it.
        pauseMenu.SetActive(false);
        // Set the time scale to 1, which resumes game time.
        Time.timeScale = 1;
    }

    public void Settings()
    {
        // Deactivate the pause menu to hide it.
        pauseMenu.SetActive(false);
        // Activate the settings menu, making it visible.
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        // Activate the pause menu to return to the pause state.
        pauseMenu.SetActive(true);
        // Deactivate the settings menu to hide it.
        settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
