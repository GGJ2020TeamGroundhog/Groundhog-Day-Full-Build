using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed = 5;
    private float jumpForce = 5;
    private bool isGrounded = true;
    public string tool;
    private Collider2D collider;
    private List<Collider2D> interactables;
    [SerializeField] private ContactFilter2D contactFilter;
    private GameManager gameManager;
    private Animator anim;
    private bool flipped = false;
    public bool inDialogue;
    public bool waitingForNextBubble;
    public DialogueTrigger dt;
    public bool moveLock;


    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        moveLock = false;
        interactables = new List<Collider2D>();
        collider = GetComponent<Collider2D>();
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        dt = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueTrigger>();
    }
    public void SetDefault()
    {
        this.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        flipped = false;
        moveLock = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 && moveLock == false)
        {
            this.transform.position = this.transform.position + this.transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && moveLock == false)
        {
            this.transform.position = this.transform.position - this.transform.right * speed * Time.deltaTime;
        }

        collider.OverlapCollider(contactFilter, interactables);

        if (interactables.Count >= 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactables[0].gameObject.GetComponent<Interactables>().Interact(tool);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (waitingForNextBubble)
            {
                dt.PlayNext();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (waitingForNextBubble)
            {
                dt.PlayNext();
            }
        }


        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space")) && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        WalkingInput(Input.GetAxis("Horizontal"));
    }
    void Pause()
    {
        gameManager.isPaused = !gameManager.isPaused;
        Debug.Log("Game is paused: " + gameManager.isPaused);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void WalkingInput(float movement)
    {
        //For the purposes of this animator, left direction = -1.0 and right direction = 1.0
        //These bool and float values were defined within the animator as assets
        //If you need the animations, I'll just send the .unity file.
        if (movement != 0)
        {
            anim.SetBool("walking", true);
            if (movement < 0 && !flipped)
            {
                flipped = true;
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (movement > 0 && flipped)
            {
                flipped = false;
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }


}