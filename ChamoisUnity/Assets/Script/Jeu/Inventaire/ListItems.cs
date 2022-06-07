using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListItems : MonoBehaviour
{
    public List<GameObject> ListeItems = new List<GameObject>();

    //public Dictionary<int, bool> DictionnaireItem = new Dictionary<int, bool>();
    [SerializeField] public GameObject inventoryMenu;

    private void Update()
    {
        parcoursListe();
    }

    public void parcoursListe()
    {
        foreach (GameObject x in ListeItems)
        {
            if(( x.GetComponent<Drag>().estDehors == false) && (inventoryMenu.activeSelf == false))
            { 
                x.SetActive(false);
            }
            else
            {
                x.SetActive(true);
            }
        }
    }
}
