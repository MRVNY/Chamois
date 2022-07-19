using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class AchievmentManager : MonoBehaviour
{

    public GameObject achievmentPrefab;

    public Sprite[] sprites;

    public AchievmentButton activeButton;

    public ScrollRect scrollRect;

    public GameObject achievementMenu;

    public GameObject visualAchievment;

    public Dictionary<string, Achievment> achievments = new Dictionary<string, Achievment>();

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

    // Start is called before the first frame update
    void Start()
    {
        encyChasseur = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
        encyChamois = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
        encyRando = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
        
        parents = new Dictionary<string, GameObject>();
        parents.Add("Chamois",scrollRect.transform.Find("Chamois").gameObject);
        parents.Add("Chasseur",scrollRect.transform.Find("Chasseur").gameObject);
        parents.Add("Randonneur",scrollRect.transform.Find("Randonneur").gameObject);

        // Récupération des données dans le JSON, lié dans le GameObject ""
        AchievmentInfoList infosInJson = JsonUtility.FromJson<AchievmentInfoList>(jsonFile.text);

        foreach (AchievmentInfo achievmentinfo in infosInJson.achievmentinfos)
        { 
            if(string.IsNullOrEmpty(achievmentinfo.dependance1))
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image);
                data.Add(achievmentinfo);
            }
            else if(string.IsNullOrEmpty(achievmentinfo.dependance2))
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image, new string[] { achievmentinfo.dependance1 });

                data.Add(achievmentinfo);
            }
            else if (string.IsNullOrEmpty(achievmentinfo.dependance3))
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image, new string[] { achievmentinfo.dependance1, achievmentinfo.dependance2 });

                data.Add(achievmentinfo);
            }
            else
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image, new string[] { achievmentinfo.dependance1, achievmentinfo.dependance2, achievmentinfo.dependance3 });

                data.Add(achievmentinfo);
            }
        }

        foreach(VerticalLayoutGroup achievmentList in scrollRect.GetComponentsInChildren<VerticalLayoutGroup>())
        {
            achievmentList.gameObject.SetActive(false);
        }

        activeButton.Click();

        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        //carteActive = GOPointer.MiniMap.GetComponent<SwitchPlayerMap>().isActive;
        // Dans un autre script, pour obtenir un achievment, utiliser : 
        // GOPointer.AchievementManager.EarnAchievment(achievmentName);

        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     achievmentMenu.SetActive(!achievmentMenu.activeSelf);
        // }        

    }

    public void EarnAchievment(string title)
    {
        if (achievments[title].EarnAchievment())
        {
            GameObject achievment = (GameObject)Instantiate(visualAchievment);
            SetAchievmentInfo("EarnCanvas", achievment, title);
            textPoints.text = "Points : " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievment(achievment));
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

    public IEnumerator HideAchievment(GameObject achievment)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievment);
    }

    public void CreateAchievment(string parent, string title, string description, int points, int spriteIndex, string[] dependencies = null)
    {

        GameObject achievment = (GameObject)Instantiate(achievmentPrefab);

        Achievment newAchievment = new Achievment(title, description, points, spriteIndex, achievment);
        achievments.Add(title, newAchievment);

        SetAchievmentInfo(parent, achievment, title);

        if(dependencies != null)
        {
            foreach(string achievmentTitle in dependencies)
            {
                Achievment dependency = achievments[achievmentTitle];
                dependency.Child = title;
                newAchievment.AddDependency(dependency);
            }
        }
    }

    public void SetAchievmentInfo(string parent, GameObject achievment, string title)
    {
        achievment.transform.SetParent(parents[parent].transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        AchiObject pointer = achievment.GetComponent<AchiObject>();
        pointer.title.text = title;
        pointer.description.text = achievments[title].Description;
        pointer.points.text = achievments[title].Points.ToString();
        pointer.image.sprite = sprites[achievments[title].SpriteIndex];
    }

    public void ChangeCategory(GameObject button)
    {
        AchievmentButton achievmentButton = button.GetComponent<AchievmentButton>();

        scrollRect.content = achievmentButton.achievmentList.GetComponent<RectTransform>();

        achievmentButton.Click();
        activeButton.Click();
        activeButton = achievmentButton;
    }

    private IEnumerator FadeAchievment(GameObject achievment)
    {
        CanvasGroup canvasGroup = achievment.GetComponent<CanvasGroup>();

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
        Destroy(achievment);
    }
}
