using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;
    
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
    public NPCController[] randoNPCList;

    //Chasseur
    public NPCController[] ChasseurNPCList;
    private string[] npcHint = { "debutQuete", "suiteForestier", "suiteRandonneur", "suitePhotographe" };

    //Chamois
    public NPCController[] chamoisNPCList;
    public GameObject ChamoisInfos;
    
    //Communs
    public GameObject DonneursInfos;
    
    [NonSerialized] public NPCController[] currentNPCList;
    
    //Donneurs
    public NPCController[] listDonneurs;
    
    // Start is called before the first frame update
    // private void Start()
    // {
    //     if(Instance == null)
    //     {
    //         Instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public async Task loadConvo()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        ChamoisInfos.SetActive(false);
        DonneursInfos.SetActive(false);
        
        foreach (var npc in ChasseurNPCList)
        {
            npc.gameObject.SetActive(false);
        }
        foreach (var npc in randoNPCList)
        {
            npc.gameObject.SetActive(false);
        }
        foreach (var npc in chamoisNPCList)
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
                currentNPCList = chamoisNPCList;

                ChamoisInfos.SetActive(true);
                listDonneurs = ChamoisInfos.GetComponentsInChildren<NPCController>();
                break;
            
            case "Chasseur":
                JPerso = JObject.Parse(ChasseurJson.text);
                currentNPCList = ChasseurNPCList;

                DonneursInfos.SetActive(true);
                listDonneurs = DonneursInfos.GetComponentsInChildren<NPCController>();
                break;
            
            case "Randonneur":
                JPerso = JObject.Parse(RandoJson.text);
                currentNPCList = randoNPCList;
                
                DonneursInfos.SetActive(true);
                listDonneurs = DonneursInfos.GetComponentsInChildren<NPCController>();
                break;
        }
        
        foreach (var npc in currentNPCList)
        {
            npc.gameObject.SetActive(true);
            npc.setConvo((JObject)JPerso[npc.name]);
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

    public void switchNode(string hint)
    {
        var tmp = hint.Split(",");
        var npcName = tmp[1];
        var node = tmp[2];

        foreach (var npc in currentNPCList)
        {
            if(npc.isActiveAndEnabled && npc.name == npcName)
            {
                npc.setFirstNode(node);
            }
        }
    }
}
