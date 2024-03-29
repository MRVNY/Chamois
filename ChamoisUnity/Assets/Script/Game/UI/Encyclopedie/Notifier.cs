﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notifier : MonoBehaviour
{
    public GameObject notifEncy;
    public GameObject notifNotes;
    public GameObject notifAchi;
    public GameObject notifQuest;
    public GameObject notifMenu;

    public static Notifier Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        notifAchi.SetActive(false);
        notifEncy.SetActive(false);
        notifNotes.SetActive(false);
        notifQuest.SetActive(false);
        notifMenu.SetActive(false);
    }

    private void Start()
    {
        notifAchi.SetActive(false);
        notifEncy.SetActive(false);
        notifNotes.SetActive(false);
        notifQuest.SetActive(false);
        notifMenu.SetActive(false);
    }

    public void NewNotes()
    {
        notifMenu.SetActive(true);
        notifNotes.SetActive(true);
        notifEncy.SetActive(true);
    }
    
    public void NewQuest()
    {
        notifMenu.SetActive(true);
        notifQuest.SetActive(true);
        notifAchi.SetActive(true);
    }

    public void SeenNotes()
    {
        notifEncy.SetActive(false);
        notifNotes.SetActive(false);
        if(notifQuest.activeSelf == false)
        {
            notifMenu.SetActive(false);
        }
    }
    
    public void SeenQuest()
    {
        notifAchi.SetActive(false);
        notifQuest.SetActive(false);
        if(notifNotes.activeSelf == false)
        {
            notifMenu.SetActive(false);
        }
    }
}
