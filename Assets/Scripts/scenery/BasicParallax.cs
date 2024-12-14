using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicParallax : MonoBehaviour
{
    [SerializeField] Vector2 velocityMovement;
    private Vector2 offset;
    private Material materialB;

    private void Awake() 
    {
        materialB = GetComponent<SpriteRenderer>().material;
    }

    private void Update() 
    {
        offset = velocityMovement * Time.deltaTime;
        materialB.mainTextureOffset += offset;
    }
}
