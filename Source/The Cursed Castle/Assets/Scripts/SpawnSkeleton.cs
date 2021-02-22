using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkeleton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skeleton;
    public float startDelay = 1.5f;
    public float repeatDelay = 1.5f;
    private Health playerhealth;
    private Health bossHealth;
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, repeatDelay);
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (playerhealth.isDie)
                Destroy(gameObject);
            else if (bossHealth.isBossDie)
                Destroy(gameObject);
        }
    }
    private void Spawn()
    {
        if (Time.timeScale == 1)
        {
            Instantiate(skeleton, transform.position, skeleton.transform.rotation);
        }   
    }
}

