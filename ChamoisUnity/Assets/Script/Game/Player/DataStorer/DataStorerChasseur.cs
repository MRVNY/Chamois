using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// classe qui stock les données pour le chasseur
///</summary>

[Serializable]
public class DataStorerChasseur : DataStorer
{
    private Boolean carteActive;

    private Boolean quete1;

    private Boolean photo5;
    private Boolean photo10;
    private Boolean photo15;

    private Boolean abattre1;
    private Boolean abattre2;
    private Boolean abattre3;

    private Boolean score1000;
    private Boolean score3000;
    private Boolean score5000;

    private Boolean nbInfos5 = false;
    private Boolean nbInfos10 = false;

    public int nbQuetes;
    public int nbPhoto;
    public int scDechets;
    public int dechets;
    public int mauvaisChamois;
    public int bonChamois;
    public int scmauvaisChamois;
    public int scbonChamois;
    public int nbPhotoMemePartie;
    public int abattus;
    public int abattusMemePartie;
    public int score;
    public int nbInfos;
    
    public static DataStorerChasseur Instance;
    
    public DataStorerChasseur()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        nbQuetes = 0;

        nbPhoto = 0;

        nbPhotoMemePartie = 0;

        abattus = 0;

        abattusMemePartie = 0;

        score = 0;

        nbInfos = 0;

        scDechets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!quete1 && nbQuetes > 1)
        {
                GOPointer.AchievementManager.EarnAchievement("Quête Chasse I");
                quete1 = true;
        }

        if (!photo5 && nbPhotoMemePartie > 4)
        {
                GOPointer.AchievementManager.EarnAchievement("Chasse Photographique I");
                photo5 = true;
        }

        if (!photo10 && nbPhotoMemePartie > 9)
        {
                GOPointer.AchievementManager.EarnAchievement("Chasse Photographique II");
                photo10 = true;
        }

        if (!photo15 && nbPhotoMemePartie > 14)
        {
                GOPointer.AchievementManager.EarnAchievement("Chasse Photographique III");
                photo15 = true;
        }

        if (!abattre1 && abattus > 0)
        {
                GOPointer.AchievementManager.EarnAchievement("Prélèvement I");
                abattre1 = true;
        }

        if (!abattre2 && abattus > 1)
        {
                GOPointer.AchievementManager.EarnAchievement("Prélèvement II");
                abattre2 = true;
        }

        if (!abattre3 && abattus > 2)
        {
                GOPointer.AchievementManager.EarnAchievement("Prélèvement III");
                abattre3 = true;
        }

        if (!score1000 && score > 999)
        {
                GOPointer.AchievementManager.EarnAchievement("Score Chasseur I");
                score1000 = true;
        }

        if (!score3000 && abattus > 2999)
        {
                GOPointer.AchievementManager.EarnAchievement("Score Chasseur II");
                score3000 = true;
        }

        if (!score5000 && score > 4999)
        {
                GOPointer.AchievementManager.EarnAchievement("Score Chasseur III");
                score5000 = true;
        }

        if (!nbInfos5 && nbInfos > 4)
        {
                GOPointer.AchievementManager.EarnAchievement("Connaissances en Chasse I");
                nbInfos5 = true;
        }

        if (!nbInfos10 && nbInfos > 9)
        {
                GOPointer.AchievementManager.EarnAchievement("Connaissances en Chasse II");
                nbInfos10 = true;
        }
    }

    public void sendData()
    {
            h.Clear();
            h.Add("Dechets", dechets);
            h.Add("scDechets", scDechets);
            h.Add("mauvaisChamois", mauvaisChamois);
            h.Add("scmauvaisChamois", scmauvaisChamois);
            h.Add("bonChamois", bonChamois);
            h.Add("scbonChamois", scbonChamois);
            h.Add("score", score);
    }
    
    public void setData(string type, int var)
    {
        switch(type)
        {
            case "scDechets":
                score += var;
                dechets++;
                scDechets += var;
                break;

            case "mauvaisChamois":
                mauvaisChamois++;
                scmauvaisChamois += var;
                score += var;
                break;
            
            case "bonChamois":
                bonChamois++;
                scbonChamois += var;
                score += var;
                break;
            
            default:
                break;
        }
    }
}
