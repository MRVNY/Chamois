using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Photographier : MonoBehaviour
{
    public Boolean chauriondePrise = false;
    public Boolean peclozPrise = false;

    EncycloContentChasseur ency;

    // Start is called before the first frame update
    void Start()
    {
        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prendrePhoto()
    {
        if(GOPointer.PlayerChasseur.GetComponent<TriggerZonePhoto>().dansChaurionde == true && chauriondePrise == false)
        {
            Debug.Log("PHOTO CHAURIONDE");
            //ajouter dans l'ency
            ency.addInfoToList("photoChaurionde", ency.pagesDynamic);
            //ency.addInfoToList("mange", ency.pagesDynamic);
            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbPhoto += 1;
            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbPhotoMemePartie += 1;
            chauriondePrise = true;
        }
        else if(GOPointer.PlayerChasseur.GetComponent<TriggerZonePhoto>().dansPecloz == true && peclozPrise == false)
        {
            Debug.Log("PHOTO PECLOZ");
            // ajouter dans l'ency
            ency.addInfoToList("photoPecloz", ency.pagesDynamic);
            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbPhoto += 1;
            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbPhotoMemePartie += 1;
            peclozPrise = true;
        }
    }
}
