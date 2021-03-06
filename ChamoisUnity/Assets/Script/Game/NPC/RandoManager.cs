using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using System;
using TMPro;
using System.Linq;

public class RandoManager : MonoBehaviour
{
    //PnJ donneur de randonnées
    //public NPCController guide;
    private DataStorerRandonneur dataSt;
    // Start is called before the first frame update
    EncycloContentRandonneur ency;
    //public TextAsset jsonFileEncy;
    //private JObject dataEncy;

    private List<Transform> randosList;
    private InteractableController[] currentRoute;
    public static int totalPoints = -1;
    public static int currentPoint = -1;
    private string randoName;
    
    private PlayerQuest currentQuest;


    void Start()
    {

        if (Global.Personnage == "Randonneur")
        {
            dataSt = (DataStorerRandonneur)DataStorer.currentDS;
        }

        //dataEncy = JObject.Parse(jsonFileEncy.text);
        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();

        randosList = new List<Transform>();
        var tmp = GetComponentsInChildren<Transform>();
        foreach (Transform t in tmp)
        {
            if (t.parent == transform)
            {
                randosList.Add(t);
            }
        }
        
        foreach (var rando in randosList)
        {
            rando.gameObject.SetActive(false);
        }
    }

    public void startRando(string rando){
        randoName = rando;
        //ency.addInfoToList("rando"+rando, ency.quete);

        int i = Global.randoNum[rando]-1;
        randosList[i].gameObject.SetActive(true);
        currentRoute = randosList[i].GetComponentsInChildren<InteractableController>();

        foreach (InteractableController ic in currentRoute)
        {
            //ic.setMessage("Oops, looks like you took a shortcut and skipped the last point, please validate the last point and come back");
            ic.setMessage("Oops, il me semble que t'as sauté les points, valide tous les points precedents et reveiens");
        }
        
        //currentRoute[0].setMessage("Hurray! You've found the starting point! The nexr point is nearby!");
        currentRoute[0].setMessage("Youpi! Tu as trouvé le point de départ! Le point suivant est proche!");
        totalPoints = currentRoute.Length;
        currentPoint = -1;
        QuestManager.Instance.addQuest("rando"+rando, totalPoints);
        currentQuest = QuestManager.Instance.currentQuest;
        QuestManager.Instance.currentQuest.currentStep = currentPoint;
    }

    public void nextRando(InteractableController point){
        if(currentRoute[currentPoint+1]==point){
            currentPoint++;
            QuestManager.Instance.currentQuest.currentStep = currentPoint;
            if(currentPoint==0) ency.addInfoToList("start"+randoName, ency.pagesDynamic);
            currentRoute[currentPoint].setMessage("T'as déjà validé ce point, cherche le point suivant!");
            if(currentPoint == totalPoints-2){
                currentRoute[currentPoint+1].setMessage("Bravo! Tu as trouvé le point final!");
            }
            else if (currentPoint >= totalPoints - 1)
            {
                endRando();
            }
            else{
                currentRoute[currentPoint+1].setMessage("Bravo! Tu as trouvé le point numéro "+(currentPoint+2)+"!");
            }
        }
    }

    public void endRando(){
        ency.addInfoToList("end"+randoName, ency.pagesDynamic);
        totalPoints = -1;
        currentPoint = -1;
        
        QuestManager.Instance.currentQuest.isFinished= true;
        dataSt.setData(randoName+"Score", 1);
        dataSt.nbRandos += 1;
        // dataSt.nbRandosMemePartie += 1;
    }

}