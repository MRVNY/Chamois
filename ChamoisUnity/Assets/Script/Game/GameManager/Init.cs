using System;
using System.Threading.Tasks;
using RPGM.Gameplay;
using UnityEngine;


///<summary>
/// classe qui active les bons composant de la scène pour jouer aux jeux
///</summary>

public class Init : MonoBehaviour
{

    public GOPointer gp;
    public NPCManager npcManager;
    
    public NPCController papa;
    public NPCController guide;
    public NPCController chamois;

    public static Task loading;
    public static Task convo;
    void Awake()
    {
        gp.Link();
        
        GOPointer.CanvasGuideJeu.SetActive(true);
        GOPointer.EncyclopedieManager.SetActive(true);
        GOPointer.AchievementManager.transform.parent.gameObject.SetActive(true);
        GOPointer.FogOfWarCanvas.transform.parent.gameObject.SetActive(true);
        GOPointer.NPCCollection.SetActive(true);
        //GOPointer.currentMap.transform.parent.gameObject.SetActive(true);
        
        //decor? day&night
    }

    private void OnEnable()
    {
        if(gp==null) Awake();
    }

    async void Start() 
    {
        if(gp==null) Awake();
        if (GOPointer.linking!=null) await GOPointer.linking;
        
        // Init convo if player start the character the first time
        convo = npcManager.loadConvo();
        
        loading = SaveLoad.LoadState();
        
        //Screen.SetResolution(1280, 720, false);
        
        gameObject.GetComponent<FinPartie>().enabled = false;

        GOPointer.EncyButton.SetActive(false);
        GOPointer.MenuManager.SetActive(true);
        GOPointer.ButtonMap.SetActive(false);
        GOPointer.MiniMap.SetActive(false);
        //GOPointer.CanvasButtonAchievment.SetActive(false);

        GOPointer.CameraFogOfWar.SetActive(false);
        GOPointer.FogOfWarCanvas.SetActive(false);
        
        GOPointer.PlayerChamois.SetActive(false);
        GOPointer.PlayerRandonneur.SetActive(false);
        GOPointer.PlayerChasseur.SetActive(false);
        
        Map.Instance.MapChamois.SetActive(false);
        Map.Instance.MapChasseur.SetActive(false);
        Map.Instance.MapRando.SetActive(false);

        GOPointer.currentPlayer.SetActive(true);
        
        switch (Global.Personnage)
        {
            case "Chasseur":
                GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>().initList();
                GOPointer.ListeChamoisSauvages.SetActive(true);
                Map.Instance.MapChasseur.SetActive(true);
                break;

            case "Randonneur":
                GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>().initList();
                GOPointer.ListeChamoisSauvages.SetActive(false);
                GOPointer.CameraFogOfWar.SetActive(true);
                GOPointer.FogOfWarCanvas.SetActive(true);
                Map.Instance.MapRando.SetActive(true);
                break;

            case "Chamois":
                GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>().initList();
                GOPointer.ListeChamoisSauvages.SetActive(false);
                Map.Instance.MapChamois.SetActive(true);
                break;
        }
        
        GOPointer.CameraReg.GetComponentInChildren<CameraControllerJoy>().ManualStart();

        if (!PlayerPrefs.HasKey(Global.Personnage))
        {
            if(convo!=null) await convo;
            GOPointer.UIManager.GetComponent<UIManager>().Start();

            switch (Global.Personnage)
            {
                case "Chamois":
                    
                    break;
                
                case "Chasseur":
                    papa.gameObject.SetActive(true);
                    papa.Start();
                    papa.onclick("3");
                    break;
                
                case "Randonneur":
                    guide.gameObject.SetActive(true);
                    guide.Start();
                    guide.onclick("init");
                    break;
            }
        }
        else
        {
            PauseMenu.instance.Resume();
        }
    }

}
