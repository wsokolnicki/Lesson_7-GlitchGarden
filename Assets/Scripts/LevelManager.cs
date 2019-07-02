using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float autoLoadNextLevelAfter = 3f;
    int currentScene;
    int numberOfScenes;

    private void Start()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings - 1;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        { Invoke("LoadNextLevel", autoLoadNextLevelAfter); }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(numberOfScenes - 1);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(numberOfScenes);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void GoBack()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        //int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}