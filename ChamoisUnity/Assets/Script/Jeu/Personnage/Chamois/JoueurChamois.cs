using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JoueurChamois : Joueur
{
    public float tempBoost = 3f;

    public float boost = 2;

    private bool hit = false;
    private bool activateOnce = true;

    public float boostTimer = 0f;
    private float timerRecul = 0f;

    private Stress stress;
    private Faim faim;

    static Boolean activateOnce2 = false;

    new void Start()
    {
        GameEvents.SaveInitiated += Save;

        Physics2D.IgnoreLayerCollision(8,9, true);
        base.Start();
        stress = GameObject.Find("Jauges").GetComponent<Stress>();

        //Load();
    }

    new void Update()
    {
        base.Update();


        if (hit)
        {
            faim = GameObject.Find("Jauges").GetComponent<Faim>();
            if(activateOnce)
            {
                vitesse *= boost;
                activateOnce = false;
            }
            boostTimer += Time.deltaTime;
            if (boostTimer >= tempBoost)
            {
                boostTimer = 0f;
                hit = false;
                activateOnce = true;
                vitesse /= boost;
                faim.faimActuelle -= 30;
                faim.setImage(faim.image, faim.faimActuelle, faim.faimMax);


                addToEncy();
            }
        }
    }

    Vector2 dir;
    private bool recul = false;

    void FixedUpdate()
    {
        if (recul)
        {
            timerRecul += Time.deltaTime;
                base.rb2d.AddForce(dir* 25, ForceMode2D.Impulse);
            if (timerRecul > 0.1f)
            {
                timerRecul = 0f;
                recul = false;
            }
        }
    }

    public void setHit(bool b)
    {
        hit = b;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Danger"))
            stress.danger(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Danger") && stress.getDanger())
            stress.danger(false);
    }

    void OnCollisionEnter2D(Collision2D coll) 
     {
         if (coll.gameObject.tag == "Danger")
         {
            hit = true;
            recul = true;

            Vector2 t = new Vector2(transform.position.x, transform.position.y);

            dir = coll.GetContact(0).point - t;

            dir = -dir.normalized;
            
         }
     }


    void Save()
    {
        Vector3 pos = transform.position;
        List<float> posJoueur = new List<float>();
        posJoueur.Add(pos.x);
        posJoueur.Add(pos.y);
        posJoueur.Add(pos.z);
        SaveLoad.Save<List<float>>(posJoueur, "position");

    }

    void Load()
    {
        if (SaveLoad.SaveExists("position"))
        {
            List<float> pos;
            pos = SaveLoad.Load<List<float>>("position");
            transform.position = new Vector3(pos[0], pos[1], pos[2]);
        }
    }

    public static void addToEncy()
    {
        if (!activateOnce2)
        {
            EncycloContentChamois ency = GameObject.Find("EncyclopedieManager").GetComponent<EncycloContentChamois>();
            ency.addInfoToList("fatigue", ency.pagesDynamic);
            activateOnce2 = true;
        }
    }
}

