using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Experience : JaugesController
{

    public Image image;

    public int expActuelle;
    public int expMax;

    public int palierExp;
    public int niveau = 1;

    public float WaitTimerExp = 3f;
    //private float timerIncrease = 0f;

    public TextMeshProUGUI niveauText;

    public GameObject fogMainCircle1;
    public GameObject fogMainCircle2;

    public Vector3 augmentScale;
    static Boolean activateOnce = false;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        StartCoroutine(ajoutExp());
    }

    // Update is called once per frame
    new void Update()
    {
        base.Start();

        if(expActuelle > expMax)
        {
            niveau += 1;
            expActuelle -= expMax;
            expMax += 50;
            fogMainCircle1.transform.localScale += augmentScale;
            fogMainCircle2.transform.localScale += augmentScale;
            addToEncy();
        }

        niveauText.SetText("Niveau : {}", niveau);
        base.setImage(image, expActuelle, expMax);
    }

    public void setExperience(int e)
    {
        if (expActuelle + e > expMax)
            expActuelle = expMax;
        else
            expActuelle += e;

        base.setImage(image, expActuelle, expMax);
    }

    public void addExperience(int nb)
    {
        expActuelle += nb;
    }

    IEnumerator ajoutExp()
    {
        while (true)
        {
            //GOPointer.Jauges.GetComponent<Experience>().addExperience(GOPointer.Jauges.GetComponent<Experience>().palierExp);
            addExperience(palierExp);
            yield return new WaitForSeconds(WaitTimerExp);
        }
    }

    public static void addToEncy()
    {
        if (!activateOnce)
        {
            EncycloContentChamois ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
            ency.addInfoToList("gainNiveau", ency.pagesDynamic);
            activateOnce = true;
        }
    }
}
