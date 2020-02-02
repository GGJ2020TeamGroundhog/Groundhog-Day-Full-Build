using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : Interactables
{
    //variables
    public GameObject room;
    public Image fadeImage;
    public FadeManager fadeManager;
    public Player player;

    //methods
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
    }
    public override void Interact(string name)
    {
        player.moveLock = !player.moveLock;
        fadeManager.StopAllCoroutines();
        fadeImage.color = Color.clear;
        StartCoroutine(fadeManager.Fade(Color.black, fadeImage, room));
        
    }
}