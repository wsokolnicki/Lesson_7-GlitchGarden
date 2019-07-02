using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    GameObject defendersParent;
    StarDisplay starDisplay;
    Defenders defender;
    int starCost;

    void Start ()
    {
        starDisplay = FindObjectOfType<StarDisplay>().GetComponent<StarDisplay>();
        defendersParent = GameObject.Find("Defenders");
        if(!defendersParent)
        {
            defendersParent = new GameObject("Defenders");
        }
	}

    private bool CanYouAffordToSpawnDeffender()
    {
        int starCost = Button.selectedDefender.GetComponent<Defenders>().GetStarCost();
        if (starCost >= starDisplay.currentStarValue)
        {
            return true;
        }
        else { return false; }
    }

    private void OnMouseDown()
    {
        //if (CanYouAffordToSpawnDeffender())
        //{
        if (Button.selectedDefender)
        {
            if (starDisplay.UseStars(Button.selectedDefender.GetComponent<Defenders>().GetStarCost()) == StarDisplay.Status.SUCCESS)
            {
                GameObject defender = Instantiate(Button.selectedDefender, CalculatorWorldPointOfMouseClick(), Quaternion.identity) as GameObject;
                defender.transform.parent = defendersParent.transform;
                //starDisplay.UseStars(Button.selectedDefender.GetComponent<Defenders>().GetStarCost());
            }
            else
            {
                Debug.Log("You don't have enough stars");
            }
        }
        else { return; }
        //}
        //else
        //{
        //    Debug.Log("You don't have enough stars");
        //}
    }

    Vector2 CalculatorWorldPointOfMouseClick()
    {
        // Vector2 currentPixelValue = Input.mousePosition;
        //float mouseX = Input.mousePosition.x;
        //float mouseY = Input.mousePosition.y;
        //float distanceFromCamera = 10f;
        //Vector3 wierdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);

        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point = new Vector2 (Mathf.RoundToInt(point.x), Mathf.RoundToInt(point.y));
        return point;
    }
}
