using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class encyclopediePagesTourner : MonoBehaviour
{
    //private TextMeshProUGUI textMesh;
    public TMP_Text tmpText;
    public Image image;
    public int id;
    ArrayList listeInfos = new ArrayList();
    
    string[] actionAjout = new string[]
    {
        "Vous avez mangé de la nourriture avariée, votre vie est en train de baisser"
    };
    
    public Sprite[] sprites;
    public int page = 0;
    
    public void Start()
    {
        
        listeInfos.Add("Manger remonte votre jauge de santé et de nourriture.");
        listeInfos.Add("La Partie se termine quand votre santé tombe à 0.");
        listeInfos.Add("Si vous vous approchez d'un danger ou que votre jauge de nourriture est faible, votre stress augmente.");
        listeInfos.Add("Vous perdez de la santé en fonction de la jauge de stress.");
        listeInfos.Add("En tant que chamoix, vous pouvez passer certaines 'barrières' que d'autres êtres vivants ne peuvent passer.");
        listeInfos.Add("Vous éloigner du danger, votre barre de stress diminuera.");
        listeInfos.Add("Faites attention à ce que vous mangez, la nourriture laissée par l'homme peut vous rendre malade en vous empoisonnant !");
        tmpText.SetText((string)listeInfos[page]);
        image.sprite = sprites[page];
    }

    public void onClickRight(string text)
    {
        if (page < listeInfos.Count - 1)
        {
            page++;
            tmpText.SetText((string)listeInfos[page]);
            if (page < 7)
            {
                image.sprite = sprites[page];
                image.enabled = true;
            }
            else
            {
                image.enabled=false;
            }
        }
    }

    public void onClickLeft(string text)
    {
        if (page > 0)
        {
            page--;
            tmpText.SetText((string)listeInfos[page]);
            if (page < 7)
            {
                image.sprite = sprites[page];
                image.enabled = true;
            }
            else
            {
                image.enabled=false;
            }
        }
    }

    public void ActionDyn()
    {
        listeInfos.Add("Vous avez mangé de la nourriture avariée, votre vie est en train de baisser");
    }
}