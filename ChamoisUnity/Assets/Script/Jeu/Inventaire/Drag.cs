using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class Drag : ListItems, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public RectTransform _rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 initialPos;
    public bool estDehors = true;
    public Canvas parentCanvas;
    public Image imageToMove;
    //public static bool isOutSlot = true;
    private Vector3 screenPoint;
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPos = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        //canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //_rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //Vector3 pos =  _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        /*Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentCanvas.transform as RectTransform,
            eventData.position, parentCanvas.worldCamera, out pos);
        imageToMove.transform.position = Vector3.Lerp(imageToMove.transform.position, parentCanvas.transform.TransformPoint(pos), Time.deltaTime * 30f);*/
        Vector3 cursorPoint = new Vector3((int)Input.mousePosition.x, (int)Input.mousePosition.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z));
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
        transform.position = new Vector3((int)cursorPosition.x, (int)cursorPosition.y, (int)cursorPosition.z);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
        RectTransform itemActuel = this._rectTransform;
        if (!Drop.PointerIsOnSlot)
        {
            _rectTransform.anchoredPosition = initialPos;
            estDehors = true;
        }
        else
        {
            estDehors = false;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {  
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        // offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
    }
}
