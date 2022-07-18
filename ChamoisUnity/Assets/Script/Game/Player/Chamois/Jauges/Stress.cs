using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Stress : JaugesController
{
    public Image image;

    public int stressActuel = 0;
    public int stressMax = 100;

    public int palierStress = 10;

    public float WaitTimerStress = 3f;
    private float timerIncrease = 0f;
    public TextMeshProUGUI stressText;

    private bool dangerProxi;

    static Boolean activateOnce = false;

    private Boolean activateStress50 = false;
    private Boolean activateStress75 = false;

    new void Start()
    {
        base.Start();
        
        stress = gameObject.GetComponent<Stress>();
        faim = gameObject.GetComponent<Faim>();
        vie = gameObject.GetComponent<Vie>();

    }

    new void Update()
    {
        base.Update();

        if (stressActuel > stressMax)
        {
            stressActuel = stressMax;
            //stress.setImage(stress.image, stress.stressActuel, stress.stressMax);
            base.setImage(image, stressActuel, stressMax);

        }

        if (stressActuel < 0)
        {
            stressActuel = 0;
            //stress.setImage(stress.image, stress.stressActuel, stress.stressMax);
            base.setImage(image, stressActuel, stressMax);

        }

        stressText.SetText("Stress : {0} / {1}", stressActuel, stressMax);

        if (base.faim.faimActuelle <= base.faim.faimActiveStress)
        {
            timerIncrease += base.timer;
            if (timerIncrease >= WaitTimerStress)
            {
                timerIncrease = 0f;

                if (stressActuel <= stressMax)
                {
                    stressActuel += palierStress;
                    base.setImage(image, stressActuel, stressMax);
                }
            }

        }
        else if (dangerProxi)
        {
            timerIncrease += base.timer;
            if (timerIncrease >= WaitTimerStress)
            {
                timerIncrease = 0f;

                if (stressActuel <= stressMax)
                {
                    stressActuel += palierStress;
                    base.setImage(image, stressActuel, stressMax);
                    addToEncy();
                }
            }

        }
        else
        {
            if (stressActuel > 0)
            {
                timerIncrease += base.timer;
                if (timerIncrease >= WaitTimerStress)
                {
                    timerIncrease = 0f;
                    stressActuel -= palierStress;
                    base.setImage(image, stressActuel, stressMax);
                }
            }
        }

        if (Global.Personnage == "Chamois" && PlayerPrefs.GetInt("inGameHelp") == 1)
        {
            if (((float)stressActuel / (float)stressMax > 0.5) && !activateStress50)
            {
                activateStress50 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Votre niveau de stress est assez haut, ce qui est dangereux pour la santé de votre chamois. S'il continue à augmenter, cela pourrait avoir un fort impact sur votre vie. Tâchez de maintenir un niveau d'alimentation haut et de vous éloigner du danger afin de le faire baisser.");
            }

            if (((float)stressActuel / (float)stressMax > 0.75) && !activateStress75)
            {
                activateStress75 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Attention ! Votre stress est très haut, à ce stade, il est extrêmement dangereux pour la santé de votre chamois. Tâchez de maintenir un niveau d'alimentation haut et de vous éloigner du danger afin de le faire baisser.");
            }
        }
    }

    public void setStress(int v)
    {
        if (stressActuel + v > stressMax)
            stressActuel = stressMax;
        else
            stressActuel += v;

        base.setImage(image, stressActuel, stressMax);
    }

    
    public void danger(bool b)
    {
        dangerProxi = b;
    }

    public bool getDanger()
    {
        return dangerProxi;
    }

    public static void addToEncy()
    {
        if (!activateOnce)
        {
            EncycloContentChamois ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
            ency.addInfoToList("danger", ency.pagesDynamic);
            activateOnce = true;
        }
    }
}
