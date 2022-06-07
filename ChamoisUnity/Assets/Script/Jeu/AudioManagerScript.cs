﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Controllers").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Controllers").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");

    }
}
