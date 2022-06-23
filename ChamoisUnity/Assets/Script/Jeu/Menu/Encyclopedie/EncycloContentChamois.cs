 using UnityEngine;
 using System.Collections.Generic;
 using System;
using System.Collections;

public class EncycloContentChamois : Encyclopedie
{
    new void Start()
    {
        base.Start();
    }

    public void addInfoToList(string action, List<ContenuPages> liste) 
    {
        base.addInfoToList(action, liste, dynamicInfo);
        if (Global.Personnage == "Chamois")
        {
            notifier.setTrue();
        }
        else
        {
            notifier.setFalse();
        }
    }

    public void initList()
    {
        dynamicInfo = new Dictionary<string, EncycloInfos>();
        staticInfo = new List<EncycloInfos>();

        pagesDynamic = new List<ContenuPages>();

        //string path = "Image/IMGEncy/Chamois/";


        dynamicInfo.Add("mange", new EncycloInfos(null, "Afin de survivre, vous devez vous nourrir, cette action fera remonter votre jauge d'alimentation et vous maintiendra en vie. Cependant, chaque plante n'a pas les mêmes propriétés, et peuvent même être dangereuses.",5));
        dynamicInfo.Add("cours", new EncycloInfos("","Courir c'est cool pour avancer", 5));
        dynamicInfo.Add("touche", new EncycloInfos(null,"Toucher des truc c'est dangereux", 1));
        dynamicInfo.Add("attaque", new EncycloInfos(null, "Vous pouvez être une proie pour certains membres de la faune locale. Ces derniers peuvent alors vous blesser, vous infligeant des dégâts aléatoires. Essayez de les éviter afin d'éviter de perdre la partie.", 6));
        dynamicInfo.Add("danger", new EncycloInfos(null, "Si vous vous rapprochez d'un danger, comme par exemple d'un prédateur, vous ressentirez de plus en plus de stress, que vous pouvez observer dans la jauge bleue en haut à gauche, quand elle devient rouge, votre stress est critique.", 6));
        dynamicInfo.Add("informations", new EncycloInfos(null, "Restez attentifs à ce qui vous entoure : certains personnages pourraient vous apprendre des choses intéressantes, il vous serait donc conseillé de converser avec ces derniers.", 6));
        dynamicInfo.Add("fatigue", new EncycloInfos(null, "Après avoir été blessé par un prédateur, vous fuierez plus vite grâce à un boost d'adrénaline, vous permettant d'avoir des chances de survivre, mais vous serez ensuite fatigué, ce qui consommera votre jauge de faim .", 6));
        dynamicInfo.Add("gainNiveau", new EncycloInfos(null, "Vous venez de gagner un niveau, au fur et à mesure que vous survivez, votre expérience augmente et gagner un niveau rendra votre chamois plus vigilant, augmentant ses qualités d'observation.", 6));
        dynamicInfo.Add("hautFait", new EncycloInfos(null, "Vous venez de gagner un haut-fait. Les haut-faits sont des objectifs secondaires de jeu vous aidant à découvrir tous les aspects du jeu. Les haut-faits vous octroient des points, composant votre score de découverte du jeu.", 6));
        // dévaler les flancs de montagne


        // Récupération des données dans le JSON, lié dans le GameObject "Encyclopédie Manager"
        EncyInfoList infosInJson = JsonUtility.FromJson<EncyInfoList>(jsonFile.text);

        foreach (EncyInfo encyinfo in infosInJson.encyinfos)
        {
            dynamicInfo.Add(encyinfo.hint, new EncycloInfos(null, encyinfo.texte, int.Parse(encyinfo.taille)));

            //data.Add(encyinfo);
        }


        staticInfo.Add(new EncycloInfos(null, "En tant que chamois, votre objectif principal est de survivre le plus longtemps possible. Pour ce faire, faites en sorte que votre barre de santé (barre rouge en haut à gauche) ne tombe pas à 0.", 6));
        staticInfo.Add(new EncycloInfos(null, "Votre second but, est de faire en sorte de faire durer votre espèce, essayez de faire naître un petit, pour cela, faites attention a votre alimentation, elle doit être assez haute pour pouvoir se reproduire !", 6));



        base.Start();
        setPageStatic(staticInfo);
    }
    
}
