using System;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace RPGM.UI
{
    public class VisualNovel : MonoBehaviour
    {
        private PauseMenu pause;
        private UIManager ui;
        public VNLayout dialogLayout;

        private Image leftImg;
        private Image rightImg;
        private TextMeshPro name;
        private TextMeshPro dialog;

        public System.Action<int> onButton;

        private int selectedButton = 0;
        private int buttonCount = 0;

        SpriteButton[] buttons;
        Camera mainCamera;
        GameModel model = Schedule.GetModel<GameModel>();
        //SpriteUIElement spriteUIElement;

        // Start is called before the first frame update
        
        void Awake()
        {
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
            //model = Schedule.GetModel<GameModel>();
        }

        private void OnEnable()
        {
            dialogLayout.gameObject.SetActive(true);
        }

        public void Next()
        {
            ui.endVisualNovel();
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
            UserInterfaceAudio.OnShowDialog();
            dialogLayout.gameObject.SetActive(true);
            dialogLayout.SetText(text);
            dialogLayout.SetButtons(options);
            //model.input.ChangeState(InputController.State.DialogControl);
            buttonCount = options.Count;
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
    }
}
