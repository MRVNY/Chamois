using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerSorter : MonoBehaviour
{
    public new SpriteRenderer renderer;
    private Collider2D layerSorter;

    // Start is called before the first frame update
    void Start()
    {
        layerSorter = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SpriteRenderer otherRenderer = collision.GetComponent<SpriteRenderer>();
        if (collision.CompareTag("Obstacle") && otherRenderer != null)
        {
            float myRoot = layerSorter.bounds.center.y - layerSorter.bounds.size.y / 2;
            float otherRoot = collision.bounds.center.y - collision.bounds.size.y / 2;
            if (myRoot > otherRoot)
            {
                otherRenderer.sortingOrder = 20;
                otherRenderer.sortingLayerName = "Front";
            }
            else
            {
                otherRenderer.sortingOrder = 10;
                otherRenderer.sortingLayerName = "Default";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer otherRenderer = collision.GetComponent<SpriteRenderer>();
        if (collision.CompareTag("Obstacle") && otherRenderer != null)
        {
            otherRenderer.sortingOrder = 10;
            otherRenderer.sortingLayerName = "Default";
        }
    }
}
