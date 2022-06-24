using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine.Playables;
using System;


public class chasseurQueteScript : MonoBehaviour
{
    public GameObject donneurDeQuete;
    public GameObject gardeForestier;
    public GameObject randonneur;
    public GameObject photographe;

    public TextAsset jsonFile;
    public TextAsset jsonFileEncy;
    public List<ConversationInfos> data;
    public List<EncyInfo> data2;

    public EncyInfo info;

    // Start is called before the first frame update
    EncycloContentChasseur ency;

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
        

        ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
        // Initial items of NPC conversation array
        var initialdonneurDeQuete = donneurDeQuete.GetComponent<ConversationScript>().items;
        var initialGardeForestier = gardeForestier.GetComponent<ConversationScript>().items;
        var initialRandonneur = randonneur.GetComponent<ConversationScript>().items;
        var initialPhotographe = photographe.GetComponent<ConversationScript>().items;

        //donneurDeQuete
        ConversationOption o1 = new ConversationOption() { text = data[0].branche1Reponse, targetId = data[0].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[0].branche2Reponse, targetId = data[0].branche2ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[0].ID, text = data[0].texte, options = new List<ConversationOption>(), hint = data[0].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        donneurDeQuete.GetComponent<ConversationScript>().Add(c1);

        ConversationOption o3 = new ConversationOption() { text = data[1].branche1Reponse, targetId = data[1].branche1ID };
        ConversationOption o4 = new ConversationOption() { text = data[1].branche2Reponse, targetId = data[1].branche2ID };
        ConversationPiece c2 = new ConversationPiece() { id = data[1].ID, text = data[1].texte, options = new List<ConversationOption>(), hint = data[1].hint };
        c2.options.Add(o3);
        c2.options.Add(o4);
        donneurDeQuete.GetComponent<ConversationScript>().Add(c2);

        ConversationPiece c3 = new ConversationPiece() { id = data[2].ID, text = data[2].texte, options = new List<ConversationOption>(), hint = data[2].hint };
        donneurDeQuete.GetComponent<ConversationScript>().Add(c3);

        ConversationPiece c4 = new ConversationPiece() { id = data[3].ID, text = data[3].texte, options = new List<ConversationOption>(), hint = data[3].hint };
        donneurDeQuete.GetComponent<ConversationScript>().Add(c4);

        ConversationPiece c5 = new ConversationPiece() { id = data[4].ID, text = data[4].texte, options = new List<ConversationOption>(), hint = data[4].hint };
        donneurDeQuete.GetComponent<ConversationScript>().Add(c5);

        donneurDeQuete.GetComponent<ConversationScript>().OnAfterDeserialize();

        //gardeForestier
        c1 = new ConversationPiece() { id = data[5].ID, text = data[5].texte, options = new List<ConversationOption>(), hint = data[5].hint };
        gardeForestier.GetComponent<ConversationScript>().Add(c1);

        gardeForestier.GetComponent<ConversationScript>().OnAfterDeserialize();

        //randonneur
        c1 = new ConversationPiece() { id = data[6].ID, text = data[6].texte, options = new List<ConversationOption>(), hint = data[6].hint };
        randonneur.GetComponent<ConversationScript>().Add(c1);

        randonneur.GetComponent<ConversationScript>().OnAfterDeserialize();

        //photographe
        c1 = new ConversationPiece() { id = data[7].ID, text = data[7].texte, options = new List<ConversationOption>(), hint = data[7].hint };
        photographe.GetComponent<ConversationScript>().Add(c1);

        photographe.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void donnerQuete()
    {
        ency.addInfoToList(data2[0].hint, ency.quete);
        //GOPointer.GameControl.GetComponent<GameControlScript>().setTrue();
        //SELF
        donneurDeQuete.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[11].ID, text = data[11].texte, options = new List<ConversationOption>(), hint = data[11].hint };
        donneurDeQuete.GetComponent<ConversationScript>().items.Add(c);
        donneurDeQuete.GetComponent<ConversationScript>().OnAfterDeserialize();

        // GARDE
        gardeForestier.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = data[12].branche1Reponse, targetId = data[1].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[12].branche2Reponse, targetId = data[12].branche2ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[12].ID, text = data[12].texte, options = new List<ConversationOption>(), hint = data[12].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        gardeForestier.GetComponent<ConversationScript>().Add(c1);

        ConversationOption o3 = new ConversationOption() { text = data[13].branche1Reponse, targetId = data[13].branche1ID };
        ConversationPiece c2 = new ConversationPiece() { id = data[13].ID, text = data[13].texte, options = new List<ConversationOption>(), hint = data[13].hint };
        c2.options.Add(o3);
        gardeForestier.GetComponent<ConversationScript>().Add(c2);

        ConversationPiece c3 = new ConversationPiece() { id = data[14].ID, text = data[14].texte, options = new List<ConversationOption>(), hint = data[14].hint };
        gardeForestier.GetComponent<ConversationScript>().Add(c3);

        ConversationPiece c4 = new ConversationPiece() { id = data[15].ID, text = data[15].texte, options = new List<ConversationOption>(), hint = data[15].hint };
        gardeForestier.GetComponent<ConversationScript>().Add(c4);
        gardeForestier.GetComponent<ConversationScript>().OnAfterDeserialize();

    }

    public void infosGardeForestier()
    {
        ency.addInfoToList(data2[1].hint, ency.quete);
        //GARDE
        gardeForestier.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[16].ID, text = data[16].texte, options = new List<ConversationOption>(), hint = data[16].hint };
        gardeForestier.GetComponent<ConversationScript>().items.Add(c);
        gardeForestier.GetComponent<ConversationScript>().OnAfterDeserialize();

        //RANDONNEUR
        randonneur.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = data[17].branche1Reponse, targetId = data[17].branche1ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[17].ID, text = data[17].texte, options = new List<ConversationOption>(), hint = data[17].hint };
        c1.options.Add(o1);
        randonneur.GetComponent<ConversationScript>().Add(c1);

        ConversationOption o2 = new ConversationOption() { text = data[18].branche1Reponse, targetId = data[18].branche1ID };
        ConversationPiece c2 = new ConversationPiece() { id = data[18].ID, text = data[18].texte, options = new List<ConversationOption>(), hint = data[18].hint };
        c2.options.Add(o2);
        randonneur.GetComponent<ConversationScript>().Add(c2);

        ConversationOption o3 = new ConversationOption() { text = data[19].branche1Reponse, targetId = data[19].branche1ID };
        ConversationPiece c3 = new ConversationPiece() { id = data[19].ID, text = data[19].texte, options = new List<ConversationOption>(), hint = data[19].hint };
        c3.options.Add(o3);
        randonneur.GetComponent<ConversationScript>().Add(c3);

        ConversationPiece c4 = new ConversationPiece() { id = data[20].ID, text = data[20].texte, options = new List<ConversationOption>(), hint = data[20].hint };
        randonneur.GetComponent<ConversationScript>().Add(c4);
        randonneur.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void infosRandonneur()
    {
        ency.addInfoToList(data2[2].hint, ency.quete);
        //SELF
        randonneur.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[21].ID, text = data[21].texte, options = new List<ConversationOption>(), hint = data[21].hint };
        randonneur.GetComponent<ConversationScript>().items.Add(c);
        randonneur.GetComponent<ConversationScript>().OnAfterDeserialize();
        // PHOTOGRAPHE
        photographe.GetComponent<ConversationScript>().items.Clear();

        ConversationOption o1 = new ConversationOption() { text = data[22].branche1Reponse, targetId = data[22].branche1ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[22].ID, text = data[22].texte, options = new List<ConversationOption>(), hint = data[22].hint };
        c1.options.Add(o1);
        photographe.GetComponent<ConversationScript>().Add(c1);

        ConversationPiece c2 = new ConversationPiece() { id = data[23].ID, text = data[23].texte, options = new List<ConversationOption>(), hint = data[23].hint };
        photographe.GetComponent<ConversationScript>().Add(c2);
        photographe.GetComponent<ConversationScript>().OnAfterDeserialize();
    }

    public void donnerPhotographe()
    {
        ency.addInfoToList(data2[3].hint, ency.quete);
        //PHOTOGRAPHE
        photographe.GetComponent<ConversationScript>().items.Clear();
        ConversationPiece c = new ConversationPiece() { id = data[24].ID, text = data[24].texte, options = new List<ConversationOption>(), hint = data[24].hint };
        photographe.GetComponent<ConversationScript>().items.Add(c);
        photographe.GetComponent<ConversationScript>().OnAfterDeserialize();
    }
}