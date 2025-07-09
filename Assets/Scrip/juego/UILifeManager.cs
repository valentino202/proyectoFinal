using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILifeManager : MonoBehaviour
{
    public static UILifeManager Instance { get; private set; }

    public Image[] corazones;
    public int vidaActual;
    public void ActualizarCorazones(int vidaActual)
    {
        this.vidaActual = vidaActual;
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vidaActual;
        }
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public int GetVidaActual()
    {
        return vidaActual;
    }

    public void OcultarTodos()
    {
        foreach (Image corazon in corazones)
        {
            corazon.enabled = false;
        }
    }
}
