﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinPartie : MonoBehaviour
{
    public GameObject finChamois;
    public GameObject finChasseur;
    public GameObject finChasseurBonChamois;
    public GameObject finChasseurMauvaisChamois;
    public GameObject finRandonneur; 

    public Text textChamois;
    public Text textChasseurMunitions;
    public Text textChasseurBonChamois;
    public Text textChasseurMauvaisChamois;
    public Text textRandonneur;

    private Boolean score1000;
    private Boolean score3000;
    private Boolean score5000;

    private Boolean nourriture15;
    private Boolean nourriture30;

    private Boolean infos5;
    private Boolean infos10;

    public bool fin = false;
    
    private DataStorerChasseur data;
    
    void Start()
    {
        finChamois.SetActive(false);
        finChasseur.SetActive(false);
        finRandonneur.SetActive(false);
    }



    public void receiveData(Hashtable h)
    {
        float tps = (float) h["tps"];
        int nouriture = (int) h["nouriture"];
        int score = (int)h["score"];
        int scBouffe = (int)h["scBouffe"];
        int scBlessure = (int)h["scBlessure"];
        int blessure = (int)h["blessure"];
        int scoreTps = (int)h["scoreTps"];

        textChamois.text = "Vous avez survécu pendant " + (int)tps + " secondes\net vous avez Mangé " + nouriture + " repas" + "\n\n Votre score est de : " + score + "pts" + "\n (Repas : " + nouriture + " --> " + scBouffe + "pts)" + "\n (Blessures : " + blessure + " --> " + scBlessure + "pts)" + "\n (Temps de jeu : " + (int)tps + "s --> " + scoreTps + "pts)";

        if (!score1000)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().score > 1000)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Score Chamois I");
                score1000 = true;
            }
        }

        if (!score3000)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().score > 3000)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Score Chamois II");
                score3000 = true;
            }
        }

        if (!score5000)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().score > 5000)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Score Chamois III");
                score5000 = true;
            }
        }

        if (!nourriture15)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().nourritureMangee > 14)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Alimentation I");
                nourriture15 = true;
            }
        }

        if (!nourriture30)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().nourritureMangee > 29)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Alimentation II");
                nourriture30 = true;
            }
        }

        if (!infos5)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos > 4)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Connaissances en Chamois I");
                infos5 = true;
            }
        }

        if (!infos10)
        {
            if (GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos > 9)
            {
                GOPointer.AchievementManager.GetComponent<AchievmentManager>().EarnAchievment("Connaissances en Chamois II");
                infos10 = true;
            }
        }

        Time.timeScale = 0f;

        finChamois.SetActive(true);
        fin = true;
    }
    
    public void receiveDataChasseur(Hashtable h)
    {
        //int score = (int)h["score"];
        textChasseurMunitions.text = "Vous n'avez plus de munitions"; //, votre score actuel est de: " + score;
        finChasseur.SetActive(true);
        fin = true;
    }
    
    public void receiveDataChasseurBonChamois(Hashtable h)
    {
        /*data.setData("bonChamois", +150);
        int dechets = (int)h["Dechets"];
        int scDechets = (int)h["scDechets"];
        int bonChamois = (int)h["bonChamois"];
        int scbonChamois = (int)h["scbonChamois"];
        int mauvaisChamois = (int)h["mauvaisChamois"];
        int scmauvaisChamois = (int)h["scmauvaisChamois"];
        int score = (int)h["score"];*/
        textChasseurBonChamois.text = "Bravo, vous avez tué le bon chamois ";// vous avez un score final de: " + score + "pts" + "\n (Dechets Ramassés : " + dechets + " --> " + scDechets + "pts)" + "\n (Mauvais Chamois tué : " + mauvaisChamois + " --> " + scmauvaisChamois + "pts)" + "\n (Bon Chamois tué : " + bonChamois + " : --> " + scbonChamois + "pts)";
        finChasseurBonChamois.SetActive(true);
        fin = true;
    }
    
    public void receiveDataChasseurMauvaisChamois(Hashtable h)
    {
        /*data.setData("mauvaisChamois", -50);
        int dechets = (int)h["Dechets"];
        int scDechets = (int)h["scDechets"];
        int mauvaisChamois = (int)h["mauvaisChamois"];
        int scmauvaisChamois = (int)h["scmauvaisChamois"];
        int score = (int)h["score"];*/
        textChasseurMauvaisChamois.text = "Aïe, vous avez tué le mauvais chamois, peut être que vous voulez réessayer ?";// Vous avez un score actuel de:" + score + "pts" + "\n (Dechets Ramassés : " + dechets + " --> " + scDechets + "pts)" + "\n (Mauvais Chamois tué : " + mauvaisChamois + " --> " + scmauvaisChamois + "pts)";
        finChasseurMauvaisChamois.SetActive(true);
        fin = true;
    }
    
    public void receiveDataRandonneur(Hashtable h)
    {
        int epionScore = (int)h["epionScore"];
        int batterieScore = (int)h["batterieScore"];
        int dentPortesScore = (int)h["dentPortesScore"];
        int grandRocScore = (int)h["grandRocScore"];
        int pointesChauriondeScore = (int)h["pointesChauriondeScore"];
        int morbierScore = (int)h["morbierScore"];
        int nivoletScore = (int)h["nivoletScore"];
        int galoppazScore = (int)h["galoppazScore"];
        int colombierScore = (int)h["colombierScore"];
        int arcalodScore = (int)h["arcalodScore"];
        int trelodScore = (int)h["trelodScore"];
        int scoreTotal = (int)h["scoreTotal"];

        textRandonneur.text = "Vous avez effectué un score de " + scoreTotal + "pts" + "\n\n (L'Épion --> " + epionScore + "pts)    " + "(Fort de la Batterie --> " + batterieScore + "pts)    " + "(Dent des Portes-- > " + dentPortesScore + "pts)    " + "\n (Grand Roc-- > " + grandRocScore + "pts)    " + "(Pointes de la Chaurionde --> " + pointesChauriondeScore + "pts)    " + "(Mont Morbier --> " + morbierScore + "pts)    " + "\n (Croix du Nivolet -- > " + nivoletScore + "pts)    " + "(Pointe de la Galoppaz-- > " + galoppazScore + "pts)    " + "(Mont Colombier --> " + colombierScore + "pts)    " + "\n (Pointe de l'Arcalod --> " + arcalodScore + "pts)    " + "(Mont Trélod --> " + trelodScore + "pts)";
        finRandonneur.SetActive(true);
        fin = true;
    }

    public void setChasseur(Boolean b)
    {
        finChasseur.SetActive(b);
        finChasseurMauvaisChamois.SetActive(b);
    }
}
