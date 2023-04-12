using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI killCounterTxt;
    private int killCount = 0;
    public void UpdateZombiesKilled()
    {
        killCount++;
        killCounterTxt.SetText("Zombies Killed: " + killCount);
    }
}
