using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour
{
    MusicManager musicManager;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        float volume = PlayerPrefsManager.GetMasterVolume();
        musicManager.ChangeVolume(volume);
    }
	
}
