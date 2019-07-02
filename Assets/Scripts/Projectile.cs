using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    Animator animator;

	void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject currentTarget = collider.gameObject;

        if(currentTarget.GetComponent<Attacker>() && currentTarget.GetComponent<Health>())
        {
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
                Destroy(gameObject);
            }
        }
        else { return; }
    }
}
