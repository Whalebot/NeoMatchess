using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public Slider gameSpeedSlider;
    public Slider masterVolumeSlider;
    public Slider sfxSlider;
    public GameSettings gameSettings;
    public AudioMixer audioMixer;
    public Button closeMenu;
    public Button openMenu;
    public GameObject pauseMenu;
    public GameObject menuButton;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        gameSpeedSlider.onValueChanged.AddListener(delegate { ChangeGameSpeed(); });
        masterVolumeSlider.onValueChanged.AddListener(delegate { ChangeMasterVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { ChangeSFXVolume(); });
        openMenu.onClick.AddListener(delegate { OpenMenu(); });
        closeMenu.onClick.AddListener(delegate { CloseMenu(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeGameSpeed()
    {
        if (gameSpeedSlider.value == 0) gameSettings.moveSpeed = gameSettings.speed0;
        else if (gameSpeedSlider.value == 1) gameSettings.moveSpeed = gameSettings.speed1;
        else if (gameSpeedSlider.value == 2) gameSettings.moveSpeed = gameSettings.speed2;
    }
    void ChangeMasterVolume() { audioMixer.SetFloat("masterVolume", masterVolumeSlider.value); }
    void ChangeSFXVolume() { audioMixer.SetFloat("sfxVolume", sfxSlider.value); }
    void CloseMenu() { GameSettings.isPaused = false; pauseMenu.SetActive(false); menuButton.SetActive(true); }
    void OpenMenu() { GameSettings.isPaused = true; pauseMenu.SetActive(true); menuButton.SetActive(false); }
}
