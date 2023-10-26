using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroySFX : MonoBehaviour
{
    private void Awake()
    {
        // Find all game objects with the tag "SFX" and store them in an array.
        GameObject[] sfxObject = GameObject.FindGameObjectsWithTag("SFX");
        // Check if there is more than one game object with the "SFX" tag.
        // If there's more than one "SFX" object destroy the most recently created object.
        if (sfxObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        // If there is only one "SFX" object do not destroy it.
        DontDestroyOnLoad(this.gameObject);
    }
}
