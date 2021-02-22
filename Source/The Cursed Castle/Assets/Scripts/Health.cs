using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthSlider;
    public float health;
    private Animator anim;
    public bool isAttacked = false;
    public bool isSkeleton = false;
    struct HealthStruct
    {
        public float maxHealth;
        public float curHealth;
    };
    HealthStruct healthObj= new HealthStruct();
    public bool isDie = false;
    public bool isBossDie = false;
    public bool isWin = false;
    public bool isPlayerDie = false;
    void Start()
    {
        healthObj.maxHealth = healthObj.curHealth = health;
        anim = GetComponent<Animator>();
        if(healthSlider!=null)
            healthSlider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(healthObj.curHealth);
        if (isBossDie)
            isWin = true;
        // = (isBossDie) ? true : false;
        if (healthObj.curHealth <= 0 && isSkeleton == false)
        {
            if (gameObject.CompareTag("Boss"))
            {
                isBossDie = true;
                anim.SetBool("BossAttack", false);
            }
            anim.SetBool("Die", true);
            isDie = true;
            if(gameObject.CompareTag("Player"))
            {
                isPlayerDie = true;
            }
        }
        else if (healthObj.curHealth <= 0 && isSkeleton)
        {
            Destroy(gameObject);
        }
        if(healthSlider!=null)
            healthSlider.value = healthObj.curHealth;
    }
    public void decreaseHealth(float decrease)
    {
       // anim.SetBool("Hit", true);
        healthObj.curHealth -= decrease;
        //isAttacked = true;
       // Invoke("resetAmnim", 0.3f);
    }
}
