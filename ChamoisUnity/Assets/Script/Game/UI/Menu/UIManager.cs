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
    [SerializeField] private GameObject achiMenu;

    private PauseMenu pause;
    public static UIManager Instance;
    

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        foreach (var panel in panels)
        {
            //panel.anchoredPosition = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            panel.position = transform.position;
            Vector2 offset = new Vector2(Screen.width, Screen.height);
            //panel.

        }
        
        chamois.SetActive(Global.Personnage=="Chamois");
        chasseur.SetActive(Global.Personnage=="Chasseur");
        randonneur.SetActive(Global.Personnage=="Randonneur");
    }

    // Start is called before the first frame update
    public void Start()
    {
        pause = GOPointer.MenuManager.GetComponent<PauseMenu>();
        achiMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIPause()
    {
        pause.Pause();
        GOPointer.MenuManager.SetActive(false);
        GOPointer.JoystickCanvas.SetActive(false);
        
        chamois.SetActive(false);
        chasseur.SetActive(false);
        randonneur.SetActive(false);
        buttons.SetActive(false);
    }

    public void UIResume()
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
        GuideManager.Instance.gameObject.SetActive(false);
        GOPointer.EncyclopedieManager.SetActive(false);
        GOPointer.VisualNovel.gameObject.SetActive(true);
        GOPointer.VisualNovel.setImages(left);
    }
    
    public void endVisualNovel()
    {
        GuideManager.Instance.gameObject.SetActive(true);
        GuideManager.Instance.Start();
        GOPointer.EncyclopedieManager.SetActive(true);
        GOPointer.VisualNovel.gameObject.SetActive(false);
        UIResume();
    }
    
    public void startEncy()
    {
        UIPause();
        //GOPointer.Ouvre.SetActive(false);
        //.setFalse();
        if (GOPointer.EncyMenu.activeSelf)
        {
            GOPointer.EncyMenu.SetActive(false);
        }
        else
        {
            GOPointer.EncyMenu.SetActive(true);
        }
    }

    public void endEncy()
    {
        Notifier.Instance.SeenNotes();
        UIResume();
    }

    public void startAchi()
    {
        UIPause();
        achi.SetActive(false);
        achiMenu.SetActive(true);
        QuestManager.Instance.gameObject.SetActive(false);
    }

    public void openArchi()
    {
        achi.SetActive(true);
        achiMenu.SetActive(false);
    }

    public void openQuest()
    {
        achiMenu.SetActive(false);
        QuestManager.Instance.gameObject.SetActive(true);
        Notifier.Instance.SeenQuest();
    }
    
    public void endAchi()
    {
        //pause.Resume();
        achi.SetActive(false);
        achiMenu.SetActive(false);
        QuestManager.Instance.gameObject.SetActive(false);
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
