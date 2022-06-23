using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using RPGM.Core;
using RPGM.Gameplay;
using RPGM.UI;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RPGM.Events
{
    /// <summary>
    /// This event will start a conversation with an NPC using a conversation script.
    /// </summary>
    /// <typeparam name="ShowConversation"></typeparam>
    public class ShowConversation : Event<ShowConversation>
    {
        public NPCController npc;
        public GameObject gameObject;
        public ConversationScript conversation;
        public string conversationItemKey;

        private DataStorerRandonneur dataStorer;

        private Button nextButton = GOPointer.VisualNovel.GetComponent<Button>();
        private Image nextButtonImage = GOPointer.VisualNovel.GetComponent<Image>();
        
        NPCManager NPCManager = GOPointer.NPCCollection.GetComponent<NPCManager>();

        public ShowConversation(){
            dataStorer = GOPointer.PlayerRandonneur.GetComponent<DataStorerRandonneur>();
        }

        public override void Execute()
        {
            ConversationPiece ci;
            //default to first conversation item if no key is specified, else find the right conversation item.
            if (string.IsNullOrEmpty(conversationItemKey))
            {
                ci = conversation.items[0];
            }
            else
            {
                ci = conversation.Get(conversationItemKey);
                if (conversationItemKey.Length == 1)
                {
                    nextButton.enabled = false;
                    nextButtonImage.enabled = false;
                }
            }

            //if this item contains an unstarted quest, schedule a start quest event for the quest.
            if (ci.quest != null)
            {
                if (!ci.quest.isStarted)
                {
                    var ev = Schedule.Add<StartQuest>(1);
                    ev.quest = ci.quest;
                    ev.npc = npc;
                }
                if (ci.quest.isFinished && ci.quest.questCompletedConversation != null)
                {
                    ci = ci.quest.questCompletedConversation.items[0];
                }
            }

            /// <summary>
            /// Voir le script ConversationPiece, et l'utilisation de hint
            /// </summary>
            if (ci.hint!=null && ci.hint != "")
            {
                if(Global.Personnage == "Chasseur")
                {
                    NPCManager.actionChasseur(ci.hint);
                }

                if (Global.Personnage == "Chamois")
                {
                    NPCManager.actionChamois(ci.hint);
                }

                if (Global.Personnage == "Randonneur")
                {
                    if(ci.hint.Length>3 && ci.hint.Substring(0, 3)=="ran"){
                        RandoManager randoManager = GOPointer.RandoManager;
                        randoManager.startRando(ci.hint.Substring(4));
                    }
                    else
                    {
                        NPCManager.actionRando(ci.hint);
                    }
                }
            }

            //show the dialog
            VisualNovel dialog = model.getDialog();
            dialog.Show(ci.text, ci.options);

            // var animator = gameObject.GetComponent<Animator>();
            // if (animator != null)
            // {
            //     animator.SetBool("Talk", true);
            //     var ev = Schedule.Add<StopTalking>(2);
            //     ev.animator = animator;
            // }

            if (ci.audio != null)
            {
                UserInterfaceAudio.PlayClip(ci.audio);
            }

            //speak some gibberish at two speech syllables per word.
            UserInterfaceAudio.Speak(gameObject.GetInstanceID(), ci.text.Split(' ').Length * 2, 1);

            //if this conversation item has an id, register it in the model.
            if (!string.IsNullOrEmpty(ci.id))
                model.RegisterConversation(gameObject, ci.id);

            //setup conversation choices, if any.
            if (ci.options.Count == 0)
            {
                nextButton.enabled = true;
                nextButtonImage.enabled = true;
            }
            else
            {
                for (int i = 0; i < ci.options.Count; i++)
                {
                    //dialog.SetButton(i, ci.options[i].text);
                    
                    dialog.dialogLayout.buttons[i].Nullify();
                    dialog.dialogLayout.buttons[i].onClickEvent += () =>
                    {
                        //hide the old text, so we can display the new.
                        dialog.Hide();

                        //This is the id of the next conversation piece.
                        int index = dialog.getClickedButton();
                        var next = ci.options[index].targetId;

                        //Make sure it actually exists!
                        if (conversation.ContainsKey(next))
                        {
                            //find the conversation piece object and setup a new event with correct parameters.
                            var c = conversation.Get(next);
                            var ev = Schedule.Add<ShowConversation>();
                            ev.conversation = conversation;
                            ev.gameObject = gameObject;
                            ev.conversationItemKey = next;
                        }
                        else
                        {
                            Debug.LogError($"No conversation with ID:{next}");
                        }
                    };
                }
                

                /*
                //if user pickes this option, schedule an event to show the new option.
                model.getDialog().onButton += (index) =>
                {
                    //hide the old text, so we can display the new.
                    model.getDialog().Hide();

                    //This is the id of the next conversation piece.
                    var next = ci.options[index].targetId;

                    //Make sure it actually exists!
                    if (conversation.ContainsKey(next))
                    {
                        //find the conversation piece object and setup a new event with correct parameters.
                        var c = conversation.Get(next);
                        var ev = Schedule.Add<ShowConversation>();
                        ev.conversation = conversation;
                        ev.gameObject = gameObject;
                        ev.conversationItemKey = next;
                    }
                    else
                    {
                        Debug.LogError($"No conversation with ID:{next}");
                    }
                };*/

            }

            //if conversation has an icon associated, this will display it.
            //dialog.SetIcon(ci.image);
        }

    }
}