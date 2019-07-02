using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed;
    public float betweenSpawnDuration;
    GameObject currentTarget;
    Animator animator;
    Defenders defenders;

    private void Start()
    {
        animator = GetComponent<Animator>();
        defenders = FindObjectOfType<Defenders>();
    }

    void Update ()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        IsDefenderDestroyed();
    }

    private void IsDefenderDestroyed()
    {
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }


    public void SetSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget (float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }

}
