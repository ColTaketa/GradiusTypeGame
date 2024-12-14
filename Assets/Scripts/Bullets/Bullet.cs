using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public int vel;
    // Start is called before the first frame update
    private void Awake() 
    {
        rbBullet = GetComponent<Rigidbody2D>();    
    }
    private void OnEnable() 
    {
        rbBullet.velocity = Vector2.up * vel;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Edge"))
        {
            gameObject.SetActive(false);
        }
    }
}
