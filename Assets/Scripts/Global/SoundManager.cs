using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    public AudioClip clickClip, correctClip, wrongClip, congradsClip;
    public AudioClip[] alphabetClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _instance = this;
    }

    public void ClickSoundPlay()
    {
        audioSource.PlayOneShot(clickClip);
    }

    public void CorrectSoundPlay()
    {
        audioSource.PlayOneShot(correctClip);
    }

    public void WrongSoundPlay()
    {
        audioSource.PlayOneShot(wrongClip);
    }

    public void CongradsSoundPlay()
    {
        audioSource.clip = congradsClip;
        audioSource.PlayDelayed(1);
    }

    /// <summary>
    /// play alphabet sound based on the argument
    /// </summary>
    /// <param name="whichAlphabet"></param>
    public void AlphabetSoundPlay(AudioClip whichAlphabet)
    {
        audioSource.clip = whichAlphabet;
        audioSource.Play();
    }
}
