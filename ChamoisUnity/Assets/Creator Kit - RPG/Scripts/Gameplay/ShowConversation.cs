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
                GameObject collec = GOPointer.NPCCollection;
                if(Global.Personnage == "Chasseur")
                {
                    /// <summary>
                    /// Voir le script ChasseurQueteSCript
                    /// </summary>
                    var script = collec.GetComponent<chasseurQueteScript>();
                    var script2 = collec.GetComponent<chasseurInfosPNJ>();


                    switch (ci.hint)
                    {
                        case "debutQuete":
                            script.donnerQuete();
                            break;
                        case "suiteForestier":
                            script.infosGardeForestier();
                            break;
                        case "suiteRandonneur":
                            script.infosRandonneur();
                            break;
                        case "suitePhotographe":
                            script.donnerPhotographe();
                            break;
                        case "recharger":
                            collec.GetComponent<MunitionsQuetesScript>().recharger();
                            break;
                        case "reponsePoidsChevreuil":
                            script2.poidsChevreuil();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "predateursPresents":
                            script2.predateursPresents();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "periodeChasse":
                            script2.periodeChasse();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "regulationChasseChamois":
                            script2.regulationChasseChamois();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "habitatChamois":
                            script2.habitatChamois();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "sociabiliteChamois":
                            script2.sociabiliteChamois();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "regimeChamois":
                            script2.regimeChamois();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "poidsChamois":
                            script2.poidsChamois();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "faunePresente":
                            script2.faunePresente();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "chasseurTelemetre":
                            script2.chasseurTelemetre();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "utiliteChasse":
                            script2.utiliteChasse();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        case "loupRegulation":
                            script2.loupRegulation();
                            GOPointer.PlayerChasseur.GetComponent<DataStorerChasseur>().nbInfos += 1;
                            break;
                        default:
                            break;
                    }
                }

                if (Global.Personnage == "Chamois")
                {
                    // <summary>
                    // Voir le script chamoisInfosPNJ
                    // </summary>
                    var script = collec.GetComponent<chamoisInfosPNJ>();


                    switch (ci.hint)
                    {
                        case "deplacementRandonneur":
                            script.deplacementRandonneur();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "brucellose":
                            script.brucellose();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "vitesseSentiers":
                            script.vitesseSentiers();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "challengeChamois":
                            script.challengeChamois();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "barriereComportementale":
                            script.barriereComportementale();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "alimentationEspeces":
                            script.alimentationEspeces();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "plantesBuffet":
                            script.plantesBuffet();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "vigilance":
                            script.vigilance();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "deplacements":
                            script.deplacements();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "gestationChamois":
                            script.gestationChamois();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "vitesseCourse":
                            script.vitesseCourse();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        case "dureeVie":
                            script.dureeVie();
                            GOPointer.PlayerChamois.GetComponent<DataStorer>().nbInfos += 1;
                            break;
                        default:
                            break;
                    }
                }

                if (Global.Personnage == "Randonneur")
                {
                    /// <summary>
                    /// Voir le script randonneurQueteScript
                    /// </summary>

                    if(ci.hint.Length>3 && ci.hint.Substring(0, 3)=="ran"){
                        RandoManager randoManager = GOPointer.RandoManager;
                        randoManager.startRando(ci.hint.Substring(4));
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