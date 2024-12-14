using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] List<GameObject> laserList;
    [SerializeField] GameObject laserBeam;

    public int listSize;
    [SerializeField] Transform cannonLeft, cannonRight, cartucho; // Cañones izquierdo y derecho
    public float timePerShoot; // Tiempo entre disparos
    public float timeActive = 2f; // Tiempo que el boss dispara
    public float timeInactive = 3f; // Tiempo que el boss espera antes de disparar nuevamente
    private bool isShooting = false;

    private Transform player;

    private void Awake()
    {
        cartucho = GameObject.Find("EnemyBulletList").transform; // Contenedor para los proyectiles
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
        AddLaserToList();
    }

    void Update()
    {
        Vector2 playerDistance = transform.position - player.position;

        // Verifica la distancia y si no está disparando
        if (Mathf.Abs(playerDistance.x) <= 20 && Mathf.Abs(playerDistance.y) <= 20)
        {
            if (!isShooting)
            {
                StartCoroutine(ShootingLaser());
            }
        }
    }

    public IEnumerator ShootingLaser()
    {
        isShooting = true;

        // Dispara durante un tiempo determinado
        float shootTime = Time.time;
        while (Time.time - shootTime < timeActive)
        {
            for (int i = 0; i < laserList.Count - 1; i += 2) // Avanza de 2 en 2 para usar proyectiles pares
            {
                if (!laserList[i].activeSelf && !laserList[i + 1].activeSelf)
                {
                    // Activa el proyectil desde el cañón izquierdo
                    laserList[i].SetActive(true);
                    laserList[i].transform.position = cannonLeft.position;
                    laserList[i].transform.rotation = cannonLeft.rotation;

                    // Activa el proyectil desde el cañón derecho
                    laserList[i + 1].SetActive(true);
                    laserList[i + 1].transform.position = cannonRight.position;
                    laserList[i + 1].transform.rotation = cannonRight.rotation;

                    yield return new WaitForSeconds(timePerShoot);
                }
            }
        }

        // Espera durante el tiempo determinado antes de disparar nuevamente
        yield return new WaitForSeconds(timeInactive);

        isShooting = false;
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
                laser.transform.SetParent(cartucho); // Emparenta los láseres al contenedor
            }
            else
            {
                Debug.LogError("El 'cartucho' no está asignado.");
            }
        }
    }
}
