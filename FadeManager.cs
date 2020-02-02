using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private Image fadeImage;
    public float fadeSpeed;
    public bool fading;
    public float fadeDelay;
    private GameManager gameManager;

    private void Awake()
    {
        fadeImage = GameObject.FindGameObjectWithTag("FadeImage").GetComponent<Image>();
        fadeImage.transform.localScale = new Vector2(Screen.width, Screen.height);
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        StartCoroutine(Fade(Color.black, fadeImage, gameManager.teleportDes));
    }

    public IEnumerator Fade(Color color, Image image, GameObject room)
    {
        fading = true;
        yield return FadeIn(color, image);
        gameManager.Teleport(room);
        if (gameManager.timeRestart)
        {
            gameManager.RewindTime();
        }
        yield return new WaitForSeconds(fadeDelay);
        yield return FadeOut(image);
        fading = false;
    }

    public IEnumerator FadeIn(Color color, Image image)
    {
        while (fading)
        {
            fadeImage.color = Color.Lerp(image.color, color, fadeSpeed * Time.deltaTime);
            if (fadeImage.color.a >= 0.95f)
            {
                fadeImage.color = image.color;
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator FadeOut(Image image)
    {
        while (fading)
        {
            fadeImage.color = Color.Lerp(image.color, Color.clear, fadeSpeed * Time.deltaTime);
            if (fadeImage.color.a <= 0.05f)
            {
                fadeImage.color = Color.clear;
                yield break;
            }

            yield return null;
        }
    }
}