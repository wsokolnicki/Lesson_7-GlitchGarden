using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public AudioClip[] levelMusicChangeArray;
    AudioSource audioSource;
    private int currentSong;

    private void Awake()
    {
        SingletonForMusic();
    }

    private void SingletonForMusic()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        { Destroy(gameObject); }
        else
        { DontDestroyOnLoad(gameObject); }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        
        if ( thisLevelMusic && currentSong != level)
        {
            audioSource.clip = levelMusicChangeArray[level];
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
            currentSong = level;
        }
    }

    public void ChangeVolume (float volume)
    {
        audioSource.volume = volume/100;
    }
}