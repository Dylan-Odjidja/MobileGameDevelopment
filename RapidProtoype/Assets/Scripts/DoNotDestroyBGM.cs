using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyBGM : MonoBehaviour
{
    private void Awake()
    {
        // Find all game objects with the tag "BGM" and store them in an array.
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("BGM");
        // Check if there is more than one game object with the "BGM" tag.
        // If there's more than one "BGM" object destroy the most recently created object.
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        // If there is only one "BGM" object do not destroy it.
        DontDestroyOnLoad(this.gameObject);
    }
}
