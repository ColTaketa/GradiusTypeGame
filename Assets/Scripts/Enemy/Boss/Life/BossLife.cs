using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    [SerializeField] int bhealth;
    [SerializeField] int currentHealth;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Slider bossLifeSlider;
    [SerializeField] LayerMask playerBulletLayer;

    void Start()
    {
        currentHealth = bhealth;
    }

    void Update()
    {
        
        if (gameObject.CompareTag("Boss"))
        {
            
            UpdateHealthBar(currentHealth, bhealth);
            
            if (currentHealth <= 0)
            {
                TriggerGameOver();
                gameObject.SetActive(false); 
                PlayerPoints.Instance.points += 1000;
            }
        }
    }


    public void UpdateHealthBar(int currentValue, int maxValue)
    {
       
        bossLifeSlider.value = (float)currentValue / maxValue;
    }

    private void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int otherLayer = other.gameObject.layer; 

        if (playerBulletLayer == (playerBulletLayer | (1 << otherLayer))) 
        {
            PlayerPoints.Instance.points += 10;
            currentHealth -= 10; 
            other.gameObject.SetActive(false);
        }
    }
}
