using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public Button pauseButton;
    public GameObject pauseList;
    public GameObject gameOver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                PauseGame();
            else if (Time.timeScale == 0)
                ContinueGame();
        }
    }
    public void PauseGame() {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        pauseList.gameObject.SetActive(true);

    }
    public void ContinueGame() {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        pauseList.gameObject.SetActive(false);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseList.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Application.LoadLevel(1);
        //SceneManager.LoadScene(1);
    }

    public void BackToStart()
    {
        Time.timeScale = 1;
        pauseList.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Application.LoadLevel(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
    }

}
