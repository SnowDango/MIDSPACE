using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AudioChange : MonoBehaviour
{
    public AudioClip load;
    public AudioClip boss;
    private static AudioSource _audioSource;

    private Boolean chnageMode = true;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.clip = load;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCount.score >= 100 && chnageMode)
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            _audioSource.clip = boss;
            _audioSource.Play();
            chnageMode = false;
        }
    }
}
