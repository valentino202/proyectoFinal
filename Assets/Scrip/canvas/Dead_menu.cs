using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_menu : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void Reintentar()
    {
       
        int nivelAnterior = GameData.NivelAnterior;

        if (nivelAnterior == 1)
        {
            SceneManager.LoadScene("Nivel");
        }
        else if (nivelAnterior == 2)
        {
            SceneManager.LoadScene("Nivel 2");
        }
        else if (nivelAnterior == 3)
        {
            SceneManager.LoadScene("Nivel 3");
        }
        
    }
}
