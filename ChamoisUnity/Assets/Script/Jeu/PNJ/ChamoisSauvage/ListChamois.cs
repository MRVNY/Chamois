using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class ListChamois : MonoBehaviour
{
    public int rdmChamoisProie;
    public List<GameObject>listDeChamois;
    private Hashtable h = new Hashtable();
    public static int nbChamoisNotProie = 2;
    int[] rdmChamoisNotProie = new int[nbChamoisNotProie];
    public bool isInTheList = false;
    public int k;
    void Start()
    {
        rdmChamoisProie = Random.Range(0,(listDeChamois.Count));
        for (int j = 0; (j < nbChamoisNotProie); j++)
        {
            while(k < j)
            {
                rdmChamoisNotProie[j] = Random.Range(0,(listDeChamois.Count));
                if (k == rdmChamoisNotProie[j])
                {
                    isInTheList = true;
                }
                if (isInTheList)
                {
                    rdmChamoisNotProie[j] = Random.Range(0, (listDeChamois.Count));
                    isInTheList = false;
                }
                else k++;
            }
        }
//        Debug.Log("id Chamois Cible = " + rdn);
        for (int i = 0; (i < listDeChamois.Count); i++)
        {
            //var i1 = i;
            listDeChamois[i].GetComponent<scriptChamoisSauvage>().id = i;
            //listDeChamois[i].onClick.AddListener(delegate() { isProie(listDeChamois[i1]);});
            if (listDeChamois[i].GetComponent<scriptChamoisSauvage>().id == rdmChamoisProie)
            {
                listDeChamois[i].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.5f);
                listDeChamois[i].SetActive(true);
            }
            for (int l = 0; (l < nbChamoisNotProie); l++)
            {
                if (listDeChamois[i].GetComponent<scriptChamoisSauvage>().id == rdmChamoisNotProie[l])
                {
                    listDeChamois[i].SetActive(true);
                }
            }
        }
    }

    public void isProie(GameObject chamois)
    {
        if (chamois.GetComponent<scriptChamoisSauvage>().id == rdmChamoisProie)
        {
            estUneProie();
        }
        else
        {
            estPasBon();
        }
    }
    
    void estUneProie()
    {
        GameObject.Find("GameManager").GetComponent<FinPartie>().receiveDataChasseurBonChamois(h);
        Debug.Log("Tu es une proie");
    }

    void estPasBon()
    {
        GameObject.Find("GameManager").GetComponent<FinPartie>().receiveDataChasseurMauvaisChamois(h);
        Debug.Log("Tu n'es pas le bon chamois");
    }
    
    
}

