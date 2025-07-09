using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanbioEscena : MonoBehaviour
{
    [SerializeField] private Button botonSiguiente;


     void Start()
    {
        if (GameData.NivelAnterior >= 3) 
        {
            botonSiguiente.gameObject.SetActive(false);
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("menu");
    }

    public void BotonSiguiente()
    {
        int nivelAnterior = GameData.NivelAnterior;

        if (nivelAnterior == 1)
        {
            SceneManager.LoadScene("Nivel 2");
        }
        else if (nivelAnterior == 2)
        {
            SceneManager.LoadScene("Nivel 3");
        }
       
    }


}
