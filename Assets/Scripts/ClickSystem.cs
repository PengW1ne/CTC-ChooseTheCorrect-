using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickSystem : MonoBehaviour
{
    private StartNewGame SNG;
    private Task Task;
    private LvlController LvlController;
    private WinSystem WinSystem;

   

    private void Start()
    {
        SNG = FindObjectOfType<StartNewGame>();
        Task = FindObjectOfType<Task>();
        LvlController = FindObjectOfType<LvlController>();
        WinSystem = FindObjectOfType<WinSystem>();
    }

    public void Click()
        {
            if (SNG.dataAnswers[gameObject.transform.GetSiblingIndex()] == Task.dataTask)
            {
                if (PlayerPrefs.GetInt("lvlNum") == 2)
                {
                    WinSystem.FullWin();
                }
                else
                {
                    WinSystem.Win();
                }
            }
            else
            {
                //incorrect answer
            }
        }
    
    

    
        
    
}


