using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// classe pour les évennements
/// </summary>
public class GameEvents : MonoBehaviour
{

    public static System.Action         SaveInitiated;
    public static System.Action<int>    FoodEaten;
    public static System.Action         SwitchCamera;
    public static System.Action         Pause;

    private List<int> idNourritureDetruite = new List<int>();
    // Start is called before the first frame update

    public static void onFoodEaten(int id)
    {
        FoodEaten?.Invoke(id);
        NourritureMangee.addToEncy();
    }

    public static void onSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }

    public static void onSwitchCamera()
    {
        SwitchCamera?.Invoke();
    }

    public static void onPause()
    {
        Pause?.Invoke();
    }

    public static void Clear()
    {
        SaveInitiated = null;
        FoodEaten = null;
        SwitchCamera = null;
        Pause = null;
    }
}