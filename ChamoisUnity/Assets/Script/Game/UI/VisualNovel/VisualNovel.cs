using System;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace RPGM.UI
{
    public class VisualNovel : MonoBehaviour
    {
        private PauseMenu pause;
        private UIManager ui;
        public VNLayout dialogLayout;

        [SerializeField] private SpriteRenderer ChamoisImg;
        [SerializeField] private SpriteRenderer ChasseurImg;
        [SerializeField] private SpriteRenderer RandonneurImg;
        public Image leftImg;
        public Image rightImg;

        public Button nextButton;
        public Image nextButtonImage;
        
        private new TextMeshPro name;
        private TextMeshPro dialog;

        public System.Action<int> onButton;

        private int selectedButton = 0;

        SpriteButton[] buttons;
        Camera mainCamera;
        GameModel model = Schedule.GetModel<GameModel>();
        //SpriteUIElement spriteUIElement;

        // Start is called before the first frame update
        
        void Awake()
        {
            nextButton = GetComponent<Button>();
            nextButtonImage = GetComponent<Image>();
            //dialogLayout = GetComponent<VNLayout>();
            buttons = dialogLayout.buttons;
            for(int j=0; j<buttons.Length; j++)
            {
                dialogLayout.buttons[j].onClickEvent += () => OnButton(j);
            }
            dialogLayout.gameObject.SetActive(false);
            //spriteUIElement = GetComponent<SpriteUIElement>();
            //mainCamera = GameObject.Find("Camera" + Global.Personnage).GetComponent<Camera>();
        }
        
        void Start()
        {
            ui = GOPointer.UIManager.GetComponent<UIManager>();
        }

        private void OnEnable()
        {
            dialogLayout.gameObject.SetActive(true);
        }

        public void Hide()
        {
            UserInterfaceAudio.OnHideDialog();
            //GOPointer.UIManager.GetComponent<UIManager>().endVisualNovel();
        }

        public void End()
        {
            ui.endVisualNovel();
        }

        public void Show(string text, List<ConversationOption> options)
        {
            dialogLayout.gameObject.SetActive(true);
            UserInterfaceAudio.OnShowDialog();
            dialogLayout.SetLayout(text, options);
            //model.input.ChangeState(InputController.State.DialogControl);
            selectedButton = -1;
        }
        

        public void SetIcon(Sprite ciImage)
        {
        }

        // InputController (optinal)
        public void FocusButton(int p0)
        {
            throw new System.NotImplementedException();
        }

        public void SelectActiveButton()
        {
            throw new System.NotImplementedException();
        }
        
        void OnButton(int index)
        {
            if (onButton != null) onButton(index);
            onButton = null;
        }
        
        public int getClickedButton()
        {
            for(int i=0; i<buttons.Length; i++)
            {
                if(buttons[i].clicked) return i;
            }

            return -1;
        }

        public void setImages(SpriteRenderer left)
        {
            if(Global.Personnage == "Chamois") rightImg.sprite = ChamoisImg.sprite;
            if(Global.Personnage == "Chasseur") rightImg.sprite = ChasseurImg.sprite;
            if(Global.Personnage == "Randonneur") rightImg.sprite = RandonneurImg.sprite;
            
            leftImg.sprite = left.sprite;
        }
    }
}
