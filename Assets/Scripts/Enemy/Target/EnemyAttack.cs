using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour

{
    [SerializeField] List<GameObject> laserList;
    [SerializeField] GameObject laserBeam;

    public int listSize;
    [SerializeField] Transform cannon, cartucho;

    private Transform player;
    public float timePerShoot;
    private bool isShooting = false; // Nueva bandera para controlar la corrutina

    private void Awake() 
    {
        cartucho = GameObject.Find("EnemyBulletList").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        AddLaserToList();
    }

    void Update()
    {
        Vector2 playerDistance = transform.position - player.position;

        // Verifica la distancia y si no está disparando ya
        if (Mathf.Abs(playerDistance.x) <= 10 && Mathf.Abs(playerDistance.y) <= 10)
        {
            if (!isShooting) // Evita iniciar múltiples corrutinas
            {
                StartCoroutine(ShootingLaser());
            }
        }
    }   

    public IEnumerator ShootingLaser()
    {
        isShooting = true; // Marca que la corrutina está activa

        for (int j = 0; j < laserList.Count; j++)
        {
            if (!laserList[j].activeSelf)
            {
                laserList[j].SetActive(true);
                laserList[j].transform.position = cannon.position;
            }

            yield return new WaitForSeconds(timePerShoot);
        }

        isShooting = false; // Marca que la corrutina terminó
    }

    public void AddLaserToList()
    {
        for (int i = 0; i < listSize; i++)
        {
            GameObject laser = Instantiate(laserBeam);
            laser.SetActive(false);
            laserList.Add(laser);

            if (cartucho != null)
            {
                laser.transform.SetParent(cartucho);
                Debug.Log($"Laser {laser.name} emparentado con {cartucho.name}");
            }
            else
            {
                Debug.LogError("El 'cartucho' no está asignado.");
            }
        }
    }
}


