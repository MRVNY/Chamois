using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TexturePercentage : MonoBehaviour
{
    public RenderTexture rdTex;
    public int prc;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Global.Personnage == "Chamois")
            {
                percentage(createTex(rdTex));
                GameObject.Find("TextDiscoveryChamois").GetComponent<TextMeshProUGUI>().SetText("Découverte de la carte : {0}%", prc);

            }
            else if (Global.Personnage == "Randonneur")
            {
                percentage(createTex(rdTex));
                GameObject.Find("TextDiscoveryRandonneur").GetComponent<TextMeshProUGUI>().SetText("Découverte de la carte : {0}%", prc);
            }
        }
    }

    Texture2D createTex(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    void percentage(Texture2D tex)
    {
        int ttalPixels = 0;
        int transparentPixels = 0;

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                if (tex.GetPixel(x, y).r == 1 && tex.GetPixel(x, y).g == 0 && tex.GetPixel(x, y).b == 0)
                {
                    ttalPixels += 1;
                    transparentPixels += 1;
                }
                else
                {
                    ttalPixels += 1;
                }
            }
        }
        prc = (int)(transparentPixels * 100 / ttalPixels);
    }

    public void rafraichir()
    {
        if (Global.Personnage == "Chamois")
        {
            percentage(createTex(rdTex));
            GameObject.Find("TextDiscoveryChamois").GetComponent<TextMeshProUGUI>().SetText("Découverte de la carte : {0}%", prc);

        }
        else if (Global.Personnage == "Randonneur")
        {
            percentage(createTex(rdTex));
            GameObject.Find("TextDiscoveryRandonneur").GetComponent<TextMeshProUGUI>().SetText("Découverte de la carte : {0}%", prc);
        }
    }
}
