using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab; 
    [SerializeField] private Transform laserParent;  
    [SerializeField] private float laserDuration = 2f; 
    [SerializeField] private float interval = 5f; 
    private GameObject pooledLaser; 
    private void Start()
    {
        CreateLaserPool(); 
        StartCoroutine(LaserRoutine());
    }
    private void CreateLaserPool()
    {
        pooledLaser = Instantiate(laserPrefab, laserParent); 
        pooledLaser.SetActive(false); 
    }
    private IEnumerator LaserRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            pooledLaser.SetActive(true);
            yield return new WaitForSeconds(laserDuration);

            pooledLaser.SetActive(false);

        }
    }
}
