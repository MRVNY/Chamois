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
        _itemActivatorObject = GameObject.Find("ItemActivatorObject");
        _activationScript = _itemActivatorObject.GetComponent<ItemActivator>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.1f);
        
        _activationScript.ActivatorItems.Add(new ActivatorItem {Item = this.gameObject, ItemPos = transform.position});
    }
}
