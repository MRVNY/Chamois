using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    /// <summary>
    /// Fonction qui récupère un objet pour le sauvegarder dans un fichier clé
    /// </summary>
    public static void Save<T>(T objectToSave, string key)
    {
        // chemin du fichier de sauvegarde
        string path = Application.persistentDataPath + "/saves/";

        //création du fichier si il n'existe pas
        Directory.CreateDirectory(path);
        
        // convertion des paramètres de sauvegarde en fichier binaires
        BinaryFormatter formatter = new BinaryFormatter();

        using(FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Create))
        {
            formatter.Serialize(fileStream, objectToSave);
        }

        //Debug.Log("Sauvegarde réussie!");
    }

    /// <summary>
    /// Cherche le fichier <param name="key"> clé </param> pour charcher un élément <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"> T qui peux être n'importe quel type de variable</typeparam>
    public static T Load<T>(string key)
    {
        if (SaveExists(key))
        {
            string path = Application.persistentDataPath + "/saves/";
            BinaryFormatter formatter = new BinaryFormatter();
            T returnValue = default(T);
            using (FileStream fileStream = new FileStream(path + key + ".txt", FileMode.Open))
            {
                returnValue = (T)formatter.Deserialize(fileStream);
            }

            return returnValue;
        }
        else return default(T);
    }

    /// <summary>
    /// Vérifie si un fichier de sauvegarde clé existe
    /// </summary>
    public static bool SaveExists(string key)
    {
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        return File.Exists(path);
    }

    /// <summary>
    /// Supprime tous les fichiers de sauvegardes
    /// </summary>
    public static void DeleteAllSaveFiles()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo dir = new DirectoryInfo(path);
        dir.Delete(true);
        Directory.CreateDirectory(path); 
    }

    public static void SaveState()
    {
        List<float> posChamois = new List<float>();
        List<float> posChasseur = new List<float>();
        List<float> posRandonneur = new List<float>();

        var position1 = GOPointer.PlayerChamois.transform.position;
        posChamois.Add(position1.x);
        posChamois.Add(position1.y);

        var position = GOPointer.PlayerChasseur.transform.position;
        posChasseur.Add(position.x);
        posChasseur.Add(position.y);

        var position2 = GOPointer.PlayerRandonneur.transform.position;
        posRandonneur.Add(position2.x);
        posRandonneur.Add(position2.y);
        
        Save<List<float>>(posChamois, "posChamois");
        Save<List<float>>(posChasseur, "posChasseur");
        Save<List<float>>(posRandonneur, "posRandonneur");
        
        PlayerPrefs.SetInt(Global.Personnage,1);
    }

    public static void LoadState()
    {
        List<float> posChamois = Load<List<float>>("posChamois");
        List<float> posChasseur = Load<List<float>>("posChasseur");
        List<float> posRandonneur = Load<List<float>>("posRandonneur");
        
        if(posChamois!=null) GOPointer.PlayerChamois.transform.position = new Vector3(posChamois[0], posChamois[1], 0);
        if(posChasseur!=null) GOPointer.PlayerChasseur.transform.position = new Vector3(posChasseur[0], posChasseur[1], 0);
        if(posRandonneur!=null) GOPointer.PlayerRandonneur.transform.position = new Vector3(posRandonneur[0], posRandonneur[1], 0);
    }
}
