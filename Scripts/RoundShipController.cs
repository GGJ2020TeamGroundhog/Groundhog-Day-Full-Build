using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// ROUND SHIP LEVEL CONTROLLER
/// 
/// This script will make the hamster wheel hub level
/// rotate using A and D while the player stays
/// in place. Nothing complicated.
/// 
/// In addition, it will rotate the background at a slow
/// speed.
/// 
/// 
/// </summary>
public class RoundShipController : MonoBehaviour
{
    //variables
    //
    public Player player;

    GameObject level;
    GameObject background;

    //methods

    void Update()
    {
        LevelControl();
        BackgroundRotate();
    }

    //at frame 1, the bg and level objects are found
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Level");
        background = GameObject.FindGameObjectWithTag("Background");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    //Input Axis changes rotate the level
    void LevelControl()
    {
        //both of these if statements will simply rotate a parent object (the hub level)
        if (Input.GetAxis("Horizontal")>0.5 && player.moveLock == true)
        {
            level.transform.Rotate(new Vector3(0f, 0f, -Input.GetAxis("Horizontal") / 15));
        }
        else if (Input.GetAxis("Horizontal")<-0.5 && player.moveLock == true)
        {
            level.transform.Rotate(new Vector3(0f, 0f, -Input.GetAxis("Horizontal") / 15));
        }
    }

    //Ambient background rotation due to moving ship :)
    void BackgroundRotate()
    {
        background.transform.Rotate(new Vector3(0f, 0f, 0.01f));
    }
}
