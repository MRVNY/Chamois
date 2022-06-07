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

        Debug.Log("Sauvegarde réussie!");
    }

    /// <summary>
    /// Cherche le fichier <param name="key"> clé </param> pour charcher un élément <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"> T qui peux être n'importe quel type de variable</typeparam>
    public static T Load<T>(string key)
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
}
