using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPlatform : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damage;

    private void Start() {
        currentHealth = maxHealth;
    }
    private void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) 
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<Ball>() != null)
        {
            takeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.GetComponent<Ball>() != null)
        {
            takeDamage(damage);
        }
    }
}
