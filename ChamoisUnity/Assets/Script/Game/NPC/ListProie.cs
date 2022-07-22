using System.Collections.Generic;
using UnityEngine;

public class ListProie : MonoBehaviour
{
    public int rdn;
    public List<GameObject> listDeProie;

    public static ListProie Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        rdn = Random.Range(0,(listDeProie.Count));
//        Debug.Log("id Proie Cible = " + rdn);
        for (int i = 0; (i < listDeProie.Count); i++)
        {
            //var i1 = i;
            listDeProie[i].GetComponent<ProieSauvage>().id = i;
            //listDeProie[i].onClick.AddListener(delegate() { isProie(listDeProie[i1]);});
        }
    }


    public void isProie(GameObject proie)
    {
        if (proie.GetComponent<ProieSauvage>().id == rdn)
        {
            estUneProie();
        }
        else
        {
            estPasBon();
        }
    }

    void estUneProie()
    {
        //Debug.Log("Tu es une proie");
    }

    void estPasBon()
    {
        //Debug.Log("Tu n'es pas la bonne proie");
    }
}
