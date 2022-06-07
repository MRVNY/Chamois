using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeterDechet : MonoBehaviour
{
    //private DataStorerChasseur data;
    //public int sc = +50;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (Global.Personnage == "Chasseur")
        {
            chasseurDechet.dechetsMain = 0;
            //data.setData("scDechets", sc);
            Debug.Log("Dechets Jeté");
            chasseurDechet.updateView();
        }
    }
}
