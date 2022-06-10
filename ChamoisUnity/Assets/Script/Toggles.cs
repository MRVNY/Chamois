using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Toggles : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showColliders;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("t"))
        // {
        //     showColliders = !showColliders;
        // }
        Physics2D.alwaysShowColliders = showColliders;
    }
    
}
