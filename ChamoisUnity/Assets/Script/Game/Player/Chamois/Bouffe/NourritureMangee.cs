using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NourritureMangee : MonoBehaviour
{
    public static List<int> nourMangee { get; private set; } = new List<int>();

    static Boolean activateOnce = false;

    public int id;

    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        nourMangee.Clear();
        Load();
    }

    public void Start()
    {
     enabled = false;   
    }

    public static void addNourMangee(List<int> liste)
    {

        foreach(int id in liste)
        {
            nourMangee.Add(id);
        }
    }

    public void Save()
    {
        SaveLoad.Save<List<int>>(nourMangee, "nourriture");
    }

    public void Load()
    {
        if (SaveLoad.SaveExists("nourriture"))
        {
            addNourMangee(SaveLoad.Load<List<int>>("nourriture"));
        }
    }

    public static void displayNourMang()
    {
        foreach(int id in nourMangee)
        {
        }
    }

    public static void addToEncy()
    {
        if (!activateOnce)
        {
            EncycloContentChamois ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
            ency.addInfoToList("mange", ency.pagesDynamic);
            activateOnce = true;
        }
    }
}
