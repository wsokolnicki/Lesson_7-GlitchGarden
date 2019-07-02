using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;

    GameObject projectileParent;
    Vector3 mainPosition;
    Animator animator;
    AttackerSpawner spawnerLine;

    private void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLanerSpawner();
        //Debug.Log(spawnerLine);
    }

    private void Update()
    {
        if(IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane()
    {
        if(spawnerLine.transform.childCount < 0)
        { return false;}

        foreach (Transform attacker in spawnerLine.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            { return true; }  
        }
        return false;
    }

    void SetMyLanerSpawner()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawnerRow in spawnerArray)
        {
            if (spawnerRow.transform.position.y == transform.position.y)
            {
                spawnerLine = spawnerRow;
                return;
            }
            //else
            //{
            //    Debug.LogError("Line isn't correct");
            //}
               
        }
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
