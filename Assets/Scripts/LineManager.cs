﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{

    public string[] sentences;
    public string[] speakerNames;
    public float[] strangeValues;
    public float[] suspicionValues;
    public Line[] lines;
	
    // Use this for initialization
	void Start ()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            lines[i].Sentence = sentences[i];
            lines[i].SpeakerName = speakerNames[i];
            lines[i].Strange = strangeValues[i];
            lines[i].Suspicion = suspicionValues[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
