using System;
using System.Threading.Tasks;
using RPGM.UI;
using TMPro;
using UnityEngine;

//[ExecuteInEditMode]
public class GOPointer : MonoBehaviour
{
    //Inspector
    public GameObject _PlayerChamois;
    public GameObject _PlayerChasseur;
    public GameObject _PlayerRandonneur;

    public GameObject _JoystickCanvas;
    public GameObject _CameraReg;

    public GameObject _MiniMap;

    public GameObject _EncyButton;

    public GameObject _CameraFogOfWar;
    public GameObject _FogOfWarCanvas;
    public GameObject _ButtonMap;
    public GameObject _CanvasGuideJeu;

    public GameObject _EncyclopedieManager;
    public AchievmentManager _AchievementManager;
    public GameObject _PageGauche;
    public GameObject _PageDroite;
    public GameObject _Livre;
    public GameObject _EncyMenu;
    
    public GameObject _UIManager;
    public GameObject _MenuManager;
    public GameObject _GameManager;
    public GameObject _GameControl;
    public GameObject _Controllers;
    public GameObject _Jauges;

    public GameObject _ListeChamoisSauvages;
    public GameObject _NPCCollection;

    public RandoManager _RandoManager;
    
    public GameObject _Pew;
    
    public VisualNovel _VisualNovel;
    public GameObject _interactvieButtons;
    
    public TextMeshProUGUI _DechetsTexte;
    public TextMeshProUGUI _MunitionsTexte;


    //Static
    public static GameObject PlayerChamois;
    public static GameObject PlayerChasseur;
    public static GameObject PlayerRandonneur;

    public static GameObject JoystickCanvas;
    public static GameObject CameraReg;
    
    public static GameObject MiniMap;
    
    public static GameObject EncyButton;

    public static GameObject CameraFogOfWar;
    public static GameObject FogOfWarCanvas;
    public static GameObject ButtonMap;
    public static GameObject CanvasGuideJeu;

    public static GameObject EncyclopedieManager;
    public static AchievmentManager AchievementManager;
    public static GameObject PageGauche;
    public static GameObject PageDroite;
    public static GameObject Livre;

    public static GameObject EncyMenu;

    public static GameObject UIManager;
    public static GameObject MenuManager;
    public static GameObject GameManager;
    public static GameObject GameControl;
    public static GameObject Controllers;
    public static GameObject Jauges;

    public static GameObject ListeChamoisSauvages;
    public static GameObject NPCCollection;

    public static RandoManager RandoManager;
    
    public static GameObject Pew;
    
    public static VisualNovel VisualNovel;
    public static GameObject interactiveButtons;
        
    public static TextMeshProUGUI DechetsTexte;
    public static TextMeshProUGUI MunitionsTexte;

    public static GameObject currentPlayer;
    public static Encyclopedie currentEncy;

    public static Task linking;
    public static GOPointer Instance;
    
    private void Awake()
    {
        Instance = this;

        Link();
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Link();
    }

    public void Link()
    {
        linking = LinkAync();
    }
    
    public async Task LinkAync()
    {
        if(linking!=null) await linking;
        PlayerChamois = _PlayerChamois;
        PlayerChasseur = _PlayerChasseur;
        PlayerRandonneur = _PlayerRandonneur;

        JoystickCanvas = _JoystickCanvas;
        CameraReg = _CameraReg;
        
        MiniMap = _MiniMap;

        EncyButton = _EncyButton;

        CameraFogOfWar = _CameraFogOfWar;
        FogOfWarCanvas = _FogOfWarCanvas;
        ButtonMap = _ButtonMap;
        CanvasGuideJeu = _CanvasGuideJeu;

        EncyclopedieManager = _EncyclopedieManager;
        EncyMenu = _EncyMenu;
        AchievementManager = _AchievementManager;
        PageGauche = _PageGauche;
        PageDroite = _PageDroite;
        Livre = _Livre;

        UIManager = _UIManager;
        MenuManager = _MenuManager;
        GameManager = _GameManager;
        GameControl = _GameControl;
        Controllers = _Controllers;
        Jauges = _Jauges;

        ListeChamoisSauvages = _ListeChamoisSauvages;
        NPCCollection = _NPCCollection;

        RandoManager = _RandoManager;
        
        Pew = _Pew;
        
        VisualNovel = _VisualNovel;
        interactiveButtons = _interactvieButtons;
                
        DechetsTexte = _DechetsTexte;
        MunitionsTexte = _MunitionsTexte;
        
        switch(Global.Personnage){
            case "Chamois":
                currentPlayer = PlayerChamois;
                currentEncy = EncyclopedieManager.GetComponent<EncycloContentChamois>();
                break;
            
            case "Chasseur":
                currentPlayer = PlayerChasseur;
                currentEncy = EncyclopedieManager.GetComponent<EncycloContentChasseur>();
                break;
            case "Randonneur":
                currentPlayer = PlayerRandonneur;
                currentEncy = EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
                break;
        }
    }

}
