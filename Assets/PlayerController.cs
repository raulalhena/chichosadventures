using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    AudioSource collectSound;
    Animator playerAnimator;
    Rigidbody2D rb;
    public GameObject restartButton;
    float inputH;
    float inputV;

    [Header("JUMP & FALL")]
    public bool isTakingOff = false;
    public bool isJumping = false;
    public bool isFalling = false;
    public float speed = 35;
    public float jumpAmount = 25;
    public bool isGrounded = true;

    [Header("Player Values")]
    public bool isAlive = true;
    public float timePower = 0;
    public int currentAge = 0;
    public int nextAge = 0;

    [Header("Pause")]
    public bool isPaused = false;

    void Start()
    {
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("timePower", 0);
        collectSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }

        if (!isAlive)
        {
            SceneManager.LoadScene("Nivel1");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentAge >= 0 && currentAge < 4 && timePower >= 0 && timePower < 3)
            {
                slowTime();
                manageAges();
            }
        }

        float velocityX = inputH * speed * Time.unscaledDeltaTime;

        transform.position = transform.position + Vector3.right * velocityX;

        if (inputV > 0 && isGrounded)
        {
            Jump();
        }

        if (inputH != 0)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        if (inputH < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (inputH > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (rb.velocity.y < 0 && !isFalling)
        {
            isFalling = true;
            playerAnimator.SetBool("isFalling", isFalling);
        }
    }

    void manageAges()
    {
        switch (timePower)
        {
            case 0:
                nextAge = 0;
                speed = 35;
                jumpAmount = 25;
                break;
            case 1:
                nextAge = 1;
                speed = 30;
                jumpAmount = 22;
                break;
            case 2:
                nextAge = 2;
                speed = 25;
                jumpAmount = 20;
                break;
            case 3:
                nextAge = 3;
                speed = 20;
                jumpAmount = 18;
                break;
        }
        if (currentAge != nextAge)
        {
            transform.GetChild(currentAge).gameObject.SetActive(false);
            transform.GetChild(nextAge).gameObject.SetActive(true);
            currentAge = nextAge;
        }
    }

    void slowTime()
    {
        Time.timeScale = 0.2f;
        if (timePower >= 0 && timePower < 4)
        {
            timePower += 0.5f;
        }
        Invoke("resetTime", 0.2f);
    }

    void speedUpTime()
    {
        Time.timeScale = 10f;
        if (timePower > 0 && timePower < 4)
        {
            timePower -= 0.5f;
        }
        
        Invoke("resetTime", 10);
    }

    void resetTime()
    {
        Time.timeScale = 1f;
    }

    void Jump()
    {
        playerAnimator.SetTrigger("takeOff");
        isJumping = true;
        playerAnimator.SetBool("isJumping", isJumping);
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            isJumping = false;
            playerAnimator.SetBool("isJumping", isJumping);
            isFalling = false;
            playerAnimator.SetBool("isFalling", isFalling);
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            isAlive = false;
            playerAnimator.SetBool("isDead", !isAlive);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            isAlive = false;
            playerAnimator.SetBool("isDead", !isAlive);
        }
        else if (collision.gameObject.CompareTag("Orb"))
        {
            if (timePower > 0)
            {
                timePower -= 0.5f;
            }
            Debug.Log(timePower);
            manageAges();
        }
    }
}
