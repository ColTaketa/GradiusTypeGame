using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenseUp : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public int poolSize = 10; 
    private List<GameObject> upsPool = new List<GameObject>(); 
    private Collider2D spawnAreaCollider; 

    public float spawnInterval = 20f; 

    void Start()
    {
        CreatePool(); 
        spawnAreaCollider = GetComponent<Collider2D>();
        StartCoroutine(SpawnPowerUpsRoutine());
    }

   
    public void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject powerUp = Instantiate(powerUpPrefab);
            powerUp.SetActive(false);
            powerUp.transform.SetParent(transform);
            upsPool.Add(powerUp);
        }
    }

    
    private IEnumerator SpawnPowerUpsRoutine()
    {
        while (true) 
        {
            SpawnPowerUp(); 
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    
    private void SpawnPowerUp()
    {
        foreach (GameObject powerUp in upsPool)
        {
            if (!powerUp.activeSelf) 
            {
                powerUp.SetActive(true);
                powerUp.transform.position = GenerateRandomPosition(); 
                powerUp.transform.rotation = Quaternion.identity;
                break; 
            }
        }
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
}
