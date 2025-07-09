using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private UILifeManager uiLifeManager;
    
    public float tiempoInicial = 60f; 
    private float tiempoRestante;

    public TMP_Text timerText;

    private bool juegoTerminado = false;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
          if(uiLifeManager == null)
            uiLifeManager = FindObjectOfType<UILifeManager>();
    }

    private void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            juegoTerminado = true;
            Ganaste();
        }

        ActualizarTexto();
    }


    
    private void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    private void Ganaste()
    {
        GameData.VidaActual = FindObjectOfType<Player>().VidaActual;
        GameData.Kills = KillCounter.Instance.GetKills();
        GameData.NivelAnterior = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("EscenaVictoria");
    }
}
