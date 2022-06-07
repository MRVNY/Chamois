﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// classe qui stock les données pour le chasseur
///</summary>
public class DataStorerChasseur : MonoBehaviour
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
    
    private Hashtable h;

    // Start is called before the first frame update
    void Start()
    {
        nbQuetes = PlayerPrefs.GetInt("nbQuetes");

        nbPhoto = PlayerPrefs.GetInt("nbPhoto");

        nbPhotoMemePartie = 0;

        abattus = PlayerPrefs.GetInt("abattus");

        abattusMemePartie = 0;

        score = 0;

        nbInfos = 0;

        scDechets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        carteActive = GameObject.Find("Game Map").GetComponent<SwitchPlayerMap>().isActive;

        if (Global.Personnage == "Chasseur")
        {
            if (!quete1 && carteActive == false)
            {
                if (nbQuetes > 1)
                {
                    AchievmentManager.Instance.EarnAchievment("Quête Chasse I");
                    quete1 = true;
                }
            }

            if (!photo5 && carteActive == false)
            {
                if (nbPhotoMemePartie > 4)
                {
                    AchievmentManager.Instance.EarnAchievment("Chasse Photographique I");
                    photo5 = true;
                }
            }

            if (!photo10 && carteActive == false)
            {
                if (nbPhotoMemePartie > 9)
                {
                    AchievmentManager.Instance.EarnAchievment("Chasse Photographique II");
                    photo10 = true;
                }
            }

            if (!photo15 && carteActive == false)
            {
                if (nbPhotoMemePartie > 14)
                {
                    AchievmentManager.Instance.EarnAchievment("Chasse Photographique III");
                    photo15 = true;
                }
            }

            if (!abattre1 && carteActive == false)
            {
                if (abattus > 0)
                {
                    AchievmentManager.Instance.EarnAchievment("Prélèvement I");
                    abattre1 = true;
                }
            }

            if (!abattre2 && carteActive == false)
            {
                if (abattus > 1)
                {
                    AchievmentManager.Instance.EarnAchievment("Prélèvement II");
                    abattre2 = true;
                }
            }

            if (!abattre3 && carteActive == false)
            {
                if (abattus > 2)
                {
                    AchievmentManager.Instance.EarnAchievment("Prélèvement III");
                    abattre3 = true;
                }
            }

            if (!score1000 && carteActive == false)
            {
                if (score > 999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Chasseur I");
                    score1000 = true;
                }
            }

            if (!score3000 && carteActive == false)
            {
                if (abattus > 2999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Chasseur II");
                    score3000 = true;
                }
            }

            if (!score5000 && carteActive == false)
            {
                if (score > 4999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Chasseur III");
                    score5000 = true;
                }
            }

            if (!nbInfos5 && carteActive == false)
            {
                if (nbInfos > 4)
                {
                    AchievmentManager.Instance.EarnAchievment("Connaissances en Chasse I");
                    nbInfos5 = true;
                }
            }

            if (!nbInfos10 && carteActive == false)
            {
                if (nbInfos > 9)
                {
                    AchievmentManager.Instance.EarnAchievment("Connaissances en Chasse II");
                    nbInfos10 = true;
                }
            }
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

            GameObject.Find("GameManager").GetComponent<FinPartie>().receiveData(h);
            enabled = false;
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
