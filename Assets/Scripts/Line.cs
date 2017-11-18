using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{

    private string sentence;
    private string speakerName;
    private float strange;
    private float suspicion;

    public string Sentence
    {
        get
        {
            return sentence;
        }
        set
        {
            sentence = value;
        }
    }

    public string SpeakerName
    {
        get
        {
            return speakerName;
        }
        set
        {
            speakerName = value;
        }
    }

    public float Strange
    {
        get
        {
            return strange;
        }
        set
        {
            strange = value;
        }
    }

    public float Suspicion
    {
        get
        {
            return suspicion;
        }
        set
        {
            suspicion = value;
        }
    }

    public Line()
    {
        sentence = "Default.";
        speakerName = "Default.";
        strange = 0f;
        suspicion = 0f;
    }
}
