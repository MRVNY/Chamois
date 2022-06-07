using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNight : MonoBehaviour
{

    public GameObject sun;
    public SpriteRenderer sr;

    public int jour;
    public string mois;
    public int nbJours;
    public int nbAnnees;

    public TextMeshProUGUI jourText;
    public TextMeshProUGUI moisText;
    public TextMeshProUGUI anneeText;

    public bool finPartie = false;

    private Color sra;
    private GameObject PanelFinPartie;

    // Start is called before the first frame update
    void Start()
    {


        sr = sun.GetComponent<SpriteRenderer>();

        jourText.SetText("1");
        moisText.SetText("Janvier");
        anneeText.SetText("2021");

        sra = sr.color;
        StartCoroutine(Sunset());
        StartCoroutine(changerDate());
    }

    void Update()
    {
        changeMois();
        changeAnnee();
        jourText.SetText("{}", jour);
        moisText.SetText(mois);
        anneeText.SetText("{}", nbAnnees);

        /*if (GameObject.Find("GameManager").GetComponent<FinPartie>().fin  == true && finPartie == false)
        {
            Debug.Log("C'est la fin");
            StopCoroutine(changerDate());
            finPartie = true;
        }*/
    }

    IEnumerator changerDate()
    {
        while (GameObject.Find("GameManager").GetComponent<FinPartie>().fin == false)
        {
            yield return new WaitForSeconds(3.0f);
            jour++;
            nbJours++;
            if(Global.Personnage == "Chamois" && GameObject.Find("GameManager").GetComponent<FinPartie>().fin == false)
            {
                //GameObject.Find("Jauges").GetComponent<Experience>().addExperience(GameObject.Find("Jauges").GetComponent<Experience>().palierExp);
            }
        }
    }

    IEnumerator Sunset()
    {
        while (sra.a > 0.0f)
        {
            if (sra.a < 0.1f)
            {
                sra.a -= 0.00005f;
                sr.color = sra;
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                sra.a -= 0.001f;
                sr.color = sra;
                yield return new WaitForSeconds(0.01f);
            }

        }
        StartCoroutine(Sunrise());
        StopCoroutine(Sunset());
    }

    IEnumerator Sunrise()
    {

        while (sra.a < 0.6f)
        {
            if (sra.a % 0.2f == 0)
            {
                jour += 1;
                nbJours += 1;
            }
            sra.a += 0.001f;
            sr.color = sra;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(Sunset());
        StopCoroutine(Sunrise());
    }

    // a décommenter pour que ce soit plus rapide 
    /*IEnumerator Sunset()
    {
        while (sra.a > 0.0f)
        {
            sra.a -= 0.03f;
            sr.color = sra;
            yield return new WaitForSeconds(0.0001f);
        }
        StartCoroutine(Sunrise());
        StopCoroutine(Sunset());
        jour += 1;
        nbJours += 1;
    }

    IEnumerator Sunrise()
    {
        while (sra.a < 0.6f)
        {
            sra.a += 0.03f;
            sr.color = sra;
            yield return new WaitForSeconds(0.0001f);
        }
        StartCoroutine(Sunset());
        StopCoroutine(Sunrise());
        jour += 1;
        nbJours += 1;
    }*/

    void changeAnnee()
    {
        if (nbJours > 366)
        {
            nbJours -= 365;
            nbAnnees += 1;
        }
    }


    void changeMois()
    {
        if (mois == "Janvier" && jour > 31)
        {
            mois = "Fevrier";
            jour -= 31;
        }
        if (mois == "Fevrier" && jour > 28)
        {
            mois = "Mars";
            jour -= 28;
        }
        if (mois == "Mars" && jour > 31)
        {
            mois = "Avril";
            jour -= 31;
        }
        if (mois == "Avril" && jour > 30)
        {
            mois = "Mai";
            jour -= 30;
        }
        if (mois == "Mai" && jour > 31)
        {
            mois = "Juin";
            jour -= 31;
        }
        if (mois == "Juin" && jour > 30)
        {
            mois = "Juillet";
            jour -= 30;
        }
        if (mois == "Juillet" && jour > 31)
        {
            mois = "Aout";
            jour -= 31;
        }
        if (mois == "Aout" && jour > 31)
        {
            mois = "Septembre";
            jour -= 31;
        }
        if (mois == "Septembre" && jour > 30)
        {
            mois = "Octobre";
            jour -= 30;
        }
        if (mois == "Octobre" && jour > 31)
        {
            mois = "Novembre";
            jour -= 31;
        }
        if (mois == "Novembre" && jour > 30)
        {
            mois = "Decembre";
            jour -= 30;
        }
        if (mois == "Decembre" && jour > 31)
        {
            mois = "Janvier";
            jour -= 31;
        }
    }

}