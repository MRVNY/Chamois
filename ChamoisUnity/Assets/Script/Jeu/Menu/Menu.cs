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
    
    public GameObject NotifMenuDeroulant ;
    public List<GameObject> ListeBoutons;
    public static bool menuOuvre = false;

    private GameObject ChapitreChamois;
    private GameObject ChapitreChasseur;
    private GameObject ChapitreRandonneur;
    private GameObject interactiveButtons;

    private void Awake()
    {
        SaveLoad.LoadState();
        ChapitreChamois = GOPointer.ChapitreChamois;
        ChapitreChasseur = GOPointer.ChapitreChasseur;
        ChapitreRandonneur = GOPointer.ChapitreRandonneur;
        interactiveButtons = GOPointer.interactiveButtons;
    }

    private void Start()
    {
        // RectTransform firstIcon = menuIcon.GetComponent<RectTransform>();
        // Vector2 root = firstIcon.position;
        // float length = firstIcon.rect.height;
        //
        // for (int i = 0; i < ListeBoutons.Count; i++)
        // {
        //     ListeBoutons[i].transform.position = new Vector2(root.x, root.y - (i+1) * length * 1.5f);
        // }
        
        pause = GetComponent<PauseMenu>();
        Deactivate();
        pause.Resume();
    }

    public void activeMain()
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
    
    public void Activate()
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
        GOPointer.GameControl.GetComponent<Notifier>().setFalse();
        if (ChapitreChamois.activeSelf || ChapitreChasseur.activeSelf || ChapitreRandonneur.activeSelf)
        {
            ChapitreChamois.SetActive(false);
            ChapitreChasseur.SetActive(false);
            ChapitreRandonneur.SetActive(false);
            pasueIcon.SetActive(true);
        }
        else
        {
            if (Global.Personnage=="Chamois") ChapitreChamois.SetActive(true);
            else if (Global.Personnage=="Chasseur") ChapitreChasseur.SetActive(true);
            else if(Global.Personnage=="Randonneur") ChapitreRandonneur.SetActive(true);
            pasueIcon.SetActive(false);
        }
    }

    public void endEncy()
    {
        NotifMenuDeroulant.SetActive(false);
        Deactivate();
    }
}
