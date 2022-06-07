using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paroisRocheuses2 : MonoBehaviour
{
    /*public GameObject zone1;
   public GameObject zone2;*/
    [SerializeField] public GameObject ColliderChamois;

    public int difficulté;

    /*PolygonCollider2D z1;
    PolygonCollider2D z2;*/
    CircleCollider2D c;

    void Start()
    {
        c = ColliderChamois.GetComponent<CircleCollider2D>();
        if (Global.Personnage != "Chamois")
        {
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }
    
    void Update()
    {
        //foreach (var x in zones)
        /*for (int i = 0; i < zones.Count; i++)
        {
            z = zones[i].GetComponent<PolygonCollider2D>();
        }*/
        /*z1 = zone1.GetComponent<PolygonCollider2D>();
        z2 = zone2.GetComponent<PolygonCollider2D>();*/
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ( /*(collider == z1) || (collider == z2)*/ (collider == c.GetComponent<CircleCollider2D>()) && (Global.Personnage == "Chamois"))
        {
            Debug.Log("vitesse moins");
            GOPointer.PlayerChamois.GetComponent<JoueurChamois>().vitesse -= difficulté;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
    if ( /*(collider == z1) || (collider == z2)*/ collider == c.GetComponent<CircleCollider2D>() && (Global.Personnage == "Chamois"))
            {
                Debug.Log("vitesse plus");
                GOPointer.PlayerChamois.GetComponent<JoueurChamois>().vitesse += difficulté;
            }
    }
}
