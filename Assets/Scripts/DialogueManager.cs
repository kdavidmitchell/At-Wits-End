using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    public Text dialogueText;
    public Animator animator;

	// Use this for initialization
	void Start ()
    {
        sentences = new Queue<string>();	
	}

    public void StartDialogue(LineManager lineManager)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();

        foreach (string sentence in lineManager.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        animator.SetBool("isOpen", false);
    }
	
	
}
