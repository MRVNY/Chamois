using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovelController : MonoBehaviour
{
    public GameObject talkButton;
    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GOPointer.CameraReg.GetComponentInChildren<Camera>();
        talkButton.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        talkButton.transform.position = Vector3.up * 100 + camera.WorldToScreenPoint(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Detector"))
        {
            talkButton.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Detector"))
        {
            talkButton.SetActive(false);
        }
    }
}
