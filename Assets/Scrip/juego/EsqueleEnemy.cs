using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueleEnemy : Entidad
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string animacionActual = "";
    [SerializeField] private float daņoPorSegundo = 1f;
    private float tiempoUltimoDaņo = 0f;
    public float intervaloDaņo = 1f;


    protected override void Start()
    {
        base.Start();

        if (animator == null)
            animator = GetComponent<Animator>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Set(int _health)
    {
        vidaMaxima = _health;
    }
    public void Set(int _health,float _speed)
    {
        vidaMaxima = _health;
        Speed = _speed;
        
    }


    protected override void Update()
    {
        base.Update();

    }


    protected override void ActualizarAnimacion(Vector2 direccion)
    {
        if (animator == null) return;

        string nuevaAnimacion = "";

        float umbral = 0.01f;

        if (direccion.magnitude < umbral) return; 

        if (Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y))
        {
            nuevaAnimacion = "EsqLado";
            spriteRenderer.flipX = direccion.x < 0;
        }
        else if (direccion.y > 0)
        {
            nuevaAnimacion = "EsqArriba";
        }
        else
        {
            nuevaAnimacion = "EsqAbajo";
        }

        if (!string.IsNullOrEmpty(nuevaAnimacion) && nuevaAnimacion != animacionActual)
        {
            animator.Play(nuevaAnimacion);
            animacionActual = nuevaAnimacion;
        }

    }
    public void ActualizarAnimacionExterna(Vector2 direccion)
    {
        ActualizarAnimacion(direccion);
    }

    public override void Morir()
    {
        FindObjectOfType<EnemySpawner>()?.EnemigoMuerto();
        KillCounter.Instance?.AņadirKill(); 
        FindObjectOfType<EnemySpawner>()?.EnemigoMuerto();
        base.Morir();

    }

    public override void OnColisionar(GameObject otro)
    {
        base.OnColisionar(otro);

        if (otro.CompareTag("Player") && Time.time > tiempoUltimoDaņo + intervaloDaņo)
        {
            IVida vida = otro.GetComponent<IVida>();
            if (vida != null)
            {
                vida.TomarDaņo((int)daņoPorSegundo);
                Debug.Log("El enemigo daņķ al jugador por trigger.");
                tiempoUltimoDaņo = Time.time;
            }

        }
    }



}
