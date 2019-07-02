using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostDisplay : MonoBehaviour
{
    Text cost;
    [SerializeField] GameObject defenderPrefab;
    Defenders defender;

    private void Start()
    {
        cost = GetComponent<Text>();
        defender = defenderPrefab.GetComponent<Defenders>();
        cost.text = defender.GetStarCost().ToString();
    }
}
