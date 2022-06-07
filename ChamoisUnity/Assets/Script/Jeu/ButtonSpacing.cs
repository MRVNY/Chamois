using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpacing : MonoBehaviour
{

    public Button buttonSup;
    public Button buttonInf1;
    public Button buttonInf2;
    public Button buttonInf3;

    private Vector3 pos;
    private Vector3 sup;
    private Vector3 inf;

    private float placementY;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        sup = buttonSup.transform.position;

        if(Global.Personnage == "Chamois")
        {
            inf = buttonInf1.transform.position;

            placementY = inf.y + ((sup.y - inf.y)/2);
            pos.y = placementY;
        }
        else if(Global.Personnage == "Chasseur")
        {
            inf = buttonInf2.transform.position;

            placementY = inf.y + ((sup.y - inf.y) / 2);
            pos.y = placementY;
        }        
        else if(Global.Personnage == "Randonneur")
        {
            inf = buttonInf3.transform.position;

            placementY = inf.y + ((sup.y - inf.y) / 2);
            pos.y = placementY;
        }


    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        sup = buttonSup.transform.position;

        if (Global.Personnage == "Chamois")
        {
            inf = buttonInf1.transform.position;

            placementY = inf.y + ((sup.y - inf.y) / 2);
            pos.y = placementY;
        }
        else if (Global.Personnage == "Chasseur")
        {
            inf = buttonInf2.transform.position;

            placementY = inf.y + ((sup.y - inf.y) / 2);
            pos.y = placementY;
        }
        else if (Global.Personnage == "Randonneur")
        {
            inf = buttonInf3.transform.position;

            placementY = inf.y + ((sup.y - inf.y) / 2);
            pos.y = placementY;
        }
    }
}
