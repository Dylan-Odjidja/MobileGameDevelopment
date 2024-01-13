using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWin : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public InterstitialAdExample interstitialAd;
    public int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadScene("Main Menu");
                Debug.Log("MORE LEVELS COMING SOON");
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
}
