using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //public int id;
    public int nourissant = 20;
    public int destressant = 10;
    public int sante = 30;
    public int score = 50;
    public Sprite[] spriteArray;

    private GameObject playerManagement;
    private JaugesController j;
    protected Collider2D collider;
    private SpriteRenderer spriteRenderer;

    private bool isEaten = false;
    private DateTime timer;

    private Hashtable h = new Hashtable();
    void Start()
    {
        playerManagement = GOPointer.Jauges;
        
        j = playerManagement.GetComponent<JaugesController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();

        h.Add("vie", sante);
        h.Add("nourriture", nourissant);
        h.Add("stress", destressant);
        h.Add("score", score);

    }

    private void onFoodEaten()
    {
        j.setJauges(h);
        isEaten = true;
        spriteRenderer.sprite = spriteArray[1];
        collider.enabled = false;
        timer = DayNight.Instance.currentDate + TimeSpan.FromDays(30);
    }

    private void Regrow()
    {
        isEaten = false;
        spriteRenderer.sprite = spriteArray[0];
        collider.enabled = true;
    }

    private void FixedUpdate()
    {
        if(isEaten)
        {
            if(timer <= DayNight.Instance.currentDate)
            {
                Regrow();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) 
     {
        if (coll.gameObject.CompareTag("Player") && !isEaten && Global.Personnage=="Chamois")
        { 
            onFoodEaten();
        }
     }
}
