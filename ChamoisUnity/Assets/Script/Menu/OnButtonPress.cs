using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonPress : MonoBehaviour
{
    public string sceneName;
    public void OnCLickButton(string personnage)
    {
        Global.Personnage = personnage;
        SceneManager.LoadScene(sceneName);
    }
}
