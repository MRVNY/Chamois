using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

public static class SaveLoad
{
    private static string savePath;
    
    static SaveLoad()
    {
        savePath = Application.persistentDataPath;
    }
    
    /// <summary>
    /// Fonction qui récupère un objet pour le sauvegarder dans un fichier clé
    /// </summary>
    public static void Save<T>(T objectToSave, string key)
    {
        // chemin du fichier de sauvegarde
        string path = savePath + "/saves/";

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
            string path = savePath + "/saves/";
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
        string path = savePath + "/saves/" + key + ".txt";
        return File.Exists(path);
    }

    /// <summary>
    /// Supprime tous les fichiers de sauvegardes
    /// </summary>
    public static void DeleteAllSaveFiles()
    {
        string path = savePath + "/saves/";
        DirectoryInfo dir = new DirectoryInfo(path);
        dir.Delete(true);
        Directory.CreateDirectory(path); 
    }

    public async static Task SaveState()
    {
        //pos
        var vect = Joueur.currentPlayer.transform.position;
        float pos1 = vect.x;
        float pos2 = vect.y;

        Save<float>(pos1, "pos1"+Global.Personnage);
        Save<float>(pos2, "pos2"+Global.Personnage);

        PlayerPrefs.SetInt(Global.Personnage,1);
        
        //fog
        if (Global.Personnage == "Randonneur")
        {
            RenderTexture rtShow = FogOfWar.Instance.rawShow.texture as RenderTexture;
            RenderTexture rtCount = FogOfWar.Instance.rawCount.texture as RenderTexture;

            Texture2D t2Show = toTexture2D(rtShow);
            Texture2D t2Count = toTexture2D(rtCount);

            byte[] bytesShow = t2Show.EncodeToPNG();
            byte[] bytesCount = t2Count.EncodeToPNG();

            Save<byte[]>(bytesShow, "FogShow");
            Save<byte[]>(bytesCount, "FogCount");
        }

        //NPC convo
        foreach (var npc in NPCManager.Instance.currentNPCList)
        {
            Save<string>(npc.firstNode, npc.name);
        }

        foreach (var npc in NPCManager.Instance.listDonneurs)
        {
            Save<string>(npc.firstNode, npc.name);
        }
        
        //ency
        Save<List<ContenuPages>>(GOPointer.currentEncy.pagesDynamic, "ency"+Global.Personnage);
        
        
    }

    public static async Task LoadState()
    {
        if (Menu.saving != null)
        {
            await Menu.saving;
        }
        
        // DateTime start = DateTime.Now;
        
        // LoadJob loadJob = new LoadJob();
        // loadJob.Schedule().Complete();
        
        //pos
        float pos1 = Load<float>("pos1"+Global.Personnage);
        float pos2 = Load<float>("pos2"+Global.Personnage);
        if(pos1!=0 && pos2!=0) Joueur.currentPlayer.transform.position = new Vector3(pos1, pos2, 0);
        
        //Debug.Log("Load pos: " + (DateTime.Now - start));
        // start = DateTime.Now;
        
        //fog
        if (Global.Personnage == "Randonneur")
        {
            Texture
                tShow = FogOfWar.Instance.rawShow
                    .texture; //GOPointer.FogOfWarCanvas.transform.Find("RawShow").GetComponent<RawImage>().texture;
            Texture
                tCount = FogOfWar.Instance.rawCount
                    .texture; //GOPointer.FogOfWarCanvas.transform.Find("RawCount").GetComponent<RawImage>().texture;

            byte[] bytesShow = Load<byte[]>("FogShow");
            byte[] bytesCount = Load<byte[]>("FogCount");

            //Debug.Log("Load bytes: " + (DateTime.Now - start));
            // start = DateTime.Now;

            if (bytesShow != null && bytesCount != null && tShow != null && tCount != null)
            {
                Texture2D t2Show = new Texture2D(tShow.width, tShow.height, TextureFormat.RGBA4444, false);
                Texture2D t2Count = new Texture2D(tCount.width, tCount.height, TextureFormat.RGBA4444, false);

                t2Show.LoadImage(bytesShow);
                t2Count.LoadImage(bytesCount);

                //Debug.Log("Load image: " + (DateTime.Now - start));
                // start = DateTime.Now;

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

            //Debug.Log("t2 to rt: " + (DateTime.Now - start));
            // start = DateTime.Now;

            FogOfWar.Instance.calculateAll();

            //Debug.Log("calculate: " + (DateTime.Now - start));
            // start = DateTime.Now;
        }

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
        
        //Debug.Log("Load convo: " + (DateTime.Now - start));
        // start = DateTime.Now;
        
        //ency 
        var tmpEncy = Load<List<ContenuPages>>("ency"+Global.Personnage);
        if (tmpEncy != null)
        {
            GOPointer.currentEncy.pagesDynamic = tmpEncy;
        }
        
        //Debug.Log("Load ency: " + (DateTime.Now - start));
    }

    static Texture2D toTexture2D(RenderTexture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA4444, false);
        RenderTexture.active = texture;

        texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
        texture2D.Apply();

        return texture2D;
    }


    private struct LoadJob : IJob
    {
        public async void Execute()
        {
        }
    }
}
