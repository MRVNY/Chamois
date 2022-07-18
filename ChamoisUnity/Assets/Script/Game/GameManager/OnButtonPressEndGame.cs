using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonPressEndGame : MonoBehaviour
{
    public void OnCLickButton(string sceneName)
    {
        GameEvents.Clear();
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneName) ;
    }
}
