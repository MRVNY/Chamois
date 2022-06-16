using System.Collections;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using RPGM.UI;
using UnityEngine;
using TMPro;

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
            if (ci.hint != "")
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
                    /// <summary>
                    /// Voir le script chamoisInfosPNJ
                    /// </summary>
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
                    var script = collec.GetComponent<randonneurQueteScript>();
                    var script2 = collec.GetComponent<randonneurRando>();
                    switch (ci.hint)
                    {
                        case "rand1":
                            script.donnerRando1();
                            break;
                        case "rand2":
                            script.donnerRando2();
                            break;
                        case "rand3":
                            script.donnerRando3();
                            break;
                        case "rand4":
                            script.donnerRando4();
                            break;
                        case "rand5":
                            script.donnerRando5();
                            break;
                        case "start1":
                            script.lancerRando1();
                            break;
                        case "suite1":
                            script.suite_Rando1();
                            break;
                        case "end1":
                            script.terminerRando1();
                            break;
                        case "start2":
                            script.lancerRando2();
                            break;
                        case "end2":
                            script.terminerRando2();
                            break;
                        case "start3":
                            script.lancerRando3();
                            break;
                        case "end3":
                            script.terminerRando3();
                            break;
                        case "start4":
                            script.lancerRando4();
                            break;
                        case "end4":
                            script.terminerRando4();
                            break;
                        case "start5":
                            script.lancerRando5();
                            break;
                        case "end5":
                            script.terminerRando5();
                            break;
                        case "infoRegVehicule":
                            script.vehicule();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegSurvol":
                            script.survol();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegChiens":
                            script.chien();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegAppareil":
                            script.appareils();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegCamping":
                            script.camping();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegFeux":
                            script.feux();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegDerangementFaune":
                            script.derangementFaune();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegRespect":
                            script.respect();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRegSentierBalise":
                            script.sentierBalise();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRecFaune":
                            script.recommandationFaune();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoRecBalise":
                            script.recommandationBalise();
                            dataStorer.nbInfos += 1;
                            break;
                        case "infoConsPrevenir":
                            script.conseilPrevenir();
                            dataStorer.nbInfos += 1;
                            break;
                        // randonnées réelles

                        // Randonnée de l'Épion
                        case "randEpion":
                            script2.donnerRandoEpion();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startEpion":
                            script2.lancerRandoEpion();
                            break;
                        case "suiteEpion":
                            script2.suiteRandoEpion();
                            break;
                        case "endEpion":
                            script2.terminerEpion();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée du Fort de la Batterie
                        case "randBatterie":
                            script2.donnerRandoBatterie();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startBatterie":
                            script2.lancerRandoBatterie();
                            break;
                        case "suiteBatterie":
                            script2.suiteRandoBatterie();
                            break;
                        case "endBatterie":
                            script2.terminerBatterie();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée de la Dent des Portes
                        case "randDentPortes":
                            script2.donnerRandoDentPortes();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startDentPortes":
                            script2.lancerRandoDentPortes();
                            break;
                        case "suiteDentPortes":
                            script2.suiteRandoDentPortes();
                            break;
                        case "endDentPortes":
                            script2.terminerDentPortes();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée du Grand Roc
                        case "randGrandRoc":
                            script2.donnerRandoGrandRoc();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startGrandRoc":
                            script2.lancerRandoGrandRoc();
                            break;
                        case "suiteGrandRoc":
                            script2.suiteRandoGrandRoc();
                            break;
                        case "endGrandRoc":
                            script2.terminerGrandRoc();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée de la Pointe de la Chaurionde
                        case "randPointeChaurionde":
                            script2.donnerRandoPointeChaurionde();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startPointeChaurionde":
                            script2.lancerRandoPointeChaurionde();
                            break;
                        case "suitePointeChaurionde":
                            script2.suiteRandoPointeChaurionde();
                            break;
                        case "endPointeChaurionde":
                            script2.terminerPointeChaurionde();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée du Mont Morbier
                        case "randMorbier":
                            script2.donnerRandoMorbier();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startMorbier":
                            script2.lancerRandoMorbier();
                            break;
                        case "suiteMorbier":
                            script2.suiteRandoMorbier();
                            break;
                        case "endMorbier":
                            script2.terminerMorbier();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée de la Croix du Nivolet
                        case "randNivolet":
                            script2.donnerRandoNivolet();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startNivolet":
                            script2.lancerRandoNivolet();
                            break;
                        case "suiteNivolet":
                            script2.suiteRandoNivolet();
                            break;
                        case "endNivolet":
                            script2.terminerNivolet();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée de la Pointe de la Galoppaz
                        case "randGaloppaz":
                            script2.donnerRandoGaloppaz();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startGaloppaz":
                            script2.lancerRandoGaloppaz();
                            break;
                        case "suiteGaloppaz":
                            script2.suiteRandoGaloppaz();
                            break;
                        case "endGaloppaz":
                            script2.terminerGaloppaz();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée du Mont Colombier
                        case "randColombier":
                            script2.donnerRandoColombier();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startColombier":
                            script2.lancerRandoColombier();
                            break;
                        case "suiteColombier":
                            script2.suiteRandoColombier();
                            break;
                        case "endColombier":
                            script2.terminerColombier();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée de la Pointe de l'Arcalod
                        case "randArcalod":
                            script2.donnerRandoArcalod();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startArcalod":
                            script2.lancerRandoArcalod();
                            break;
                        case "suiteArcalod":
                            script2.suiteRandoArcalod();
                            break;
                        case "endArcalod":
                            script2.terminerArcalod();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        // Randonnée du Mont Trélod
                        case "randTrelod":
                            script2.donnerRandoTrelod();
                            GOPointer.RandoDecouverteText.GetComponent<TextMeshProUGUI>().SetText("Randonnées découvertes : \n11 / 11");
                            break;
                        case "startTrelod":
                            script2.lancerRandoTrelod();
                            break;
                        case "suiteTrelod":
                            script2.suiteRandoTrelod();
                            break;
                        case "endTrelod":
                            script2.terminerTrelod();
                            dataStorer.nbRandos += 1;
                            dataStorer.nbRandosMemePartie += 1;
                            PlayerPrefs.SetInt("nbRandos", (PlayerPrefs.GetInt("nbRandos") + 1));
                            break;

                        default:
                            break;
                    }
                }
            }

            //calculate a position above the player's sprite.
            var position = gameObject.transform.position;
            var sr = gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                position += new Vector3(0, 2 * sr.size.y + (ci.options.Count == 0 ? 0.1f : 0.2f), 0);
            }

            //show the dialog
            model.dialog.Show(position, ci.text);
            var animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Talk", true);
                var ev = Schedule.Add<StopTalking>(2);
                ev.animator = animator;
            }

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
                //do nothing
            }
            else
            {
                //Create option buttons below the dialog.
                for (var i = 0; i < ci.options.Count; i++)
                {
                    model.dialog.SetButton(i, ci.options[i].text);
                }

                switch (ci.options.Count) {
                    default:
                        break;
                    case 1:
                        model.dialog.dialogLayout.buttonA.Nullify();
                        model.dialog.dialogLayout.buttonA.onClickEvent += () =>
                         {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[0].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        break;
                    case 2:
                        model.dialog.dialogLayout.buttonA.Nullify();
                        model.dialog.dialogLayout.buttonB.Nullify();
                        model.dialog.dialogLayout.buttonA.onClickEvent += () =>
                        {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[0].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        model.dialog.dialogLayout.buttonB.onClickEvent += () =>
                        {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[1].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        break;
                    case 3:
                        model.dialog.dialogLayout.buttonA.Nullify();
                        model.dialog.dialogLayout.buttonB.Nullify();
                        model.dialog.dialogLayout.buttonC.Nullify();
                        model.dialog.dialogLayout.buttonA.onClickEvent += () =>
                        {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[0].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        model.dialog.dialogLayout.buttonB.onClickEvent += () =>
                        {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[1].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        model.dialog.dialogLayout.buttonC.onClickEvent += () =>
                        {//hide the old text, so we can display the new.
                            model.dialog.Hide();

                            //This is the id of the next conversation piece.
                            var next = ci.options[2].targetId;

                            //Make sure it actually exists!
                            if (conversation.ContainsKey(next))
                            {
                                //find the conversation piece object and setup a new event with correct parameters.
                                var c = conversation.Get(next);
                                var ev = Schedule.Add<ShowConversation>(0.25f);
                                ev.conversation = conversation;
                                ev.gameObject = gameObject;
                                ev.conversationItemKey = next;
                            }
                            else
                            {
                                Debug.LogError($"No conversation with ID:{next}");
                            }
                        };
                        break;
                }

                /*
                //if user pickes this option, schedule an event to show the new option.
                model.dialog.onButton += (index) =>
                {
                    //hide the old text, so we can display the new.
                    model.dialog.Hide();

                    //This is the id of the next conversation piece.
                    var next = ci.options[index].targetId;

                    //Make sure it actually exists!
                    if (conversation.ContainsKey(next))
                    {
                        //find the conversation piece object and setup a new event with correct parameters.
                        var c = conversation.Get(next);
                        var ev = Schedule.Add<ShowConversation>(0.25f);
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
            model.dialog.SetIcon(ci.image);
        }

    }
}