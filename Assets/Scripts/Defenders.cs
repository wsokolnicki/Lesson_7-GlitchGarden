using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public int starCost;
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars (int amount)
    {
        starDisplay.AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
