using System.Collections.Generic;
using System.Linq;
using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace RPGM.Gameplay
{
    /// <summary>
    /// Main class for implementing NPC game objects & starting dialogs
    /// </summary>
   
    public class InteractableController : MonoBehaviour
    {
        protected InteractiveButtons Buttons;
        protected GameObject actionButton;
        protected new Camera camera;
        protected bool isTarget = false;

        public string type = "NPC";

        private string message = "";

        // Quete non-utilise
        protected Quest activeQuest = null;
        protected Quest[] quests;

        //Permet d'acceder a des fonctions, notamment dialog.Hide()
        protected GameModel model = Schedule.GetModel<GameModel>();
    
        void Start()
        {
            if (type != "NPC")
            {
                Buttons = GOPointer.interactiveButtons.GetComponent<InteractiveButtons>();
                camera = CameraControllerJoy.Instance.GetComponent<Camera>();
            }

            if (type == "Recharge" && Global.Personnage == "Chasseur")
            {
                actionButton = Buttons.recharge;
            }

            if(type == "Rando" && Global.Personnage == "Randonneur")
            {
                actionButton = Buttons.validate;
            }
            
            if(type == "Trash" && Global.Personnage == "Chasseur")
            {
                actionButton = Buttons.pickUp;
            }
            
            if(type == "TrashCan" && Global.Personnage == "Chasseur")
            {
                actionButton = Buttons.throwTrash;
            }
            
            if (actionButton != null)
            {
                actionButton.SetActive(false);
            }

        }
        protected void OnEnable()
        {
            // Ummm... there're no Quests in any children
            quests = gameObject.GetComponentsInChildren<Quest>();
        }
        
        protected void Update()
        {
            if(actionButton!=null && isTarget){
                actionButton.transform.position = Vector3.up * 100 + camera.WorldToScreenPoint(transform.position);
                //Debug.Log(transform.position);
            }

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
                isTarget = true;
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
                isTarget = false;
            }
        }

        void onclick()
        {
            if(message!=""){
                GOPointer.CanvasGuideJeu.GetComponent<GuideManager>().showGuide(message);
                //Debug.Log(message);
            }
            
            if(type=="Rando"){
                if(RandoManager.currentPoint <= RandoManager.totalPoints-1){
                    GOPointer.RandoManager.nextRando(this);
                }
            }

            if (type == "Trash")
            {
                chasseurDechet.dechetsMain++;
                Destroy(gameObject);
                chasseurDechet.updateView();
            }
            
            if(type == "TrashCan")
            {
                chasseurDechet.dechetsMain = 0;
                chasseurDechet.updateView();
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

        public void setMessage(string msg){
            message = msg;
        }
    }
}