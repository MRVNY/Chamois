using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerRandonneur : Joueur
{
    public int nbRando = 0;
    public int maxRando = 3;
    
    public Boolean epion = false;
    public Boolean batterie = false;
    public Boolean dentPortes = false;
    public Boolean grandRoc = false;
    public Boolean pointesChaurionde = false;
    public Boolean morbier = false;
    public Boolean nivolet = false;
    public Boolean galoppaz = false;
    public Boolean colombier = false;
    public Boolean arcalod = false;
    public Boolean trelod = false;

    public int epionScore = 0;
    public int batterieScore = 0;
    public int dentPortesScore = 0;
    public int grandRocScore = 0;
    public int pointesChauriondeScore = 0;
    public int morbierScore = 0;
    public int nivoletScore = 0;
    public int galoppazScore = 0;
    public int colombierScore = 0;
    public int arcalodScore = 0;
    public int trelodScore = 0;

    public int epionCurrent = 0;
    public int batterieCurrent = 0;
    public int dentPortesCurrent = 0;
    public int grandRocCurrent = 0;
    public int pointesChauriondeCurrent = 0;
    public int morbierCurrent = 0;
    public int nivoletCurrent = 0;
    public int galoppazCurrent = 0;
    public int colombierCurrent = 0;
    public int arcalodCurrent = 0;
    public int trelodCurrent = 0;
    
    public DataStorerRandonneur dataStorer;

    new void Start()
    {
        base.Start();
        nbRando = 0;
        dataStorer = GOPointer.PlayerRandonneur.GetComponent<DataStorerRandonneur>();
    }

    new void Update()
    {
        base.Update();
        if(nbRando == maxRando)
        {
            dataStorer.sendData();
        }
    }
}
