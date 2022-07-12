using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject title;
    public GameObject main;
    public GameObject options;
    public GameObject select;

    void Start()
    {
        // title = GameObject.Find("Titre");
        // main = GameObject.Find("MainMenu");
        // options = GameObject.Find("OptionsMenu");
        // select = GameObject.Find("SelectionPersonnage");
        
        title.SetActive(true);
        main.SetActive(true);
        options.SetActive(false);
        select.SetActive(false);
    }

    public void clickPlay()
    {
        title.SetActive(false);
        main.SetActive(false);
        options.SetActive(false);
        select.SetActive(true);
    }

    public void clickOptions()
    {
        title.SetActive(false);
        main.SetActive(false);
        options.SetActive(true);
        select.SetActive(false);
    }

    public void clickGenerique()
    {
        title.SetActive(false);
        main.SetActive(false);
        options.SetActive(false);
        select.SetActive(false);
        SceneManager.LoadScene("StarWars");
    }

    public void backToMenu()
    {
        title.SetActive(true);
        main.SetActive(true);
        options.SetActive(false);
        select.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
      Application.Quit();
    }

    public void sortirGenerique()
    {
        SceneManager.LoadScene("Menu");
    }
}
