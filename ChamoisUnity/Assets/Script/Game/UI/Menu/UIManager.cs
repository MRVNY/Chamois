using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    
    [SerializeField] private GameObject achi;
    
    private PauseMenu pause;
    

    private void Awake()
    {
        foreach (var panel in panels)
        {
            //panel.anchoredPosition = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            panel.position = transform.position;
        }
        
        chamois.SetActive(Global.Personnage=="Chamois");
        chasseur.SetActive(Global.Personnage=="Chasseur");
        randonneur.SetActive(Global.Personnage=="Randonneur");
    }

    // Start is called before the first frame update
    public void Start()
    {
        pause = GOPointer.MenuManager.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UIPause()
    {
        pause.Pause();
        GOPointer.MenuManager.SetActive(false);
        GOPointer.JoystickCanvas.SetActive(false);
        
        chamois.SetActive(false);
        chasseur.SetActive(false);
        randonneur.SetActive(false);
        buttons.SetActive(false);
    }

    void UIResume()
    {
        pause.Resume();
        buttons.SetActive(true);
        chamois.SetActive(Global.Personnage=="Chamois");
        chasseur.SetActive(Global.Personnage=="Chasseur");
        randonneur.SetActive(Global.Personnage=="Randonneur");
        GOPointer.MenuManager.SetActive(true);
        GOPointer.MenuManager.GetComponent<Menu>().Deactivate();
    }
    public void startVisualNovel(SpriteRenderer left)
    {
        UIPause();
        GOPointer.EncyclopedieManager.SetActive(false);
        GOPointer.VisualNovel.gameObject.SetActive(true);
        GOPointer.VisualNovel.setImages(left);
    }
    
    public void endVisualNovel()
    {
        GOPointer.VisualNovel.gameObject.SetActive(false);
        UIResume();
    }

    public void startAchi()
    {
        UIPause();
        achi.SetActive(true);
    }
    
    public void endAchi()
    {
        //pause.Resume();
        achi.SetActive(false);
        UIResume();
    }

    public void startMiniMap()
    {
        GOPointer.MiniMap.SetActive(true);
        UIPause();
    }

    public void endMiniMap()
    {
        GOPointer.MiniMap.SetActive(false);
        UIResume();
    }
}
