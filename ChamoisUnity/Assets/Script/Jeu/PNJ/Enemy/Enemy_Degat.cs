using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Classe <c>Enemy_Degat</c> 
/// </summary>
/// <remarks>
/// Ajouter ce script a toute faune infligeant des dégats au joueur chamois
/// </remarks>
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Degat : Enemy
{

    private Rigidbody2D rb;

    private Vie vie;
    private JoueurChamois joueur;
    private DataStorer data;
    private GameObject pm;
    public int sc = -100;
    public int tpsGriffure;
    public int tpsMorsure;
    public int tpsMorsureGrave;
    public int rdn;
    public bool isHit;
    static Boolean activateOnce = false;

    new void Start()
    {
        base.Start();
        pm = GOPointer.PlayerChamois;

        if (pm != null)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            
            vie = pm.GetComponentInChildren<Vie>();
            joueur = GOPointer.PlayerChamois.GetComponent<JoueurChamois>();
            data = pm.GetComponent<DataStorer>();
        }
    }

    void Update()
    {
        if (isHit)
        {
            if(rdn == 0)
            {
                Debug.Log("Vous avez subi une griffure, " + tpsGriffure + " secondes de saignement");
            }
            else if(rdn == 1)
            {
                Debug.Log("Vous avez subi une morsure, " + tpsMorsure + " secondes de saignement");
            }
            else if(rdn == 2)
            {
                Debug.Log("Vous avez subi une morsure grave, " + tpsMorsureGrave + " secondes de saignement");
            }

            StartCoroutine(Blessure());
        }
    }

    IEnumerator Blessure()
    {
        if(Global.Personnage == "Chamois")
        {
            GOPointer.PlayerChamois.GetComponent<JoueurChamois>().boostTimer = 0f;
            isHit = false;
            vie.vieActuelle -= (int)base.damage;
            for (int i = 0; i < tps(); i++)
            {
                vie.vieActuelle -= (int)base.damageSaignement;
                vie.setImage(vie.image, vie.vieActuelle, vie.pvMax);
                yield return new WaitForSeconds(0.1f);
            }
            StopCoroutine(Blessure());
        }
    }

    /// <summary>
    /// Permet d'infliger des dégâts quand le joueur est touché
    /// </summary>
    /// <param name="coll">collider touché</param>
     void OnCollisionEnter2D(Collision2D coll) 
     {
        if(Global.Personnage == "Chamois")
        {
            if (coll.gameObject.tag == "Player")
            {
                if (PlayerPrefs.GetInt("soundEffects") == 1)
                {
                    GameObject.Find("predateurs").GetComponent<AudioSource>().Play();
                }
                rdn = Random.Range(0, 3);
                isHit = true;
                data.setData("blessure", sc);
                addToEncy();
            }
        }
     }

    int tps()
    {
        int t;
        switch (rdn)
        {
            case 0:
                t = tpsGriffure;
                break;

            case 1:
                t = tpsMorsure;
                break;

            case 2:
                t = tpsMorsureGrave;
                break;
            
            default:
                Debug.Log("tps : default");
                t = 0;
            break;
        }
        return t;
    }
    
    public static void addToEncy()
    {
        if (!activateOnce)
        {
            EncycloContentChamois ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
            ency.addInfoToList("attaque", ency.pagesDynamic);
            activateOnce = true;
        }
    }
}