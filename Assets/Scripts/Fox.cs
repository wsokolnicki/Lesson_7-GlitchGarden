using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Attacker))]
public class Fox : MonoBehaviour
{
    Animator foxAnimator;
    Attacker attacker;

    private void Start()
    {
        foxAnimator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        GameObject obj = collider.gameObject;

        if(!obj.GetComponent<Defenders>())
        {   return; }
     
        if(obj.GetComponent<Stone>())
        {
            foxAnimator.SetTrigger("JumpTrigger");
        }
        else
        {
            foxAnimator.SetBool("isAttacking", true);
            attacker.Attack(obj);
        }
    }
}
