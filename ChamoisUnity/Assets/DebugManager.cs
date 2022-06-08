using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{

    public GameObject guide;
    public GameObject ency;
    public GameObject achi;
    public GameObject fog;
    public GameObject decor;
    public GameObject npc;
    public GameObject map;
    public GameObject chamoisMap;
    public GameObject chasseurMap;
    public GameObject randonneurMap;
    public GameObject miniMap;

    public SpriteRenderer dayNight;
    public RawImage fogImage;
    public SpriteRenderer fogRed;
    public SpriteRenderer fogBlue;
    
    void Awake()
    {
        guide.SetActive(false);
        ency.SetActive(true);
        achi.SetActive(true);
        fog.SetActive(true);
        decor.SetActive(true);
        npc.SetActive(true);
        map.SetActive(true);
        chamoisMap.SetActive(true);
        chasseurMap.SetActive(true);
        randonneurMap.SetActive(true);
        miniMap.SetActive(true);

        dayNight.enabled = false;
        fogImage.enabled = false;
        fogRed.enabled = false;
        fogBlue.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
