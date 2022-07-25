using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using System;

public class randonneurQueteScript : MonoBehaviour
{
    public GameObject donneurDeRando;
    public GameObject startRando1;
    public GameObject suiteRando1;
    public GameObject endRando1;
    public GameObject startRando2;
    public GameObject endRando2;
    public GameObject startRando3;
    public GameObject endRando3;
    public GameObject startRando4;
    public GameObject endRando4;
    public GameObject startRando5;
    public GameObject endRando5;
    public GameObject donneurInfos1;
    public GameObject donneurInfos2;
    public GameObject donneurInfos3;
    public GameObject donneurInfos4;
    public GameObject donneurInfos5;
    public GameObject donneurInfos6;
    public GameObject donneurInfos7;
    public GameObject donneurInfos8;
    public GameObject donneurInfos9;
    public GameObject donneurInfos10;
    public GameObject donneurInfos11;
    public GameObject donneurInfos12;

    public GameObject pnjTest;

    public TextAsset jsonFile;
    public TextAsset jsonFileEncy;
    public List<ConversationInfos> data; 
    public List<EncyInfo> data2;

    public EncyInfo info;

    // Start is called before the first frame update
    EncycloContentRandonneur ency;

    void Start()
    {
        // Récupération des données dans le JSON, lié dans le GameObject "NPC Collection"
        ConversationInfosList infosInJson = JsonUtility.FromJson<ConversationInfosList>(jsonFile.text);
        data = new List<ConversationInfos>();

        foreach (ConversationInfos convinfo in infosInJson.convinfos)
        {
            data.Add(convinfo);
        }

        EncyInfoList infosInJson2 = JsonUtility.FromJson<EncyInfoList>(jsonFileEncy.text);
        data2 = new List<EncyInfo>();

        foreach (EncyInfo encyinfo in infosInJson2.encyinfos)
        {
            data2.Add(encyinfo);
        }

        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
        // Initial items of NPC conversation array
        var initialdonneurDRando = donneurDeRando.GetComponent<ConversationScript>().items;
        var initialstartRando1 = startRando1.GetComponent<ConversationScript>().items;
        var initialsuiteRando1 = suiteRando1.GetComponent<ConversationScript>().items;
        var initialendRando1 = endRando1.GetComponent<ConversationScript>().items;
        var initialstartRando2 = startRando2.GetComponent<ConversationScript>().items;
        var initialendRando2 = endRando2.GetComponent<ConversationScript>().items;
        var initialstartRando3 = startRando3.GetComponent<ConversationScript>().items;
        var initialendRando3 = endRando3.GetComponent<ConversationScript>().items;
        var initialstartRando4 = startRando4.GetComponent<ConversationScript>().items;
        var initialendRando4 = endRando4.GetComponent<ConversationScript>().items;
        var initialstartRando5 = startRando5.GetComponent<ConversationScript>().items;
        var initialendRando5 = endRando5.GetComponent<ConversationScript>().items;
        var initialdonneurInfos1 = donneurInfos1.GetComponent<ConversationScript>().items;
        var initialdonneurInfos2 = donneurInfos2.GetComponent<ConversationScript>().items;
        var initialdonneurInfos3 = donneurInfos3.GetComponent<ConversationScript>().items;

        //pnj de test
        ConversationPiece c = new ConversationPiece() { id = data[0].ID, text = data[0].texte, options = new List<ConversationOption>(), hint = "" };
        pnjTest.GetComponent<ConversationScript>().items.Add(c);
        pnjTest.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo1
        ConversationOption o1 = new ConversationOption() { text = data[1].branche1Reponse, targetId = data[1].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[1].branche2Reponse, targetId = data[1].branche2ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[1].ID, text = data[1].texte, options = new List<ConversationOption>(), hint = data[1].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos1.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = data[2].ID, text = data[2].texte, options = new List<ConversationOption>(), hint = data[2].hint };
        donneurInfos1.GetComponent<ConversationScript>().Add(c2); 
        ConversationPiece c3 = new ConversationPiece() { id = data[3].ID, text = data[3].texte, options = new List<ConversationOption>(), hint = data[3].hint };
        donneurInfos1.GetComponent<ConversationScript>().Add(c3);
        donneurInfos1.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo2
         o1 = new ConversationOption() { text = data[4].branche1Reponse, targetId = data[4].branche1ID };
         o2 = new ConversationOption() { text = data[4].branche2Reponse, targetId = data[4].branche2ID };
         c1 = new ConversationPiece() { id = data[4].ID, text = data[4].texte, options = new List<ConversationOption>(), hint = data[4].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos2.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[5].ID, text = data[5].texte, options = new List<ConversationOption>(), hint = data[5].hint };
        donneurInfos2.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[6].ID, text = data[6].texte, options = new List<ConversationOption>(), hint = data[6].hint };
        donneurInfos2.GetComponent<ConversationScript>().Add(c3);
        donneurInfos2.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo3
         o1 = new ConversationOption() { text = data[7].branche1Reponse, targetId = data[7].branche1ID };
         o2 = new ConversationOption() { text = data[7].branche2Reponse, targetId = data[7].branche2ID };
         c1 = new ConversationPiece() { id = data[7].ID, text = data[7].texte, options = new List<ConversationOption>(), hint = data[7].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos3.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[8].ID, text = data[8].texte, options = new List<ConversationOption>(), hint = data[8].hint };
        donneurInfos3.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[9].ID, text = data[9].texte, options = new List<ConversationOption>(), hint = data[9].hint };
        donneurInfos3.GetComponent<ConversationScript>().Add(c3);
        donneurInfos3.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo4
         o1 = new ConversationOption() { text = data[10].branche1Reponse, targetId = data[10].branche1ID };
         o2 = new ConversationOption() { text = data[10].branche2Reponse, targetId = data[10].branche2ID };
         c1 = new ConversationPiece() { id = data[10].ID, text = data[10].texte, options = new List<ConversationOption>(), hint = data[10].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos4.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[11].ID, text = data[11].texte, options = new List<ConversationOption>(), hint = data[11].hint };
        donneurInfos4.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[12].ID, text = data[12].texte, options = new List<ConversationOption>(), hint = data[12].hint };
        donneurInfos4.GetComponent<ConversationScript>().Add(c3);
        donneurInfos4.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo5
         o1 = new ConversationOption() { text = data[13].branche1Reponse, targetId = data[13].branche1ID };
         o2 = new ConversationOption() { text = data[13].branche2Reponse, targetId = data[13].branche2ID };
         c1 = new ConversationPiece() { id = data[13].ID, text = data[13].texte, options = new List<ConversationOption>(), hint = data[13].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos5.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[14].ID, text = data[14].texte, options = new List<ConversationOption>(), hint = data[14].hint };
        donneurInfos5.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[15].ID, text = data[15].texte, options = new List<ConversationOption>(), hint = data[15].hint };
        donneurInfos5.GetComponent<ConversationScript>().Add(c3);
        donneurInfos5.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo6
         o1 = new ConversationOption() { text = data[16].branche1Reponse, targetId = data[16].branche1ID };
         o2 = new ConversationOption() { text = data[16].branche2Reponse, targetId = data[16].branche2ID };
         c1 = new ConversationPiece() { id = data[16].ID, text = data[16].texte, options = new List<ConversationOption>(), hint = data[16].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos6.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[17].ID, text = data[17].texte, options = new List<ConversationOption>(), hint = data[17].hint };
        donneurInfos6.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[18].ID, text = data[18].texte, options = new List<ConversationOption>(), hint = data[18].hint };
        donneurInfos6.GetComponent<ConversationScript>().Add(c3);
        donneurInfos6.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo7
         o1 = new ConversationOption() { text = data[19].branche1Reponse, targetId = data[19].branche1ID };
         o2 = new ConversationOption() { text = data[19].branche2Reponse, targetId = data[19].branche2ID };
         c1 = new ConversationPiece() { id = data[19].ID, text = data[19].texte, options = new List<ConversationOption>(), hint = data[19].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos7.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[20].ID, text = data[20].texte, options = new List<ConversationOption>(), hint = data[20].hint };
        donneurInfos7.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[21].ID, text = data[21].texte, options = new List<ConversationOption>(), hint = data[21].hint };
        donneurInfos7.GetComponent<ConversationScript>().Add(c3);
        donneurInfos7.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo8
         o1 = new ConversationOption() { text = data[22].branche1Reponse, targetId = data[22].branche1ID };
         o2 = new ConversationOption() { text = data[22].branche2Reponse, targetId = data[22].branche2ID };
         c1 = new ConversationPiece() { id = data[22].ID, text = data[22].texte, options = new List<ConversationOption>(), hint = data[22].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos8.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[23].ID, text = data[23].texte, options = new List<ConversationOption>(), hint = data[23].hint };
        donneurInfos8.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[24].ID, text = data[24].texte, options = new List<ConversationOption>(), hint = data[24].hint };
        donneurInfos8.GetComponent<ConversationScript>().Add(c3);
        donneurInfos8.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo9
         o1 = new ConversationOption() { text = data[25].branche1Reponse, targetId = data[25].branche1ID };
         o2 = new ConversationOption() { text = data[25].branche2Reponse, targetId = data[25].branche2ID };
         c1 = new ConversationPiece() { id = data[25].ID, text = data[25].texte, options = new List<ConversationOption>(), hint = data[25].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos9.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[26].ID, text = data[26].texte, options = new List<ConversationOption>(), hint = data[26].hint };
        donneurInfos9.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[27].ID, text = data[27].texte, options = new List<ConversationOption>(), hint = data[27].hint };
        donneurInfos9.GetComponent<ConversationScript>().Add(c3);
        donneurInfos9.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo10
         o1 = new ConversationOption() { text = data[28].branche1Reponse, targetId = data[28].branche1ID };
         o2 = new ConversationOption() { text = data[28].branche2Reponse, targetId = data[28].branche2ID };
         c1 = new ConversationPiece() { id = data[28].ID, text = data[28].texte, options = new List<ConversationOption>(), hint = data[28].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos10.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[29].ID, text = data[29].texte, options = new List<ConversationOption>(), hint = data[29].hint };
        donneurInfos10.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[30].ID, text = data[30].texte, options = new List<ConversationOption>(), hint = data[30].hint };
        donneurInfos10.GetComponent<ConversationScript>().Add(c3);
        donneurInfos10.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo11
         o1 = new ConversationOption() { text = data[31].branche1Reponse, targetId = data[31].branche1ID };
         o2 = new ConversationOption() { text = data[31].branche2Reponse, targetId = data[31].branche2ID };
         c1 = new ConversationPiece() { id = data[31].ID, text = data[31].texte, options = new List<ConversationOption>(), hint = data[31].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos11.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[32].ID, text = data[32].texte, options = new List<ConversationOption>(), hint = data[32].hint };
        donneurInfos11.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[33].ID, text = data[33].texte, options = new List<ConversationOption>(), hint = data[33].hint };
        donneurInfos11.GetComponent<ConversationScript>().Add(c3);
        donneurInfos11.GetComponent<ConversationScript>().OnAfterDeserialize();

        // DonneurInfo12
         o1 = new ConversationOption() { text = data[34].branche1Reponse, targetId = data[34].branche1ID };
         o2 = new ConversationOption() { text = data[34].branche2Reponse, targetId = data[34].branche2ID };
         c1 = new ConversationPiece() { id = data[34].ID, text = data[34].texte, options = new List<ConversationOption>(), hint = data[34].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurInfos12.GetComponent<ConversationScript>().Add(c1);
         c2 = new ConversationPiece() { id = data[35].ID, text = data[35].texte, options = new List<ConversationOption>(), hint = data[35].hint };
        donneurInfos12.GetComponent<ConversationScript>().Add(c2);
         c3 = new ConversationPiece() { id = data[36].ID, text = data[36].texte, options = new List<ConversationOption>(), hint = data[36].hint };
        donneurInfos12.GetComponent<ConversationScript>().Add(c3);
        donneurInfos12.GetComponent<ConversationScript>().OnAfterDeserialize();
    }



    // RANDONNEE NUMERO 1

    public void donnerRando1()
    {
        ency.addInfoToList("rando1", ency.quete);
        //SELF
        donneurDeRando.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà pris la randonnée : Forêt des Chutes d'Eau. \nConsultez votre encyclopédie...", options = new List<ConversationOption>(), hint = "" };
        donneurDeRando.GetComponent<ConversationScript>().items.Add(c);
        donneurDeRando.GetComponent<ConversationScript>().OnAfterDeserialize();

        //START POINT
        startRando1.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous commencer la randonnée : Forêt des Chutes d'Eau ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        startRando1.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "C'est parti !! Mais attention, ne prenez pas le chemin à gauche !", options = new List<ConversationOption>(), hint = "start1" };
        startRando1.GetComponent<ConversationScript>().Add(c2);
        startRando1.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void lancerRando1()
    {
        ency.addInfoToList("startrando1", ency.quete);
        //SELF
        startRando1.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà lancé la randonnée : Forêt des Chutes d'Eau. \nDirigez-vous vers le checkpoint...", options = new List<ConversationOption>(), hint = "" };
        startRando1.GetComponent<ConversationScript>().items.Add(c);
        startRando1.GetComponent<ConversationScript>().OnAfterDeserialize();

        //CHECKPOINT
        suiteRando1.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous valider le checkpoint de : Forêt des Chutes d'Eau ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        suiteRando1.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !! Dirigez-vous maintenant vers le sud pour gravir le Mont Peney", options = new List<ConversationOption>(), hint = "suite1" };
        suiteRando1.GetComponent<ConversationScript>().Add(c2);
        suiteRando1.GetComponent<ConversationScript>().OnAfterDeserialize();
        startRando1.GetComponent<ConversationScript>().items.Clear();
    }

    public void suite_Rando1()
    {
        ency.addInfoToList("suiterando1", ency.quete);
        //SELF
        suiteRando1.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà validé le checkpoint de : Forêt des Chutes d'Eau. \nDirigez-vous vers l'arrivée...", options = new List<ConversationOption>(), hint = "" };
        suiteRando1.GetComponent<ConversationScript>().items.Add(c);
        suiteRando1.GetComponent<ConversationScript>().OnAfterDeserialize();

        //END POINT
        endRando1.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous terminer la randonnée : Forêt des Chutes d'Eau ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        endRando1.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !!", options = new List<ConversationOption>(), hint = "end1" };
        endRando1.GetComponent<ConversationScript>().Add(c2);
        endRando1.GetComponent<ConversationScript>().OnAfterDeserialize();
        suiteRando1.GetComponent<ConversationScript>().items.Clear();
    }

    public void terminerRando1()
    {
        ency.addInfoToList("endrando1", ency.quete);
        endRando1.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà effectué la randonnée : Forêt des Chutes d'Eau...", options = new List<ConversationOption>(), hint = "" };
        endRando1.GetComponent<ConversationScript>().items.Add(c);
        endRando1.GetComponent<ConversationScript>().OnAfterDeserialize();
    }



    // RANDONNEE NUMERO 2

    public void donnerRando2()
    {
        ency.addInfoToList("rando2", ency.quete);
        //SELF
        donneurDeRando.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà pris la randonnée : Chemin des Chamois. \nConsultez votre encyclopédie...", options = new List<ConversationOption>(), hint = "" };
        donneurDeRando.GetComponent<ConversationScript>().items.Add(c);
        donneurDeRando.GetComponent<ConversationScript>().OnAfterDeserialize();

        //START POINT
        startRando2.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous commencer la randonnée : Chemin des Chamois ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        startRando2.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "C'est parti !!", options = new List<ConversationOption>(), hint = "start2" };
        startRando2.GetComponent<ConversationScript>().Add(c2);
        startRando2.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void lancerRando2()
    {
        ency.addInfoToList("startrando2", ency.quete);
        //SELF
        startRando2.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà lancé la randonnée : Chemin des Chamois. \nDirigez-vous vers l'arrivée...", options = new List<ConversationOption>(), hint = "" };
        startRando2.GetComponent<ConversationScript>().items.Add(c);
        startRando2.GetComponent<ConversationScript>().OnAfterDeserialize();

        //END POINT
        endRando2.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous terminer la randonnée : Chemin des Chamois ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        endRando2.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !!", options = new List<ConversationOption>(), hint = "end2" };
        endRando2.GetComponent<ConversationScript>().Add(c2);
        endRando2.GetComponent<ConversationScript>().OnAfterDeserialize();
        startRando2.GetComponent<ConversationScript>().items.Clear();
    }

    public void terminerRando2()
    {
        ency.addInfoToList("endrando2", ency.quete);
        endRando2.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà effectué la randonnée : Chemin des Chamois...", options = new List<ConversationOption>(), hint = "" };
        endRando2.GetComponent<ConversationScript>().items.Add(c);
        endRando2.GetComponent<ConversationScript>().OnAfterDeserialize();
    }



    // RANDONNEE NUMERO 3

    public void donnerRando3()
    {
        ency.addInfoToList("rando3", ency.quete);
        //SELF
        donneurDeRando.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà pris la randonnée : Côte des Cailloux. \nConsultez votre encyclopédie...", options = new List<ConversationOption>(), hint = "" };
        donneurDeRando.GetComponent<ConversationScript>().items.Add(c);
        donneurDeRando.GetComponent<ConversationScript>().OnAfterDeserialize();

        //START POINT
        startRando3.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous commencer la randonnée : Côte des Cailloux ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        startRando3.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "C'est parti !!", options = new List<ConversationOption>(), hint = "start3" };
        startRando3.GetComponent<ConversationScript>().Add(c2);
        startRando3.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void lancerRando3()
    {
        ency.addInfoToList("startrando3", ency.quete);
        //SELF
        startRando3.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà lancé la randonnée : Côte des Cailloux. \nDirigez-vous vers l'arrivée...", options = new List<ConversationOption>(), hint = "" };
        startRando3.GetComponent<ConversationScript>().items.Add(c);
        startRando3.GetComponent<ConversationScript>().OnAfterDeserialize();

        //END POINT
        endRando3.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous terminer la randonnée : Côte des Cailloux ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        endRando3.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !!", options = new List<ConversationOption>(), hint = "end3" };
        endRando3.GetComponent<ConversationScript>().Add(c2);
        endRando3.GetComponent<ConversationScript>().OnAfterDeserialize();
        startRando3.GetComponent<ConversationScript>().items.Clear();
    }

    public void terminerRando3()
    {
        ency.addInfoToList("endrando3", ency.quete);
        endRando3.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà effectué la randonnée : Côte des Cailloux...", options = new List<ConversationOption>(), hint = "" };
        endRando3.GetComponent<ConversationScript>().items.Add(c);
        endRando3.GetComponent<ConversationScript>().OnAfterDeserialize();
    }



    // RANDONNEE NUMERO 4

    public void donnerRando4()
    {
        ency.addInfoToList("rando4", ency.quete);
        //SELF
        donneurDeRando.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà pris la randonnée : Montée du Vertige. \nConsultez votre encyclopédie...", options = new List<ConversationOption>(), hint = "" };
        donneurDeRando.GetComponent<ConversationScript>().items.Add(c);
        donneurDeRando.GetComponent<ConversationScript>().OnAfterDeserialize();

        //START POINT
        startRando4.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous commencer la randonnée : Montée du Vertige ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        startRando4.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "C'est parti !!", options = new List<ConversationOption>(), hint = "start4" };
        startRando4.GetComponent<ConversationScript>().Add(c2);
        startRando4.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void lancerRando4()
    {
        ency.addInfoToList("startrando4", ency.quete);
        //SELF
        startRando4.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà lancé la randonnée : Montée du Vertige. \nDirigez-vous vers l'arrivée...", options = new List<ConversationOption>(), hint = "" };
        startRando4.GetComponent<ConversationScript>().items.Add(c);
        startRando4.GetComponent<ConversationScript>().OnAfterDeserialize();

        //END POINT
        endRando4.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous terminer la randonnée : Montée du Vertige ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        endRando4.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !!", options = new List<ConversationOption>(), hint = "end4" };
        endRando4.GetComponent<ConversationScript>().Add(c2);
        endRando4.GetComponent<ConversationScript>().OnAfterDeserialize();
        startRando4.GetComponent<ConversationScript>().items.Clear();
    }

    public void terminerRando4()
    {
        ency.addInfoToList("endrando4", ency.quete);
        endRando4.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà effectué la randonnée : Montée du Vertige...", options = new List<ConversationOption>(), hint = "" };
        endRando4.GetComponent<ConversationScript>().items.Add(c);
        endRando4.GetComponent<ConversationScript>().OnAfterDeserialize();
    }



    // RANDONNEE NUMERO 5

    public void donnerRando5()
    {
        ency.addInfoToList("rando5", ency.quete);
        //SELF
        donneurDeRando.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà pris la randonnée : Escursion de l'escalade. \nConsultez votre encyclopédie...", options = new List<ConversationOption>(), hint = "" };
        donneurDeRando.GetComponent<ConversationScript>().items.Add(c);
        donneurDeRando.GetComponent<ConversationScript>().OnAfterDeserialize();

        //START POINT
        startRando5.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous commencer la randonnée : Escursion de l'escalade ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        startRando5.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "C'est parti !!", options = new List<ConversationOption>(), hint = "start5" };
        startRando5.GetComponent<ConversationScript>().Add(c2);
        startRando5.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void lancerRando5()
    {
        ency.addInfoToList("startrando5", ency.quete);
        //SELF
        startRando5.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà lancé la randonnée : Escursion de l'escalade. \nDirigez-vous vers l'arrivée...", options = new List<ConversationOption>(), hint = "" };
        startRando5.GetComponent<ConversationScript>().items.Add(c);
        startRando5.GetComponent<ConversationScript>().OnAfterDeserialize();

        //END POINT
        endRando5.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = "Oui", targetId = "2.1" };
        ConversationOption o2 = new ConversationOption() { text = "Non", targetId = "2.2" };
        ConversationPiece c1 = new ConversationPiece() { id = "2", text = "Souhaitez-vous terminer la randonnée : Escursion de l'escalade ?", options = new List<ConversationOption>(), hint = "" };
        c1.options.Add(o1);
        c1.options.Add(o2);
        endRando5.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = "2.1", text = "Bien joué !!", options = new List<ConversationOption>(), hint = "end5" };
        endRando5.GetComponent<ConversationScript>().Add(c2);
        endRando5.GetComponent<ConversationScript>().OnAfterDeserialize();
        startRando5.GetComponent<ConversationScript>().items.Clear();
    }

    public void terminerRando5()
    {
        ency.addInfoToList("endrando5", ency.quete);
        endRando5.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = "2", text = "Vous avez déjà effectué la randonnée : Escursion de l'escalade...", options = new List<ConversationOption>(), hint = "" };
        endRando5.GetComponent<ConversationScript>().items.Add(c);
        endRando5.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void vehicule()
    {
        ency.addInfoToList(data2[16].hint, ency.pagesDynamic);
        donneurInfos1.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[37].ID, text = data[37].texte, options = new List<ConversationOption>(), hint = data[37].hint };
        donneurInfos1.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos1.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void survol()
    {
        ency.addInfoToList(data2[17].hint, ency.pagesDynamic);
        donneurInfos2.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[38].ID, text = data[38].texte, options = new List<ConversationOption>(), hint = data[38].hint };
        donneurInfos2.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos2.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void chien()
    {
        ency.addInfoToList(data2[18].hint, ency.pagesDynamic);
        donneurInfos3.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[39].ID, text = data[39].texte, options = new List<ConversationOption>(), hint = data[39].hint };
        donneurInfos3.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos3.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void appareils()
    {
        ency.addInfoToList(data2[19].hint, ency.pagesDynamic);
        donneurInfos4.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[40].ID, text = data[40].texte, options = new List<ConversationOption>(), hint = data[40].hint };
        donneurInfos4.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos4.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void camping()
    {
        ency.addInfoToList(data2[20].hint, ency.pagesDynamic);
        donneurInfos5.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[41].ID, text = data[41].texte, options = new List<ConversationOption>(), hint = data[41].hint };
        donneurInfos5.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos5.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void feux()
    {
        ency.addInfoToList(data2[21].hint, ency.pagesDynamic);
        donneurInfos6.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[42].ID, text = data[42].texte, options = new List<ConversationOption>(), hint = data[42].hint };
        donneurInfos6.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos6.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void derangementFaune()
    {
        ency.addInfoToList(data2[22].hint, ency.pagesDynamic);
        donneurInfos7.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[43].ID, text = data[43].texte, options = new List<ConversationOption>(), hint = data[43].hint };
        donneurInfos7.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos7.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void respect()
    {
        ency.addInfoToList(data2[23].hint, ency.pagesDynamic);
        donneurInfos8.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[44].ID, text = data[44].texte, options = new List<ConversationOption>(), hint = data[44].hint };
        donneurInfos8.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos8.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void sentierBalise()
    {
        ency.addInfoToList(data2[24].hint, ency.pagesDynamic);
        donneurInfos9.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[45].ID, text = data[45].texte, options = new List<ConversationOption>(), hint = data[45].hint };
        donneurInfos9.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos9.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void recommandationFaune()
    {
        ency.addInfoToList(data2[25].hint, ency.pagesDynamic);
        donneurInfos10.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[46].ID, text = data[46].texte, options = new List<ConversationOption>(), hint = data[46].hint };
        donneurInfos10.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos10.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void recommandationBalise()
    {
        ency.addInfoToList(data2[26].hint, ency.pagesDynamic);
        donneurInfos11.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[47].ID, text = data[47].texte, options = new List<ConversationOption>(), hint = data[47].hint };
        donneurInfos11.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos11.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void conseilPrevenir()
    {
        ency.addInfoToList(data2[27].hint, ency.pagesDynamic);
        donneurInfos12.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[48].ID, text = data[48].texte, options = new List<ConversationOption>(), hint = data[48].hint };
        donneurInfos12.GetComponent<ConversationScript>().items.Add(c);
        donneurInfos12.GetComponent<ConversationScript>().OnAfterDeserialize();
    }
}