using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2f;  
    public float leftLimit = -5.4f;  
    public float rightLimit = 5.4f; 
    private bool movingRight = true; 
    void Update()
    {
        MoveBoss();
    }

    void MoveBoss()
    {
        
        float moveDirection = movingRight ? 1f : -1f;
        
        transform.Translate(Vector3.right * speed * moveDirection * Time.deltaTime);

        if (transform.position.x >= rightLimit)
        {
            movingRight = false; 
        }
        else if (transform.position.x <= leftLimit)
        {
            movingRight = true; 
        }
    }
}
