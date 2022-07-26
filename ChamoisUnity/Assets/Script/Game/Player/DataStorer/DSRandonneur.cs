 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
/// <summary>
/// classe qui stock les données pour le randonneur
///</summary>

[Serializable]
public class DSRandonneur : DataStorer
{
    public int nbRando = 0;
    public int maxRando = 3;
    
    public string currentRando = "";
    public int scoreTotal;

    public int nbRandos = 0;
    public int nbRandosMemePartie = 0;
    public Boolean randoDif = false;
    public int nbDechets = 0;
    public int nbDechetsMemePartie = 0;
    public int meilleureRando = 0;
    public int nbInfos = 0;
    public int score = 0;
    
    private Boolean rando1 = false;
    private Boolean rando5partie = false;

    private Boolean randoDifficile = false;

    private Boolean dechet10 = false;
    private Boolean dechet20 = false;

    private Boolean rando5000pts = false;
    private Boolean rando7500pts = false;
    private Boolean rando9000pts = false;
    private Boolean rando9500pts = false;

    private Boolean nbInfos5 = false;
    private Boolean nbInfos10 = false;

    private Boolean score1000 = false;
    private Boolean score3000 = false;
    private Boolean score5000 = false;

    public static DSRandonneur Instance;
    
    public DSRandonneur()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
        h.Add("epionScore",0);
        h.Add("batterieScore",0);
        h.Add("dentPortesScore",0);
        h.Add("grandRocScore",0);
        h.Add("pointesChauriondeScore",0);
        h.Add("morbierScore",0);
        h.Add("nivoletScore",0);
        h.Add("galoppazScore",0);
        h.Add("colombierScore",0);
        h.Add("arcalodScore",0);
        h.Add("trelodScore",0);
        h.Add("scoreTotal",0);
    }

    void Update()
    {
        meilleureRando = PlayerPrefs.GetInt("meilleureRando");

        //GOPointer.textRando.SetText("Randonnées effectuées : \n{0} / 11", nbRandosMemePartie);

        if (!rando1 && nbRandos > 0)
        {
            AchievementManager.Instance.EarnAchievement("Jambes Solides I");
            rando1 = true;
        }

        if (!rando5partie && nbRandosMemePartie > 4)
        {
            AchievementManager.Instance.EarnAchievement("Jambes Solides II");
            rando5partie = true;
        }

        if (!randoDifficile && randoDif == true)
        {
            AchievementManager.Instance.EarnAchievement("Randonneur Aguéri I");
            randoDifficile = true;
        }

        if (!dechet10 && nbDechets > 9)
        {
            AchievementManager.Instance.EarnAchievement("Ami de la Nature I");
            dechet10 = true;
        }

        if (!dechet20 && nbDechets > 19)
        {
            AchievementManager.Instance.EarnAchievement("Ami de la Nature II");
            dechet20 = true;
        }

        if (!rando5000pts && meilleureRando > 4999)
        {
            AchievementManager.Instance.EarnAchievement("Randonnée Parfaite I");
            rando5000pts = true;
        }

        if (!rando7500pts && meilleureRando > 7499)
        {
            AchievementManager.Instance.EarnAchievement("Randonnée Parfaite II");
            rando7500pts = true;
        }

        if (!rando9000pts && meilleureRando > 8999)
        {
            AchievementManager.Instance.EarnAchievement("Randonnée Parfaite III");
            rando9000pts = true;
        }

        if (!rando9500pts && meilleureRando > 9499)
        {
            AchievementManager.Instance.EarnAchievement("Randonnée Parfaite IV");
            rando9500pts = true;
        }

        if (!nbInfos5 && nbInfos > 4)
        {
            AchievementManager.Instance.EarnAchievement("Connaissances en Randonnée I");
            nbInfos5 = true;
        }

        if (!nbInfos10 && nbInfos > 9)
        {
            AchievementManager.Instance.EarnAchievement("Connaissances en Randonnée II");
            nbInfos10 = true;
        }

        if (!score1000 && score > 999)
        {
            AchievementManager.Instance.EarnAchievement("Score Randonneur I");
            score1000 = true;
        }

        if (!score3000 && score > 2999)
        {
            AchievementManager.Instance.EarnAchievement("Score Randonneur II");
            score3000 = true;
        }

        if (!score5000 && score > 4999)
        {
            AchievementManager.Instance.EarnAchievement("Score Randonneur III");
            score5000 = true;
        }

        if(nbRando >= maxRando) GameOver.Instance.End("Bravo, vous avez fait toutes les randonnées !");
        
    }

    public void sendData()
    {
        h["scoreTotal"] = scoreTotal;
    }

    public void setData(string type, int var)
    {
        h[type] = var;
    }
}
