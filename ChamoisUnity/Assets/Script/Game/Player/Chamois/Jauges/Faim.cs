using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Faim : JaugesController
{
    public Image image;

    public int faimActuelle = 100;
    public int faimMax = 100;

    public int palierFaim = 10;

    public int faimActiveStress = 20;
    public TextMeshProUGUI faimText;

    private Boolean activateFaim50 = false;
    private Boolean activateFaim30 = false;
    private Boolean activateFaim10 = false;

    public float waitTimerFaim = 3f;
    private float timerIncrease = 0f;

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

        if (faimActuelle > faimMax)
        {
            faimActuelle = faimMax;
            //faim.setImage(faim.image, faim.faimActuelle, faim.faimMax);
            base.setImage(image, faimActuelle, faimMax);

        }

        if (faimActuelle < 0)
        {
            faimActuelle = 0;
            //faim.setImage(faim.image, faim.faimActuelle, faim.faimMax);
            base.setImage(image, faimActuelle, faimMax);

        }

        if (Global.Personnage == "Chamois" && PlayerPrefs.GetInt("inGameHelp") == 1)
        {
            if (((float)faimActuelle / (float)faimMax < 0.5) && !activateFaim50)
            {
                activateFaim50 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Votre niveau d'alimentation est tombé en dessous de 50%, faites attention de ne pas le laisser chuter plus, pour le restaurer, tentez de trouver de quoi vous nourir dans vos environs");
            }

            if (((float)faimActuelle / (float)faimMax < 0.3) && !activateFaim30)
            {
                activateFaim30 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Attention ! Votre niveau d'alimentation est tombé en dessous de 30%, faites attention de ne pas le laisser chuter plus car cela pourrait avoir des répercussions sur votre barre de santé. Pour le restaurer, tâchez de trouver de quoi vous nourir dans les environs");
            }

            if (((float)faimActuelle / (float)faimMax < 0.1) && !activateFaim10)
            {
                activateFaim10 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("ATTENTION ! Votre niveau d'alimentation est tombé en dessous de 10% ! Votre état est critique car si votre faim à un impact fort sur votre santé, soit votre barre de vie. Essayez à tout prix de trouver de la nourriture afin de d'éviter plus de problèmes");
            }

        }

        if (faimActuelle > 0)
        {

            timerIncrease += base.timer;
            if (timerIncrease >= waitTimerFaim)
            {
                timerIncrease = 0f;
                faimActuelle -= palierFaim;
                base.setImage(image, faimActuelle, faimMax);
            }
        }
        faimText.SetText("Faim : {0} / {1}", faimActuelle, faimMax);
    }

        public void setFaim(int v)
    {
        if (faimActuelle + v > faimMax)
            faimActuelle = faimMax;
        else
            faimActuelle += v;

        base.setImage(image, faimActuelle, faimMax);
    }
}
