using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject resume;
    public Image menuIcon;
    public GameObject pasueIcon;
    private PauseMenu pause;
    private Notifier notifier;
    
    public GameObject NotifMenuDeroulant ;
    public List<GameObject> ListeBoutons;
    public static bool menuOuvre = false;

    private GameObject ChapitreChamois;
    private GameObject ChapitreChasseur;
    private GameObject ChapitreRandonneur;
    private GameObject interactiveButtons;


    private void Start()
    {
        ChapitreChamois = GOPointer.ChapitreChamois;
        ChapitreChasseur = GOPointer.ChapitreChasseur;
        ChapitreRandonneur = GOPointer.ChapitreRandonneur;
        interactiveButtons = GOPointer.interactiveButtons;
        
        pause = GetComponent<PauseMenu>();
        
        notifier = GOPointer.GameControl.GetComponent<Notifier>();
        Deactivate();
        pause.Resume();
    }

    public void ActiveMain()
    {
        NotifMenuDeroulant.SetActive(false);
        if (menuIcon.enabled)
        {
            pause.Pause();
            Activate();
        }
        else
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1)
            {
                GOPointer.MenuManager.GetComponent<AudioSource>().Play();
            }
            Deactivate();
        }
    }

    private void Activate()
    {
        resume.SetActive(true);
        menuIcon.enabled = false;
        pasueIcon.SetActive(true);
        interactiveButtons.SetActive(false);
        
        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(true);
        }
        menuOuvre = true;
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GOPointer.MenuManager.GetComponent<AudioSource>().Play();
        }

    }
    
    public void Deactivate()
    {
        resume.SetActive(false);
        menuIcon.enabled = true;
        pasueIcon.SetActive(false);
        interactiveButtons.SetActive(true);

        ChapitreChamois.SetActive(false);
        ChapitreChasseur.SetActive(false);
        ChapitreRandonneur.SetActive(false);
        
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GOPointer.MenuManager.GetComponent<AudioSource>().Play();
        }

        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(false);
        }

        menuOuvre = false;
        pause.Resume();
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Switch(string perso)
    {
        Global.Personnage = perso;
        SceneManager.LoadScene("Game");
    }

    public void EncyOnClick()
    {
        Vibrate.vibration();
        //GOPointer.Ouvre.SetActive(false);
        notifier.setFalse();
        if (ChapitreChamois.activeSelf || ChapitreChasseur.activeSelf || ChapitreRandonneur.activeSelf)
        {
            ChapitreChamois.SetActive(false);
            ChapitreChasseur.SetActive(false);
            ChapitreRandonneur.SetActive(false);
            pasueIcon.SetActive(true);
        }
        else
        {
            switch (Global.Personnage)
            {
                case "Chamois":
                    ChapitreChamois.SetActive(true);
                    break;
                case "Chasseur":
                    ChapitreChasseur.SetActive(true);
                    break;
                case "Randonneur":
                    ChapitreRandonneur.SetActive(true);
                    break;
            }

            pasueIcon.SetActive(false);
        }
    }

    public void endEncy()
    {
        NotifMenuDeroulant.SetActive(false);
        Deactivate();
    }
}
