using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EncycloContentRandonneur : Encyclopedie
{
    private static Dictionary<string, EncycloInfos> dynamicInfo
        = new Dictionary<string, EncycloInfos>();

    private List<EncycloInfos> staticInfo
        = new List<EncycloInfos>();

    public List<ContenuPages> quete
        = new List<ContenuPages>();

    public List<ContenuPages> pagesDynamic = new List<ContenuPages>();

    private string chapitre;

    public TextAsset jsonFile;
    public ArrayList data = new ArrayList();
    public EncyInfo info;

    new void Start()
    {
        enabled = false;
    }

    public void addInfoToList(string action, List<ContenuPages> liste)
    {
        base.addInfoToList(action, liste, dynamicInfo);
        if (Global.Personnage == "Randonneur")
        {
            GameObject.Find("GameControl").GetComponent<GameControlScript>().setTrue();
        }
        else
        {
            GameObject.Find("GameControl").GetComponent<GameControlScript>().setFalse();
        }
    }

    public void initList()
    {
        dynamicInfo = new Dictionary<string, EncycloInfos>();
        staticInfo = new List<EncycloInfos>();
        pagesDynamic = new List<ContenuPages>();
        quete = new List<ContenuPages>();

        // Récupération des données dans le JSON, lié dans le GameObject "Encyclopédie Manager"
        EncyInfoList infosInJson = JsonUtility.FromJson<EncyInfoList>(jsonFile.text);

        foreach (EncyInfo encyinfo in infosInJson.encyinfos)
        {
            dynamicInfo.Add(encyinfo.hint, new EncycloInfos(null, encyinfo.texte, int.Parse(encyinfo.taille)));

            data.Add(encyinfo);
        }


        dynamicInfo.Add("hautFait", new EncycloInfos(null, "Vous venez de gagner un haut-fait. Les haut-faits sont des objectifs secondaires de jeu vous aidant à découvrir tous les aspects du jeu. Les haut-faits vous octroient des points, composant votre score de découverte du jeu.", 6));

        staticInfo.Add(new EncycloInfos(null, "En tant que randonneur, votre objectif principal est de découvrir l'environnement qui vous entoure. Vous pouvez aussi rechercher des randonnées que vous pouvez effectuer afin de vous donner du challenge dans votre aventure...", 6));
        staticInfo.Add(new EncycloInfos(null, "Cependant, essayez de découvrir en étant le moins néfaste possible pour votre environnement, afin d'effectuer la meilleure performance possible en tant que randonneur.", 6));


        base.Start();
        setPageStatic(staticInfo);
    }

    public void onClickGauche()
    {
        switch (chapitre)
        {
            case "statique":
                if (pagesStatic.Count > 0)
                    base.onClickGauche(pagesStatic);
                break;

            case "dynamique":
                if (pagesDynamic.Count > 0)
                    base.onClickGauche(pagesDynamic);
                break;

            case "quete":
                if (quete.Count > 0)
                    base.onClickGauche(quete);
                break;
        }
    }

    public void onClickDroite()
    {
        switch (chapitre)
        {
            case "statique":
                if (pagesStatic.Count > 0)
                    base.onClickDroite(pagesStatic);
                break;

            case "dynamique":
                if (pagesDynamic.Count > 0)
                    base.onClickDroite(pagesDynamic);
                break;

            case "quete":
                if (quete.Count > 0)
                    base.onClickDroite(quete);
                break;
        }
    }


    public void onChapterSelected(string chapitre)
    {
        this.chapitre = chapitre;
        switch (chapitre)
        {
            case "statique":
                if (pagesStatic.Count > 0)
                    base.onChapterSelected(pagesStatic);
                break;

            case "dynamique":
                if (pagesDynamic.Count > 0)
                    base.onChapterSelected(pagesDynamic);
                break;

            case "quete":
                if (quete.Count > 0)
                    base.onChapterSelected(quete);
                break;
        }

    }
}
