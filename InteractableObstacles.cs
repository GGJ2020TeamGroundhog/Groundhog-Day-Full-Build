using UnityEngine;

public class InteractableObstacles : Interactables
{
    bool isFixed = false;
    public string tool;
    public string dialogueMessage;

    public override void Interact(string toolUsed) {
        if (tool == toolUsed) {
            isFixed = true;
            Debug.Log("You fixed obstacle!");
        }
        else if(tool == "noTool") {
            isFixed = true;
        }
    }
}
