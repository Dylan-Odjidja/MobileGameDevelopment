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
        musicObject = GameObject.FindWithTag("BGM");
        audioSource = musicObject.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("BGMVolume");
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("BGMVolume", musicVolume);
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
