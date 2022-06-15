using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class GuideManager : MonoBehaviour
{

    public TextMeshProUGUI guideText;
    public GameObject guideCanvas;



    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("boolean help : " + PlayerPrefs.GetFloat("inGameHelp"));
        if(PlayerPrefs.GetInt("inGameHelp") == 1 && !SaveLoad.SaveExists("pos"+Global.Personnage))
        {
            GOPointer.MenuManager.GetComponent<PauseMenu>().Pause();
            guideCanvas.SetActive(true);
            Time.timeScale = 0;
            guideText.SetText(Global.guide[Global.Personnage]);
        }
        else
        {
            guideCanvas.SetActive(false);
        }
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
        GOPointer.CanvasGuideJeu.GetComponent<Canvas>().enabled = false;
        //GOPointer.CanvasGuideJeu.SetActive(false);
        //wait(1000);
        await Task.Delay(2000);
        Time.timeScale = 1;
    }
}
