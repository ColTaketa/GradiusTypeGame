using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] int enemyHealth, currentHealth;

    private void Start()
    {
        enemyHealth = 50;
        currentHealth = enemyHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= 25;
            if (currentHealth <= 0)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
                PlayerPoints.Instance.points += 100;
            }
        }
    }
}


