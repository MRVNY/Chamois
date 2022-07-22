using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Serialization;


public class AchievementManager : MonoBehaviour
{

    [FormerlySerializedAs("achievmentPrefab")] public GameObject achievementPrefab;

    public Sprite[] sprites;

    public AchievementButton activeButton;

    public ScrollRect scrollRect;

    public GameObject achievementMenu;

    [FormerlySerializedAs("visualAchievment")] public GameObject visualAchievement;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    public Sprite unlockedSprite;

    public Text textPoints;

    //private Boolean carteActive;
    
    private int fadeTime = 4;

    static Boolean activateOnceChamois = false;
    static Boolean activateOnceChasseur = false;
    static Boolean activateOnceRandonneur = false;
    
    EncycloContentChasseur encyChasseur;
    EncycloContentChamois encyChamois;
    EncycloContentRandonneur encyRando;

    public TextAsset jsonFile;
    public ArrayList data = new ArrayList();

    private Dictionary<string, GameObject> parents;

    public static AchievementManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        encyChasseur = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
        encyChamois = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
        encyRando = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
        
        parents = new Dictionary<string, GameObject>();
        parents.Add("Chamois",scrollRect.transform.Find("Chamois").gameObject);
        parents.Add("Chasseur",scrollRect.transform.Find("Chasseur").gameObject);
        parents.Add("Randonneur",scrollRect.transform.Find("Randonneur").gameObject);

        // Récupération des données dans le JSON, lié dans le GameObject ""
        AchievementInfoList infosInJson = JsonUtility.FromJson<AchievementInfoList>(jsonFile.text);

        foreach (AchievementInfo achievementinfo in infosInJson.achievementinfos)
        { 
            if(string.IsNullOrEmpty(achievementinfo.dependance1))
            {
                CreateAchievement(achievementinfo.joueur, achievementinfo.nomAch, achievementinfo.descAch, achievementinfo.points, achievementinfo.image);
                data.Add(achievementinfo);
            }
            else if(string.IsNullOrEmpty(achievementinfo.dependance2))
            {
                CreateAchievement(achievementinfo.joueur, achievementinfo.nomAch, achievementinfo.descAch, achievementinfo.points, achievementinfo.image, new string[] { achievementinfo.dependance1 });

                data.Add(achievementinfo);
            }
            else if (string.IsNullOrEmpty(achievementinfo.dependance3))
            {
                CreateAchievement(achievementinfo.joueur, achievementinfo.nomAch, achievementinfo.descAch, achievementinfo.points, achievementinfo.image, new string[] { achievementinfo.dependance1, achievementinfo.dependance2 });

                data.Add(achievementinfo);
            }
            else
            {
                CreateAchievement(achievementinfo.joueur, achievementinfo.nomAch, achievementinfo.descAch, achievementinfo.points, achievementinfo.image, new string[] { achievementinfo.dependance1, achievementinfo.dependance2, achievementinfo.dependance3 });

                data.Add(achievementinfo);
            }
        }

        foreach(VerticalLayoutGroup achievementList in scrollRect.GetComponentsInChildren<VerticalLayoutGroup>())
        {
            achievementList.gameObject.SetActive(false);
        }

        activeButton.Click();

        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        //carteActive = GOPointer.MiniMap.GetComponent<SwitchPlayerMap>().isActive;
        // Dans un autre script, pour obtenir un achievement, utiliser : 
        // GOPointer.AchievementManager.EarnAchievement(achievementName);

        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     achievementMenu.SetActive(!achievementMenu.activeSelf);
        // }        

    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            textPoints.text = "Points : " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievement(achievement));
            //addToEncy();

      
            if (Global.Personnage == "Chasseur" && !activateOnceChasseur)
            {
                encyChasseur.addInfoToList("hautFait", encyChasseur.pagesDynamic);
                activateOnceChasseur = true;
            }
            else if (Global.Personnage == "Chamois" && !activateOnceChamois)
            {
                encyChamois.addInfoToList("hautFait", encyChamois.pagesDynamic);
                activateOnceChamois = true;
            }
            else if (Global.Personnage == "Randonneur" && !activateOnceRandonneur)
            {
                encyRando.addInfoToList("hautFait", encyRando.pagesDynamic);
                activateOnceRandonneur = true;
            }
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex, string[] dependencies = null)
    {

        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(title, description, points, spriteIndex, achievement);
        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);

        if(dependencies != null)
        {
            foreach(string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(parents[parent].transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        AchiObject pointer = achievement.GetComponent<AchiObject>();
        pointer.title.text = title;
        pointer.description.text = achievements[title].Description;
        pointer.points.text = achievements[title].Points.ToString();
        pointer.image.sprite = sprites[achievements[title].SpriteIndex];
    }

    public void ChangeCategory(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;
    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;

        int startAlpha = 0;
        int endAlpha = 1;


        for (int i = 0; i < 2; i++)
        {

            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                progress += rate * Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(2);
            startAlpha = 1;
            endAlpha = 0;
        }
        Destroy(achievement);
    }
}
