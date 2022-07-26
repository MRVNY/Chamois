using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// classe qui stock les données pour le chamois
///</summary>

[Serializable]
public class DSChamois : DataStorer
{    
    public int nourritureMangee;
    public float tempsSurvecu;
    public int score;
    public int nbInfos;
    private int blessure;
    private int scBouffe;
    private int scBlessure;
    private int scoreTps;
    private float tempsSup;
    private float tempsInf;
    public int naissance;
    public int nourritureTotale;

    private Boolean carteActive;

    private Boolean temps1minute = false;
    private Boolean temps3minute = false;
    private Boolean temps5minute = false;
    private Boolean temps10minute = false;

    private Boolean naissance1 = false;
    private Boolean naissance2 = false;

    private Boolean score1000 = false;
    private Boolean score3000 = false;
    private Boolean score5000 = false;

    private Boolean nourriture15 = false;
    private Boolean nourriture30 = false;

    private Boolean nbInfos5 = false;
    private Boolean nbInfos10 = false;
    
    public static DSChamois Instance;
    
    public DSChamois()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        nourritureMangee = 0;

        tempsSurvecu = 0f;

        score = 0;

        nbInfos = 0;

        blessure = 0;

        scBouffe = 0;

        scBlessure = 0;

        scoreTps = 0;

        tempsSup = 1f;

        tempsInf = 0f;

        naissance = 0;

        nourritureTotale = 0;
    }

    void Update()
    {   
        tempsSurvecu += Time.deltaTime;
        tempsInf += Time.deltaTime;
        if(tempsInf >= tempsSup)
        {
            scoreTps += 5;
            score += 5;
            tempsInf = 0f;
        }


        if (!temps1minute && tempsSurvecu > 60.0)
        {
            GOPointer.AchievementManager.EarnAchievement("Survivre I");
            temps1minute = true;
        }


        if (!temps3minute && tempsSurvecu > 180.0)
        {
            GOPointer.AchievementManager.EarnAchievement("Survivre II");
            temps3minute = true;
        }


        if (!temps5minute && tempsSurvecu > 300.0)
        {
            GOPointer.AchievementManager.EarnAchievement("Survivre III");
            temps5minute = true;
        }


        if (!temps10minute && tempsSurvecu > 600.0)
        {
            GOPointer.AchievementManager.EarnAchievement("Survivre IV");
            temps10minute = true;
        }


        if (!naissance1 && naissance > 0)
        {
            GOPointer.AchievementManager.EarnAchievement("Heureux Évènement I");
            naissance1 = true;
        }


        if (!naissance2 && naissance > 1)
        {
            GOPointer.AchievementManager.EarnAchievement("Heureux Évènement II");
            naissance2 = true;
        }


        if (!nbInfos5 && nbInfos > 4)
        {
            GOPointer.AchievementManager.EarnAchievement("Connaissances en Chamois I");
            nbInfos5 = true;
        }


        if (!nbInfos10 && nbInfos > 9)
        {
            GOPointer.AchievementManager.EarnAchievement("Connaissances en Chamois II");
            nbInfos10 = true;
        }


        if (!score1000 && score > 999)
        {
            GOPointer.AchievementManager.EarnAchievement("Score Chamois I");
            score1000 = true;
        }


        if (!score3000 && score > 2999)
        {
            GOPointer.AchievementManager.EarnAchievement("Score Chamois II");
            score3000 = true;
        }


        if (!score5000 && score > 4999)
        {
            GOPointer.AchievementManager.EarnAchievement("Score Chamois III");
            score5000 = true;
        }


        if (!nourriture15 && nourritureMangee > 14)
        {
            GOPointer.AchievementManager.EarnAchievement("Alimentation I");
            nourriture15 = true;
        }


        if (!nourriture30 && nourritureMangee > 29)
        {
            GOPointer.AchievementManager.EarnAchievement("Alimentation II");
            nourriture30 = true;
        }
    }

    public void sendData()
    {
        h.Clear();
        h.Add("tps", tempsSurvecu);
        h.Add("nouriture", nourritureMangee);
        h.Add("score", score);
        h.Add("blessure", blessure);
        h.Add("scBouffe", scBouffe);
        h.Add("scBlessure", scBlessure);
        h.Add("scoreTps", scoreTps);
    }

    public void setData(string type, int var)
    {
        switch(type)
        {
            case "nourriture":
            nourritureMangee ++;
            score += var;
            scBouffe += var;
            break;

            case "blessure":
            blessure++;
            scBlessure += var;
            score += var;
            break;



            default:
            break;
        }
    }
}
