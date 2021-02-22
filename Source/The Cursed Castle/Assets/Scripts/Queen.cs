using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator queenAnim;
    public bool isWithPlayer = false;
    public AudioSource audioSource;
    public AudioClip happy;

    void Start()
    {
        queenAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //audioSource.PlayOneShot(attack,1.0f);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            queenAnim.SetBool("PlayerArrived", true);
            audioSource.PlayOneShot(happy, 1.0f);
            isWithPlayer = true;
        }
    }
}
