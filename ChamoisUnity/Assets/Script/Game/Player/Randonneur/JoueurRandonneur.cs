using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class JoueurRandonneur : Joueur
{
    [NonSerialized] public DSRandonneur DS = new DSRandonneur();

    private void Awake()
    {
        DS = new DSRandonneur();
    }
}
