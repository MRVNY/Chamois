using System.Collections.Generic;
using UnityEngine;

public static class Global
{

    private static string personnageJoue;
    public static Dictionary<string, string> guide = new Dictionary<string, string>(){
        {"Chasseur", "En tant que chasseur, votre objectif principal est d'aider à la régulation des espèces. N'hésitez pas à converser avec tous les perosnnages afin d'obtenir des informations ou d'obtenir des quêtes de chasse."},
        {"Chamois", "En tant que chamois, votre objectif principal est de survivre le plus longtemps possible. " +
                   // "Pour ce faire, faites en sorte que votre barre de santé (barre rouge en haut à gauche) ne tombe pas à 0. 
                   "Vous découvrirez un second but en cours de jeu" +
                   //est de faire en sorte de faire durer votre espèce, " +
                   //essayez de faire naître un petit, pour cela, faites attention a votre alimentation, elle doit être assez haute pour pouvoir se reproduire 
                   "!"},
        {"Randonneur", "En tant que randonneur, votre objectif principal est de découvrir l'environnement qui vous entoure. Vous pouvez aussi rechercher des randonnées que vous pouvez effectuer afin de vous donner du challenge dans votre aventure... Cependant, essayez de découvrir en étant le moins néfaste possible pour votre environnement, afin d'effectuer la meilleure performance possible en tant que randonneur."}

    };
    //public static Dictionary<string, GameObject> encychapter = new Dictionary<string, GameObject>();
    public static Dictionary<string, string> persoNum = new Dictionary<string, string>(){
        {"Chamois", "1"},
        {"Chasseur", "3"},
        {"Randonneur", "2"}
    };
    public static Dictionary<string, int> randoNum = new Dictionary<string, int>(){
        {"Epion", 1},
        {"Batterie", 2},
        {"DentPortes", 3},
        {"GrandRoc", 4},
        {"PointeChaurionde", 5},
        {"Morbier", 6},
        {"Nivolet", 7},
        {"Galoppaz", 8},
        {"Colombier", 9},
        {"Arcalod", 10},
        {"Trelod", 11}
    };
    public static bool sliding = false;
    public static int difficulty = 1;
    public static bool pause = false;


    static Global()
    {
        personnageJoue = "Chasseur";
        // encychapter.Add("Chamois", (GOPointer.ChapitreChamois));
        // encychapter.Add("Chasseur", (GOPointer.ChapitreChasseur));
        // encychapter.Add("Randonneur", (GOPointer.ChapitreRandonneur));

    }


    public static string Personnage
    {
        set => personnageJoue = value;
        get => personnageJoue;
    }

}
