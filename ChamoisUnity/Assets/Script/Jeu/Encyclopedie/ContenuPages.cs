using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenuPages
{
    private List<EncycloInfos> informations = new List<EncycloInfos>();

    private int poidsMax = 5;
    private int poidsActuel = 0;

    public ContenuPages()
    {
        poidsActuel = 0;
        informations.Clear();
    }

    public void Add( EncycloInfos info )
    {
        poidsActuel += info.getPoid();
        informations.Add(info);
    }

    public int getPoidsActuel()
    {
        return poidsActuel;
    }

    public int getPoidsMax()
    {
        return poidsMax;
    }

    public List<EncycloInfos> getInformations()
    {
        return informations;
    }

}
