using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;

public class NPCManager : MonoBehaviour
{
    //JSON

    public TextAsset ENCY;
    
    public TextAsset ChamoisJson;
    public TextAsset ChasseurJson;
    public TextAsset RandoJson;

    private JObject JENCY;
    private JObject JPerso;

    private DataStorerRandonneur dataRando;
    private DataStorer dataChamois;
    private DataStorerChasseur dataChasseur;

    EncycloContentRandonneur encyRando;
    EncycloContentChamois encyChamois;
    EncycloContentChasseur encyChasseur;

    //NPC
    //Rando
    public NPCController GuideRando;

    //Chasseur
    public NPCController[] ChasseurNPCList;
    private string[] npcHint = new[] { "debutQuete", "suiteForestier", "suiteRandonneur", "suitePhotographe" };

    //Chamois
    public GameObject ChamoisInfos;
    
    //Communs
    public GameObject DonneursInfos;
    
    //Donneurs
    private NPCController[] listDonneurs;

    // private void Awake()
    // {
    //     GuideRando.gameObject.SetActive(false);
    //     ChamoisInfos.SetActive(false);
    //     DonneursInfos.SetActive(false);
    //     foreach (var npc in ChasseurNPCList)
    //     {
    //         npc.gameObject.SetActive(false);
    //     }
    // }

    // Start is called before the first frame update
    public void loadConvo()
    {
        GuideRando.gameObject.SetActive(false);
        ChamoisInfos.SetActive(false);
        DonneursInfos.SetActive(false);
        foreach (var npc in ChasseurNPCList)
        {
            npc.gameObject.SetActive(false);
        }
        
        dataRando = GOPointer.PlayerRandonneur.GetComponent<DataStorerRandonneur>();
        dataChamois = GOPointer.PlayerChamois.GetComponent<DataStorer>();
        dataChasseur = GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>();
        
        encyRando = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
        encyChamois = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
        encyChasseur = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
        
        JENCY = (JObject)JObject.Parse(ENCY.text)[Global.Personnage];
        
        switch (Global.Personnage)
        {
            case "Chamois":
                JPerso = JObject.Parse(ChamoisJson.text);
                
                ChamoisInfos.SetActive(true);
                listDonneurs = ChamoisInfos.GetComponentsInChildren<NPCController>();
                break;
            
            case "Chasseur":
                JPerso = JObject.Parse(ChasseurJson.text);
                
                foreach (var npc in ChasseurNPCList)
                {
                    npc.gameObject.SetActive(true);
                    npc.setConvo((JObject)JPerso[npc.name]);
                    npc.setFirstNode("3.00");
                }
                
                DonneursInfos.SetActive(true);
                listDonneurs = DonneursInfos.GetComponentsInChildren<NPCController>();
                break;
            
            case "Randonneur":
                JPerso = JObject.Parse(RandoJson.text);
                
                GuideRando.gameObject.SetActive(true);
                GuideRando.setConvo((JObject)JPerso["GuideRando"]);
                
                DonneursInfos.SetActive(true);
                listDonneurs = DonneursInfos.GetComponentsInChildren<NPCController>();
                break;
        }
        
        foreach (var don in listDonneurs)
        {
            don.setConvo((JObject)JPerso[don.name]);
        }
    }

    public void actionRando(string hint)
    {
        dataRando.nbInfos++;
        encyRando.addInfoToList(hint,encyRando.pagesDynamic);
    }

    public void actionChasseur(string hint)
    {
        dataChasseur.nbInfos++;

        if (npcHint.Contains(hint))
        {
            switch (hint)
            {
                case "debutQuete":
                    ChasseurNPCList[0].setFirstNode("3");
                    break;
                case "suiteForestier":
                    ChasseurNPCList[1].setFirstNode("3");
                    break;
                case "suiteRandonneur":
                    ChasseurNPCList[2].setFirstNode("3");
                    break;
                case "suitePhotographe":
                    ChasseurNPCList[3].setFirstNode("3");
                    break;
            }
        }
        else
        {
            encyChasseur.addInfoToList(hint,encyChasseur.pagesDynamic);
        }
    }
    
    public void actionChamois(string hint)
    {
        dataChamois.nbInfos++;
        encyChamois.addInfoToList(hint,encyChamois.pagesDynamic);
    }
}
