using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
/// <summary>
/// classe qui stock les données pour le randonneur
///</summary>
public class DataStorerRandonneur : MonoBehaviour
{
    private int epionScore;
    private int batterieScore;
    private int dentPortesScore;
    private int grandRocScore;
    private int pointesChauriondeScore;
    private int morbierScore;
    private int nivoletScore;
    private int galoppazScore;
    private int colombierScore;
    private int arcalodScore;
    private int trelodScore;
    public int scoreTotal;

    public int nbRandos;
    public int nbRandosMemePartie;
    public Boolean randoDif;
    public int nbDechets;
    public int nbDechetsMemePartie;
    public int meilleureRando;
    public int nbInfos;
    public int score;
    public TextMeshProUGUI textRando;

    private Boolean carteActive;


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

    private Hashtable h;

    void Start()
    {
        h = new Hashtable();

        epionScore = 0;

        batterieScore = 0;

        dentPortesScore = 0;

        grandRocScore = 0;

        pointesChauriondeScore = 0;

        morbierScore = 0;

        nivoletScore = 0;

        galoppazScore = 0;

        colombierScore = 0;

        arcalodScore = 0;

        trelodScore = 0;
        
        nbRandos = PlayerPrefs.GetInt("nbRandos");
        nbRandosMemePartie = 0;
        randoDif = (PlayerPrefs.GetInt("randoDifficile", 1) != 1);
        nbDechets = PlayerPrefs.GetInt("nbDechets");
        nbDechetsMemePartie = 0;
        meilleureRando = PlayerPrefs.GetInt("meilleureRando");
        nbInfos = 0;
        score = 0;
        scoreTotal = 0;
    }

    void Update()
    {
        meilleureRando = PlayerPrefs.GetInt("meilleureRando");

        carteActive = GOPointer.MiniMap.GetComponent<SwitchPlayerMap>().isActive;

        scoreTotal = epionScore + batterieScore + dentPortesScore + grandRocScore + pointesChauriondeScore + morbierScore + nivoletScore + galoppazScore + colombierScore + arcalodScore + trelodScore;

        if(Global.Personnage == "Randonneur")
        {
            textRando.SetText("Randonnées effectuées : \n{0} / 11", nbRandosMemePartie);

            if (!rando1 && carteActive == false)
            {
                if (nbRandos > 0)
                {
                    AchievmentManager.Instance.EarnAchievment("Jambes Solides I");
                    rando1 = true;
                }
            }

            if (!rando5partie && carteActive == false)
            {
                if (nbRandosMemePartie > 4)
                {
                    AchievmentManager.Instance.EarnAchievment("Jambes Solides II");
                    rando5partie = true;
                }
            }

            if (!randoDifficile && carteActive == false)
            {
                if (randoDif == true)
                {
                    AchievmentManager.Instance.EarnAchievment("Randonneur Aguéri I");
                    randoDifficile = true;
                }
            }

            if (!dechet10 && carteActive == false)
            {
                if (nbDechets > 9)
                {
                    AchievmentManager.Instance.EarnAchievment("Ami de la Nature I");
                    dechet10 = true;
                }
            }

            if (!dechet20 && carteActive == false)
            {
                if (nbDechets > 19)
                {
                    AchievmentManager.Instance.EarnAchievment("Ami de la Nature II");
                    dechet20 = true;
                }
            }

            if (!rando5000pts && carteActive == false)
            {
                if (meilleureRando > 4999)
                {
                    AchievmentManager.Instance.EarnAchievment("Randonnée Parfaite I");
                    rando5000pts = true;
                }
            }

            if (!rando7500pts && carteActive == false)
            {
                if (meilleureRando > 7499)
                {
                    AchievmentManager.Instance.EarnAchievment("Randonnée Parfaite II");
                    rando7500pts = true;
                }
            }

            if (!rando9000pts && carteActive == false)
            {
                if (meilleureRando > 8999)
                {
                    AchievmentManager.Instance.EarnAchievment("Randonnée Parfaite III");
                    rando9000pts = true;
                }
            }

            if (!rando9500pts && carteActive == false)
            {
                if (meilleureRando > 9499)
                {
                    AchievmentManager.Instance.EarnAchievment("Randonnée Parfaite IV");
                    rando9500pts = true;
                }
            }

            if (!nbInfos5 && carteActive == false)
            {
                if (nbInfos > 4)
                {
                    AchievmentManager.Instance.EarnAchievment("Connaissances en Randonnée I");
                    nbInfos5 = true;
                }
            }

            if (!nbInfos10 && carteActive == false)
            {
                if (nbInfos > 9)
                {
                    AchievmentManager.Instance.EarnAchievment("Connaissances en Randonnée II");
                    nbInfos10 = true;
                }
            }

            if (!score1000 && carteActive == false)
            {
                if (score > 999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Randonneur I");
                    score1000 = true;
                }
            }

            if (!score3000 && carteActive == false)
            {
                if (score > 2999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Randonneur II");
                    score3000 = true;
                }
            }

            if (!score5000 && carteActive == false)
            {
                if (score > 4999)
                {
                    AchievmentManager.Instance.EarnAchievment("Score Randonneur III");
                    score5000 = true;
                }
            }
        }

        
    }

    public void sendData()
    {
        h.Clear();
        h.Add("epionScore", epionScore);
        h.Add("batterieScore", batterieScore);
        h.Add("dentPortesScore", dentPortesScore);
        h.Add("grandRocScore", grandRocScore);
        h.Add("pointesChauriondeScore", pointesChauriondeScore);
        h.Add("morbierScore", morbierScore);
        h.Add("nivoletScore", nivoletScore);
        h.Add("galoppazScore", galoppazScore);
        h.Add("colombierScore", colombierScore);
        h.Add("arcalodScore", arcalodScore);
        h.Add("trelodScore", trelodScore);
        h.Add("scoreTotal", scoreTotal);

        GOPointer.GameManager.GetComponent<FinPartie>().receiveDataRandonneur(h);
        enabled = false;
    }

    public void setData(string type, int var)
    {
        switch (type)
        {
            case "epionScore":
                epionScore = var;
                break;
            case "batterieScore":
                batterieScore = var;
                break;
            case "dentPortesScore":
                dentPortesScore = var;
                break;
            case "grandRocScore":
                grandRocScore = var;
                break;
            case "pointesChauriondeScore":
                pointesChauriondeScore = var;
                break;
            case "morbierScore":
                morbierScore = var;
                break;
            case "nivoletScore":
                nivoletScore = var;
                break;
            case "galoppazScore":
                galoppazScore = var;
                break;
            case "colombierScore":
                colombierScore = var;
                break;
            case "arcalodScore":
                arcalodScore = var;
                break;
            case "trelodScore":
                trelodScore = var;
                break;
            default:
                break;
        }
        /*switch(type)
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
        }*/
    }
}
