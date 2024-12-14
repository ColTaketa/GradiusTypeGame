using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementE : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float amplitude;
    [SerializeField] float frequency;
    private float directionAngle; // Ángulo recibido desde el spawner
    private Vector3 startPosition;
    private Rigidbody2D rbEnemy;

    private float localTime = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    public void SetSpawnerRotation(float angle)
    {
        Debug.Log("Ángulo recibido: " + angle);
        directionAngle = angle; // Guardar el ángulo del spawner
    }

    void FixedUpdate()
    {
        localTime += Time.fixedDeltaTime;

        float angleInRadians = directionAngle * Mathf.Deg2Rad;
        float xDirection = Mathf.Cos(angleInRadians);
        float yDirection = Mathf.Sin(angleInRadians);

        float x = startPosition.x + xDirection * speed * localTime;
        float y = startPosition.y + Mathf.Sin(localTime * frequency) * amplitude + yDirection * speed * localTime;

        transform.position = new Vector3(x, y, startPosition.z);
    }
}
