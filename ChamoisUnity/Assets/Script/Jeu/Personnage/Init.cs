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
    void Awake()
    {
        gp.Link();
    }
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
        
        gameObject.GetComponent<FinPartie>().enabled = false;

        GOPointer.EncyButton.SetActive(false);

        switch (Global.Personnage)
        {
            case "Chasseur":
                GOPointer.PlayerChamois.SetActive(false);
                GOPointer.PlayerRandonneur.SetActive(false);

                GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>().initList();

                GOPointer.CameraFogOfWar.SetActive(false);
                GOPointer.FogOfWarCanvas.SetActive(false);

                //GOPointer.CameraFogOfWarChamois.SetActive(false);
                //GOPointer.FogOfWarCanvasChamois.SetActive(false);

                GOPointer.MenuManager.SetActive(true);
                GOPointer.ButtonMap.SetActive(false);
                //GOPointer.OptimisationWorldChamois.SetActive(false);
                GOPointer.OptimisationWorldRandonneur.SetActive(false);



                break;

            case "Randonneur":
                GOPointer.PlayerChamois.SetActive(false);
                GOPointer.PlayerChasseur.SetActive(false);

                GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>().initList();
                GOPointer.MenuManager.SetActive(true);
                GOPointer.ButtonMap.SetActive(false);
                GOPointer.ListeChamoisSauvages.SetActive(false);
                //GOPointer.CanvasButtonAchievment.SetActive(false);
                GOPointer.OptimisationWorldChamois.SetActive(false);
                GOPointer.OptimisationWorldChasseur.SetActive(false);


                //GOPointer.CameraFogOfWarChamois.SetActive(false);
                //GOPointer.FogOfWarCanvasChamois.SetActive(false);


                break;

            case "Chamois":
                //print(GOPointer.PlayerChasseur);
                GOPointer.PlayerChasseur.SetActive(false);
                GOPointer.CameraFogOfWar.SetActive(false);
                GOPointer.FogOfWarCanvas.SetActive(false);

                //GOPointer.CameraFogOfWarChamois.SetActive(false);
                //GOPointer.FogOfWarCanvasChamois.SetActive(false);

                GOPointer.PlayerRandonneur.SetActive(false);

                GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>().initList();
                GOPointer.MenuManager.SetActive(true);
                GOPointer.ButtonMap.SetActive(false);
                GOPointer.ListeChamoisSauvages.SetActive(false);
                //GOPointer.CanvasButtonAchievment.SetActive(false);
                GOPointer.OptimisationWorldChasseur.SetActive(false);
                GOPointer.OptimisationWorldRandonneur.SetActive(false);
                
                break;

        }
        
        npcManager.loadConvo();
        papa.gameObject.SetActive(true);
        GOPointer.UIManager.GetComponent<UIManager>().Start();
        papa.Start();
        papa.onclick();
    }

}
