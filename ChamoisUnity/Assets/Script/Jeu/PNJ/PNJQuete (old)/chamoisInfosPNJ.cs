using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using System;

public class chamoisInfosPNJ : MonoBehaviour
{
    public GameObject infosDeplacementRandonneur;
    public GameObject infosBrucellose;
    public GameObject infosVitesseSentiers;
    public GameObject infosChallengeChamois;
    public GameObject infosBarriereComportementale;
    public GameObject infosAlimentationEspeces;
    public GameObject infosPlantesBuffet;
    public GameObject infosVigilance;
    public GameObject infosDeplacements;
    public GameObject infosGestationChamois;
    public GameObject infosVitesseCourse;
    public GameObject infosDureeVie;

    public TextAsset jsonFile;
    public TextAsset jsonFileEncy;
    public List<ConversationInfos> data;
    public List<EncyInfo> data2;

    EncycloContentChamois ency;

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

        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();

        //infosDeplacementRandonneur;
        ConversationOption o1 = new ConversationOption() { text = data[0].branche1Reponse, targetId = data[0].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[0].branche2Reponse, targetId = data[0].branche2ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[0].ID, text = data[0].texte, options = new List<ConversationOption>(), hint = data[0].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosDeplacementRandonneur.GetComponent<ConversationScript>().Add(c1);
        ConversationPiece c2 = new ConversationPiece() { id = data[1].ID, text = data[1].texte, options = new List<ConversationOption>(), hint = data[1].hint };
        infosDeplacementRandonneur.GetComponent<ConversationScript>().Add(c2);
        ConversationPiece c3 = new ConversationPiece() { id = data[2].ID, text = data[2].texte, options = new List<ConversationOption>(), hint = data[2].hint };
        infosDeplacementRandonneur.GetComponent<ConversationScript>().Add(c3);
        infosDeplacementRandonneur.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosBrucellose;
        o1 = new ConversationOption() { text = data[3].branche1Reponse, targetId = data[3].branche1ID };
        o2 = new ConversationOption() { text = data[3].branche2Reponse, targetId = data[3].branche2ID };
        c1 = new ConversationPiece() { id = data[3].ID, text = data[3].texte, options = new List<ConversationOption>(), hint = data[3].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosBrucellose.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[4].ID, text = data[4].texte, options = new List<ConversationOption>(), hint = data[4].hint };
        infosBrucellose.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[5].ID, text = data[5].texte, options = new List<ConversationOption>(), hint = data[5].hint };
        infosBrucellose.GetComponent<ConversationScript>().Add(c3);
        infosBrucellose.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosVitesseSentiers;
        o1 = new ConversationOption() { text = data[6].branche1Reponse, targetId = data[6].branche1ID };
        o2 = new ConversationOption() { text = data[6].branche2Reponse, targetId = data[6].branche2ID };
        c1 = new ConversationPiece() { id = data[6].ID, text = data[6].texte, options = new List<ConversationOption>(), hint = data[6].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosVitesseSentiers.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[7].ID, text = data[7].texte, options = new List<ConversationOption>(), hint = data[7].hint };
        infosVitesseSentiers.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[8].ID, text = data[8].texte, options = new List<ConversationOption>(), hint = data[8].hint };
        infosVitesseSentiers.GetComponent<ConversationScript>().Add(c3);
        infosVitesseSentiers.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosChallengeChamois;
        o1 = new ConversationOption() { text = data[9].branche1Reponse, targetId = data[9].branche1ID };
        o2 = new ConversationOption() { text = data[9].branche2Reponse, targetId = data[9].branche2ID };
        c1 = new ConversationPiece() { id = data[9].ID, text = data[9].texte, options = new List<ConversationOption>(), hint = data[9].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c1);

        o1 = new ConversationOption() { text = data[10].branche1Reponse, targetId = data[10].branche1ID };
        o2 = new ConversationOption() { text = data[10].branche2Reponse, targetId = data[10].branche2ID };
        ConversationOption o3 = new ConversationOption() { text = data[10].branche3Reponse, targetId = data[10].branche3ID };
        c1 = new ConversationPiece() { id = data[10].ID, text = data[10].texte, options = new List<ConversationOption>(), hint = data[10].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[11].ID, text = data[11].texte, options = new List<ConversationOption>(), hint = data[11].hint };
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[12].ID, text = data[12].texte, options = new List<ConversationOption>(), hint = data[12].hint };
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c3);

        ConversationPiece c4 = new ConversationPiece() { id = data[13].ID, text = data[13].texte, options = new List<ConversationOption>(), hint = data[13].hint };
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c4);

        ConversationPiece c5 = new ConversationPiece() { id = data[14].ID, text = data[14].texte, options = new List<ConversationOption>(), hint = data[14].hint };
        infosChallengeChamois.GetComponent<ConversationScript>().Add(c5);

        infosChallengeChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosBarriereComportementale;
        o1 = new ConversationOption() { text = data[15].branche1Reponse, targetId = data[15].branche1ID };
        o2 = new ConversationOption() { text = data[15].branche2Reponse, targetId = data[15].branche2ID };
        c1 = new ConversationPiece() { id = data[15].ID, text = data[15].texte, options = new List<ConversationOption>(), hint = data[15].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosBarriereComportementale.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[16].ID, text = data[16].texte, options = new List<ConversationOption>(), hint = data[16].hint };
        infosBarriereComportementale.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[17].ID, text = data[17].texte, options = new List<ConversationOption>(), hint = data[17].hint };
        infosBarriereComportementale.GetComponent<ConversationScript>().Add(c3);
        infosBarriereComportementale.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosAlimentationEspeces;
        o1 = new ConversationOption() { text = data[18].branche1Reponse, targetId = data[18].branche1ID };
        o2 = new ConversationOption() { text = data[18].branche2Reponse, targetId = data[18].branche2ID };
        c1 = new ConversationPiece() { id = data[18].ID, text = data[18].texte, options = new List<ConversationOption>(), hint = data[18].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosAlimentationEspeces.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[19].ID, text = data[19].texte, options = new List<ConversationOption>(), hint = data[19].hint };
        infosAlimentationEspeces.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[20].ID, text = data[20].texte, options = new List<ConversationOption>(), hint = data[20].hint };
        infosAlimentationEspeces.GetComponent<ConversationScript>().Add(c3);
        infosAlimentationEspeces.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosPlantesBuffet;
        o1 = new ConversationOption() { text = data[21].branche1Reponse, targetId = data[21].branche1ID };
        o2 = new ConversationOption() { text = data[21].branche2Reponse, targetId = data[21].branche2ID };
        c1 = new ConversationPiece() { id = data[21].ID, text = data[21].texte, options = new List<ConversationOption>(), hint = data[21].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosPlantesBuffet.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[22].ID, text = data[22].texte, options = new List<ConversationOption>(), hint = data[22].hint };
        infosPlantesBuffet.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[23].ID, text = data[23].texte, options = new List<ConversationOption>(), hint = data[23].hint };
        infosPlantesBuffet.GetComponent<ConversationScript>().Add(c3);
        infosPlantesBuffet.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosVigilance;
        o1 = new ConversationOption() { text = data[24].branche1Reponse, targetId = data[24].branche1ID };
        o2 = new ConversationOption() { text = data[24].branche2Reponse, targetId = data[24].branche2ID };
        c1 = new ConversationPiece() { id = data[24].ID, text = data[24].texte, options = new List<ConversationOption>(), hint = data[24].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosVigilance.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[25].ID, text = data[25].texte, options = new List<ConversationOption>(), hint = data[25].hint };
        infosVigilance.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[26].ID, text = data[26].texte, options = new List<ConversationOption>(), hint = data[26].hint };
        infosVigilance.GetComponent<ConversationScript>().Add(c3);
        infosVigilance.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosDeplacements;
        o1 = new ConversationOption() { text = data[27].branche1Reponse, targetId = data[27].branche1ID };
        o2 = new ConversationOption() { text = data[27].branche2Reponse, targetId = data[27].branche2ID };
        c1 = new ConversationPiece() { id = data[27].ID, text = data[27].texte, options = new List<ConversationOption>(), hint = data[27].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosDeplacements.GetComponent<ConversationScript>().Add(c1);
        c2 = new ConversationPiece() { id = data[28].ID, text = data[28].texte, options = new List<ConversationOption>(), hint = data[28].hint };
        infosDeplacements.GetComponent<ConversationScript>().Add(c2);
        c3 = new ConversationPiece() { id = data[29].ID, text = data[29].texte, options = new List<ConversationOption>(), hint = data[29].hint };
        infosDeplacements.GetComponent<ConversationScript>().Add(c3);
        infosDeplacements.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosGestationChamois;
        o1 = new ConversationOption() { text = data[30].branche1Reponse, targetId = data[30].branche1ID };
        o2 = new ConversationOption() { text = data[30].branche2Reponse, targetId = data[30].branche2ID };
        c1 = new ConversationPiece() { id = data[30].ID, text = data[30].texte, options = new List<ConversationOption>(), hint = data[30].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosGestationChamois.GetComponent<ConversationScript>().Add(c1);

        o1 = new ConversationOption() { text = data[31].branche1Reponse, targetId = data[31].branche1ID };
        o2 = new ConversationOption() { text = data[31].branche2Reponse, targetId = data[31].branche2ID };
        o3 = new ConversationOption() { text = data[31].branche3Reponse, targetId = data[31].branche3ID };
        c1 = new ConversationPiece() { id = data[31].ID, text = data[31].texte, options = new List<ConversationOption>(), hint = data[31].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosGestationChamois.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[32].ID, text = data[32].texte, options = new List<ConversationOption>(), hint = data[32].hint };
        infosGestationChamois.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[33].ID, text = data[33].texte, options = new List<ConversationOption>(), hint = data[33].hint };
        infosGestationChamois.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[34].ID, text = data[34].texte, options = new List<ConversationOption>(), hint = data[34].hint };
        infosGestationChamois.GetComponent<ConversationScript>().Add(c4);

        c5 = new ConversationPiece() { id = data[35].ID, text = data[35].texte, options = new List<ConversationOption>(), hint = data[35].hint };
        infosGestationChamois.GetComponent<ConversationScript>().Add(c5);

        infosGestationChamois.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosVitesseCourse;
        o1 = new ConversationOption() { text = data[36].branche1Reponse, targetId = data[36].branche1ID };
        o2 = new ConversationOption() { text = data[36].branche2Reponse, targetId = data[36].branche2ID };
        c1 = new ConversationPiece() { id = data[36].ID, text = data[36].texte, options = new List<ConversationOption>(), hint = data[36].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c1);

        o1 = new ConversationOption() { text = data[37].branche1Reponse, targetId = data[37].branche1ID };
        o2 = new ConversationOption() { text = data[37].branche2Reponse, targetId = data[37].branche2ID };
        o3 = new ConversationOption() { text = data[37].branche3Reponse, targetId = data[37].branche3ID };
        c1 = new ConversationPiece() { id = data[37].ID, text = data[37].texte, options = new List<ConversationOption>(), hint = data[37].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[38].ID, text = data[38].texte, options = new List<ConversationOption>(), hint = data[38].hint };
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[39].ID, text = data[39].texte, options = new List<ConversationOption>(), hint = data[39].hint };
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[40].ID, text = data[40].texte, options = new List<ConversationOption>(), hint = data[40].hint };
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c4);

        c5 = new ConversationPiece() { id = data[41].ID, text = data[41].texte, options = new List<ConversationOption>(), hint = data[41].hint };
        infosVitesseCourse.GetComponent<ConversationScript>().Add(c5);

        infosVitesseCourse.GetComponent<ConversationScript>().OnAfterDeserialize();

        //infosDureeVie;
        o1 = new ConversationOption() { text = data[42].branche1Reponse, targetId = data[42].branche1ID };
        o2 = new ConversationOption() { text = data[42].branche2Reponse, targetId = data[42].branche2ID };
        c1 = new ConversationPiece() { id = data[42].ID, text = data[42].texte, options = new List<ConversationOption>(), hint = data[42].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        infosDureeVie.GetComponent<ConversationScript>().Add(c1);

        o1 = new ConversationOption() { text = data[43].branche1Reponse, targetId = data[43].branche1ID };
        o2 = new ConversationOption() { text = data[43].branche2Reponse, targetId = data[43].branche2ID };
        o3 = new ConversationOption() { text = data[43].branche3Reponse, targetId = data[43].branche3ID };
        c1 = new ConversationPiece() { id = data[43].ID, text = data[43].texte, options = new List<ConversationOption>(), hint = data[43].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        c1.options.Add(o3);
        infosDureeVie.GetComponent<ConversationScript>().Add(c1);

        c2 = new ConversationPiece() { id = data[44].ID, text = data[44].texte, options = new List<ConversationOption>(), hint = data[44].hint };
        infosDureeVie.GetComponent<ConversationScript>().Add(c2);

        c3 = new ConversationPiece() { id = data[45].ID, text = data[45].texte, options = new List<ConversationOption>(), hint = data[45].hint };
        infosDureeVie.GetComponent<ConversationScript>().Add(c3);

        c4 = new ConversationPiece() { id = data[46].ID, text = data[46].texte, options = new List<ConversationOption>(), hint = data[46].hint };
        infosDureeVie.GetComponent<ConversationScript>().Add(c4);

        c5 = new ConversationPiece() { id = data[47].ID, text = data[47].texte, options = new List<ConversationOption>(), hint = data[47].hint };
        infosDureeVie.GetComponent<ConversationScript>().Add(c5);

        infosDureeVie.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void deplacementRandonneur()
    {
        ency.addInfoToList(data2[0].hint, ency.pagesDynamic);
        //SELF
        infosDeplacementRandonneur.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[48].ID, text = data[48].texte, options = 
            new List<ConversationOption>(), hint = data[48].hint };
        infosDeplacementRandonneur.GetComponent<ConversationScript>().items.Add(c);
        infosDeplacementRandonneur.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void brucellose()
    {
        ency.addInfoToList(data2[1].hint, ency.pagesDynamic);
        //SELF
        infosBrucellose.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[49].ID, text = data[49].texte, options = new List<ConversationOption>(), hint = data[49].hint };
        infosBrucellose.GetComponent<ConversationScript>().items.Add(c);
        infosBrucellose.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void vitesseSentiers()
    {
        ency.addInfoToList(data2[2].hint, ency.pagesDynamic);
        //SELF
        infosVitesseSentiers.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[50].ID, text = data[50].texte, options = new List<ConversationOption>(), hint = data[50].hint };
        infosVitesseSentiers.GetComponent<ConversationScript>().items.Add(c);
        infosVitesseSentiers.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void challengeChamois()
    {
        ency.addInfoToList(data2[3].hint, ency.pagesDynamic);
        //SELF
        infosChallengeChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[51].ID, text = data[51].texte, options = new List<ConversationOption>(), hint = data[51].hint };
        infosChallengeChamois.GetComponent<ConversationScript>().items.Add(c);
        infosChallengeChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void barriereComportementale()
    {
        ency.addInfoToList(data2[4].hint, ency.pagesDynamic);
        //SELF
        infosBarriereComportementale.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[52].ID, text = data[52].texte, options = new List<ConversationOption>(), hint = data[52].hint };
        infosBarriereComportementale.GetComponent<ConversationScript>().items.Add(c);
        infosBarriereComportementale.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void alimentationEspeces()
    {
        ency.addInfoToList(data2[5].hint, ency.pagesDynamic);
        //SELF
        infosAlimentationEspeces.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[53].ID, text = data[53].texte, options = new List<ConversationOption>(), hint = data[53].hint };
        infosAlimentationEspeces.GetComponent<ConversationScript>().items.Add(c);
        infosAlimentationEspeces.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void plantesBuffet()
    {
        ency.addInfoToList(data2[6].hint, ency.pagesDynamic);
        //SELF
        infosPlantesBuffet.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[54].ID, text = data[54].texte, options = new List<ConversationOption>(), hint = data[54].hint };
        infosPlantesBuffet.GetComponent<ConversationScript>().items.Add(c);
        infosPlantesBuffet.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void vigilance()
    {
        ency.addInfoToList(data2[7].hint, ency.pagesDynamic);
        //SELF
        infosVigilance.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[55].ID, text = data[55].texte, options = new List<ConversationOption>(), hint = data[55].hint };
        infosVigilance.GetComponent<ConversationScript>().items.Add(c);
        infosVigilance.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void deplacements()
    {
        ency.addInfoToList(data2[8].hint, ency.pagesDynamic);
        //SELF
        infosDeplacements.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[56].ID, text = data[56].texte, options = new List<ConversationOption>(), hint = data[56].hint };
        infosDeplacements.GetComponent<ConversationScript>().items.Add(c);
        infosDeplacements.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void gestationChamois()
    {
        ency.addInfoToList(data2[9].hint, ency.pagesDynamic);
        //SELF
        infosGestationChamois.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[57].ID, text = data[57].texte, options = new List<ConversationOption>(), hint = data[57].hint };
        infosGestationChamois.GetComponent<ConversationScript>().items.Add(c);
        infosGestationChamois.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void vitesseCourse()
    {
        ency.addInfoToList(data2[10].hint, ency.pagesDynamic);
        //SELF
        infosVitesseCourse.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[58].ID, text = data[58].texte, options = new List<ConversationOption>(), hint = data[58].hint };
        infosVitesseCourse.GetComponent<ConversationScript>().items.Add(c);
        infosVitesseCourse.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void dureeVie()
    {
        ency.addInfoToList(data2[11].hint, ency.pagesDynamic);
        //SELF
        infosDureeVie.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[59].ID, text = data[59].texte, options = new List<ConversationOption>(), hint = data[59].hint };
        infosDureeVie.GetComponent<ConversationScript>().items.Add(c);
        infosDureeVie.GetComponent<ConversationScript>().OnAfterDeserialize();
    }
}
