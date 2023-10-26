using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip sfx1, sfx2, sfx3;
    private float sfxVolume = 1f;
    public Slider sfxSlider;
    public GameObject sfxObject;

    void Start()
    {
        sfx1 = Resources.Load<AudioClip>("Swing");
        sfx2 = Resources.Load<AudioClip>("Death");
        sfx3 = Resources.Load<AudioClip>("Jump");

        // Find any game object in the scene with the tag "SFX" and assign it to the sfxObject variable.
        sfxObject = GameObject.FindWithTag("SFX");
        // Get the AudioSource component from the sfxObject and assign it to the static audioSource variable.
        audioSource = sfxObject.GetComponent<AudioSource>();
        // Retrieve the sfx volume (if it exists) from the previous scene using PlayerPrefs and assign it to the sfxVolume variable.
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        // Set the volume of the audio source to the retrieved or default sfxVolume.
        audioSource.volume = sfxVolume;
        // Set the value of the volumeSlider UI control to match the current sfxVolume.
        sfxSlider.value = sfxVolume;
    }

    void Update()
    {
        // Update the audioSource's volume to match the current sfxVolume.
        audioSource.volume = sfxVolume;
        // Store the current sfxVolume in PlayerPrefs so that it can be retrieved in the next scene.
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void updateVolume(float volume)
    {
        // Update the sfxVolume based on the provided volume parameter.
        sfxVolume = volume;
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerSwing":
                audioSource.PlayOneShot(sfx1);
                break;
            case "PlayerJump":
                audioSource.PlayOneShot(sfx2);
                break;
            case "PlayerDeath":
                audioSource.PlayOneShot(sfx3);
                break;
        }
    }
}
