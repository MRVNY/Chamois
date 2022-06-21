using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<RectTransform> panels;
    [SerializeField] private GameObject chamois;
    [SerializeField] private GameObject chasseur;
    [SerializeField] private GameObject randonneur;
    [SerializeField] private GameObject buttons;
    
    private PauseMenu pause;
    

    private void Awake()
    {
        foreach (var panel in panels)
        {
            panel.position = transform.position;
        }
        
        chamois.SetActive(Global.Personnage=="Chamois");
        chasseur.SetActive(Global.Personnage=="Chasseur");
        randonneur.SetActive(Global.Personnage=="Randonneur");
    }

    // Start is called before the first frame update
    void Start()
    {
        pause = GOPointer.MenuManager.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startVisualNovel(SpriteRenderer left)
    {
        pause.Pause();
        GOPointer.MenuManager.SetActive(false);
        GOPointer.JoystickCanvas.SetActive(false);
        
        chamois.SetActive(false);
        chasseur.SetActive(false);
        randonneur.SetActive(false);
        buttons.SetActive(false);
        
        GOPointer.VisualNovel.SetActive(true);

        GOPointer.VisualNovel.GetComponent<VisualNovel>().setImages(left);
    }
    
    public void endVisualNovel()
    {
        GOPointer.MenuManager.SetActive(true);
        pause.Resume();
        GOPointer.VisualNovel.SetActive(false);
        buttons.SetActive(true);
        chamois.SetActive(Global.Personnage=="Chamois");
        chasseur.SetActive(Global.Personnage=="Chasseur");
        randonneur.SetActive(Global.Personnage=="Randonneur");
    }
}
