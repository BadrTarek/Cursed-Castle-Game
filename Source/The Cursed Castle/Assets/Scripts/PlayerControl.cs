using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float inputHorizontal;
    private Animator playerAnim;
    private Rigidbody2D playerRB;
    public float speed = 0.5f;
    private float scaleX;
    public float gravityModifier;
    public float jumpForce = 10;
    public bool isOnGround = false;
    public GameObject arrow;
    private Vector3 arrowPos;
    private Health playerhealth;
    private Health bossHealthWin;
    public float playerPosition;
    public AudioSource audioSource;
    public AudioClip gameOver;
    //public AudioClip attack;
    public AudioClip die;
    private bool repeatSound = false;
    public bool wantToDoor = false;
    public bool isGameOver = false;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        scaleX = transform.localScale.x;
        playerRB = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        //arrow = GetComponent<GameObject>();
        //arrowPos = new Vector3(arrow.position.x, -1.76f , arrow.position.z);
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 0 )
            bossHealthWin = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (!playerhealth.isDie)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                    transform.localScale = new Vector3(-scaleX, transform.localScale.y, 0);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector3(scaleX, transform.localScale.y, 0);
                }
                inputHorizontal = Input.GetAxis("Horizontal");
                if (Input.GetKey("right") || Input.GetKey("left"))
                {
                    playerAnim.SetBool("Run", true);
                    transform.Translate(Vector3.right * inputHorizontal * speed);
                }
                else
                {
                    playerAnim.SetBool("Run", false);
                    transform.Translate(Vector3.right * inputHorizontal * speed);
                }



                if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
                {
                    playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    isOnGround = false;
                }

                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    //Debug.Log("Badr Tarek");
                    arrowPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    Instantiate(arrow, arrowPos, arrow.transform.rotation);
                    if (transform.localScale.x < 0)
                        playerPosition = -1;
                    else
                        playerPosition = 1;
                }
            }
            //int y = SceneManager.GetActiveScene().buildIndex;
            // Debug.Log(SceneManager.GetActiveScene().buildIndex);
            if (Input.GetKeyDown(KeyCode.X))
            {
                //if(SceneManager.GetActiveScene())

                //Debug.Log(SceneManager.GetActiveScene());
                //Debug.Log("Winnnn");

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    playerAnim.SetBool("Greeting", true);
                    Invoke("resetGreetingAnim", 2f);
                }
                else
                    playerAnim.SetBool("Greeting", false);
            }

            if (playerhealth.isPlayerDie && !repeatSound)
            {
                audioSource.PlayOneShot(die, 1.0f);
                Invoke("GameOver", 3f);
                repeatSound = true;
            }
        }
    }
    private void resetGreetingAnim()
    {
        playerAnim.SetBool("Greeting", false);
    }
    private void GameOver()
    {
        isGameOver = true;
        audioSource.PlayOneShot(gameOver, 1.0f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
        /*else if(collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("Win");
            if(bossHealthWin.isBossDie && bossHealthWin.isWin)
            {
                if(Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }*/
    }

}
