using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform jugador;
  

    private Rigidbody2D rb;
    private EsqueleEnemy esqueleEnemy;
    public static bool jugadorestavivo = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        esqueleEnemy = GetComponent<EsqueleEnemy>(); 

        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    void FixedUpdate()
    {
        if (jugadorestavivo == true)
        {
            Movimientoenemugos();
        }
        else
        {
            return;
        }
    }

    void Movimientoenemugos()
    {
        if (jugador == null) return;

        Vector2 direccion = ((Vector2)jugador.position - rb.position).normalized;

        rb.MovePosition(rb.position + direccion * esqueleEnemy.SpeedValue * Time.fixedDeltaTime);

        if (esqueleEnemy != null)
        {
            esqueleEnemy.ActualizarAnimacionExterna(direccion);
        }
    }
}
