using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
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

        public void SetButtons(List<ConversationOption> options)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                if(i<options.Count)
                {
                    buttons[i].gameObject.SetActive(true);
                    buttons[i].SetText(options[i].text);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }

        public void SetText(string text)
        {
            textMeshPro.text = text;
        }
    }
}
