using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracNouriture : MonoBehaviour
{
    public int id;

    public int nourissant = 20;
    public int destressant = 10;
    public int sante = 30;
    public int score = 50;
    public Sprite[] spriteArray;

    private GameObject playerManagement;
    private JaugesController j;
    private int compteur_sprite;

    private bool isEaten = false;

    private Hashtable h = new Hashtable();
    void Start()
    {
        enabled = false;
        playerManagement = GOPointer.Jauges;

        if (playerManagement != null && Global.Personnage=="Chamois")
        {
            j = playerManagement.GetComponent<JaugesController>();

            h.Add("vie", sante);
            h.Add("nourriture", nourissant);
            h.Add("stress", destressant);
            h.Add("score", score);

            GameEvents.FoodEaten += onFoodEaten;

            NourritureRepousse.onTimeToGrowTrigger += onTimeToGrow;

            compteur_sprite = 0;

            if (NourritureMangee.nourMangee.Contains(id))
            {
                Destroy(this.gameObject);
            }

        }
        else
        {
            enabled = false;
        }

    }

    private void onTimeToGrow()
    {
        if (this != null)
        {
            if (compteur_sprite > 0)
            {
                compteur_sprite--;
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[compteur_sprite];
            }
        }
    }

    private void onFoodEaten(int id)
    {
        if (id.Equals(this.id))
        {
            j.setJauges(h);
            compteur_sprite++;

            if (spriteArray.Length != 0)
            {
                if ((compteur_sprite % spriteArray.Length) > 0)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[compteur_sprite];
                }else {
                    NourritureMangee.nourMangee.Add(id);
                    NourritureMangee.displayNourMang();
                     Destroy(gameObject);
                      }
            }else {
                NourritureMangee.nourMangee.Add(id);
                NourritureMangee.displayNourMang();
                Destroy(gameObject);
                }
        }
    }

    private void onDestroy()
    {
        //NourritureMangee.instance.onFoodEatenTrigger -= onFoodEaten;
        NourritureRepousse.onTimeToGrowTrigger -= onTimeToGrow;

        GameEvents.FoodEaten -= onFoodEaten;
    }

    void OnTriggerEnter2D(Collider2D coll) 
     {
        if (coll.gameObject.tag == "Player" && !isEaten)
         {
            GameEvents.onFoodEaten(id);
            isEaten = true;
         }
     }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isEaten = false;
        }
    }
}
