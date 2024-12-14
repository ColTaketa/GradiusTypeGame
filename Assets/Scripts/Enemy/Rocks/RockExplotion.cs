using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockExplotion : MonoBehaviour
{
    [SerializeField] private int rockHealth = 75;
    private int currentHealth;
    [SerializeField] private GameObject smallRockPrefab;
    
    private List<GameObject> smallRockPool = new List<GameObject>();
    private int poolSize = 10; 

    private void Start()
    {
        currentHealth = rockHealth;
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject smallRock = Instantiate(smallRockPrefab);
            smallRock.SetActive(false);
            smallRockPool.Add(smallRock);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Player"))
        {
            currentHealth -= 25;

            if (currentHealth <= 0)
            {
                PlayerPoints.Instance.points += 100;
                SpawnSmallRocks(); 
                Destroy(gameObject); 
            }
        }
    }

    private void SpawnSmallRocks()
    {
        for (int i = 0; i < 2; i++) 
        {
            GameObject smallRock = GetFromPool(); 
            if (smallRock != null)
            {
                smallRock.transform.position = transform.position + (Vector3)(Random.insideUnitCircle * 1f);
                smallRock.SetActive(true); 
            }
        }
    }

   
    private GameObject GetFromPool()
    {
        foreach (var rock in smallRockPool)
        {
            if (!rock.activeInHierarchy) 
            {
                return rock;
            }
        }

        
        return null;
    }
}
