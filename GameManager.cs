using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // RESET CONSTANTS
    private const int TIMELIMIT = 180;


    public Player player;
    public GameObject teleportDes;
    public bool isPaused = false;
    public Image fadeImage;
    public FadeManager fadeManager;
    public bool timeRestart = false;


    [HideInInspector] public int timeIteration;
    private int timeLeft = TIMELIMIT;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        fadeManager = GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>();
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        timeIteration = 1;
        timerText.text = (timeLeft.ToString());
        StartCoroutine("LoseTime");

    }

    // Update is called once per frame
    void Update()
    {
        int minute = (timeLeft / 60);
        int second = (timeLeft % 60);
        string timerT = string.Format("{0:00}:{1:00}", minute, second);
        timerText.text = timerT;
    }

    public void Teleport(GameObject spawnPoint)
    {
        player.transform.position = spawnPoint.transform.position;
    }



    // TIME 
    IEnumerator LoseTime()
    {
        while (true)
        {
            while (!isPaused)
            { 
                if (timeLeft <= 0.0f)
                {
                    timerText.enabled =false;
                    yield return timerEnded();
                    timerText.enabled=true;
                }
                else
                {
                    yield return new WaitForSeconds(1);
                    timeLeft--;
                }
            }
            yield return null;
        }
    }
    IEnumerator timerEnded()
    {
        timeLeft = TIMELIMIT;
        Debug.Log("REWIND TIME\n Time iteration: " + timeIteration);
        fadeImage.color = Color.clear;

        yield return GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>().Fade(Color.blue, fadeImage, teleportDes);

    }

    public void RewindTime()
    {
        timeIteration++;
        player.SetDefault();
        timeRestart = false;


    }

}
