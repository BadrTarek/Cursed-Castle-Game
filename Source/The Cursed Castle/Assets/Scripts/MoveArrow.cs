using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=0.5f;
    public float damage;
    private PlayerControl player;
    private float scaleX;
    void Start()
    {
        scaleX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            /*if (transform.localScale.x < 0 )
                transform.Translate(Vector3.up * speed);
            else
                transform.Translate(Vector3.down * speed);*/
            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
            //Debug.Log(player.transform.localScale.x);
            if (player.playerPosition > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, 0);
            transform.Translate(Vector3.left * speed);
        }
        else if (player.playerPosition < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, 0);
            transform.Translate(Vector3.right * speed);
        }
        if (transform.position.x > 8.7)
            Destroy(gameObject);
        else if (transform.position.x < -8.7)
            Destroy(gameObject);
    }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.timeScale == 1)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                collision.GetComponent<Health>().decreaseHealth(damage);
                Destroy(gameObject);
            }
        }
    }
}
