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
    public GameObject _ItemActivatorObjectChamois;
    public GameObject _ItemActivatorObjectChasseur;
    public GameObject _ItemActivatorObjectRandonneur;
    
    public GameObject _MiniMap;


    public GameObject _EncyButton;

    public GameObject _CameraFogOfWar;
    public GameObject _FogOfWarCanvas;
    public GameObject _ButtonMap;
    public GameObject _CanvasButtonAchievment;
    public GameObject _CanvasGuideJeu;

    public GameObject _EncyclopedieManager;
    public GameObject _AchievementManager;
    public GameObject _PageGauche;
    public GameObject _PageDroite;
    public GameObject _Livre;

    public GameObject _MenuManager;
    public GameObject _GameManager;
    public GameObject _GameControl;
    public GameObject _Controllers;
    public GameObject _Jauges;

    public GameObject _ListeChamoisSauvages;
    public GameObject _NPCCollection;

    public GameObject _RandoDecouverteText;
    
    public GameObject _Pew;


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
    public static GameObject ItemActivatorObjectChamois;
    public static GameObject ItemActivatorObjectChasseur;
    public static GameObject ItemActivatorObjectRandonneur;
    public static GameObject MiniMap;
    
    public static GameObject EncyButton;

    public static GameObject CameraFogOfWar;
    public static GameObject FogOfWarCanvas;
    public static GameObject ButtonMap;
    public static GameObject CanvasButtonAchievment;
    public static GameObject CanvasGuideJeu;

    public static GameObject EncyclopedieManager;
    public static GameObject AchievementManager;
    public static GameObject PageGauche;
    public static GameObject PageDroite;
    public static GameObject Livre;

    public static GameObject MenuManager;
    public static GameObject GameManager;
    public static GameObject GameControl;
    public static GameObject Controllers;
    public static GameObject Jauges;

    public static GameObject ListeChamoisSauvages;
    public static GameObject NPCCollection;

    public static GameObject RandoDecouverteText;
    
    public static GameObject Pew;

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
        ItemActivatorObjectChamois = _ItemActivatorObjectChamois;
        ItemActivatorObjectChasseur = _ItemActivatorObjectChasseur;
        ItemActivatorObjectRandonneur = _ItemActivatorObjectRandonneur;
        MiniMap = _MiniMap;

        EncyButton = _EncyButton;

        CameraFogOfWar = _CameraFogOfWar;
        FogOfWarCanvas = _FogOfWarCanvas;
        ButtonMap = _ButtonMap;
        CanvasButtonAchievment = _CanvasButtonAchievment;
        CanvasGuideJeu = _CanvasGuideJeu;

        EncyclopedieManager = _EncyclopedieManager;
        AchievementManager = _AchievementManager;
        PageGauche = _PageGauche;
        PageDroite = _PageDroite;
        Livre = _Livre;
        MenuManager = _MenuManager;
        GameManager = _GameManager;
        GameControl = _GameControl;
        Controllers = _Controllers;
        Jauges = _Jauges;

        ListeChamoisSauvages = _ListeChamoisSauvages;
        NPCCollection = _NPCCollection;

        RandoDecouverteText = _RandoDecouverteText;
        
        Pew = _Pew;
    }

}
