using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject notifToEnableEncyclopedie;
    public GameObject notifToEnableMenuDeroulant;
    public static bool notifEnabledEncyclopedie = false;

    void Update()
    {
        if(Time.timeScale == 1)
        {
            if ((notifEnabledEncyclopedie) && (RegroupementMenu.menuOuvre == false))
            {
                notifToEnableMenuDeroulant.SetActive(true);
                notifToEnableEncyclopedie.SetActive(false);
            }
            else if ((notifEnabledEncyclopedie) && (RegroupementMenu.menuOuvre))
            {
                notifToEnableMenuDeroulant.SetActive(true);
                notifToEnableEncyclopedie.SetActive(true);
            }
            else
            {
                notifToEnableMenuDeroulant.SetActive(false);
                notifToEnableEncyclopedie.SetActive(false);
            }
        }
    }

    public void setTrue()
    {
        notifEnabledEncyclopedie = true;
    }

    public void setFalse()
    {
        notifEnabledEncyclopedie = false;
    }
}
