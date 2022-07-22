using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JaugesController : MonoBehaviour
{
    protected float timer;

    protected bool stop = false;

    protected Stress stress;
    protected Faim faim;
    protected Vie vie;
    //protected Experience experience;

    protected GameObject player;
    protected GameObject guide;
    
    protected void Start()
    {
        if (Global.Personnage != "Chamois")
        {
            gameObject.SetActive(false);
        }
        else{
            guide = GOPointer.CanvasGuideJeu;
            if (Global.Personnage == "Chamois")
            {
                player = GOPointer.PlayerChamois;
                GameEvents.Pause += Pause;
                stress = gameObject.GetComponent<Stress>();
                faim = gameObject.GetComponent<Faim>();
                vie = gameObject.GetComponent<Vie>();
                //experience = gameObject.GetComponent<Experience>();
            }
        }
    }
     
    protected void Update()
    {
        timer = Time.deltaTime;
    }


    public void setImage(Image image, int numerateur, int max)
    {
        image.fillAmount = (float)numerateur/(float)max;
    }

    public void setJauges(Hashtable h)
    {
        if (Global.Personnage == "Chamois")
        {

            int v = (int)h["vie"];
            int f = (int)h["nourriture"];
            int s = (int)h["stress"];
            //int e = (int) h["experience"];

            if (h.ContainsKey("score"))
            {
                int sc = (int)h["score"];
                player.GetComponent<DataStorerChamois>().setData("nourriture", sc);
            }


            vie.setVie(v);
            faim.setFaim(f);
            stress.setStress(s);
            //experience.setExperience(e);
        }
    }

    protected void Pause()
    {
        enabled = !enabled;
        gameObject.SetActive(enabled);
    }



}
