using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace RPGM.UI
{

    [ExecuteInEditMode]
    public class VNLayout : MonoBehaviour
    {
        public float padding = 0.25f;
        public TextMeshProUGUI textMeshPro;

        //public SpriteButton buttonA, buttonB, buttonC;
        public GameObject options;

        public SpriteButton[] buttons;

        void Awake()
        {
            buttons = options.GetComponentsInChildren<SpriteButton>();
        }

        public void SetIcon(Sprite icon)
        {
        }

        public void SetText(string text)
        {
            SetDialogText(text);
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }

        public void SetButtonText(int index, string text)
        {
            buttons[index].SetText(text);
            buttons[index].gameObject.SetActive(true);
        }

        public void SetText(string text, string[] buttonsText)
        {
            SetDialogText(text);
            foreach(SpriteButton button in buttons)
            {
                button.gameObject.SetActive(false);
                button.SetText(buttonsText[Array.IndexOf(buttons,button)]);
            }
        }
        
        void SetDialogText(string text)
        {
            textMeshPro.text = text;
        }

        public float GetHeight()
        {
            return 0;
        }
    }
}
