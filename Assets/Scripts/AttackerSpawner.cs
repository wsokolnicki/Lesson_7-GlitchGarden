using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;


    void Update()
    {
        foreach (GameObject thisAttacker in enemyPrefab)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }


    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        float timeToNextSpawn = attackerGameObject.GetComponent<Attacker>().betweenSpawnDuration;
        float spawnPerSecond = 1 / timeToNextSpawn;

        if (Time.deltaTime > timeToNextSpawn)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold) ;


    }

    private void Spawn(GameObject myGameObject)
    {
        GameObject attacker = Instantiate(myGameObject) as GameObject;
        attacker.transform.parent = transform;
        attacker.transform.position = transform.position;
    }

    public void DestroyAll()
    {
        Destroy(gameObject);
    }
}
