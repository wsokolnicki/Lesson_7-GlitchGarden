using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;

    public void DealDamage(float damage)
    {
        health -= damage;
        Death(health);
    }

    public void Death(float currentHealth)
    {
        if (currentHealth <=0)
        {
            Destroy(gameObject);
        }
    }
}
