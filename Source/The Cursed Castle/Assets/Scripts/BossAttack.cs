using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    private Animator anim;
    private Transform player;
    public float speed=0.1f;
    private Animator bossAnim;
    private float scaleX;
    public bool isFired = false;
    private float fireTime=0;
    private bool isPlayerDied;
    private Health playerhealth;
    private Health bossHealth;
    private Rigidbody2D bossRB;
    public AudioClip bossDie;
    public bool notRepeatDieSound = false;
   // private AudioSource bossAudio;
    public AudioClip bossAttackSound;
    public float bossDelayFire = 6f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scaleX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("attackFire", 2f, 10f);
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
        bossRB = GetComponent<Rigidbody2D>();
        //bossAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            if (!bossHealth.isBossDie)
            {
                if (!playerhealth.isDie)
                {
                    if (isFired == true && fireTime <= bossDelayFire)
                    {
                        //Debug.Log(fireTime);
                        //fireTime--;
                        if (fireTime == bossDelayFire)
                        {
                            //Debug.Log("Badr Tarek ");
                            anim.SetBool("BossAttack", false);
                            isFired = false;
                        }
                        fireTime += Time.deltaTime;
                        //Debug.Log("Boss");
                        if (transform.position.x > player.transform.position.x)
                        {
                            transform.localScale = new Vector3(-scaleX, transform.localScale.y, 0);
                        }
                        else if (transform.position.x < player.transform.position.x)
                        {
                            transform.localScale = new Vector3(scaleX, transform.localScale.y, 0);
                        }
                        Vector2 target = new Vector2(player.position.x - 2, transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, target, speed);
                        if (timeBtwAttack <= 0)
                        {
                            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                            for (int i = 0; i < enemiesToDamage.Length; i++)
                            {
                                //Debug.Log("Boss");
                                anim.SetBool("BossAttack", true);
                                AudioSource.PlayClipAtPoint(bossAttackSound, transform.position);
                                isFired = true;
                                enemiesToDamage[i].GetComponent<Health>().decreaseHealth(damage);
                            }
                            timeBtwAttack = startTimeBtwAttack;
                        }
                        else
                        {
                            timeBtwAttack -= Time.deltaTime;
                        }
                    }
                    if (fireTime >= bossDelayFire)
                    {
                        //Debug.Log("Badr Tarek ");
                        anim.SetBool("BossAttack", false);
                        isFired = false;
                    }
                    //Debug.Log(fireTime);
                }
                else
                    anim.SetBool("BossAttack", false);
            }
            else
            {
                anim.SetBool("BossAttack", false);
                if(!notRepeatDieSound)
                {
                    AudioSource.PlayClipAtPoint(bossDie, transform.position);
                    notRepeatDieSound = true;
                }
                
                transform.position = new Vector3(transform.position.x, -2.24f, transform.position.z);
            }
        }
    }
    private void attackFire()
    {
        isFired = true;
        fireTime = 0f;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
