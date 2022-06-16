using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EncycloContentRandonneur : Encyclopedie
{
    new void Start()
    {
        base.Start();
    }

    public void addInfoToList(string action, List<ContenuPages> liste)
    {
        base.addInfoToList(action, liste, dynamicInfo);
        if (Global.Personnage == "Randonneur")
        {
            GOPointer.GameControl.GetComponent<Notifier>().setTrue();
        }
        else
        {
            GOPointer.GameControl.GetComponent<Notifier>().setFalse();
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
}
