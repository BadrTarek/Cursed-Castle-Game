using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingManager;
    public GameObject startUI;
    public GameObject qualityList;
    public GameObject soundList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        Application.LoadLevel(1);
    }
    public void SettingManagerUI ()
    {
        settingManager.SetActive(true);
        startUI.SetActive(false);
    }
    public void ExitFromGame()
    {
        Application.Quit();
    }
    public void BackToStartMenuFromSetting()
    {
        settingManager.SetActive(false);
        startUI.SetActive(true);
    }
    public void DisplayQualityList()
    {
        settingManager.SetActive(false);
        qualityList.SetActive(true);
    }
    public void BackToSettingMenuFromQuaityList()
    {
        settingManager.SetActive(true);
        qualityList.SetActive(false);
    }
    public void SetLowQuaity()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void SetHighQuaity()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void SetUltraQuaity()
    {
        QualitySettings.SetQualityLevel(4);
    }
    public void MuteSound()
    {
        AudioListener.volume = 0f;
    }
    public void UnMuteSound()
    {
        AudioListener.volume = 1.0f;
    }
    public void SoundManager()
    {
        settingManager.SetActive(false);
        soundList.SetActive(true);
    }
    public void BackToSettingFromSounds()
    {
        settingManager.SetActive(true);
        soundList.SetActive(false);
    }
}
