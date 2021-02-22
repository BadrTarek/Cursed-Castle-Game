using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBoss : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float speed;
    private Animator bossAnim;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = new Vector2(player.position.x-3, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target ,speed );
    }
    
}
