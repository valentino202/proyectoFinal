using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameTimer;
using UnityEngine.UI;

public class ResultadoFinal : MonoBehaviour
{
    public AudioSource victorySound;
    [SerializeField] private Button botonSiguiente;
    [SerializeField] private TMP_Text textoKills;


    void Start()
    {
       
        textoKills.text = "Kills : " + GameData.Kills;


        if (victorySound != null)
        {
            victorySound.Play();
        }

        if (GameData.NivelAnterior >= 3)
        {
            botonSiguiente.gameObject.SetActive(false);
        }
    }
}
