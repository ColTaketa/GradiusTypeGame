using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float velocityPlayer;
    [SerializeField] float dashSpeed = 15f;  // Velocidad del dash
    [SerializeField] float dashDuration = 0.3f;  // Duración del dash
    [SerializeField] Collider2D playerCollider;
    [SerializeField] TrailRenderer trailRenderer;  // Para el TrailRenderer
    private Rigidbody2D rbPlayer;
    private float verticalInp, horizontalInp;

    // Variables para el dash
    private bool isDashing = false;
    private float dashTime = 0;

    // Referencia al escudo de defensa
    [SerializeField] PlayerLife playerLife;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        playerLife = GetComponent<PlayerLife>();
    }

    private void FixedUpdate()
    {
        verticalInp = Input.GetAxisRaw("Vertical");
        horizontalInp = Input.GetAxisRaw("Horizontal");
        
        if (!isDashing) 
        {
            Movement();
        }
        else
        {
            Dash();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(horizontalInp) > 0)  // Si se presiona Shift y hay movimiento horizontal
        {
            StartDash();
        }
    }

    public void Movement()
    {
        Vector2 velocity = new Vector2(horizontalInp, verticalInp).normalized;
        rbPlayer.velocity = velocity * velocityPlayer;
    }

    void StartDash()
    {
        if (!isDashing) 
        {
            isDashing = true;
            dashTime = 0;
            trailRenderer.enabled = true;  // Activar el TrailRenderer

            // Desactivar el collider para evitar daño
        if (playerLife != null)
        {
            playerLife.defenseActivated = true;  // Activar el escudo
        }
        }
    }

    void Dash()
    {
        dashTime += Time.deltaTime;

        // Movimiento en el dash (dirección del dash)
        Vector2 dashDirection = new Vector2(horizontalInp, 0).normalized;  // Solo horizontal
        rbPlayer.velocity = dashDirection * dashSpeed;  // Aplicamos la velocidad del dash

        if (dashTime >= dashDuration)  // Si el tiempo del dash ha pasado
        {
            EndDash();
        }
    }

    void EndDash()
    {
        isDashing = false;
        trailRenderer.enabled = false;  // Desactivar el TrailRenderer

        // Desactivar el escudo (dejar que el jugador reciba daño de nuevo)
        if (playerLife != null)
        {
            playerLife.defenseActivated = false;  // Desactivar el escudo
        }
    }
}

