using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactables
{
    private DialogueTrigger dialogueTrigger;
    public int startIndex;

    private void Start() {
        dialogueTrigger = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueTrigger>();
        dialogueTrigger.index = startIndex;
        dialogueTrigger.character = GetComponent<DialogueByCharacter>();
    }

    public override void Interact(string noUse) {
        dialogueTrigger.StartDialogue();
    }
}
