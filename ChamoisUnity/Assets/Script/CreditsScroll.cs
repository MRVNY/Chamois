using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        Vector3 vectorUp = transform.TransformDirection(0, 1, 0);

        position += vectorUp * speed * Time.deltaTime;
        transform.position = position;
    }
}
