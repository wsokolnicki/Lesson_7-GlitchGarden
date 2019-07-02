using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    public Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] LevelManager levelManager;
    [SerializeField] Text volumeValue;
    [SerializeField] Text difficultyValue;
    string[] difficulty;

    MusicManager musicManager;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        difficulty = new string[] { "Easy", "Medium", "Hard" };
    }

    void Update()
    {
        VolumeSliderInPreferences();

        DifficultySliderInPreferences();
    }

    private void DifficultySliderInPreferences()
    {
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        difficultyValue.text = CheckDifficulty(PlayerPrefsManager.GetDifficulty());
    }

    private void VolumeSliderInPreferences()
    {
        musicManager.ChangeVolume(volumeSlider.value);
        volumeValue.text = volumeSlider.value.ToString();
    }

    private string CheckDifficulty(float difficultyNo)
    {
        if (difficultyNo == 1)
        { return difficulty[0]; }
        else if (difficultyNo == 2)
        { return difficulty[1]; }
        else { return difficulty[2]; }
    }

    public void SetDefault()
        {
        volumeSlider.value = 50f;
        difficultySlider.value = 2f;
        }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.GoBack();
    }
}
