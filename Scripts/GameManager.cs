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
    private const float TIMELIMIT = 120.0f;


    private Player player;
    public GameObject teleportDes;
    public bool isPaused = false;
    private Image fadeImage;
    private FadeManager fadeManager;



    private float timeIteration;
    private float timeLeft = TIMELIMIT;
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
        timerText.text = (timeLeft.ToString()  );
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
        timeIteration++;
        timeLeft = TIMELIMIT;
        Debug.Log("REWIND TIME\n Time iteration: "+timeIteration);
        fadeImage.color = Color.clear;

        yield return GameObject.FindGameObjectWithTag("FadeManager").GetComponent<FadeManager>().Fade(Color.blue, fadeImage, teleportDes);
        RewindTime();

    }

    public void RewindTime()
    {
        player.SetDefault();



    }

}
