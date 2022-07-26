using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;


public class Vie : JaugesController
{

    public Image image;

    public int vieActuelle = 100;
    public int pvMax = 100;

    public int palierVieFaim = 10;
    public int palierVieStress = 10;

    public float timerStress = 3f;
    public float timerFaim = 2f;

    private float timerIncrease = 0f;

    private Boolean activateVie50 = false;
    private Boolean activateVie30 = false;
    private Boolean activateVie10 = false;

    public TextMeshProUGUI vieText;


    Joueur joueur;

    new void Start()
    {
        base.Start();
        GameEvents.SaveInitiated += Save;
        
        stress = gameObject.GetComponent<Stress>();
        faim = gameObject.GetComponent<Faim>();
        vie = gameObject.GetComponent<Vie>();

        //guide = GOPointer.CanvasGuideJeu;
        

        Load();
    }

    new void Update()
    {
        base.Update();

        vieText.SetText("Vie : {0} / {1}", vieActuelle, pvMax);

        if(vieActuelle > pvMax)
        {
            vieActuelle = pvMax;
            //vie.setImage(vie.image, vie.vieActuelle, vie.pvMax);
            base.setImage(image, vieActuelle, pvMax);

        }

        if (vieActuelle < 0)
        {
            vieActuelle = 0;
            //vie.setImage(vie.image, vie.vieActuelle, vie.pvMax);
            base.setImage(image, vieActuelle, pvMax);

        }

        if (Global.Personnage == "Chamois" && PlayerPrefs.GetInt("inGameHelp") == 1)
        {

            //Debug.Log("Vie Max : " + pvMax);
            //Debug.Log("Vie Act : " + vieActuelle);
            //Debug.Log("% de vie : " + (float)vieActuelle / (float)pvMax);

            if (((float)vieActuelle / (float)pvMax < 0.5) && !activateVie50)
            {
                activateVie50 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Votre vie est tombée en dessous de 50%, faites attention de ne pas la laisser chuter plus, pour la restaurer, maintenez un niveau d'alimentation élevé et tâchez de ne pas vous faire attaquer par un prédateur...");
            }

            if (((float)vieActuelle / (float)pvMax < 0.3) && !activateVie30)
            {
                activateVie30 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                //guide.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Attention ! Votre vie est tombée en dessous de 30%, faites attention de ne pas la laisser chuter plus, pour la restaurer, maintenez un niveau d'alimentation élevé et tâchez de ne pas vous faire attaquer par un prédateur...");
            }

            if (((float)vieActuelle / (float)pvMax < 0.1) && !activateVie10)
            {
                activateVie10 = true;
                Time.timeScale = 0;
                guide.SetActive(true);

                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("ATTENTION ! Votre vie est tombée en dessous de 10% ! Votre état est critique, restez donc éloigné des prédateurs, et essayez de maintenir un niveau d'alientation élevé afin de régénérer votre vie !");
            }

        }

        if (vieActuelle <= 0)
        {
            GameOver.Instance.End("Vous êtes mort...");

            GameEvents.onPause();


            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else
        {
            if (base.faim.faimActuelle <= 0)
            {
                
                timerIncrease += base.timer;
                if (timerIncrease >= timerFaim)
                {
                    timerIncrease = 0f;
                    vieActuelle -= palierVieFaim;
                    base.setImage(image, vieActuelle, pvMax);
                }
            }
            if (base.stress.stressActuel >= base.stress.stressMax)
            {
                timerIncrease += base.timer;
                if (timerIncrease >= timerStress)
                {
                    timerIncrease = 0f;
                    vieActuelle -= palierVieStress;
                    base.setImage(image, vieActuelle, pvMax);
                }
            }
        }
    }

    public void setVie(int v)
    {
        if (vieActuelle + v > pvMax)
            vieActuelle = pvMax;
        else
            vieActuelle += v;

        base.setImage(image, vieActuelle, pvMax);
    }

    void Save()
    {
        Hashtable h = new Hashtable();
        h.Add("vie", vieActuelle);
        h.Add("stress", base.stress.stressActuel);
        h.Add("nourriture", base.faim.faimActuelle);

        SaveLoad.Save<Hashtable>(h, "jauges");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("jauges"))
        {
            Hashtable h = SaveLoad.Load<Hashtable>("jauges");
            base.setJauges(h);
        }
    }
}
