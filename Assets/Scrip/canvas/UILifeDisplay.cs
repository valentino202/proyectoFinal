using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILifeDisplay : MonoBehaviour
{
    public Image[] corazones;

    void Start()
    {
        int vida = GameData.VidaActual;
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vida;
        }
    }
}
