using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public static Task saving;
    
    public static Menu Instance;


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
        DontDestroyOnLoad(this);
    }

    async void Start()
    {
        if(GOPointer.GameControl==null) GOPointer.Instance.Link();
        if (Init.loading!=null) await Init.loading;
        if (GOPointer.linking!=null) await GOPointer.linking;

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
        saving = SaveLoad.SaveState();

        resume.SetActive(true);
        menuIcon.enabled = false;
        pasueIcon.SetActive(true);
        InteractiveButtons.Instanace.SetActive(false);
        
        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(true);
        }
        menuOuvre = true;
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            if(GOPointer.MenuManager==null) GOPointer.Instance.Link();
            GOPointer.MenuManager.GetComponent<AudioSource>().Play();
        }

    }
    
    public async void Deactivate()
    {
        if(saving!=null) await saving;
        if(GOPointer.EncyMenu==null) GOPointer.Instance.Link();

        resume.SetActive(false);
        menuIcon.enabled = true;
        pasueIcon.SetActive(false);
        InteractiveButtons.Instanace.SetActive(true);

        GOPointer.EncyMenu.SetActive(false);
        
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
        if (GOPointer.EncyMenu.activeSelf)
        {
            GOPointer.EncyMenu.SetActive(false);
            pasueIcon.SetActive(true);
        }
        else
        {
            GOPointer.EncyMenu.SetActive(true);
            pasueIcon.SetActive(false);
        }
    }

    public void endEncy()
    {
        NotifMenuDeroulant.SetActive(false);
        Deactivate();
    }
}
