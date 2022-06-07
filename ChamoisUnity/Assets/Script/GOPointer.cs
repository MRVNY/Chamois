using UnityEngine;

public class GOPointer : MonoBehaviour
{
    //Inspector
    public GameObject _PlayerChamois;
    public GameObject _PlayerChasseur;
    public GameObject _PlayerRandonneur;

    public GameObject _JoystickCanvasChamois;
    public GameObject _JoystickCanvasChasseur;
    public GameObject _JoystickCanvasRandonneur;

    public GameObject _OptimisationWorldChamois;
    public GameObject _OptimisationWorldChasseur;
    public GameObject _OptimisationWorldRandonneur;

    public GameObject _Ouvre;
    public GameObject _OuvreChamois;
    public GameObject _OuvreChasseur;
    public GameObject _OuvreRandonneur;

    public GameObject _CameraFogOfWar;
    public GameObject _FogOfWarCanvas;
    public GameObject _ButtonMap;
    public GameObject _CanvasButtonAchievment;

    public GameObject _EncyclopedieManager;
    public GameObject _MenuManager;

    public GameObject _ListeChamoisSauvages;
    public GameObject _NPCCollection;

    public GameObject _RandoDecouverteText;


    //Static
    public static GameObject PlayerChamois;
    public static GameObject PlayerChasseur;
    public static GameObject PlayerRandonneur;

    public static GameObject JoystickCanvasChamois;
    public static GameObject JoystickCanvasChasseur;
    public static GameObject JoystickCanvasRandonneur;

    public static GameObject OptimisationWorldChamois;
    public static GameObject OptimisationWorldChasseur;
    public static GameObject OptimisationWorldRandonneur;

    public static GameObject Ouvre;
    public static GameObject OuvreChamois;
    public static GameObject OuvreChasseur;
    public static GameObject OuvreRandonneur;

    public static GameObject CameraFogOfWar;
    public static GameObject FogOfWarCanvas;
    public static GameObject ButtonMap;
    public static GameObject CanvasButtonAchievment;

    public static GameObject EncyclopedieManager;
    public static GameObject MenuManager;

    public static GameObject ListeChamoisSauvages;
    public static GameObject NPCCollection;

    public static GameObject RandoDecouverteText;

    void Awake(){
        PlayerChamois = _PlayerChamois;
        PlayerChasseur = _PlayerChasseur;
        PlayerRandonneur = _PlayerRandonneur;

        JoystickCanvasChamois = _JoystickCanvasChamois;
        JoystickCanvasChasseur = _JoystickCanvasChasseur;
        JoystickCanvasRandonneur = _JoystickCanvasRandonneur;

        OptimisationWorldChamois = _OptimisationWorldChamois;
        OptimisationWorldChasseur = _OptimisationWorldChasseur;
        OptimisationWorldRandonneur = _OptimisationWorldRandonneur;

        Ouvre = _Ouvre;
        OuvreChamois = _OuvreChamois;
        OuvreChasseur = _OuvreChasseur;
        OuvreRandonneur = _OuvreRandonneur;

        CameraFogOfWar = _CameraFogOfWar;
        FogOfWarCanvas = _FogOfWarCanvas;
        ButtonMap = _ButtonMap;
        CanvasButtonAchievment = _CanvasButtonAchievment;

        EncyclopedieManager = _EncyclopedieManager;
        MenuManager = _MenuManager;

        ListeChamoisSauvages = _ListeChamoisSauvages;
        NPCCollection = _NPCCollection;

        RandoDecouverteText = _RandoDecouverteText;
    }

}
