using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static AudioSource audioSource;
    private float musicVolume = 1f;
    public Slider volumeSlider;
    public GameObject musicObject;

    void Start()
    {
        // Find any game object in the scene with the tag "BGM" and assign it to the musicObject variable.
        musicObject = GameObject.FindWithTag("BGM");
        // Get the AudioSource component from the musicObject and assign it to the static audioSource variable.
        audioSource = musicObject.GetComponent<AudioSource>();
        // Retrieve the music volume (if it exists) from the previous scene using PlayerPrefs and assign it to the musicVolume variable.
        musicVolume = PlayerPrefs.GetFloat("BGMVolume");
        // Set the volume of the audio source to the retrieved or default musicVolume.
        audioSource.volume = musicVolume;
        // Set the value of the volumeSlider UI control to match the current musicVolume.
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        // Update the audioSource's volume to match the current musicVolume.
        audioSource.volume = musicVolume;
        // Store the current musicVolume in PlayerPrefs so that it can be retrieved in the next scene.
        PlayerPrefs.SetFloat("BGMVolume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        // Update the musicVolume based on the provided volume parameter.
        musicVolume = volume;
    }
}
