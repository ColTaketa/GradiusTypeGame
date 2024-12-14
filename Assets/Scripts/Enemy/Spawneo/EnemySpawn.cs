using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawner
{
    public List<GameObject> spawnList;
    [SerializeField] GameObject enemyPrefab;

    public int listSize;
    private Transform enemyListParent;

    // Obtener el ángulo de rotación del spawner
    private float spawnAngle;

    private void Awake()
    {
        enemyListParent = GameObject.FindGameObjectWithTag("EnemyList").transform;
        if (enemyListParent == null)
        {
            Debug.LogError("No se encontró un objeto vacío llamado 'EnemyList' en la jerarquía.");
        }
    }

    void Start()
    {
        SpawningEnemies();
    }

    // Método para spawnear enemigos
    public void SpawningEnemies()
    {
        for (int i = 0; i < listSize; i++)
        {
            GameObject spawns = Instantiate(enemyPrefab);
            spawnList.Add(spawns);
            spawns.transform.SetParent(enemyListParent);
            spawns.SetActive(false); // Empieza desactivado
        }
    }

    // Método que controla la oleada
    public IEnumerator StartWave(int waitingTime)
    {
        // Obtener el ángulo de rotación del spawner
        spawnAngle = transform.eulerAngles.z;

        foreach (GameObject enemy in spawnList)
        {
            if (enemy != null)
            {
                enemy.SetActive(true); // Activa el enemigo

                // Establecer la posición y la rotación del enemigo
                enemy.transform.position = transform.position; 
                enemy.transform.rotation = transform.rotation;

                // Llamamos al método SetSpawnerRotation para pasar el ángulo de rotación al enemigo
                enemy.GetComponent<BasicMovementE>().SetSpawnerRotation(spawnAngle);

                yield return new WaitForSeconds(waitingTime); // Espera entre enemigos
            }
        }

        gameObject.SetActive(false); // Desactivar el spawner después de spawnnear todos los enemigos
    }

    public bool AllEnemiesDestroyed()
    {
        foreach (var enemy in spawnList)
        {
            if (enemy != null && enemy.activeSelf)
            {
                return false; // Si algún enemigo está activo, devuelve false
            }
        }
        return true; // Todos los enemigos están destruidos
    }
}
