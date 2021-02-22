using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStone : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().decreaseHealth(damage);
            Destroy(gameObject);
        }else if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
