using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EncycloInfos
{
    private string image;
    private string text = "nan";

    private int poids;

    public EncycloInfos(string path, string text, int poids)
    {
        if (!string.IsNullOrEmpty(path))
        {
            image = path;  
        } 

        this.text = text;

        this.poids = poids;
    }

    public string getImage()
    {
        return image;
    }

    public string getText()
    {
        return text;
    }

    public int getPoid()
    {
        return poids;
    }
}
