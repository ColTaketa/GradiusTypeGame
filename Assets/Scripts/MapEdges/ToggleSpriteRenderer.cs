using UnityEngine;

public class ToggleSpriteRenderer : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 0.5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // Update the sprite renderer's visibility based on the distance
        spriteRenderer.enabled = distanceToPlayer <= detectionRange;
    }
}

