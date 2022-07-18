using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDechets : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listDechets = new List<GameObject>();
    public int r1;
    public int r2;
    public int r3;

    public void Start()
    {
        random1();
        random2();
        random3();
        if (Global.Personnage == "Chasseur"){
            for (int l = 0; (l < listDechets.Count); l++)
            {
                int idDechet = listDechets[l].GetComponent<ramasseDechets>().ID;
                if (idDechet == r1 || idDechet == r2 || idDechet == r3)
                {
                    listDechets[l].SetActive(true);
                }
            }
        }
    }
    
    public int random1()
    {
        r1 = Random.Range(1,(listDechets.Count));
        return r1;
    }

    public int random2()
    {
        r2 = Random.Range(1,(listDechets.Count));
        if (r2 == r1)
        {
            random2();
        }
        return r2;
    }

    public int random3()
    {
        r3 = Random.Range(1,(listDechets.Count));
        if (r3 == r1 || r3 == r2)
        {
            random3();
        }
        return r3;
    }
}
