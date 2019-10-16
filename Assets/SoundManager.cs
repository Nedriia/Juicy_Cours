using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip arcadeBckg, musicBckg, explosion, shootPlayer;
    AudioSource arcadeBckg_src, musicBckg_src, explosion_src, shootPlayer_src;
    public bool SoundActive;
    // Start is called before the first frame update
    void Start()
    {
        arcadeBckg_src =  gameObject.AddComponent<AudioSource>();
        arcadeBckg_src.clip = arcadeBckg;
        arcadeBckg_src.Play();
        arcadeBckg_src.loop = true;
        arcadeBckg_src.volume = 0.25f;

        musicBckg_src = gameObject.AddComponent<AudioSource>();
        musicBckg_src.clip = musicBckg;
        musicBckg_src.Play();
        musicBckg_src.loop = true;
        musicBckg_src.volume = 0.7f;

        explosion_src = gameObject.AddComponent<AudioSource>();
        explosion_src.clip = explosion;

        shootPlayer_src = gameObject.AddComponent<AudioSource>();
        shootPlayer_src.clip = shootPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExplision()
    {
        if (SoundActive)
        {
            explosion_src.Play();
        }

    }

    public void PlayShoot()
    {
        if (SoundActive)
        {
            shootPlayer_src.Play();
            shootPlayer_src.pitch = Random.Range(100, 300) / 100.0f;
        }
    }

    public void DisableMusics()
    {
        arcadeBckg_src.volume = 0f;
        musicBckg_src.volume = 0f;
    }

    public void ActiveMusics()
    {
        arcadeBckg_src.volume = 0.25f;
        musicBckg_src.volume = 0.7f;
    }
}
