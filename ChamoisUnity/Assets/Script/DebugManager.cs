using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
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
    public GameObject ui;

    public SpriteRenderer dayNight;
    public RawImage fogImage;
    public SpriteRenderer fogRed;
    public SpriteRenderer fogBlue;
    public SpriteRenderer fogCount;
    
    void Awake()
    {
        //SaveLoad.DeleteAllSaveFiles();
        //Global.Personnage = "Chamois";

        // RectTransform[] panels = ui.GetComponentsInChildren<RectTransform>();
        // foreach (var panel in panels)
        // {
        //     if (panel.transform.parent == ui.transform)
        //     {
        //         panel.position = ui.transform.position;
        //     }
        //     
        // }

        guide.SetActive(true);
        ency.SetActive(true);
        achi.SetActive(true);
        fog.SetActive(true);
        decor.SetActive(true);
        npc.SetActive(true);
        map.SetActive(true);
        chamoisMap.SetActive(true);
        chasseurMap.SetActive(true);
        randonneurMap.SetActive(true);
        miniMap.SetActive(false);

        dayNight.enabled = false;
        fogImage.enabled = true;
        fogRed.enabled = true;
        fogBlue.enabled = true;
        fogCount.enabled = true;
    }

    private void Start()
    {
        GOPointer.VisualNovel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void clearSave()
    {
        SaveLoad.DeleteAllSaveFiles();
        print("Save files deleted");
    }
}
