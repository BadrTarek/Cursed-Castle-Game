using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;
    private Animator playerAnim;
    public AudioClip attack;
    private AudioSource audioSource;
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
    }
    private void Update()
    {
        /*if(timeBtwAttack<=0)
        {*/
            /*
             if(Input.GetKeyDown(KeyCode.LeftControl))
            playerAnim.SetBool("Attack", true);
        else
            playerAnim.SetBool("Attack", false);
             */
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerAnim.SetBool("Attack", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position , attackRange , whatIsEnemies);
                
                for (int i = 0; i<enemiesToDamage.Length; i++)
                {
                audioSource.PlayOneShot(attack,1.0f);
                    enemiesToDamage[i].GetComponent<Health>().decreaseHealth(damage);
                }

            }
            else
                playerAnim.SetBool("Attack", false);

            timeBtwAttack = startTimeBtwAttack;
        /*}
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }*/
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
