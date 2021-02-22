using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    private Animator anim;
    private Transform player;
    public float speed = 0.3f;
    private float scaleX;
    public bool isAttacked = false;
    private float attackTime = 0;
    private Health playerhealth;
    private Health bossHealth;
    public AudioClip skeletonAttackSound;
    private AudioSource ausio;
    private void Start()
    {
        anim = GetComponent<Animator>();
        scaleX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("attackFire", 2f, 10f);
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            //  transform.Translate(Vector3.right * speed);
            if (!bossHealth.isBossDie)
            {
                if (!playerhealth.isDie)
                {
                    Vector2 target = new Vector2(player.position.x - 1, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, target, speed);
                    if (timeBtwAttack <= 0)
                    {
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            if (!playerhealth.isDie)
                            {
                                //Debug.Log("Boss");
                                if (transform.position.x > player.transform.position.x)
                                {
                                    transform.localScale = new Vector3(-scaleX, transform.localScale.y, 0);
                                }
                                else if (transform.position.x < player.transform.position.x)
                                {
                                    transform.localScale = new Vector3(scaleX, transform.localScale.y, 0);
                                }

                                anim.SetBool("Attack", true);
                                AudioSource.PlayClipAtPoint(skeletonAttackSound, transform.position);
                                isAttacked = true;
                                enemiesToDamage[i].GetComponent<Health>().decreaseHealth(damage);
                            }

                            else
                            {

                                anim.SetBool("Attack", false);
                                anim.SetBool("Idle", true);
                            }
                        }
                        timeBtwAttack = startTimeBtwAttack;
                    }
                    else
                    {
                        timeBtwAttack -= Time.deltaTime;
                    }

                    if (attackTime >= 5)
                    {
                        anim.SetBool("Attack", false);
                        isAttacked = false;
                    }
                    //Debug.Log(attackTime);
                }
                else
                {
                    anim.SetBool("Attack", false);
                    anim.SetBool("Idle", true);
                }
            }
            else
                Destroy(gameObject);
        }
    }
    private void attackFire()
    {
        isAttacked = true;
        attackTime = 0f;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
