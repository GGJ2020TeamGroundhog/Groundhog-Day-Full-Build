using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Computer : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshPro iterationText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timeIteration>=3)
        iterationText.text = gameManager.timeIteration.ToString();
    }
}
