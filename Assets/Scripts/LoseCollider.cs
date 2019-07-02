using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    int howManyLives = 3;
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
    }

    private void Update()
    {
        ActivateLoseCondition();
    }

    void ActivateLoseCondition()
    {
        if (howManyLives <= 0)
        { levelManager.LoadLoseScene(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        howManyLives--;
        Destroy(other.gameObject);
    }
}
