using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    public virtual void Interact(string name) { Debug.Log("You interacted with something!"); }
}
