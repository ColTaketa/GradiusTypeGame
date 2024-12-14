using UnityEngine;

public class FollowingPlayer : MonoBehaviour
{
    [SerializeField] Transform player; // Referencia al jugador
    [SerializeField] float distanceZ = -10f; // Distancia en Z (modular)

    private void Awake()
    {
        GameObject[] existingCameras = GameObject.FindGameObjectsWithTag("MainCamera");

        if (existingCameras.Length > 1)
        {
            Destroy(gameObject); 
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, player.position.z + distanceZ);
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("Player no asignado a la cámara.");
        }
    }
}


