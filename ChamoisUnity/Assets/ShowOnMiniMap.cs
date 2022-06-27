using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMiniMap : MonoBehaviour
{
    public RectTransform bigMap;
    public RectTransform miniMap;

    public GameObject chamoisIcon;

    public GameObject chasseurIcon;

    public GameObject randoIcon;
    private GameObject playerIcon;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        chamoisIcon.SetActive(false);
        chasseurIcon.SetActive(false);
        randoIcon.SetActive(false);
        
        switch (Global.Personnage)
        {
            case "Chamois":
                playerIcon = chamoisIcon;
                player = GOPointer.PlayerChamois;
                break;
            case "Chasseur":
                playerIcon = chasseurIcon;
                player = GOPointer.PlayerChasseur;
                break;
            case "Randonneur":
                playerIcon = randoIcon;
                player = GOPointer.PlayerRandonneur;
                break;
        }
        playerIcon.SetActive(true);

        UpdatePos();
    }

    private void OnEnable()
    {
        if(playerIcon != null && player != null)
        {
            UpdatePos();
        }
    }

    // private void Update()
    // {
    //     UpdatePos();
    // }

    private void UpdatePos()
    {
        Vector2 playerPos = player.transform.position;
        playerIcon.transform.position = translatePosition(playerPos);
    }

    Vector2 translatePosition(Vector2 pos)
    {
        return ((miniMap.rect.height / bigMap.rect.height) * (pos - (Vector2)bigMap.position)) + (Vector2)miniMap.position;
    }
}
