using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class GuideManager : MonoBehaviour
{

    public TextMeshProUGUI guideText;
    public static GuideManager Instance;


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
    }

    // Start is called before the first frame update
    public void Start()
    {
        // //Debug.Log("boolean help : " + PlayerPrefs.GetFloat("inGameHelp"));
        // if(PlayerPrefs.GetInt("inGameHelp") == 1 && PlayerPrefs.GetInt(Global.Personnage)!=1)
        // {
        //     GOPointer.MenuManager.GetComponent<PauseMenu>().Pause();
        //     gameObject.SetActive(true);
        //     Time.timeScale = 0;
        //     guideText.SetText(Global.guide[Global.Personnage]);
        // }
        // else
            gameObject.SetActive(false);
    }


    void Update()
    {
    }



    async Task UseDelay(int x)
    {
        await Task.Delay(1000);
    }

    public async void fermerGuide()
    {
        GOPointer.MenuManager.GetComponent<PauseMenu>().Resume();
        gameObject.SetActive(false);
        //GOPointer.CanvasGuideJeu.SetActive(false);
        //wait(1000);
        await Task.Delay(2000);
        Time.timeScale = 1;
    }

    public void showGuide(string text)
    {
        GOPointer.MenuManager.GetComponent<PauseMenu>().Pause();
        GOPointer.CanvasGuideJeu.SetActive(true);
        gameObject.SetActive(true);
        guideText.SetText(text);
    }
}
