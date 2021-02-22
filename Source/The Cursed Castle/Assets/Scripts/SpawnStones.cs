using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStones : MonoBehaviour
{
    public GameObject[] stones;
    public int index;
    public float startDelay = 1.5f;
    public float repeatDelay = 1.5f;
    private PlayerControl player;
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
        if (Time.timeScale == 1) { 
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
            index = Random.Range(0, stones.Length);
            Vector3 pos = new Vector3(Random.Range(8, -8), 4.16f, 0);
            Instantiate(stones[index], pos, stones[index].transform.rotation);
        }
    }
}
