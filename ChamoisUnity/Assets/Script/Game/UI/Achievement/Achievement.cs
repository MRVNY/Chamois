using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Achievement
{

    private string name;
    private string description;
    public bool unlocked;
    private int points;
    private int spriteIndex;
    private Image background;

    private GameObject achievmentRef;
    private List<Achievement> dependencies = new List<Achievement>();
    private string child;

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }
    public int Points { get => points; set => points = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    public string Child { get => child; set => child = value; }
    public GameObject AchievmentRef { get => achievmentRef; set => achievmentRef = value; }

    public Achievement(string name, string description, int points, int spriteIndex, GameObject achievmentRef)
    {
        this.name = name;
        this.description = description;
        this.points = points;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.AchievmentRef = achievmentRef;
        background = AchievmentRef.GetComponent<Image>();
        LoadAchievment();
    }

    public void AddDependency(Achievement dependency)
    {
        dependencies.Add(dependency);
    }

    public bool EarnAchievement()
    {
        if (!unlocked && !dependencies.Exists(x => x.unlocked == false))
        {
            background.sprite = GOPointer.AchievementManager.unlockedSprite;
            SaveAchievment(true);
            
            if(child != null)
            {
                GOPointer.AchievementManager.EarnAchievement(child);
            }

            return true;
        }
        return false;
    }

    public void SaveAchievment(bool value)
    {
        unlocked = value;

        int tmpPoints = PlayerPrefs.GetInt("Points");

        PlayerPrefs.SetInt("Points", tmpPoints += points);

        PlayerPrefs.SetInt(name, value ? 1 : 0);

        PlayerPrefs.Save();

    }

    public void LoadAchievment()
    {
        //unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        if (PlayerPrefs.GetInt(name) == 1)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;

        }

        if (unlocked)
        {
            GOPointer.AchievementManager.textPoints.text = "Points : " + PlayerPrefs.GetInt("Points");
            background.sprite = GOPointer.AchievementManager.unlockedSprite;

        }
    }

}
