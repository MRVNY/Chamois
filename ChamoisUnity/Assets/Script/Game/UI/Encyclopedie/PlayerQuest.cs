using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerQuest
{
    public string title;
    public string desc;
    public Hashtable hints;
    public string hintName = "";
    public int totalSteps = 0;
    public int currentStep = 0;
    
    public string[] participants;
    public string nextQuest;

    public bool isFinished = false;
    
    public PlayerQuest(string title, string desc)
    {
        this.title = title;
        this.desc = desc;
        hints = new Hashtable();
    }

}
