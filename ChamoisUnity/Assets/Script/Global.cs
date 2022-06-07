using System.Collections.Generic;

public static class Global
{

    private static string personnageJoue;
    public static Dictionary<string, string> guide = new Dictionary<string, string>();


    static Global()
    {
        personnageJoue = "Chamois";
        guide.Add("Chasseur", "En tant que chasseur, votre objectif principal est d'aider à la régulation des espèces. N'hésitez pas à converser avec tous les perosnnages afin d'obtenir des informations ou d'obtenir des quêtes de chasse.");
        guide.Add("Chamois", "En tant que chamois, votre objectif principal est de survivre le plus longtemps possible. " +
                   // "Pour ce faire, faites en sorte que votre barre de santé (barre rouge en haut à gauche) ne tombe pas à 0. 
                   "Vous découvrirez un second but en cours de jeu" +
                   //est de faire en sorte de faire durer votre espèce, " +
                   //essayez de faire naître un petit, pour cela, faites attention a votre alimentation, elle doit être assez haute pour pouvoir se reproduire 
                   "!");
        guide.Add("Randonneur", "En tant que randonneur, votre objectif principal est de découvrir l'environnement qui vous entoure. Vous pouvez aussi rechercher des randonnées que vous pouvez effectuer afin de vous donner du challenge dans votre aventure... Cependant, essayez de découvrir en étant le moins néfaste possible pour votre environnement, afin d'effectuer la meilleure performance possible en tant que randonneur.");


    }


    public static string Personnage
    {
        set
        {
            personnageJoue = value;
        }

        get
        {
            return personnageJoue;
        }
    }

}
