using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public static KillCounter Instance;

    public int kills = 0;
    public TMP_Text killText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AñadirKill()
    {
        kills++;
        if (killText != null)
            killText.text = "Kills: " + kills;
    }
    public int GetKills()
    {
        return kills;
    }
}
