using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject ControlsMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene(2);
    }

    public void ControlsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        MainMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

    public void CreditsButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        MainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
