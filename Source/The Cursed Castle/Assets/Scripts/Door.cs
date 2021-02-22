using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    private Health bossHealth;
    
    private Animator doorAnim;
    public Text pressEnterText;
    private PlayerControl player;
    void Start () {
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
        doorAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
   
    // Update is called once per frame
    void Update () {
        if(bossHealth.isBossDie)
        {
            Invoke("openDoor", 3f);
            if (Input.GetKeyDown(KeyCode.LeftShift))
                SceneManager.LoadScene(2);
        }
    }
    private void openDoor()
    {
        pressEnterText.text = "<< Press Left Shift";
        doorAnim.SetBool("isWin", true);
        //sprite.sortingOrder = sortingOrder;
    }
}
