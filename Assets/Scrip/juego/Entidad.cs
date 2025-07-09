using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColisionable
    {
        void OnColisionar(GameObject otro);
    }

    public interface IVida
    {
        void TomarDaño(int cantidad);
        void Morir();
    }


public class Entidad : MonoBehaviour, IColisionable, IVida
{
    
    [SerializeField] protected int vidaMaxima = 5;
    [SerializeField] protected float Speed = 5f;
    public int VidaActual { get; private set; }

    protected Vector2 direccionMovimiento;

    public int VidaMaxima => vidaMaxima;
    public float SpeedValue => Speed;
    public Vector2 DireccionMovimiento => direccionMovimiento;

    protected virtual void Start()
    {
        VidaActual = vidaMaxima;
    }

    protected virtual void Update()
    {
        ActualizarAnimacion(direccionMovimiento);
    }

    public virtual void TomarDaño(int cantidad)
    {
        VidaActual -= cantidad;

        if (VidaActual < 0)
            VidaActual = 0;

        if(this is Player)
        {
           UILifeManager.Instance?.ActualizarCorazones(VidaActual);
        }

        if (VidaActual <= 0)
        {
            Morir();
        }
    }

    public virtual void Morir()
    {
        Destroy(gameObject);
    }

    public virtual void OnColisionar(GameObject otro)
    {
        Debug.Log($"{gameObject.name} colisionó con {otro.name}");
    }


    protected virtual void ActualizarAnimacion(Vector2 direccion)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnColisionar(other.gameObject);
    }



}
