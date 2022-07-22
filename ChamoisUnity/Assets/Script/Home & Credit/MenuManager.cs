using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class MenuManager : MonoBehaviour
{

    public GameObject title;
    public GameObject main;
    public GameObject options;
    public GameObject select;
    public GameObject loading;
    public TextMeshProUGUI percentage;

    void Start()
    {
        title.SetActive(true);
        main.SetActive(true);
        options.SetActive(false);
        select.SetActive(false);
        loading.SetActive(false);
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

    public void PlayGame(string personnage)
    {
        loading.SetActive(true);
        Global.Personnage = personnage;
        StartCoroutine(LoadAsynchronously("Game"));
    }

    public void QuitGame()
    {
      Application.Quit();
    }

    public void sortirGenerique()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            percentage.text = (int)(operation.progress*100/.9f) + " %";
            yield return null;
        }
    }
}
