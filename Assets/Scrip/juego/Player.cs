using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameTimer;

public class Player : Entidad
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 ultimaDireccion = Vector2.down;
    public Bullet bulletPrefab;
    public bool IsShooting = false;

    [SerializeField] private GameObject tirachinasSprite;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private UILifeManager uiVidaManager;





    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        if (uiVidaManager == null)
            uiVidaManager = FindObjectOfType<UILifeManager>();

        uiVidaManager?.ActualizarCorazones(VidaActual);

    }

    public override void TomarDaño(int cantidad)
    {
        base.TomarDaño(cantidad);
        uiVidaManager?.ActualizarCorazones(VidaActual);
    }


    protected override void Update()
    {

        if (IsShooting == true)
        {
            movement = Vector2.zero;
            direccionMovimiento = Vector2.zero;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            AnimarDisparo(ultimaDireccion);
            IsShooting = true;
            Invoke(nameof(SetIsShooting), 1);
            return;
        }
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) movement.y += 1;
        if (Input.GetKey(KeyCode.S)) movement.y -= 1;
        if (Input.GetKey(KeyCode.A)) movement.x -= 1;
        if (Input.GetKey(KeyCode.D)) movement.x += 1;

        movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            ultimaDireccion = movement;
        }

        direccionMovimiento = movement;
        ActualizarAnimacion(movement);

        if (tirachinasSprite.activeSelf)
        {
            tirachinasSprite.SetActive(false);
        }

 

    }
    public void SetIsShooting()
    {
        IsShooting = false;
    }

    public void Shoot()
    {
        Bullet bulltet = Instantiate(bulletPrefab);
        bulltet.transform.position = transform.position;
        bulltet.gameObject.transform.up = ultimaDireccion.normalized;

    }

    public override void Morir()
    {
        uiVidaManager?.OcultarTodos();
        base.Morir();
        GameData.NivelAnterior = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Dead");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }
    protected override void ActualizarAnimacion(Vector2 direccion)
    {
        if (animator == null) return;

        if (direccion.y > 0)
            animator.Play("playerArriba");
        else if (direccion.y < 0)
            animator.Play("playerAbajo");
        else if (direccion.x != 0)
        {
            animator.Play("playerLado");
            spriteRenderer.flipX = direccion.x < 0;
        }
        else
        {
            animator.Play("base");
        }
    }


    private void AnimarDisparo(Vector2 dir)
    {
        if (tirachinasSprite != null)
        {
            
            if (dir.y < 0 || dir.x != 0)
            {
                tirachinasSprite.SetActive(true);

               
                if (dir.y < 0)
                {
                    
                    tirachinasSprite.transform.localPosition = new Vector3(-0.174f, -0.126f, 0f);
                }
                else if (dir.x < 0)
                {
                    
                    tirachinasSprite.transform.localPosition = new Vector3(-0.222f, -0.088f, 0f);
                }
                else if (dir.x > 0)
                {
                    
                    tirachinasSprite.transform.localPosition = new Vector3(0.057f, -0.105f, 0f);
                }

                
                spriteRenderer.flipX = dir.x < 0;
            }
            else
            {
                
                tirachinasSprite.SetActive(false);
            }
        }

        if (dir.y > 0)
            animator.Play("lanzarArriba");
        else if (dir.y < 0)
            animator.Play("lanzarAbajo");
        else
        {
            animator.Play("lanzarLado");
            spriteRenderer.flipX = dir.x < 0;
        }
    }

}
