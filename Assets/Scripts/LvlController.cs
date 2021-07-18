using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    private StartNewGame SNG;
    private Task Task;
    private WinSystem WinSystem;

    public int overLvlNum;
    private void Start()
    {
        SNG = FindObjectOfType<StartNewGame>();
        Task = FindObjectOfType<Task>();
        WinSystem = FindObjectOfType<WinSystem>();
    }

    public void NextLvl()
    {
        overLvlNum = PlayerPrefs.GetInt("lvlNum");
        PlayerPrefs.SetInt("lvlNum", overLvlNum + 1);
        if (overLvlNum > 2)
        {
            PlayerPrefs.SetInt("lvlNum", 2);
        }
        
        for (int i = 0; i < SNG.cells.Length; i++)
        {
            Destroy(SNG.cells[i]);
        }
        
        WinSystem.WinPanel.SetActive(false);
        WinSystem.FullWinPanel.SetActive(false);
        
        SNG.CheckLvlDifficulty();
        SNG.ChouseTheme();
        SNG.CellListCompletion();
        SNG.FillCell();
        Task.TaskSelect(SNG.themeNum);
    }

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
    }
}