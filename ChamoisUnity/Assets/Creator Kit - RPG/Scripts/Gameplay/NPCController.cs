using System.Collections.Generic;
using System.Linq;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Main class for implementing NPC game objects & starting dialogs
    /// </summary>
   
    public class NPCController : InteractableController
    {
        public ConversationScript conversations;
        public string firstNode = "";
        private JObject convoTree;
        public TextAsset jsonFile;

        new void Start()
        {
            if(jsonFile != null){
                convoTree = JObject.Parse(jsonFile.text);
                conversations = gameObject.AddComponent<ConversationScript>();

                foreach(JProperty obj in convoTree.OfType<JProperty>()){
                    ConversationPiece c1 = new ConversationPiece() { id = obj.Name, text = (string)obj.Value["text"], options = new List<ConversationOption>(), hint = (string)obj.Value["hint"]};
                    if (obj.Value["choices"] != null)
                    {
                        foreach (JProperty cho in obj.Value["choices"].OfType<JProperty>())
                        {
                            c1.options.Add(new ConversationOption() { text = (string)cho.Value, targetId = cho.Name});
                        }
                    }
                    conversations.Add(c1);
                }
                conversations.OnAfterDeserialize();
            }

            base.Start();
        }

        void Update()
        {
            if(actionButton!=null && firstNode!="")
                actionButton.transform.position = Vector3.up * 100 + camera.WorldToScreenPoint(transform.position);
        }

        /// <summary>
        /// Si ce qui rentre en dans la zone du NPC est un joueur, on test son role et on demande l'affichage de la piece de conversation adequate
        /// A utiliser avec les zones de Draw2DShape
        /// </summary>
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Detector") && actionButton!=null)
            {
                actionButton.SetActive(true);
                actionButton.GetComponent<Button>().onClick.RemoveAllListeners();
                actionButton.GetComponent<Button>().onClick.AddListener(() => { onclick(); });
            }
            
            if (collision.gameObject.CompareTag("Detector"))
            {
                firstNode = Global.persoNum[Global.Personnage];
            }
        }

        /// <summary>
        /// Si le joueur quitte le rayon du NPC, on cache le dialogue
        /// </summary>
        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Detector") && actionButton!=null)
            {
                actionButton.GetComponent<Button>().onClick.RemoveAllListeners();
                actionButton.SetActive(false);
            }

            firstNode = "";
        }

        void onclick()
        {
            var c = GetConversation();
            if (c!=null && c.isInIndex(firstNode))
            {
                SpriteRenderer myImage = gameObject.GetComponent<SpriteRenderer>();
                GOPointer.UIManager.GetComponent<UIManager>().startVisualNovel(myImage);
                var ev = Schedule.Add<Events.ShowConversation>();
                ev.conversation = c;
                ev.npc = this;
                ev.gameObject = gameObject;
                ev.conversationItemKey = firstNode;
            }
        }

        /// <summary>
        /// Pas encore d'utilisation de quete, par defaut retourne le premier element de la liste de dialogues
        /// </summary>
        ConversationScript GetConversation()
        {
            // There are two ways to get the conversation: 1. by conversationscrit 2. by JSON
            if (activeQuest == null && conversations!=null){
                return conversations;
            }
            foreach (var q in quests)
            {
                if (q == activeQuest)
                {
                    if (q.IsQuestComplete())
                    {
                        CompleteQuest(q);
                        return q.questCompletedConversation;
                    }
                    return q.questInProgressConversation;
                }
            }
            return null;
        }
    }
}