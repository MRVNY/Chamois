using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[ExecuteInEditMode]
public class Position : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<RectTransform> rects = GetComponentsInChildren<RectTransform>().ToList();
        RectTransform pop = rects[0];
        rects.RemoveAt(0);
        rects.Add(pop);

        foreach (RectTransform rect in rects)
        {
            rect.pivot = new Vector2(0, 1);
        }

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                rects[6 * i + j].position = new Vector3(j * 100, -i * 100, 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
