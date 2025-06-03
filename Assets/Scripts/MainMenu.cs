using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button closeMenu;
    public Button openMenu;
    public GameObject pauseMenu;
    public GameObject menuButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OpenMenu() {  pauseMenu.SetActive(true); }
    public void CloseMenu() { pauseMenu.SetActive(false);  }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
