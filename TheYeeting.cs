using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheYeeting : MonoBehaviour
{
    private Transform transform;
    public bool isSpinning = false;
    private float degrees = .5f;
    public float timeLeft = 40;
    public bool timerRunning = true;
    float shrink = .09f;
    float xDrift = .1f;
    float yDrift = .1f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        isSpinning = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (timerRunning)
        {
            timeLeft -= Time.smoothDeltaTime;
            if (timeLeft >= 0)
            {
                transform.eulerAngles += new Vector3(0, 0, degrees);
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * shrink;
            }
            else
            {
                timerRunning = false;
                isSpinning = false;
            }
        }
    }
}
