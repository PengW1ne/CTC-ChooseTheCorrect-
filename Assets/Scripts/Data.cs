using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Object[] objectsArray;
    public Questions[] questionsesArray;
    public Answers[] answersArray;
    

    [Serializable] public struct Object
    {
        public string topicName;
        public Sprite[] Objects;
    }
    
    [Serializable] public struct Questions
    {
        public string topicName;
        public string[] questions;
    }
    
    [Serializable] public struct Answers
    {
        public string answer;
    }
}
