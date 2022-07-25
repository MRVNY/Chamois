using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mJauges : Joueur
{

    [Header("Variable pour la détection du tag")]
    public OnTrigger2DScript danger;
    [Space(10)]
    
    //public Dialogue dialogue;
     [Space(30)]
//Jauges
    private int max = 100;

    public Image vie;
    public Image stress;
    public Image faim;

    public int vieActuelle = 100;
    public int palierVieFaim = 10;
    public int palierVieStress = 10;

    public int stressActuel = 0;
    public int palierStress = 10;

    public int faimActuelle = 100;
    public int palierFaim = 10;
    public int faimStartStress = 30;

// Timer
    public float WaitingTimeFaim = 2f;
    public float WaitingTimeStress = 2f;
    public float WaitingTimeStressDanger = 1f;
    public float WaitingTimeVieStress = 3f;
    public float WaitingTimeVieFaim = 2f;

    private float timerFaim = 0f;
    private float timerStress = 0f;
    private float timerStressDanger = 0f;
    private float timerVie = 0f;

    public float boostDuration = 3f;

    //statistique de la partie
    private float tempsSurvecu = 0f;
    private int nouritureMangee = 0;
    private Hashtable h = new Hashtable();

    /*public static new mJauges instance;

    private bool show = true;*/

    new void Start()
    {
        base.Start();
        //instance = this;
    }

    new void Update()
    {

    

        tempsSurvecu += base.time;

        if (vieActuelle > 0)
        {
            //Controlleur Stress
            if(danger.estDedans && stressActuel < 100)
            {
                /*if (show)
                {
                    FindObjectOfType<DialogueManager>().StartDialog(dialogue, 0, 1);
                    show = false;
                }*/

                timerStressDanger += base.time;
                if (timerStressDanger > WaitingTimeStressDanger)
                {
                    timerStressDanger = 0f;
                    stressActuel += 1;
                    setImage(stress, stressActuel);
                }
            }
            
            //Controlleur Faim
            if(faimActuelle > 0)
            {
            timerFaim += base.time;
            if (timerFaim > WaitingTimeFaim)
            {
                timerFaim = 0f;
                faimActuelle -= palierFaim;
                setImage(faim, faimActuelle);
            }
            }

            //Controlleur Stress en fonction de la faim
            if (faimActuelle < faimStartStress)
            {
                if (stressActuel < 100)
                {
                    timerStress += base.time;
                    if (timerStress > WaitingTimeStress)
                    {
                    timerStress = 0f;
                    stressActuel += palierStress;
                    setImage(stress, stressActuel);
                    }
                }
            }
            else
            {
                // Controlleur dissipation de Stress
                if (stressActuel > 0 && !danger.estDedans)
                {   
                    //show = true;

                    timerStress += Time.deltaTime;
                    if (timerStress > WaitingTimeStress)
                    {
                    timerStress = 0f;
                    stressActuel -= palierStress;
                    setImage(stress, stressActuel);
                    }
                }
            }

            //controlleur pv pour le stress
            if (stressActuel >= 100)
            {
                timerVie += base.time;
                if (timerVie > WaitingTimeVieStress)
                {
                    timerVie = 0f;
                    vieActuelle -= palierVieStress;
                    setImage(vie, vieActuelle);
                }
            }

            //controlleur pv pour la faim
            if (faimActuelle <= 0)
            {
                timerVie += base.time;
                if (timerVie > WaitingTimeVieFaim)
                {
                    timerVie = 0f;
                    vieActuelle -= palierVieFaim;
                    setImage(vie, vieActuelle);
                }
            }
        }

        //appel de la fin de partie
        else
        {
            Time.timeScale = 0;
            h.Add("tps", tempsSurvecu);
            h.Add("nouriture", nouritureMangee);
            //FinPartie.instance.receiveData(h);
            //base.stop = true;
        }
    }

    // controlleur de jauges quand Nourriture mangée
    public void setJauges(Hashtable mh)
    {
        int v = (int) mh["vie"];
        int f = (int) mh["nourriture"];
        int s = (int) mh["stress"];

        nouritureMangee ++;

        if (vieActuelle + v > 100)
            vieActuelle = 100;
        else
            vieActuelle += v;

        if (stressActuel - s < 0)
            stressActuel = 0;
        else
            stressActuel -= s;

        if (faimActuelle + f > 100)
            faimActuelle = 100;
        else
            faimActuelle+= f;

        setImage(vie, vieActuelle);
        setImage(stress, stressActuel);
        setImage(faim, faimActuelle);

        //FindObjectOfType<DialogueManager>().StartDialog(dialogue, 2, 2);
    }

    // Changement de l'image jauge quand modification
    public void setImage(Image image, int numerateur)
    {
        image.fillAmount = (float)numerateur/(float)max;
    }

}