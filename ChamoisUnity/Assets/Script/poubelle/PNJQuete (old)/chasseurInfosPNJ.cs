using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using System;

public class chasseurInfosPNJ : MonoBehaviour
{
    public GameObject infosLoupRegulation;
    public GameObject infosUtiliteChasse;
    public GameObject infosChasseurTelemetre;
    public GameObject infosFaunePresente;
    public GameObject infosPoidsChamois;
    public GameObject infosSociabiliteChamois;
    public GameObject infosRegimeChamois;
    public GameObject infosHabitatChamois;
    public GameObject infosRegulationChasseChamois;
    public GameObject infoPoidsChevreuil;
    public GameObject infoPredateursPresents;
    public GameObject infoPeriodeChasse;

    public TextAsset jsonFile;
    public TextAsset jsonFileEncy;
    public List<ConversationInfos> data;
    public List<EncyInfo> data2;
    public EncyInfo info;

    EncycloContentChasseur ency;

    void Start()
    {
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

        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();

        //infosLoupRegulation;
        ConversationOption o1 = new ConversationOption() { text = data[0].branche1Reponse, targetId = data[0].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[0].branche2Reponse, targetId = data[0].branche2ID };
        ConversationOption o3 = new ConversationOption() { text = data[0].branche3Reponse, targetId = data[0].branche3ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[0].ID, text = data[0].texte, options = new List<ConversationOption>(), hint = data[0].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosLoupRegulation.GetComponent<ConversationScript>().Add(c1);

        ConversationPiece c2 = new ConversationPiece() { id = data[1].ID, text = data[1].texte, options = new List<ConversationOption>(), hint = data[1].hint };
        infosLoupRegulation.GetComponent<ConversationScript>().Add(c2);

        ConversationPiece c3 = new ConversationPiece() { id = data[2].ID, text = data[2].texte, options = new List<ConversationOption>(), hint = data[2].hint };
        infosLoupRegulation.GetComponent<ConversationScript>().Add(c3);

        ConversationPiece c4 = new ConversationPiece() { id = data[3].ID, text = data[3].texte, options = new List<ConversationOption>(), hint = data[3].hint };
        infosLoupRegulation.GetComponent<ConversationScript>().Add(c4);

        infosLoupRegulation.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosUtiliteChasse;
        o1 = new ConversationOption() { text = data[4].branche1Reponse, targetId = data[4].branche1ID };
        o2 = new ConversationOption() { text = data[4].branche2Reponse, targetId = data[4].branche2ID };
        c1 = new ConversationPiece() { id = data[4].ID, text = data[4].texte, options = new List<ConversationOption>(), hint = data[4].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosUtiliteChasse.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[5].ID, text = data[5].texte, options = new List<ConversationOption>(), hint = data[5].hint };
        infosUtiliteChasse.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[6].ID, text = data[6].texte, options = new List<ConversationOption>(), hint = data[6].hint };
        infosUtiliteChasse.GetComponent<ConversationScript>().Add(c3);

        infosUtiliteChasse.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosChasseurTelemetre;
        o1 = new ConversationOption() { text = data[7].branche1Reponse, targetId = data[7].branche1ID };
        o2 = new ConversationOption() { text = data[7].branche2Reponse, targetId = data[7].branche2ID };
        c1 = new ConversationPiece() { id = data[7].ID, text = data[7].texte, options = new List<ConversationOption>(), hint = data[7].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosChasseurTelemetre.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[8].ID, text = data[8].texte, options = new List<ConversationOption>(), hint = data[8].hint };
        infosChasseurTelemetre.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[9].ID, text = data[9].texte, options = new List<ConversationOption>(), hint = data[9].hint };
        infosChasseurTelemetre.GetComponent<ConversationScript>().Add(c3);

        infosChasseurTelemetre.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosFaunePresente;
        o1 = new ConversationOption() { text = data[10].branche1Reponse, targetId = data[10].branche1ID };
        o2 = new ConversationOption() { text = data[10].branche2Reponse, targetId = data[10].branche2ID };
        o3 = new ConversationOption() { text = data[10].branche3Reponse, targetId = data[10].branche3ID };
        c1 = new ConversationPiece() { id = data[10].ID, text = data[10].texte, options = new List<ConversationOption>(), hint = data[10].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosFaunePresente.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[11].ID, text = data[11].texte, options = new List<ConversationOption>(), hint = data[11].hint };
        infosFaunePresente.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[12].ID, text = data[12].texte, options = new List<ConversationOption>(), hint = data[12].hint };
        infosFaunePresente.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[13].ID, text = data[13].texte, options = new List<ConversationOption>(), hint = data[13].hint };
        infosFaunePresente.GetComponent<ConversationScript>().Add(c4);

        infosFaunePresente.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosPoidsChamois;
        o1 = new ConversationOption() { text = data[14].branche1Reponse, targetId = data[14].branche1ID };
        o2 = new ConversationOption() { text = data[14].branche2Reponse, targetId = data[14].branche2ID };
        o3 = new ConversationOption() { text = data[14].branche3Reponse, targetId = data[14].branche3ID };
        c1 = new ConversationPiece() { id = data[14].ID, text = data[14].texte, options = new List<ConversationOption>(), hint = data[14].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c1);

        o1 = new ConversationOption() { text = data[15].branche1Reponse, targetId = data[15].branche1ID };
        o2 = new ConversationOption() { text = data[15].branche2Reponse, targetId = data[15].branche2ID };
        o3 = new ConversationOption() { text = data[15].branche3Reponse, targetId = data[15].branche3ID };
        c2 = new ConversationPiece() { id = data[15].ID, text = data[15].texte, options = new List<ConversationOption>(), hint = data[15].hint };
        c2.options.Add(o1);
        c2.options.Add(o2);
        c2.options.Add(o3);
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[16].ID, text = data[16].texte, options = new List<ConversationOption>(), hint = data[16].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[17].ID, text = data[17].texte, options = new List<ConversationOption>(), hint = data[17].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c4);

        ConversationPiece c5 = new ConversationPiece() { id = data[18].ID, text = data[18].texte, options = new List<ConversationOption>(), hint = data[18].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c5);

        ConversationPiece c6 = new ConversationPiece() { id = data[19].ID, text = data[19].texte, options = new List<ConversationOption>(), hint = data[19].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c6);

        ConversationPiece c7 = new ConversationPiece() { id = data[20].ID, text = data[20].texte, options = new List<ConversationOption>(), hint = data[20].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().Add(c7);

        infosPoidsChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosSociabiliteChamois;
        o1 = new ConversationOption() { text = data[21].branche1Reponse, targetId = data[21].branche1ID };
        o2 = new ConversationOption() { text = data[21].branche2Reponse, targetId = data[21].branche2ID };
        c1 = new ConversationPiece() { id = data[21].ID, text = data[21].texte, options = new List<ConversationOption>(), hint = data[21].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosSociabiliteChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[22].ID, text = data[22].texte, options = new List<ConversationOption>(), hint = data[22].hint };
        infosSociabiliteChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[23].ID, text = data[23].texte, options = new List<ConversationOption>(), hint = data[23].hint };
        infosSociabiliteChamois.GetComponent<ConversationScript>().Add(c3);

        infosSociabiliteChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosRegimeChamois;
        o1 = new ConversationOption() { text = data[24].branche1Reponse, targetId = data[24].branche1ID };
        o2 = new ConversationOption() { text = data[24].branche2Reponse, targetId = data[24].branche2ID };
        o3 = new ConversationOption() { text = data[24].branche3Reponse, targetId = data[24].branche3ID };
        c1 = new ConversationPiece() { id = data[24].ID, text = data[24].texte, options = new List<ConversationOption>(), hint = data[24].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosRegimeChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[25].ID, text = data[25].texte, options = new List<ConversationOption>(), hint = data[25].hint };
        infosRegimeChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[26].ID, text = data[26].texte, options = new List<ConversationOption>(), hint = data[26].hint };
        infosRegimeChamois.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[27].ID, text = data[27].texte, options = new List<ConversationOption>(), hint = data[27].hint };
        infosRegimeChamois.GetComponent<ConversationScript>().Add(c4);

        infosRegimeChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosHabitatChamois;
        o1 = new ConversationOption() { text = data[28].branche1Reponse, targetId = data[28].branche1ID };
        o2 = new ConversationOption() { text = data[28].branche2Reponse, targetId = data[28].branche2ID };
        o3 = new ConversationOption() { text = data[28].branche3Reponse, targetId = data[28].branche3ID };
        c1 = new ConversationPiece() { id = data[28].ID, text = data[28].texte, options = new List<ConversationOption>(), hint = data[28].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosHabitatChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[29].ID, text = data[29].texte, options = new List<ConversationOption>(), hint = data[29].hint };
        infosHabitatChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[30].ID, text = data[30].texte, options = new List<ConversationOption>(), hint = data[30].hint };
        infosHabitatChamois.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[31].ID, text = data[31].texte, options = new List<ConversationOption>(), hint = data[31].hint };
        infosHabitatChamois.GetComponent<ConversationScript>().Add(c4);

        infosHabitatChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosRegulationChasseChamois;
        o1 = new ConversationOption() { text = data[32].branche1Reponse, targetId = data[32].branche1ID };
        o2 = new ConversationOption() { text = data[32].branche2Reponse, targetId = data[32].branche2ID };
        o3 = new ConversationOption() { text = data[32].branche3Reponse, targetId = data[32].branche3ID };
        c1 = new ConversationPiece() { id = data[32].ID, text = data[32].texte, options = new List<ConversationOption>(), hint = data[32].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosRegulationChasseChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[33].ID, text = data[33].texte, options = new List<ConversationOption>(), hint = data[33].hint };
        infosRegulationChasseChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[34].ID, text = data[34].texte, options = new List<ConversationOption>(), hint = data[34].hint };
        infosRegulationChasseChamois.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[35].ID, text = data[35].texte, options = new List<ConversationOption>(), hint = data[35].hint };
        infosRegulationChasseChamois.GetComponent<ConversationScript>().Add(c4);

        infosRegulationChasseChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infoPoidsChevreuil;
        o1 = new ConversationOption() { text = data[36].branche1Reponse, targetId = data[36].branche1ID };
        o2 = new ConversationOption() { text = data[36].branche2Reponse, targetId = data[36].branche2ID };
        o3 = new ConversationOption() { text = data[36].branche3Reponse, targetId = data[36].branche3ID };
        c1 = new ConversationPiece() { id = data[36].ID, text = data[36].texte, options = new List<ConversationOption>(), hint = data[36].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[37].ID, text = data[37].texte, options = new List<ConversationOption>(), hint = data[37].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c2);

        o1 = new ConversationOption() { text = data[38].branche1Reponse, targetId = data[38].branche1ID };
        o2 = new ConversationOption() { text = data[38].branche2Reponse, targetId = data[38].branche2ID };
        o3 = new ConversationOption() { text = data[38].branche3Reponse, targetId = data[38].branche3ID };
        c3 = new ConversationPiece() { id = data[38].ID, text = data[38].texte, options = new List<ConversationOption>(), hint = data[38].hint };
        c3.options.Add(o1);
        c3.options.Add(o2);
        c3.options.Add(o3);
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[39].ID, text = data[39].texte, options = new List<ConversationOption>(), hint = data[39].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c4);

        c5 = new ConversationPiece() { id = data[40].ID, text = data[40].texte, options = new List<ConversationOption>(), hint = data[40].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c5);

        c6 = new ConversationPiece() { id = data[41].ID, text = data[41].texte, options = new List<ConversationOption>(), hint = data[41].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c6);

        c7 = new ConversationPiece() { id = data[42].ID, text = data[42].texte, options = new List<ConversationOption>(), hint = data[42].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().Add(c7);

        infoPoidsChevreuil.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infoPredateursPresents;
        o1 = new ConversationOption() { text = data[43].branche1Reponse, targetId = data[43].branche1ID };
        o2 = new ConversationOption() { text = data[43].branche2Reponse, targetId = data[43].branche2ID };
        o3 = new ConversationOption() { text = data[43].branche3Reponse, targetId = data[43].branche3ID };
        c1 = new ConversationPiece() { id = data[43].ID, text = data[43].texte, options = new List<ConversationOption>(), hint = data[43].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infoPredateursPresents.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[44].ID, text = data[44].texte, options = new List<ConversationOption>(), hint = data[44].hint };
        infoPredateursPresents.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[45].ID, text = data[45].texte, options = new List<ConversationOption>(), hint = data[45].hint };
        infoPredateursPresents.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[46].ID, text = data[46].texte, options = new List<ConversationOption>(), hint = data[46].hint };
        infoPredateursPresents.GetComponent<ConversationScript>().Add(c4);

        infoPredateursPresents.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infoPeriodeChasse;
        o1 = new ConversationOption() { text = data[47].branche1Reponse, targetId = data[47].branche1ID };
        o2 = new ConversationOption() { text = data[47].branche2Reponse, targetId = data[47].branche2ID };
        o3 = new ConversationOption() { text = data[47].branche3Reponse, targetId = data[47].branche3ID };
        c1 = new ConversationPiece() { id = data[47].ID, text = data[47].texte, options = new List<ConversationOption>(), hint = data[47].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infoPeriodeChasse.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[48].ID, text = data[48].texte, options = new List<ConversationOption>(), hint = data[48].hint };
        infoPeriodeChasse.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[49].ID, text = data[49].texte, options = new List<ConversationOption>(), hint = data[49].hint };
        infoPeriodeChasse.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[50].ID, text = data[50].texte, options = new List<ConversationOption>(), hint = data[50].hint };
        infoPeriodeChasse.GetComponent<ConversationScript>().Add(c4);

        infoPeriodeChasse.GetComponent<ConversationScript>().OnAfterDeserialize();

    }

    public void poidsChevreuil()
    {
        ency.addInfoToList(data2[4].hint, ency.pagesDynamic);
        //SELF
        infoPoidsChevreuil.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[51].ID, text = data[51].texte, options = new List<ConversationOption>(), hint = data[51].hint };
        infoPoidsChevreuil.GetComponent<ConversationScript>().items.Add(c);
        infoPoidsChevreuil.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void predateursPresents()
    {
        ency.addInfoToList(data2[5].hint, ency.pagesDynamic);
        //SELF
        infoPredateursPresents.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[52].ID, text = data[52].texte, options = new List<ConversationOption>(), hint = data[52].hint };
        infoPredateursPresents.GetComponent<ConversationScript>().items.Add(c);
        infoPredateursPresents.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void periodeChasse()
    {
        ency.addInfoToList(data2[6].hint, ency.pagesDynamic);
        //SELF
        infoPeriodeChasse.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[53].ID, text = data[53].texte, options = new List<ConversationOption>(), hint = data[53].hint };
        infoPeriodeChasse.GetComponent<ConversationScript>().items.Add(c);
        infoPeriodeChasse.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void regulationChasseChamois()
    {
        ency.addInfoToList(data2[7].hint, ency.pagesDynamic);
        //SELF
        infosRegulationChasseChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[54].ID, text = data[54].texte, options = new List<ConversationOption>(), hint = data[54].hint };
        infosRegulationChasseChamois.GetComponent<ConversationScript>().items.Add(c);
        infosRegulationChasseChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void habitatChamois()
    {
        ency.addInfoToList(data2[8].hint, ency.pagesDynamic);
        //SELF
        infosHabitatChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[55].ID, text = data[55].texte, options = new List<ConversationOption>(), hint = data[55].hint };
        infosHabitatChamois.GetComponent<ConversationScript>().items.Add(c);
        infosHabitatChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void sociabiliteChamois()
    {
        ency.addInfoToList(data2[9].hint, ency.pagesDynamic);
        //SELF
        infosSociabiliteChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[56].ID, text = data[56].texte, options = new List<ConversationOption>(), hint = data[56].hint };
        infosSociabiliteChamois.GetComponent<ConversationScript>().items.Add(c);
        infosSociabiliteChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void regimeChamois()
    {
        ency.addInfoToList(data2[10].hint, ency.pagesDynamic);
        //SELF
        infosRegimeChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[57].ID, text = data[57].texte, options = new List<ConversationOption>(), hint = data[57].hint };
        infosRegimeChamois.GetComponent<ConversationScript>().items.Add(c);
        infosRegimeChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void poidsChamois()
    {
        ency.addInfoToList(data2[11].hint, ency.pagesDynamic);
        //SELF
        infosPoidsChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[58].ID, text = data[58].texte, options = new List<ConversationOption>(), hint = data[58].hint };
        infosPoidsChamois.GetComponent<ConversationScript>().items.Add(c);
        infosPoidsChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void faunePresente()
    {
        ency.addInfoToList(data2[12].hint, ency.pagesDynamic);
        //SELF
        infosFaunePresente.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[59].ID, text = data[59].texte, options = new List<ConversationOption>(), hint = data[59].hint };
        infosFaunePresente.GetComponent<ConversationScript>().items.Add(c);
        infosFaunePresente.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void chasseurTelemetre()
    {
        ency.addInfoToList(data2[13].hint, ency.pagesDynamic);
        //SELF
        infosChasseurTelemetre.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[60].ID, text = data[60].texte, options = new List<ConversationOption>(), hint = data[60].hint };
        infosChasseurTelemetre.GetComponent<ConversationScript>().items.Add(c);
        infosChasseurTelemetre.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void utiliteChasse()
    {
        ency.addInfoToList(data2[14].hint, ency.pagesDynamic);
        //SELF
        infosUtiliteChasse.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[61].ID, text = data[61].texte, options = new List<ConversationOption>(), hint = data[61].hint };
        infosUtiliteChasse.GetComponent<ConversationScript>().items.Add(c);
        infosUtiliteChasse.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void loupRegulation()
    {
        ency.addInfoToList(data2[15].hint, ency.pagesDynamic);
        //SELF
        infosLoupRegulation.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[62].ID, text = data[62].texte, options = new List<ConversationOption>(), hint = data[62].hint };
        infosLoupRegulation.GetComponent<ConversationScript>().items.Add(c);
        infosLoupRegulation.GetComponent<ConversationScript>().OnAfterDeserialize();
    }
}
