using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] List<GameObject> bulletList;
    public int listSize;
    [SerializeField] GameObject[] cannons;
    void Start()
    {
        AddBulletsToList(listSize);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           for(int i = 0; i < cannons.Length; i++)
           {
            ShootBullets(cannons[i].transform);
           }
        }
           
        
    }
    private void AddBulletsToList(int amount)
    {
        for(int j = 0; j < amount; j++)
        {
        for(int i = 0; i < cannons.Length; i++)
        {
            GameObject bullets = Instantiate(bullet);
            bullets.SetActive(false);
            bulletList.Add(bullets);
            bullets.transform.SetParent(cannons[i].transform);
        }
        }
    }

    private GameObject ShootBullets(Transform cannon)
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeSelf)
            {
                bulletList[i].SetActive(true);
                bulletList[i].transform.position = cannon.position;
                bulletList[i].transform.rotation = cannon.rotation;
                return bulletList[i];
            }
        }
        AddBulletsToList(1);
        GameObject newBullet = bulletList[bulletList.Count - 1];
        newBullet.SetActive(true);
        newBullet.transform.position = cannon.position;
        newBullet.transform.rotation = cannon.rotation;

        return newBullet;
    }
}
