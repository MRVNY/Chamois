using System.Collections;
using TMPro;
using UnityEngine;

public class Munitions : MonoBehaviour
{
    private int nbBalles;
    private Hashtable h = new Hashtable();
    public int nbBallesMax; 

    TextMeshProUGUI text;
    void Start()
    {
        nbBalles = nbBallesMax;
        text = GameObject.Find("Munitions/MunitionsTexte").GetComponent<TextMeshProUGUI>();
        updateView();
    }

    public void perdUneBalle(){
        nbBalles -= 1;
        updateView();
        aDesMunitions();
    }

    public bool aDesMunitions()
    {
        if (nbBalles == 0)
        {
            GOPointer.GameManager.GetComponent<FinPartie>().receiveDataChasseur(h);

            return false;
        }

        return true;
    }

    /// <summary>
    /// fonction qui remet le nombre de balles aux max
    /// </summary>
    public void recupereMunitions()
    {
        nbBalles = nbBallesMax;
        updateView();
    }

    private void updateView()
    {
        text.SetText("" + nbBalles);
    }
}
