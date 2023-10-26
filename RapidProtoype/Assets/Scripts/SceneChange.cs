using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void MoveToScene(int sceneId)
    {
        // Load the scene specified by the sceneId
        SceneManager.LoadScene(sceneId);
    }

}
