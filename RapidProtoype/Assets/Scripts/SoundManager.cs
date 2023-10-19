using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerSwingSound, playerDeathSound, playerJumpSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerSwingSound = Resources.Load<AudioClip>("PlayerSwing");
        playerDeathSound = Resources.Load<AudioClip>("PlayerDeath");
        playerJumpSound = Resources.Load<AudioClip>("PlayerJump");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerSwing":
                audioSource.PlayOneShot(playerSwingSound);
                break;
            case "PlayerDeath":
                audioSource.PlayOneShot(playerDeathSound);
                break;
            case "PlayerJump":
                audioSource.PlayOneShot(playerJumpSound);
                break;
        }
    }
}
