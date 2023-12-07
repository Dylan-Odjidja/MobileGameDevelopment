using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public InterstitialAdExample interstitialAd;
    public GameObject menu;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D boxCollider)
    {
        StartCoroutine(Win());
    }

    public IEnumerator Win()
    {
        // Wait for 2 seconds before executing the following code
        yield return new WaitForSeconds(1.5f);
        // Play Ad
        interstitialAd.ShowAd();
        // Activate the menu GameObject
        menu.SetActive(true);
        // Set the game's time scale to zero, effectively pausing the game.
        Time.timeScale = 0;
    }
}
