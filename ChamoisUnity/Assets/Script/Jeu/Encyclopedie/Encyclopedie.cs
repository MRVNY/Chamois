using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encyclopedie : MonoBehaviour
{
    public List<ContenuPages> pagesStatic;
    protected ContenuPages page;

    protected int pageActuelle = 0;

    protected GameObject pG;
    protected GameObject pD; 

    public Font font;

    protected void Start()
    {
        enabled = false;
        pagesStatic = new List<ContenuPages>();
        pG = GOPointer.PageGauche;
        pD = GOPointer.PageDroite;

        GOPointer.Livre.SetActive(false);
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

    protected void CurrentPage(int pageGauche, List<ContenuPages> pages)
    {
        if (pages.Count <= pageGauche + 1)
        {
            formatagePage(pageGauche, pages, pG);
        }
        else if ( pages.Count > pageGauche + 1 )
        {
            formatagePage(pageGauche, pages, pG);
            formatagePage(pageGauche + 1, pages, pD);
        }

    }

    protected void formatagePage(int indexe, List<ContenuPages> pages, GameObject gm)
    {
            ContenuPages page = pages[indexe];
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

    protected void onClickGauche(List<ContenuPages> pages)
    {
        if (pageActuelle > 0)
        {
            onPageChanged(pG);
            onPageChanged(pD);
            pageActuelle -= 2;
            CurrentPage(pageActuelle, pages);
        }
    }

    protected void onClickDroite(List<ContenuPages> pages)
    {
        if (pageActuelle +2 < pages.Count)
        {
            onPageChanged(pG);
            onPageChanged(pD);
            pageActuelle += 2;
            CurrentPage(pageActuelle, pages);
        }
    }

    protected void onChapterSelected(List<ContenuPages> pages)
    {
        pageActuelle = 0;
        CurrentPage(pageActuelle, pages);
    }

    public void onEncyclopedieClosed()
    {
        onPageChanged(pG);
        onPageChanged(pD);
    }

    private void onPageChanged(GameObject gm)
    {
        foreach(Transform i in gm.transform)
        {
            Destroy(i.gameObject);
        }
    }
}
