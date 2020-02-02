using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTools : Interactables
{
    public string toolName;

    public override void Interact(string notUsed) {
        Player pc = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        string currentTool = pc.tool;
        pc.tool = toolName;

        if (currentTool != "") {
            Instantiate(Resources.Load(currentTool), this.transform.position, this.transform.rotation);
        }

        Debug.Log("You picked up a tool!");

        Destroy(this.gameObject);
    }
}
