using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    public float transitionTime = 1f;

    public Animator transition;
    public void ButtonPressed(string sceneName)
    {
        StartCoroutine(transitionAnim(sceneName));
    }

    IEnumerator transitionAnim(string sceneName)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void ButtonPressednoTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
}
