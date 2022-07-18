using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 spawn;
    public float distance = 40; 
    private Hashtable h = new Hashtable();
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10,13, true);
        spawn = transform.position;
    }
    void Update()
    {
        /// la balle se détruit automatiquement après une certaine distance parcourue
        if (Vector3.Distance(spawn, transform.position) > distance)
        {
            Destroy(gameObject);
        }
    }

    /// si la balle rencontre un collider elle le détruit (A AMELIORER)
    void OnCollisionEnter2D(Collision2D col)
    {
        /*if (col.gameObject.name == "ListeChamoisSauvages")
        {
            Destroy(col.gameObject);
            if (gameObject.GetComponent<ListChamois>().rdn == gameObject.GetComponent<scriptChamoisSauvage>().id)
            {
                GOPointer.GameManager.GetComponent<FinPartie>().receiveDataChasseur(h);
            }
        }*/

        //if(col.gameObject.tag == "Danger" || col.gameObject.tag == "Faune" || col.gameObject.tag == "ProiePrincipale" || col.gameObject.tag == "Pnj" || col.gameObject.tag == "PnjImportant")
        if(col.gameObject.GetComponent<Killable>() != null)
        {
            switch(col.gameObject)
            {
                default:
                    Destroy(col.gameObject);
                break;
            }

            if(col.gameObject.GetComponent<Killable>().typeTuable == "PnjImportant" && PlayerPrefs.GetInt("inGameHelp") == 1)
            {
                GOPointer.CanvasGuideJeu.SetActive(true);
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().guideText.SetText("Vous venez d'abattre froidement un être-humain, qui était important dans le déroulement de votre quête, peut-être devriez-vous recommencer une partie ?");

            }

        }
        Destroy(gameObject);


    }
}