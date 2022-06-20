using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Main class for implementing NPC game objects & starting dialogs
    /// </summary>
   
    public class NPCController : MonoBehaviour
    {
        private InteractiveButtons Buttons;
        private GameObject actionButton;
        private Camera camera;

        public string type = "NPC";
        //Liste des elements dans le srcipt de conversation
        public ConversationScript[] conversations;
        private string foo = "";

        // Quete non-utilise
        Quest activeQuest = null;
        Quest[] quests;

        //Permet d'acceder a des fonctions, notamment dialog.Hide()
        GameModel model = Schedule.GetModel<GameModel>();
        //GameModel model = new GameModel();
        
        void Start()
        {
            if (type != "NPC")
            {
                Buttons = GOPointer.interactiveButtons.GetComponent<InteractiveButtons>();
                camera = GOPointer.CameraReg.GetComponentInChildren<Camera>();
            }

            if (type == "DonneurRando")
            {
                actionButton = Buttons.talk;
            }
                
            if (type == "Recharge" && Global.Personnage == "Chasseur")
            {
                actionButton = Buttons.recharge;
            }
               

            if (actionButton != null)
            {
                actionButton.SetActive(false);
            }
        }
        void OnEnable()
        {
            // Ummm... there're no Quests in any children
            quests = gameObject.GetComponentsInChildren<Quest>();
        }
        
        void Update()
        {
            if(actionButton!=null && foo!="")
                actionButton.transform.position = Vector3.up * 100 + camera.WorldToScreenPoint(transform.position);
        }

        /// <summary>
        /// Si ce qui rentre en contact avec le NPC est un joueur, on test son role et on demande l'affichage de la piece de conversation adequate
        /// </summary>
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (Global.Personnage == "Chamois")
                {
                    foo = "1";
                }
                else if (Global.Personnage == "Randonneur")
                {
                    foo = "2";
                }
                else if (Global.Personnage == "Chasseur")
                {
                    foo = "3";
                }
                else
                {
                    foo = "";
                }
                // On recupere la conversation et on lance le script ShowConversation()
            }
        }

        /// <summary>
        /// Si ce qui rentre en dans la zone du NPC est un joueur, on test son role et on demande l'affichage de la piece de conversation adequate
        /// A utiliser avec les zones de Draw2DShape
        /// </summary>
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Detector") && actionButton!=null)
            {
                actionButton.SetActive(true);
                actionButton.GetComponent<Button>().onClick.AddListener(() => { onclick(); });
            }
            
            if (collision.gameObject.CompareTag("Detector"))
            {
                if (Global.Personnage == "Chamois")
                {
                    foo = "1";
                }
                else if (Global.Personnage == "Randonneur")
                {
                    foo = "2";
                }
                else if (Global.Personnage == "Chasseur")
                {
                    foo = "3";
                }
                else
                {
                    foo = "";
                }
            }
        }

        /// <summary>
        /// Si le joueur quitte le rayon du NPC, on cache le dialogue
        /// </summary>
        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Detector") && actionButton!=null)
            {
                actionButton.GetComponent<Button>().onClick.RemoveAllListeners();
                actionButton.SetActive(false);
            }

            foo = "";

            // if (model.getDialog()) {
            //     if (collision.gameObject.CompareTag("Player"))
            //     {
            //         model.getDialog().Hide();
            //     }
            // }
        }

        public void onclick()
        {
            Debug.Log(actionButton.GetComponent<Button>().onClick);
            var c = GetConversation();
            if (c!=null && c.isInIndex(foo))
            {
                GOPointer.UIManager.GetComponent<UIManager>().startVisualNovel();
                var ev = Schedule.Add<Events.ShowConversation>();
                ev.conversation = c;
                ev.npc = this;
                ev.gameObject = gameObject;
                ev.conversationItemKey = foo;
            }
        }

        public void CompleteQuest(Quest q)
        {
            if (activeQuest != q) throw new System.Exception("Completed quest is not the active quest.");
            foreach (var i in activeQuest.requiredItems)
            {
                model.RemoveInventoryItem(i.item, i.count);
            }
            activeQuest.RewardItemsToPlayer();
            activeQuest.OnFinishQuest();
            activeQuest = null;
        }

        public void StartQuest(Quest q)
        {
            if (activeQuest != null) throw new System.Exception("Only one quest should be active.");
            activeQuest = q;
        }

        /// <summary>
        /// Pas encore d'utilisation de quete, par defaut retourne le premier element de la liste de dialogues
        /// </summary>
        ConversationScript GetConversation()
        {
            // There are two ways to get the conversation: 1. by conversationscrit 2. by JSON
            if (activeQuest == null && conversations.Length > 0){
                return conversations[0];
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