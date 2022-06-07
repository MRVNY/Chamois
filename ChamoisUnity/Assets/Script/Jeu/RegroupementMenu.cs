using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RegroupementMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainButton;
    public List<GameObject> ListeBoutons = new List<GameObject>();
    public static bool menuOuvre = false;
    // Start is called before the first frame update
    
    public void activeMain()
    {
        if (!ListeBoutons[1].activeSelf)
        {
            Activate();
        }
        else
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1)
            {
                GameObject.Find("MenuManager").GetComponent<AudioSource>().Play();
            }
            Unactivate();
        }
    }
    
    public void Activate()
    {   
        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(true);
        }
        menuOuvre = true;
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GameObject.Find("MenuManager").GetComponent<AudioSource>().Play();
        }
    }
    
    public void Unactivate()
    {
        if (PlayerPrefs.GetInt("soundEffects") == 1)
        {
            GameObject.Find("MenuManager").GetComponent<AudioSource>().Play();
        }

        for (int i = 0; i < ListeBoutons.Count; i++)
        {
            ListeBoutons[i].SetActive(false);
        }

        menuOuvre = false;
    }
}
