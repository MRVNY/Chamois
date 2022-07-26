using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNight : MonoBehaviour
{

    // public GameObject sun;
    // public SpriteRenderer sr;

    public TextMeshProUGUI dateText;
    public DateTime currentDate;
    public DateTime goalDate = new DateTime(2022,5,1);
    private CultureInfo french;

    public static DayNight Instance;

    //private Color sra;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        french = new CultureInfo("fr-FR");
        currentDate = new DateTime(2021, 12, 1);
    }

    void Update()
    {
        if (!Global.pause)
        {
            currentDate = currentDate.Add(TimeSpan.FromMinutes(10));
            dateText.SetText(currentDate.ToString("dd MMMM yyyy", french));
            if (goalDate != null && currentDate == goalDate)
            {
                QuestManager.Instance.endQuest();
            }
        }
    }

    // IEnumerator changerDate()
    // {
    //     while (FinPartie.Instance.fin == false)
    //     {
    //         yield return new WaitForSeconds(3.0f);
    //         jour++;
    //         nbJours++;
    //         if(Global.Personnage == "Chamois" && FinPartie.Instance.fin == false)
    //         {
    //             //GOPointer.Jauges.GetComponent<Experience>().addExperience(GOPointer.Jauges.GetComponent<Experience>().palierExp);
    //         }
    //     }
    // }

    // IEnumerator Sunset()
    // {
    //     while (sra.a > 0.0f)
    //     {
    //         if (sra.a < 0.1f)
    //         {
    //             sra.a -= 0.00005f;
    //             sr.color = sra;
    //             yield return new WaitForSeconds(0.01f);
    //         }
    //         else
    //         {
    //             sra.a -= 0.001f;
    //             sr.color = sra;
    //             yield return new WaitForSeconds(0.01f);
    //         }
    //
    //     }
    //     StartCoroutine(Sunrise());
    //     StopCoroutine(Sunset());
    // }
    //
    // IEnumerator Sunrise()
    // {
    //
    //     while (sra.a < 0.6f)
    //     {
    //         if (sra.a % 0.2f == 0)
    //         {
    //             jour += 1;
    //             nbJours += 1;
    //         }
    //         sra.a += 0.001f;
    //         sr.color = sra;
    //         yield return new WaitForSeconds(0.01f);
    //     }
    //     StartCoroutine(Sunset());
    //     StopCoroutine(Sunrise());
    // }
}