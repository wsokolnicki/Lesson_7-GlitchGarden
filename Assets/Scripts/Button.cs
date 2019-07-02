using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    Defenders defender;
    StarDisplay starDisplay;
    SpriteRenderer spriteRenderer;
    private Button[] buttonArray;
    public static GameObject selectedDefender;

    private void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defender = defenderPrefab.GetComponent<Defenders>();
        starDisplay = FindObjectOfType<StarDisplay>().GetComponent<StarDisplay>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        { DisableSelectedDefender(); }

         Affordable(starDisplay.currentStarValue, defender.GetStarCost());
    }

    private void Affordable(int currentStars, int defenderCost)
    {
            if (currentStars < defenderCost)
            {
                spriteRenderer.color = Color.black;
                DisableSelectedDefender();
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
    }

    private void DisableSelectedDefender()
    {
        transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        if(spriteRenderer.color == Color.white)
        { 
            transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
            selectedDefender = defenderPrefab;
        }
    }
}
