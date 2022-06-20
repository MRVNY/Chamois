using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButtons : MonoBehaviour
{
    public GameObject talk;

    public GameObject recharge;
    // Start is called before the first frame update
    void Start()
    {
        //desactivateAll();
    }
    
    public void deactivateExcept()
    {
        foreach (GameObject go in GetComponentsInChildren<GameObject>())
        {
            go.SetActive(false);
        }
    }

    public void desactivateAll()
    {
        foreach (var go in GetComponentsInChildren<GameObject>())
        {
            go.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
