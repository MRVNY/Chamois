using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TexturePercentage : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RenderTexture rdTex;
    private int prc;

    public GameObject area;
    private Dictionary<RectTransform,int> rectsPrc = new Dictionary<RectTransform, int>();

    private void Awake()
    {
        RectTransform[] rects = area.GetComponentsInChildren<RectTransform>();
        foreach (var rect in rects)
        {
            rectsPrc.Add(rect,0);
        }
    }

    Texture2D createTex(RectTransform rt)
    {
        
        Vector2 pos = rt.position;
        
        Texture2D tex = new Texture2D(rdTex.width/6, rdTex.height/6, TextureFormat.RGB24, false);
        //Texture2D tex = new Texture2D(rdTex.width, rdTex.height, TextureFormat.RGB24, false);
        
        RenderTexture.active = rdTex;
        
        tex.ReadPixels(new Rect(pos.x*rdTex.width/600,(600+pos.y-100)*rdTex.height/600,rdTex.width/6,rdTex.height/6), 0, 0);
        //tex.ReadPixels(new Rect(0,0,rdTex.width,rdTex.height), 0, 0);
        
        tex.Apply();
        return tex;
    }

    IEnumerator percentage(RectTransform rt)
    {

        Texture2D tex = createTex(rt);
        int ttalPixels = 0;
        int transparentPixels = 0;

        for (int x = 0; x < tex.width; x++)
        {
            //yield return new WaitForSeconds(0.01f);
            for (int y = 0; y < tex.height; y++)
            {
                if (tex.GetPixel(x, y).r == 1) //&& tex.GetPixel(x, y).g == 0 && tex.GetPixel(x, y).b == 0)
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
        
        yield return new WaitForSeconds(0.01f);

        rectsPrc[rt] = (int)(transparentPixels * 100 / ttalPixels);

        prc = rectsPrc.Values.Sum() / rectsPrc.Count;
        text.SetText("Découverte de la carte : {0}%", prc);

        //yield return new WaitForSecondsRealtime(1f);
    }

    public void rafraichir(RectTransform rt)
    {
        StartCoroutine(percentage(rt));
    }
}
