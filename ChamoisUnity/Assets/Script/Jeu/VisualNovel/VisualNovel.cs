using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNovel : MonoBehaviour
{
    private PauseMenu pause;
    private UIManager ui;
    
    // Start is called before the first frame update
    void Start()
    {
        ui = GOPointer.UIManager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        
    }

    public void Next()
    {
        ui.endVisualNovel();
    }
}
