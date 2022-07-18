using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;
using UnityEngine.Playables;
using System;

public class MunitionsQuetesScript : MonoBehaviour
{
    public GameObject caisseMun;
    public GameObject modePewpew;

    public TextAsset jsonFile;
    public List<ConversationInfos> data;
    public EncyInfo info;

    // Start is called before the first frame update
    void Start()
    {
        ConversationInfosList infosInJson = JsonUtility.FromJson<ConversationInfosList>(jsonFile.text);
        data = new List<ConversationInfos>();

        foreach (ConversationInfos convinfo in infosInJson.convinfos)
        {
            data.Add(convinfo);
        }

        //caisseMun
        ConversationOption o1 = new ConversationOption() { text = data[8].branche1Reponse, targetId = data[8].branche1ID };
        ConversationOption o2 = new ConversationOption() { text = data[8].branche2Reponse, targetId = data[8].branche2ID };
        ConversationPiece c1 = new ConversationPiece() { id = data[8].ID, text = data[8].texte, options = new List<ConversationOption>(), hint = data[8].hint };
        c1.options.Add(o1);
        c1.options.Add(o2);
        caisseMun.GetComponent<ConversationScript>().Add(c1);

        ConversationPiece c2 = new ConversationPiece() { id = data[9].ID, text = data[9].texte, options = new List<ConversationOption>(), hint = data[9].hint };
        caisseMun.GetComponent<ConversationScript>().Add(c2);

        ConversationPiece c3 = new ConversationPiece() { id = data[10].ID, text = data[10].texte, options = new List<ConversationOption>(), hint = data[10].hint };
        caisseMun.GetComponent<ConversationScript>().Add(c3);

        caisseMun.GetComponent<ConversationScript>().OnAfterDeserialize();
        
        //modePewpew = GOPointer.UIManager.transform.Find("ModePewPew").gameObject;

    }

    public void recharger()
    {
        GOPointer.PlayerChasseur.GetComponent<Munitions>().recupereMunitions();
        if (!modePewpew.activeSelf)
        {
            modePewpew.SetActive(true);
        }
    }
}
