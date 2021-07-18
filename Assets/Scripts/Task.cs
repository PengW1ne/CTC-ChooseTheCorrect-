using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Task : MonoBehaviour
{
    private StartNewGame SNG;
    public Text taskText;

    private int task;
    public int dataTask;
    int temp = 0;
    // Start is called before the first frame update


    private void Start()
    {
        SNG = FindObjectOfType<StartNewGame>();
    }

    public void TaskSelect(int themeNum)
    {
        string whatFind = "";
        
        switch (themeNum)
        {
            case 0:
                whatFind = "number ";
                break;
            
            case 1:
                whatFind = "letter ";
                break;
        }

        task = Random.Range(0, SNG.answers.Length);
        
        int[] tempTask = new int[3] {0,0,0};
        tempTask[temp] = task;
        
            while (!(task == tempTask[temp]))
            {
                task = Random.Range(0, SNG.answers.Length);
                tempTask[temp] = task;
            }
            temp++;
        
        
        dataTask = SNG.dataAnswers[task];
        taskText.text = "Find the " + whatFind + " " + (SNG.answers[task]);
    }
}
