using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovel : MonoBehaviour
{
    public GameObject Jaugues;
    public GameObject Bouton;
    public GameObject Munitions;
    public GameObject Dechets;
    public GameObject Discovery;
    public GameObject Rando;
    
    // Start is called before the first frame update
    void Start()
    {
        GOPointer.MenuManager.GetComponent<PauseMenu>().Pause();
        GOPointer.MenuManager.SetActive(false);
        GOPointer.JoystickCanvas.SetActive(false);
        
        Jaugues.SetActive(false);
        Bouton.SetActive(false);
        Munitions.SetActive(false);
        Dechets.SetActive(false);
        Discovery.SetActive(false);
        Rando.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        GOPointer.MenuManager.SetActive(true);
        GOPointer.MenuManager.GetComponent<PauseMenu>().Resume();

        if (Global.Personnage == "Chamois")
        {
            Jaugues.SetActive(true);
        }
        else if(Global.Personnage == "Chassuer")
        {
            Bouton.SetActive(true);
            Munitions.SetActive(true);
            Dechets.SetActive(true);
        }
        else
        {
            Discovery.SetActive(true);
            Rando.SetActive(true);
        }
      
        
        gameObject.SetActive(false);
    }
}
