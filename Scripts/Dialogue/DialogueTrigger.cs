using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to 
public class DialogueTrigger : MonoBehaviour
{
    public DialogueByCharacter character;
    public int index;

    public void Start()
    {
    }
    public void StartDialogue()
    {
        GetComponent<DialogueManager>().StartNewDialogue(character, index);
    }
    public void StartMonologue()
    {

    }
    //Remove this later; GM should take care of it
    public void PlayNext()
    {
        GetComponent<DialogueManager>().PlayBubble();
    }
}
