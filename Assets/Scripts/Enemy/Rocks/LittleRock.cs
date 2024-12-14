using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRock : MonoBehaviour
{
    [SerializeField] int rockHealth, currentHealth;

    private void Start()
    {
        rockHealth = 50;
        currentHealth = rockHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHealth -= 25;
            if (currentHealth <= 0)
            {
                Destroy(gameObject); // Destruye el enemigo
                PlayerPoints.Instance.points += 50;
            }
        }
    }
}
