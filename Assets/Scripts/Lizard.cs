using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour 
{
    Animator animator;
    Attacker attacker;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Destroy(gameObject);
        GameObject obj = collider.gameObject;

        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
        else
        {
            animator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
