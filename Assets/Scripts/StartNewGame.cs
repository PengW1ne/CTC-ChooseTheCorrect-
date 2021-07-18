using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StartNewGame : MonoBehaviour
{
    private Data Data;
    private Task Task;
    public GameObject pfCell;
    public int themeNum;

    public  GameObject[] cells;
    private List<int> cellList;
    
    public  string[] answers;
    [HideInInspector]
    public  int[] dataAnswers;
    
    private GameObject newObj;
    private Image[] image;

    private int lvlNum;
    private int randomNum;
    private int gameButtonsCount;
    

    private void Start()
    {
        Data = FindObjectOfType<Data>();
        Task = FindObjectOfType<Task>();

        CheckLvlDifficulty();
        ChouseTheme();
        CellListCompletion();
        FillCell();

        Task.TaskSelect(themeNum);
        
    }

    public void CheckLvlDifficulty()
    {
        lvlNum = PlayerPrefs.HasKey("lvlNum") ? PlayerPrefs.GetInt("lvlNum") : 0;
        switch (lvlNum)
        {
            case 0:
                gameButtonsCount = 3;
                break;

            case 1:
                gameButtonsCount = 6;
                break;

            case 2:
                gameButtonsCount = 9;
                break;
        }

        cells = new GameObject[gameButtonsCount];

        for (int i = 0; i < gameButtonsCount; i++)
        {
            newObj =  Instantiate(pfCell, gameObject.transform);
            cells[i] = newObj;
        }
    }

    public void ChouseTheme()
    {
        themeNum = Random.Range(0, Data.objectsArray.Length);
    }

    public void FillCell()
    {
        image = new Image[cells.Length];
        dataAnswers = new int[cells.Length];
        answers = new String[cells.Length];
        Data.answersArray = new Data.Answers[cells.Length];
        
        for (int i = 0; i < cells.Length; i++)
        {
            image[i] =  cells[i].transform.Find("CellBackGroundPanel/Panel/Image").gameObject.GetComponent<Image>();
            image[i].sprite = Data.objectsArray[themeNum].Objects[cellList[i]];
            answers[i] = (cellList[i] + 1).ToString();
            dataAnswers[i] = (cellList[i] + 1);

            if (themeNum != 0)  // Условие для всех стринговых ответов, если нет других числовых, это единственное разделение, по темам, 
            {
                string temp = answers[i];
                answers[i] = Data.questionsesArray[themeNum].questions[int.Parse(temp)-1];
            }
            
            Data.answersArray[i].answer = answers[i];
        }
        
        
    }

    public void CellListCompletion()
    {
        cellList = new List<int>(new int[Data.objectsArray[themeNum].Objects.Length]);
         
        for (int i = 0; i < 8; i++)
        {
            randomNum  = Random.Range(0, cellList.Count);
            if (!cellList.Contains(randomNum))
            {
                cellList[i] = randomNum;
            }
            else
                i--;
        }
    }
    
    
}