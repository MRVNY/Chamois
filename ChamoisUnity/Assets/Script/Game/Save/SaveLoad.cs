using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using RPGM.Gameplay;
using UnityEditor;
using UnityEngine.UI;

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

    public async static Task SaveState()
    {
        //pos
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
        
        //fog
        RenderTexture rtShow = FogOfWar.Instance.rawShow.texture as RenderTexture;
        RenderTexture rtCount = FogOfWar.Instance.rawCount.texture as RenderTexture;
        
        Texture2D t2Show = toTexture2D(rtShow);
        Texture2D t2Count = toTexture2D(rtCount);
        
        byte[] bytesShow = t2Show.EncodeToPNG();
        byte[] bytesCount = t2Count.EncodeToPNG();
        
        Save<byte[]>(bytesShow, "FogShow");
        Save<byte[]>(bytesCount, "FogCount");

        //NPC convo
        foreach (var npc in NPCManager.Instance.currentNPCList)
        {
            Save<string>(npc.firstNode, npc.name);
        }

        foreach (var npc in NPCManager.Instance.listDonneurs)
        {
            Save<string>(npc.firstNode, npc.name);
        }
    }

    public static async Task LoadState()
    {
        if (PauseMenu.saving != null)
        {
            await PauseMenu.saving;
        }
        
        //pos
        List<float> posChamois = Load<List<float>>("posChamois");
        List<float> posChasseur = Load<List<float>>("posChasseur");
        List<float> posRandonneur = Load<List<float>>("posRandonneur");
        
        if(posChamois!=null) GOPointer.PlayerChamois.transform.position = new Vector3(posChamois[0], posChamois[1], 0);
        if(posChasseur!=null) GOPointer.PlayerChasseur.transform.position = new Vector3(posChasseur[0], posChasseur[1], 0);
        if(posRandonneur!=null) GOPointer.PlayerRandonneur.transform.position = new Vector3(posRandonneur[0], posRandonneur[1], 0);
        
        //fog
        Texture tShow = FogOfWar.Instance.rawShow.texture; //GOPointer.FogOfWarCanvas.transform.Find("RawShow").GetComponent<RawImage>().texture;
        Texture tCount = FogOfWar.Instance.rawCount.texture; //GOPointer.FogOfWarCanvas.transform.Find("RawCount").GetComponent<RawImage>().texture;
        
        byte[] bytesShow = Load<byte[]>("FogShow");
        byte[] bytesCount = Load<byte[]>("FogCount");
        
        if (bytesShow!=null && bytesCount!=null && tShow!=null && tCount!=null)
        {
            Texture2D t2Show = new Texture2D(tShow.width, tShow.height, TextureFormat.RGBA4444, false);
            Texture2D t2Count = new Texture2D(tCount.width, tCount.height, TextureFormat.RGBA4444, false);

            t2Show.LoadImage(bytesShow);
            t2Count.LoadImage(bytesCount);
            
            RenderTexture rtShow = new RenderTexture(t2Show.width, t2Show.height, 0);
            RenderTexture rtCount = new RenderTexture(t2Count.width, t2Count.height, 0);
            
            RenderTexture.active = rtShow;
            Graphics.Blit(t2Show, rtShow);
            FogOfWar.Instance.rawShow.texture = rtShow;
            FogOfWar.Instance.camShow.targetTexture = rtShow;
            
            RenderTexture.active = rtCount;
            Graphics.Blit(t2Count, rtCount);
            FogOfWar.Instance.rawCount.texture = rtCount;
            FogOfWar.Instance.camCount.targetTexture = rtCount;
        }

        FogOfWar.Instance.calculateAll();
        
        //NPC convo
        if(Init.convo!=null) await Init.convo;
        
        foreach (var npc in NPCManager.Instance.currentNPCList)
        {
            string tmp = Load<string>(npc.name);
            if (tmp != null)
            {
                npc.firstNode = tmp;
            }
        }

        foreach (var npc in NPCManager.Instance.listDonneurs)
        {
            string tmp = Load<string>(npc.name);
            if (tmp != null)
            {
                npc.firstNode = tmp;
            }
        }
    }

    static Texture2D toTexture2D(RenderTexture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA4444, false);
        RenderTexture.active = texture;

        texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2D.Apply();

        return texture2D;
    }
}
