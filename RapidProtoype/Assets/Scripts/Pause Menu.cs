using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Settings()
    {

    }

    public void Quit()
    {

    }
}
