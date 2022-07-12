using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class chasseurDechet : MonoBehaviour
{
    public static int dechetsMain;
    public static int limiteDechetsMain = 2;
    static TextMeshProUGUI text;
    void Start()
    {
        dechetsMain = 0;
        text = GOPointer.DechetsTexte;
        updateView();
    }
    
    public static void updateView()
    {
        text.SetText("" + dechetsMain + "/" + limiteDechetsMain);
    }
}
