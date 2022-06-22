using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


namespace RPGM.UI
{
    public class SpriteButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public TMP_Text textMeshPro;
        public bool clicked = false;
        public event System.Action onClickEvent;

        public void Enter()
        {
            textMeshPro.color = Color.yellow;
            UserInterfaceAudio.OnButtonEnter();
        }

        public void Exit()
        {
            clicked = false;
            textMeshPro.color = Color.white;
            UserInterfaceAudio.OnButtonExit();
        }

        public void Click()
        {
            clicked = true;
            if (onClickEvent != null) onClickEvent();
            textMeshPro.color = Color.white;
            UserInterfaceAudio.OnButtonClick();
        }

        public void OnPointerClick(PointerEventData eventData) => Click();

        public void OnPointerEnter(PointerEventData eventData) => Enter();

        public void OnPointerExit(PointerEventData eventData) => Exit();

        public void SetText(string text) => textMeshPro.text = text;

        public void Reset()
        {
            textMeshPro = GetComponentInChildren<TextMeshPro>();
        }

        public bool isNull()
        {
            return onClickEvent == null;
        }

        public void Nullify()
        {
            onClickEvent = null;
            clicked = false;
        }
        
        //public void setOnclick(int i)
    }
}