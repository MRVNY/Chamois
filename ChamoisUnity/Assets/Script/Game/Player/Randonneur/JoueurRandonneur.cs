﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class JoueurRandonneur : Joueur
{
    public DataStorerRandonneur dataStorer = new DataStorerRandonneur();

    private void Awake()
    {
        dataStorer = new DataStorerRandonneur();
    }
}
