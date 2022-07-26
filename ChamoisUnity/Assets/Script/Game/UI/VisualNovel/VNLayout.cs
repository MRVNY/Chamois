using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RPGM.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace RPGM.UI
{

    //[ExecuteInEditMode]
    public class VNLayout : MonoBehaviour
    {
        public float padding = 0.25f;
        public TextMeshProUGUI textMeshPro;
        private string[] fullText;
        private string currentText;
        private List<ConversationOption> optionText; 

        //public SpriteButton buttonA, buttonB, buttonC;
        public GameObject options;
        public SpriteButton fullScreenButton;

        [NonSerialized] public SpriteButton[] buttons;
        
        private Coroutine tmpCoroutine;
        private bool rolling = false;

        void Awake()
        {
            buttons = options.GetComponentsInChildren<SpriteButton>();
        }

        public void SetButtons()
        {
            if (optionText.Count == 1 && optionText[0].text == "")
            {
                fullScreenButton.gameObject.SetActive(true);
            }
            else
            {
                fullScreenButton.gameObject.SetActive(false);
                
                options.SetActive(true);
                for(int i = 0; i < buttons.Length; i++)
                {
                    if(i<optionText.Count && optionText[i].text != "")
                    {
                        buttons[i].gameObject.SetActive(true);
                        buttons[i].SetText(optionText[i].text);
                    }
                    else
                    {
                        buttons[i].gameObject.SetActive(false);
                    }
                }
            }
        }

        public void SetLayout(string text, List<ConversationOption> optionText)
        {
            this.optionText = optionText;
            options.SetActive(false);
            fullText = text.Split('\n');
            setDialog();
        }

        private void setDialog()
        {
            fullScreenButton.gameObject.SetActive(false);
            if (fullText.Length > 3)
            {
                currentText = fullText[0] + "\n" + fullText[1] + "\n" + fullText[2];
                fullText = fullText.Skip(3).ToArray();
            }
            else
            {
                currentText = String.Join("\n", fullText);
                fullText = Array.Empty<string>();
            }
            rolling = true;
            tmpCoroutine = StartCoroutine("PlayText");
        }
        
        IEnumerator PlayText()
        {
            string story = currentText;
            textMeshPro.text = "";
            foreach (char c in story) 
            {
                textMeshPro.text += c;
                yield return new WaitForSecondsRealtime(0.02f);
            }
            if (fullText.Length==0) SetButtons();
            
            rolling = false;
        }

        public void skip()
        {
            if (rolling)
            {
                rolling = false;
                StopCoroutine(tmpCoroutine);
                textMeshPro.text = currentText;
                if (fullText.Length==0) SetButtons();
            }
            else
            {
                if (fullText.Length>0) setDialog();
                else if (optionText.Count==0) GOPointer.VisualNovel.End();
                else SetButtons();
            }
        }
    }
}
