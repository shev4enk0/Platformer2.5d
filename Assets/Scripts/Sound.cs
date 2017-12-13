using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource sourse;
    public AudioClip[] clip;
    // Use this for initialization
    void Start()
    {
        sourse = GetComponent<AudioSource>();
        MusicPlay();
    }

    void OnEnable()
    {
        Platform.Broken += PlayBrokenSound;
        Hat.Catched += PlayYes;
    }

    void OnDisable()
    {
        Platform.Broken -= PlayBrokenSound;
        Hat.Catched -= PlayYes;
    }

    void PlayBrokenSound()
    {
        sourse.PlayOneShot(clip[0]);
    }

    void PlayYes()
    {
        sourse.PlayOneShot(clip[1]);
    }

    void MusicPlay()
    {
        sourse.playOnAwake = true;
        sourse.loop = true;
        clip = 2;
        sourse.Play();
    }
}
