using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Animator animator;
    //Health health;
    float health;
    GameObject enemy;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //health = GetComponent<Health>();
    }

    private void Update()
    {
        if(!enemy && animator.GetBool("isAttacked"))
        {
            animator.SetBool("isAttacked", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

         GameObject obj = collider.gameObject;

        if (obj)
        {
            if (!obj.GetComponent<Attacker>() || obj.GetComponent<Fox>())
            {
                return;
            }
            enemy = obj;
            animator.SetBool("isAttacked", true);
        }
    }
}
