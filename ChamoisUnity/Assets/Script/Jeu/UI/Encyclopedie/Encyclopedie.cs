using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encyclopedie : MonoBehaviour
{
    public List<ContenuPages> pagesStatic = new List<ContenuPages>();
    public List<ContenuPages> pagesDynamic = new List<ContenuPages>();
    public List<ContenuPages> quete = new List<ContenuPages>();

    private Encyclopedie showing;

    protected Notifier notifier;

    protected ContenuPages page;
    protected string chapitre;
    
    protected static Dictionary<string, EncycloInfos> dynamicInfo = new Dictionary<string, EncycloInfos>();
    protected List<EncycloInfos> staticInfo = new List<EncycloInfos>();
    
    public TextAsset jsonFile;
    //public ArrayList data = new ArrayList();
    public EncyInfo info;

    protected int pageActuelle = 0;

    protected GameObject pG;
    protected GameObject pD;

    public Font font;
    public GameObject encyButtons;
    private GameObject leftButton;
    private GameObject rightButton;
    

    protected void Start()
    {
        notifier = GOPointer.GameControl.GetComponent<Notifier>();
        pG = GOPointer.PageGauche;
        pD = GOPointer.PageDroite;

        GOPointer.Livre.SetActive(false);
        updateShowing();
        
        leftButton = encyButtons.transform.Find("Gauche").gameObject;
        rightButton = encyButtons.transform.Find("Droite").gameObject;
    }

    protected void updateShowing()
    {
        if (Global.Personnage == "Chamois") showing = gameObject.GetComponent<EncycloContentChamois>();
        else if(Global.Personnage == "Chasseur") showing = gameObject.GetComponent<EncycloContentChasseur>();
        else if(Global.Personnage == "Randonneur") showing = gameObject.GetComponent<EncycloContentRandonneur>();
    }

    protected void setPageStatic(List<EncycloInfos> pages)
    {
        page = new ContenuPages();
 
        foreach(EncycloInfos i in pages)
       {
           if (page.getPoidsActuel() >= page.getPoidsMax())
           {
               pagesStatic.Add(page);
               page = new ContenuPages();
           }
           page.Add(i);
        }
        pagesStatic.Add(page);
    }

    protected void CurrentPage(int pageActuelle, List<ContenuPages> pages)
    {
        int pageGauche = pageActuelle + 1;
        if (pages.Count <= pageGauche)
        {
            formatagePage(pageGauche, pages, pG);
        }
        else if ( pages.Count > pageGauche )
        {
            formatagePage(pageGauche, pages, pG);
            formatagePage(pageGauche, pages, pD);
        }
        leftButton.SetActive(pageActuelle >= 2);
        rightButton.SetActive(pages.Count - pageActuelle > 2);
    }

    protected void formatagePage(int indexe, List<ContenuPages> pages, GameObject gm)
    {
            ContenuPages page = pages[(indexe-1)];
            int id = 0;

            foreach(EncycloInfos i in page.getInformations())
            {
                if (!string.IsNullOrEmpty(i.getImage()))
                {
                    Sprite sprite = Resources.Load<Sprite>(i.getImage());
                    GameObject image = new GameObject("image_" + id.ToString());
                    image.transform.SetParent(gm.transform);
                    image.AddComponent<Image>();
                    Image img = image.GetComponent<Image>();
                    img.sprite = sprite;
                    img.rectTransform.sizeDelta = new Vector2(img.sprite.rect.width/2, img.sprite.rect.height/2);
                }

                if (!string.IsNullOrEmpty(i.getText()))
                {
                    GameObject text = new GameObject("text_" + id.ToString());
                    text.transform.SetParent(gm.transform);
                    text.AddComponent<Text>().text = i.getText();
                    Text txt = text.GetComponent<Text>();
                    txt.font = font;
                    txt.color = Color.black;
                    txt.fontSize = 25;
                }
                id ++;
            }
    }

    protected void addInfoToList(string action, List<ContenuPages> liste, Dictionary<string, EncycloInfos> dico)
    {
        
        if (!dico.ContainsKey(action))
            return;
        ContenuPages page = new ContenuPages();
        if (liste.Count > 0)
        {

            if (liste[liste.Count - 1].getPoidsActuel() <= liste[liste.Count - 1].getPoidsMax())
                liste[liste.Count - 1].Add(dico[action]);
            
            else
            {
                page.Add(dico[action]);
                liste.Add(page);
            }
        }
        else
        {
            page.Add(dico[action]);
            liste.Add(page);
        }
    }

    public void onClickGauche()
    {
        List<ContenuPages> pages = showing.getPages();

        if (pages != null && pages.Count > 0 && pageActuelle > 0)
        {
            onPageChanged(pG);
            onPageChanged(pD);
            pageActuelle -= 2;
            CurrentPage(pageActuelle, pages);
        }
    }
    
    public void onClickDroite()
    {
        List<ContenuPages> pages = showing.getPages();

        if (pages != null && pages.Count > 0 && pageActuelle +2 < pages.Count)
        {
            onPageChanged(pG);
            onPageChanged(pD);
            pageActuelle = Math.Min(pageActuelle+2,pages.Count);
            CurrentPage(pageActuelle, pages);
        }

    }

    public void onChapterSelected(string chapitre)
    {
        GOPointer.Livre.SetActive(true);
        GOPointer.ChapitreChamois.SetActive(false);
        GOPointer.ChapitreChasseur.SetActive(false);
        GOPointer.ChapitreRandonneur.SetActive(false);
        encyButtons.SetActive(true);

        pageActuelle = 0;
        this.chapitre = chapitre;
        List<ContenuPages> pages = getPages();
        if(pages != null && pages.Count > 0)
        {
            CurrentPage(pageActuelle, pages);
        }
        leftButton.SetActive(pageActuelle > 2);
        rightButton.SetActive(pages.Count - pageActuelle > 2);
}

    public void onEncyclopedieClosed()
    {
        onPageChanged(pG);
        onPageChanged(pD);
        GOPointer.Livre.SetActive(false);
        encyButtons.SetActive(false);
        GOPointer.MenuManager.GetComponent<Menu>().endEncy();
    }

    private void onPageChanged(GameObject gm)
    {
        if (gm != null)
        {
            foreach(Transform i in gm.transform)
            {
                Destroy(i.gameObject);
            }
        }
    }

    public List<ContenuPages> getPages()
    {
        switch (showing.chapitre)
        {
            case "statique":
                return showing.pagesStatic;
            case "dynamique":
                return showing.pagesDynamic;
            case "quete":
                return showing.quete;
            default:
                return null;
        }
    }
}
