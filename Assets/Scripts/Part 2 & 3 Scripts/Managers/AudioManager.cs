using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource backgroundMusic;
    //public AudioSource buttonPressSound;
    public AudioSource speedBoostSound;
    public AudioSource jumpBoostSound;
    public AudioSource immunitySound;
    public AudioSource bossSound;
    public AudioSource deathSound;
    public AudioSource footStepsSound;
    public AudioSource pickupActivationSound;

    public AudioSource buttonpressedAudioSource;

    //public GameObject ButtonSoundObject;
    //private AudioSource ButtonSoundAudioSource;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            //ButtonSoundAudioSource= GetComponent<AudioSource>();
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        
    }

    // Play background music
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusic.volume = Mathf.Clamp01(volume);  // Ensure volume is within range [0, 1]
    }

    // Play button press sound
    public void PlayButtonPressSound()
    {

        buttonpressedAudioSource.Play();



    }
    public void SetButtonPressedVolume(float volume)
    {
        //buttonPressSound.volume = Mathf.Clamp01(volume);  // Ensure volume is within range [0, 1]
    }

    // Play pickup activation sound
   
    public void PlaySpeedBoostSound()
    {
      speedBoostSound.PlayOneShot(speedBoostSound.clip);
    }
    public void PlayJumpBoostSound()
    {
        jumpBoostSound.Play();
    }
    public void PlayImmunitySound()
    {
        immunitySound.Play();
    }
   
    public void PlayDeathSound()
    {
        deathSound.Play();
    }
   
   


}
