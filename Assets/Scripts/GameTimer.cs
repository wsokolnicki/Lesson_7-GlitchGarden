using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    Slider slider;
    AudioSource audioSource;
    LevelManager levelManager;
    AttackerSpawner[] attackerSpawner;
    [SerializeField] float timeForALevel = 60f;
    GameObject winText;
    float musicLenght =5f;
    float startTime = 0f;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = timeForALevel;
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
        attackerSpawner = FindObjectsOfType<AttackerSpawner>();
        winText = GameObject.Find("Win Text");
        winText.SetActive(false);
    }

    private void Update()
    {
        StartCoroutine(LoadWinScene());
        TimerDown();
    }

    IEnumerator LoadWinScene()
    {
        if (TimerDown())
        {
            DestroyAttarckers();
            winText.SetActive(true);
            audioSource.Play();
            yield return new WaitForSeconds(musicLenght);
            levelManager.LoadNextLevel();
        }
    }

    private void DestroyAttarckers()
    {
       foreach(AttackerSpawner aS in attackerSpawner)
        {
            aS.GetComponent<AttackerSpawner>().DestroyAll();
        }
    }

    private bool TimerDown()
    {
        if(startTime < timeForALevel)
        {
            startTime += Time.deltaTime;
            slider.value = startTime;
            return false;
        }
        else { return true; }
    }
}
