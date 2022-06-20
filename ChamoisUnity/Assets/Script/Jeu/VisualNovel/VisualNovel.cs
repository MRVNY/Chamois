using System;
using RPGM.Core;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

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
        SpriteUIElement spriteUIElement;

        // Start is called before the first frame update
        
        void Awake()
        {
            //dialogLayout = GetComponent<VNLayout>();
            buttons = dialogLayout.buttons;
            for(int i=0; i<buttons.Length; i++)
            {
                dialogLayout.buttons[i].onClickEvent += () => OnButton(i);
            }
            dialogLayout.gameObject.SetActive(false);
            spriteUIElement = GetComponent<SpriteUIElement>();
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
            //ui.endVisualNovel();
        }

        public void Hide()
        {
            UserInterfaceAudio.OnHideDialog();
            GOPointer.UIManager.GetComponent<UIManager>().endVisualNovel();

        }

        public void End()
        {
            ui.endVisualNovel();
        }

        public void Show(string text)
        {
            dialogLayout.gameObject.SetActive(true);
            dialogLayout.SetText(text);
            //model.input.ChangeState(InputController.State.DialogControl);
            buttonCount = 0;
            selectedButton = -1;
        }

        public void Show(string text, string[] buttons)
        {
            UserInterfaceAudio.OnShowDialog();
            dialogLayout.gameObject.SetActive(true);
            dialogLayout.SetText(text, buttons);
            //model.input.ChangeState(InputController.State.DialogControl);
            buttonCount = buttons.Length;
            selectedButton = -1;
        }

        public void SetButton(int i, string text)
        {
            var d = dialogLayout;
            d.SetButtonText(i, text);
            buttonCount = Mathf.Max(buttonCount, i + 1);
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
    }
}
