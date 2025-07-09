using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform jugador;
    public float radioMin = 20f;             
    public float radioMax = 50f;            
    public float tiempoEntreSpawns = 3f;
    public int maxEnemigos = 10;


    public int healthOfEnemys;
    public float speedOfEnemys;

    private int enemigosActivos = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }
    void Update()
    {
        if (!EnemyAI.jugadorestavivo)
        {
            StopAllCoroutines(); 
            enabled = false;     
        }
    }

    IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            if (EnemyAI.jugadorestavivo && enemigosActivos < maxEnemigos)
            {
                Vector2 direccion = Random.insideUnitCircle.normalized;
                float distancia = Random.Range(radioMin, radioMax);
                if(jugador != null)
                {
                    Vector2 posicionSpawn = (Vector2)jugador.position + direccion * distancia;
                    GameObject enemy = Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity);
                    enemy.GetComponent<EsqueleEnemy>().Set(healthOfEnemys, speedOfEnemys);
                    enemigosActivos++;
                }
               
            }
            yield return new WaitForSeconds(tiempoEntreSpawns);
        }
    }

    public void EnemigoMuerto()
    {
        enemigosActivos = Mathf.Max(0, enemigosActivos - 1);
    }
}
