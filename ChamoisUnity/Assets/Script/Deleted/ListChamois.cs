using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

//THIS SCRIPT HAS BEEN REMOVED FROM THE GAME, BUT KEPT FOR OTHER DEPRECATED PREFABS
public class ListChamois : MonoBehaviour
{
    public int target;
    private List<GameObject> listDeChamois;
    
    // public static int nbChamoisNotProie = 2;
    // int[] rdmChamoisNotProie = new int[nbChamoisNotProie];
    // public bool isInTheList = false;
    // public int k;
    // void Start()
    // {
    //     listDeChamois = GetComponentsInChildren<GameObject>().ToList();
    //     target = Random.Range(0,(listDeChamois.Count));
    //     
    // }
    //
    // public void isProie(GameObject chamois)
    // {
    //     if (chamois.GetComponent<Weak>().id == target)
    //     {
    //         estUneProie();
    //     }
    //     else
    //     {
    //         estPasBon();
    //     }
    // }
    //
    // void estUneProie()
    // {
    //     GOPointer.GameManager.GetComponent<FinPartie>().receiveDataChasseurBonChamois(new Hashtable());
    //     Debug.Log("Tu es une proie");
    // }
    //
    // void estPasBon()
    // {
    //     GOPointer.GameManager.GetComponent<FinPartie>().receiveDataChasseurMauvaisChamois(new Hashtable());
    //     Debug.Log("Tu n'es pas le bon chamois");
    // }
    //
    
}

