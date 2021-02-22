using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Queen queen;
    public GameObject winUI;
    public GameObject heart;
    public AudioSource audioSource;
    public AudioClip kissSound;
    private bool notRepeatSound = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (queen.isWithPlayer == true  && !notRepeatSound)
        {
            Invoke("kiss", 2.0f);
            notRepeatSound = true;
        }
    }
    public void kiss()
    {
        heart.SetActive(true);
        audioSource.PlayOneShot(kissSound, 1.0f);
        Invoke("win", 3.0f);
    }
    public void win()
    {
        Time.timeScale = 0;
        winUI.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }
    public void BackToStart()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
