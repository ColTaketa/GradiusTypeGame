using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            
            other.gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("BossBullet"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            
        }
    }
}
