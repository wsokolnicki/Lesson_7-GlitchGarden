using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StarDisplay : MonoBehaviour
{
    Defenders defenders;
    TextMeshProUGUI starText;
    public int currentStarValue = 5;
    public enum Status {SUCCESS, FAILURE }

    void Start()
    {
        defenders = GetComponent<Defenders>();
        starText = GetComponent<TextMeshProUGUI>();
        starText.text = currentStarValue.ToString();
    }

    public void AddStars (int amount)
    {
        currentStarValue += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if(currentStarValue >= amount)
        {
            currentStarValue -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
         return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        starText.text = currentStarValue.ToString();
    }
}
