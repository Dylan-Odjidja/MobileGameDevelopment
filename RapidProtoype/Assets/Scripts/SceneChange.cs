using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject menu;

    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void OpenSettings()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
