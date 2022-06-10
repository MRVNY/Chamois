using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GOPointer.Controllers.GetComponent<AudioSource>().volume = 0;//PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        //GOPointer.Controllers.GetComponent<AudioSource>().volume = 0;//PlayerPrefs.GetFloat("volume");

    }
}
