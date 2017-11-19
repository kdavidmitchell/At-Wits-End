using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public LineManager lineManager;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(lineManager);
    }
}
