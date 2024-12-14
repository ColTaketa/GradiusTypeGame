using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{    private float vel = 30f; 

    private void Update()
    {
        
        float rotationAmount = vel * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }
}
