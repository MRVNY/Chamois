using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TriggerZonePhoto : MonoBehaviour
{
    public GameObject boutonPhoto;

    public Boolean dansChaurionde = false;
    public Boolean dansPecloz = false;

    public Sprite photoChaurionde;
    public Sprite photoPecloz;
    private Sprite currentImage;

    public GameObject zoneChaurionde;
    public GameObject zonePecloz;

    PolygonCollider2D PCChaurionde;
    PolygonCollider2D PCPecloz;

    // Start is called before the first frame update
    void Start()
    {
        PCChaurionde = zoneChaurionde.GetComponent<PolygonCollider2D>();
        PCPecloz = zonePecloz.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("entrée fonction");
        if(Global.Personnage == "Chasseur")
        {
            //Debug.Log("on est le chasseur");
            if (collider == PCChaurionde)
            {
                //Debug.Log("Vous êtes sur la pointe de la chaurionde");
                dansChaurionde = true;
                boutonPhoto.SetActive(true);
                currentImage = photoChaurionde;
            }
            else if (collider == PCPecloz)
            {
                //Debug.Log("Vous êtes sur le mont pecloz");
                dansPecloz = true;
                boutonPhoto.SetActive(true);
                currentImage = photoPecloz;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if(Global.Personnage == "Chasseur")
        {
            if (collider == PCChaurionde || collider == PCPecloz)
            {
                dansPecloz = false;
                dansChaurionde = false;
                boutonPhoto.SetActive(false);
            }
        }
    }
}
