using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject FullWinPanel;


    public void Win()
    {
        WinPanel.SetActive(true);
    }

    public void FullWin()
    {
        FullWinPanel.SetActive(true);
    }

    
}
