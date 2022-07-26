using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class QuestManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI hint;
    public TextMeshProUGUI finished;

    public GameObject left;
    public GameObject right;
    private int onPage = 0;

    private Hashtable allQuests = new Hashtable();
    [NonSerialized] public List<PlayerQuest> foundQuests = new List<PlayerQuest>();
    private PlayerQuest empty;
    [NonSerialized] public PlayerQuest currentQuest;

    public GameObject target;
    public string oldTag;
    
    public static QuestManager Instance;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        if (foundQuests.Count == 0)
        {
            JObject objs = (JObject)JObject.Parse(jsonFile.text)[Global.Personnage];

            foreach (JProperty obj in objs.OfType<JProperty>())
            {
                PlayerQuest tmp = new PlayerQuest(obj.Name, obj.Value["description"]?.ToString());
                
                if (obj.Value["hints"] != null)
                {
                    foreach (JProperty hint in obj.Value["hints"])
                    {
                        tmp.hints.Add(hint.Name, hint.Value.ToString());
                    }
                }

                tmp.participants = ((string)obj.Value["participants"])?.Split(',');

                tmp.nextQuest = obj.Value["nextQuest"]?.ToString();

                allQuests.Add(obj.Name, tmp);
            }
            
            empty = new PlayerQuest("Pas de quête en cours", "Baladez dans les Baugues pour en touver !");
            empty.isFinished = true;
            foundQuests.Insert(0,empty);
        }
    }

    private void OnEnable()
    {
        if(foundQuests.Count==0)
        {
            Start();
        }
        
        currentQuest = foundQuests[0];
        onPage = 0;
        LoadPage(currentQuest);
    }

    public void addQuest(string title)
    {
        addQuest(title,0);
    }
    
    public void addQuest(string title, int steps)
    {
        if (foundQuests.Contains(empty))
        {
            foundQuests.Remove(empty);
        }

        if (currentQuest.isFinished)
        {
            if (allQuests.ContainsKey(title))
            {
                PlayerQuest tmp = (PlayerQuest)allQuests[title];
                tmp.totalSteps = steps;
                foundQuests.Insert(0,tmp);
                currentQuest = tmp;
            }
        
            Notifier.Instance.NewQuest();

            switch (title)
            {
                case "UnChamoisMalade":
                    startKillQuest();
                    break;
                case "TrouverTroupeau":
                    startZoneQuest("Troupeau");
                    break;
                case "Survivre":
                    startTimeQuest(new DateTime(2022,5,1));
                    break;
            }
        }
        else
        {
            GOPointer.CanvasGuideJeu.SetActive(true);
            GuideManager.Instance.guideText.SetText("Vous avez déjà une quête en cours !");
        }
        
    }

    public void LoadPage(PlayerQuest quest)
    {
        title.text = quest.title;
        description.text = quest.desc;
        finished.text = quest!=empty ? (quest.isFinished ? "Finie" : "En cours") : "";
        
        hint.text = quest.hints.ContainsKey(quest.hintName) ? quest.hints[quest.hintName].ToString() : "";
        if (quest.totalSteps > 0)
        {
            hint.text = "Points validés : " + (quest.currentStep+1) + "/" + quest.totalSteps;
        }
        
        left.SetActive(onPage > 0);
        right.SetActive(onPage < foundQuests.Count - 1);
    }

    public void NextPage()
    {
        if(onPage < foundQuests.Count - 1)
        {
            onPage++;
            LoadPage(foundQuests[onPage]);
        }
    }
    
    public void PreviousPage()
    {
        if(onPage > 0)
        {
            onPage--;
            LoadPage(foundQuests[onPage]);
        }
    }

    public void startKillQuest()
    {
        var listDeChamois = GOPointer.ListeChamoisSauvages.GetComponentsInChildren<SpriteRenderer>(false);
        
        var i = Random.Range(0, listDeChamois.Length);
        target = listDeChamois[i].gameObject;
        listDeChamois[i].color = Color.red;
        oldTag = target.tag;
        target.tag = "Target";
    }
    
    public void endKillQuest()
    {
        target.GetComponent<SpriteRenderer>().color = Color.white;
        endQuest();
    }

    public void startZoneQuest(string zoneName)
    {
        target = ((Collider2D)ZoneManager.Instance.zones[zoneName])?.gameObject;
        if(target != null)
        {
            oldTag = target.tag;
            target.tag = "Target";
        }
    }

    void startTimeQuest(DateTime endDate)
    {
        DayNight.Instance.goalDate = endDate;
    }

    public void endQuest()
    {
        if(target!=null) target.tag = oldTag;
        target = null;
        currentQuest.isFinished = true;
        
        if(currentQuest.participants!=null)
        {
            foreach (var npc in currentQuest.participants)
            {
                ((NPCController)NPCManager.Instance.currentNPCTable[npc]).setFirstNode("");
            }
        }
        
        if(currentQuest.nextQuest!=null)
        {
            addQuest(currentQuest.nextQuest);
        }
        
        GOPointer.CanvasGuideJeu.SetActive(true);
        GuideManager.Instance.guideText.SetText("Vous avez fini la quête !");

        Notifier.Instance.NewQuest();
        
        if(!foundQuests.Contains(empty) && foundQuests.Count==allQuests.Count && currentQuest.isFinished)
        {
            GameOver.Instance.End("Vous avez fini toutes les quêtes !");
        }
    }

}
