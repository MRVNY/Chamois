using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Main class for implementing NPC game objects & starting dialogs
    /// </summary>
   
    public class NPCController : MonoBehaviour
    {
        //Liste des elements dans le srcipt de conversation
        public ConversationScript[] conversations;

        // Quete non-utilise
        Quest activeQuest = null;
        Quest[] quests;

        //Permet d'acceder a des fonctions, notamment dialog.Hide()
        GameModel model = Schedule.GetModel<GameModel>();
        void OnEnable()
        {
            quests = gameObject.GetComponentsInChildren<Quest>();
        }

        /// <summary>
        /// Si ce qui rentre en contact avec le NPC est un joueur, on test son role et on demande l'affichage de la piece de conversation adequate
        /// </summary>
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                string foo;

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
                var c = GetConversation();
                if (c.isInIndex(foo))
                {
                    var ev = Schedule.Add<Events.ShowConversation>();
                    ev.conversation = c;
                    ev.npc = this;
                    ev.gameObject = gameObject;
                    ev.conversationItemKey = foo;
                }
            }
        }

        /// <summary>
        /// Si ce qui rentre en dans la zone du NPC est un joueur, on test son role et on demande l'affichage de la piece de conversation adequate
        /// A utiliser avec les zones de Draw2DShape
        /// </summary>
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                string foo;

                if (Global.Personnage == "Chamois")
                {
                    foo = "11";
                }
                else if (Global.Personnage == "Randonneur")
                {
                    foo = "22";
                }
                else if (Global.Personnage == "Chasseur")
                {
                    foo = "33";
                }
                else
                {
                    foo = "";
                }
                var c = GetConversation();
                if (c.isInIndex(foo))
                {
                    var ev = Schedule.Add<Events.ShowConversation>();
                    ev.conversation = c;
                    ev.npc = this;
                    ev.gameObject = gameObject;
                    ev.conversationItemKey = foo;
                }
            }
        }

        /// <summary>
        /// Si le joueur quitte le rayon du NPC, on cache le dialogue
        /// </summary>
        public void OnTriggerExit2D(Collider2D collision)
        {
            if (model.dialog) {
                if (collision.gameObject.CompareTag("Player"))
                {
                    model.dialog.Hide();
                }
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
            if (activeQuest == null){
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