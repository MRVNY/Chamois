using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject guide;
    public GameObject ency;
    public GameObject achi;
    public GameObject fog;
    public GameObject decor;
    public GameObject dayNight;
    public GameObject npc;
    public GameObject map;
    public GameObject chamoisMap;
    public GameObject chasseurMap;
    public GameObject randonneurMap;


    void Awake()
    {
        guide.SetActive(true);
        ency.SetActive(true);
        achi.SetActive(true);
        fog.SetActive(true);
        decor.SetActive(true);
        dayNight.SetActive(true);
        npc.SetActive(true);
        map.SetActive(true);
        chamoisMap.SetActive(true);
        chasseurMap.SetActive(true);
        randonneurMap.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
