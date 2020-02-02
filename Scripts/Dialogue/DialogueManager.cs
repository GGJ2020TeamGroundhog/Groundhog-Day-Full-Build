using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI characterName;
    private TextMeshProUGUI characterSpeech;
    private Image image;
    public AudioSource sfxSource;

    private DialogueByCharacter currentCharacter;
    private Dialogue currentDialogue;
    //private bool isMonologue;

    private int currentBubble;
    private string currentText;
    private AudioClip currentSfx;

    public float charInterval;
    public float commaInterval;
    public float periodInterval;
    //public float bubbleInterval;

    /*
     * REPLACE THIS with appropriate GameManager attributes (i.e. should tell the GM that
    the player is in a conversation that must be progressed by pressing 'E', plus when the dialogue ends
    and the player's free to move again)
    */
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void StartNewDialogue(DialogueByCharacter character, int index)
    {
        player.inDialogue = true;
        currentCharacter = character;
        currentDialogue = currentCharacter.dialogues[index];
        PlayBubble();
    }

    void LoadDialogue()
    {
        //Determines who talks first; speakers take turns
        if (currentCharacter.firstSpeaker == DialogueByCharacter.SpeakingOrder.Player)
        {
            if (currentBubble % 2 == 0)
            {
                characterName.text = currentCharacter.player.characterName;
                image.sprite = currentCharacter.player.image;
                currentSfx = currentCharacter.player.sfx;
            }
            else
            {
                characterName.text = currentCharacter.other.characterName;
                image.sprite = currentCharacter.other.image;
                currentSfx = currentCharacter.other.sfx;
            }
        }
        else
        {
            if (currentBubble % 2 == 0)
            {
                characterName.text = currentCharacter.other.characterName;
                image.sprite = currentCharacter.other.image;
                currentSfx = currentCharacter.other.sfx;
            }
            else
            {
                characterName.text = currentCharacter.player.characterName;
                image.sprite = currentCharacter.player.image;
                currentSfx = currentCharacter.player.sfx;
            }
        }

        //Readies text/images
        characterSpeech.maxVisibleCharacters = 0;

        currentText = currentDialogue.bubbles[currentBubble];
        characterSpeech.text = currentText;

    }

    //Later, should only be accessed by GM
    public void PlayBubble()
    {
        Debug.Log(currentBubble + ", " + currentDialogue.bubbles.Length);
        LoadDialogue();

        if (currentBubble < currentDialogue.bubbles.Length)
        {
            if (currentBubble < currentDialogue.bubbles.Length - 1)
            {
                player.waitingForNextBubble = true;
            }
            else
            {
                player.waitingForNextBubble = false;
            }
            //At first, should bring up the dialogue boxes (hidden otherwise)
            StopCoroutine(PlayChar());
            StartCoroutine(PlayChar());
            currentBubble++;
        }
        else
        {
            player.inDialogue = false;
            //Should hide the dialogue boxes once that convo is over
            Debug.Log("Done!");
        }
    }

    IEnumerator PlayChar()
    {
        WaitForSeconds wait = new WaitForSeconds(charInterval);
        WaitForSeconds comWait = new WaitForSeconds(commaInterval);
        WaitForSeconds perWait = new WaitForSeconds(periodInterval);

        //sfxSource.clip = currentSfx;

        foreach (char c in currentText.ToCharArray())
        {
            characterSpeech.maxVisibleCharacters++;

            //sfxSource.Play();

            if (c.Equals(','))
            {
                yield return comWait;
            }
            else if (c.Equals('.') || c.Equals('!') || c.Equals('?') || c.Equals('-'))
            {
                yield return perWait;
            }
            else
            {
                yield return wait;
            }

        }
        //sfxSource.Stop();
        
    }
}
