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
    private DataStorerChamois dataChamois;
    private DataStorerChasseur dataChasseur;

    EncycloContentRandonneur encyRando;
    EncycloContentChamois encyChamois;
    EncycloContentChasseur encyChasseur;

    //NPC
    //Rando
    public NPCController[] randoNPCList;

    //Chasseur
    public NPCController[] ChasseurNPCList;

    //Chamois
    public NPCController[] chamoisNPCList;
    public GameObject ChamoisInfos;
    
    //Communs
    public GameObject DonneursInfos;
    
    [NonSerialized] public NPCController[] currentNPCList;
    [NonSerialized] public Hashtable currentNPCTable;
    
    //Donneurs
    public NPCController[] listDonneurs;

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

        dataRando = DataStorerRandonneur.Instance;
        dataChamois = DataStorerChamois.Instance;
        dataChasseur = DataStorerChasseur.Instance;
        
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

        currentNPCTable = new Hashtable();
        
        foreach (var npc in currentNPCList)
        {
            currentNPCTable.Add(npc.name, npc);
            npc.gameObject.SetActive(true);
            npc.setConvo((JObject)JPerso[npc.name]);
            //npc.setFirstNode(Global.persoNum[Global.Personnage]);
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
        encyChasseur.addInfoToList(hint, encyChasseur.pagesDynamic);
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
        
        ((NPCController)currentNPCTable[npcName])?.setFirstNode(node);
    }

    public void questAction(string hint)
    {
        var tmp = hint.Split(",");
        string from = tmp[1]; //from can be the hint or the NPC name (or both)
        string to = tmp[2]; //to is the NPC that you have to talk to next
        string questName = tmp[3];
        
        ((NPCController)currentNPCTable[to])?.setFirstNode(questName);
        ((NPCController)currentNPCTable[from])?.setFirstNode("asked");

        if (QuestManager.Instance.foundQuests[0].title != questName)
        {
            QuestManager.Instance.addQuest(questName);
        }
        
        QuestManager.Instance.currentQuest.hintName = from;
        Notifier.Instance.NewQuest();
    }
}
