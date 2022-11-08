using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{

    private GameObject _itemActivatorObject;
    private ItemActivator _activationScript;

    // Start is called before the first frame update
    void Start()
    {
        _activationScript = ItemActivator.currentActivator;
        StartCoroutine(AddToList());
    }

    IEnumerator AddToList()
    {
        _activationScript.ActivatorItems.Add(new ActivatorItem {Item = gameObject, ItemPos = transform.position + new Vector3(50,-50,0)});
        yield return new WaitForSeconds(0.1f);
    }
    
}
