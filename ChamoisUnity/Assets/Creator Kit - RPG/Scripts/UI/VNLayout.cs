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

    [ExecuteInEditMode]
    public class VNLayout : MonoBehaviour
    {
        public float padding = 0.25f;
        public TextMeshProUGUI textMeshPro;
        private string[] fullText;
        private string currentText;
        private List<ConversationOption> optionText; 

        //public SpriteButton buttonA, buttonB, buttonC;
        public GameObject options;

        [NonSerialized] public SpriteButton[] buttons;

        void Awake()
        {
            buttons = options.GetComponentsInChildren<SpriteButton>();
        }

        public void SetButtons()
        {
            options.SetActive(true);
            for(int i = 0; i < buttons.Length; i++)
            {
                if(i<optionText.Count)
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

        public void SetLayout(string text, List<ConversationOption> optionText)
        {
            this.optionText = optionText;
            options.SetActive(false);
            fullText = text.Split('\n');
            setDialog();
        }

        private void setDialog()
        {
            if (fullText.Length > 3)
            {
                currentText = fullText[0] + "\n" + fullText[1] + "\n" + fullText[2];
                fullText = fullText.Skip(3).ToArray();
            }
            else
            {
                currentText = String.Join("\n", fullText);
                fullText = new string[0];
            }
            StartCoroutine("PlayText");
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
            if(fullText.Length==0) SetButtons();
        }

        public void skip()
        {
            if(currentText == textMeshPro.text && optionText.Count==0) GOPointer.VisualNovel.GetComponent<VisualNovel>().End();
            
            if (currentText != textMeshPro.text)
            {
                StopCoroutine("PlayText");
                textMeshPro.text = currentText;
            }
            else if (fullText.Length!=0) setDialog();
            
            if(currentText == textMeshPro.text && fullText.Length==0) SetButtons();
        }
    }
}
