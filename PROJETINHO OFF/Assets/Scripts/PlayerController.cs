using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header ("Inputs")]
    private bool lKey;
    private bool rKey;
    private bool facingRight = true;
    private bool jump = false;
    private bool isMoving = false;

    [Header ("Values")]
    public Vector2 jumpHeight;
    public float jumpForce;
    public float spd;

    [Header ("Inspector")]
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer renderer;

    [Header ("Ground Check")]
    public bool isGrounded;
    public Transform groundCheck;
    public Vector2 bottomOffset;
    public Vector2 bottomSquare;
    public Vector2 squareSize;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Audio
    [Header ("Audio")]
    public AudioSource charAudio;
    public AudioClip walk;
    public float walkingSoundDelay;
    private int cdAudioRun = 0;

    void Start() {  
        rb = GetComponent<Rigidbody2D>();
        charAudio.clip = walk;
    }

    void FixedUpdate() {
        //isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRadius, whatIsGround);
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + bottomSquare, squareSize, 0f, whatIsGround);

        //moveInput = Input.GetAxis("Horizontal");
        lKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        rKey = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);


        //rb.velocity = new Vector2(atualSpdH, rb.velocity.y);
		if (rKey == true)
		{
			renderer.flipX = false;
		}

		if (facingRight == true && lKey == true) {
			renderer.flipX = true;
		}

        if (Input.GetButton("Jump") && isGrounded == true)
        {
            //GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
            animator.SetTrigger("JumpTrigger");
        }


        // THE PUTARIA BEGINS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        if(rb.velocity.x != 0)
        {
            animator.SetBool("Movement", true);
        }
        else
        {
            animator.SetBool("Movement", false);
        }

        if (rb.velocity.y != 0)
        {
            animator.SetBool("Midair", true);
        }
        else
        {
            animator.SetBool("Midair", false);
        }
    }

    void Update() {
        animator.SetFloat("VelocityY", rb.velocity.y);
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 11, true);
        Physics2D.IgnoreLayerCollision(9, 12, true);
		Physics2D.IgnoreLayerCollision(9, 13, true);
		Physics2D.IgnoreLayerCollision(9, 14, true);
		Physics2D.IgnoreLayerCollision(9, 15, true);
		Physics2D.IgnoreLayerCollision(9, 16, true);
        Physics2D.IgnoreLayerCollision(9, 18, true);

        if (lKey && rKey)
        {
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }

        //THE PUTARIA ENDS--------------------------------------------------------------------------
        //Audio begins

        if ((lKey || rKey && isGrounded == true) && !(lKey && rKey))
        {
            if (cdAudioRun == 0)
            {
                cdAudioRun = 1;
                StartCoroutine(Walking());
            }

        }
        if (isGrounded == false)
        {
            charAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void Walk(Vector2 direction)
    {
        //if (!(rKey && lKey) && isGrounded)
        //{
            rb.velocity = (new Vector2(direction.x * spd, rb.velocity.y));
        //}
        //if(!isGrounded)
        //{
            //rb.velocity = (new Vector2(direction.x * spd, rb.velocity.y));
        //}
    }

    public IEnumerator Walking()
    {
        if ((lKey || rKey && isGrounded == true) && !(lKey && rKey))
        {
            yield return new WaitForSeconds(walkingSoundDelay);
            cdAudioRun = 0;
            if (isGrounded == true)
            {
                if (lKey || rKey)
                {
                    charAudio.Play();
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomSquare };

        Gizmos.DrawWireCube((Vector2)transform.position + bottomSquare, squareSize);
    }
}


