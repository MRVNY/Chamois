using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FogOfWar : MonoBehaviour
{
    //public AssetReference asset;
    public TextMeshProUGUI text;
    
    public RawImage rawShow;
    public RawImage rawCount;

    public Camera camShow;
    public Camera camCount;
    
    private int prc;

    public GameObject area;
    public Dictionary<RectTransform,int> rectsPrc = new Dictionary<RectTransform, int>();

    public static FogOfWar Instance;
    
    private RectTransform[] rects;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
        rects = area.GetComponentsInChildren<RectTransform>();
        foreach (var rect in rects)
        {
            rectsPrc.Add(rect,0);
        }
        
        rawShow.enabled = true;
        rawCount.enabled = true;
        
        foreach (var sprite in GOPointer.PlayerRandonneur.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = true;
        }

        calculateAll();
    }

    public Texture2D createTex(RectTransform rt)
    {
        
        Vector2 pos = rt.position;
        
        Texture2D tex = new Texture2D(rawCount.texture.width/6, rawCount.texture.height/6, TextureFormat.RGBA4444, false);
        
        RenderTexture.active = rawCount.texture as RenderTexture;
        
        tex.ReadPixels(new Rect(pos.x*rawCount.texture.width/600,(600+pos.y-100)*rawCount.texture.height/600,rawCount.texture.width/6,rawCount.texture.height/6), 0, 0);
        
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

    public void calculateAll()
    {
        if (rects != null)
        {
            foreach (var rect in rects)
            {
                rafraichir(rect);
            }
        }
        
    }
}
