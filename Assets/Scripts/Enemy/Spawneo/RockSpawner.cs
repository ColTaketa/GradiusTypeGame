using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour, ISpawner
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private List<GameObject> enemyPool = new List<GameObject>(); 
    private Transform enemyListParent; 
    private Collider2D spawnAreaCollider;
    private void Awake()
    {
        
        enemyListParent = GameObject.Find("EnemyList").transform;
        if (enemyListParent == null)
        {
            Debug.LogError("No se encontró 'EnemyList' en la jerarquía.");
        }
        spawnAreaCollider = GetComponent<Collider2D>();
        if (spawnAreaCollider == null)
        {
            Debug.LogError("El objeto necesita un Collider2D para definir el área de spawn.");
        }
    }

    void Start()
    {
        CreatePool();
    }

    
    public void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false); 
            enemy.transform.SetParent(enemyListParent); 
            enemyPool.Add(enemy);
        }
    }

   
    public IEnumerator StartWave(int waitingTime)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy != null && !enemy.activeSelf) 
            {
                enemy.SetActive(true); 
                enemy.transform.position = GenerateRandomPosition(); 
                enemy.transform.rotation = transform.rotation; 

                yield return new WaitForSeconds(waitingTime); 
            }
        }

        
        gameObject.SetActive(false);
    }

    private Vector3 GenerateRandomPosition()
    {
        if (spawnAreaCollider != null)
        {
            Bounds bounds = spawnAreaCollider.bounds;
            
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                transform.position.z); 
        }

        return transform.position;
    }

    
    public bool AreEnemiesAlive()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy != null && enemy.activeSelf)
            {
                return true; 
            }
        }
        return false; 
    }
}