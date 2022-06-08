using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerSorter : MonoBehaviour
{
    public SpriteRenderer renderer;
    private Collider2D layerSorter;

    // Start is called before the first frame update
    void Start()
    {
        layerSorter = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float myRoot = layerSorter.bounds.center.y - layerSorter.bounds.size.y / 2;
        float otherRoot = collision.bounds.center.y - collision.bounds.size.y / 2;
        if (collision.tag == "Obstacle" && myRoot > otherRoot)
        {
            renderer.sortingOrder = 0;
        }
        else
        {
            renderer.sortingOrder = 100;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        renderer.sortingOrder = 100;
    }
}
