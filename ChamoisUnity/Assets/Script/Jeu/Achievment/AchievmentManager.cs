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

    private AchievmentButton activeButton;

    public ScrollRect scrollRect;

    public GameObject achievmentMenu;

    public GameObject visualAchievment;

    public Dictionary<string, Achievment> achievments = new Dictionary<string, Achievment>();

    public Sprite unlockedSprite;

    public Text textPoints;

    private Boolean carteActive;

    private static AchievmentManager instance;

    private int fadeTime = 4;

    static Boolean activateOnceChamois = false;
    static Boolean activateOnceChasseur = false;
    static Boolean activateOnceRandonneur = false;

    public TextAsset jsonFile;
    public ArrayList data = new ArrayList();


    public static AchievmentManager Instance 
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievmentManager>();
            }
            return AchievmentManager.instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.delete("Points");
        activeButton = GameObject.Find("ChamoisBtn").GetComponent<AchievmentButton>();

        // Récupération des données dans le JSON, lié dans le GameObject ""
        AchievmentInfoList infosInJson = JsonUtility.FromJson<AchievmentInfoList>(jsonFile.text);

        foreach (AchievmentInfo achievmentinfo in infosInJson.achievmentinfos)
        {
           if(achievmentinfo.dependance1 == "")
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image);
                data.Add(achievmentinfo);
            }
            else if(achievmentinfo.dependance2 == "")
            {
                CreateAchievment(achievmentinfo.joueur, achievmentinfo.nomAch, achievmentinfo.descAch, achievmentinfo.points, achievmentinfo.image, new string[] { achievmentinfo.dependance1 });

                data.Add(achievmentinfo);
            }
            else if (achievmentinfo.dependance3 == "")
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

        foreach(GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievmentList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click();

        achievmentMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteAll();
        carteActive = GOPointer.MiniMap.GetComponent<SwitchPlayerMap>().isActive;
        // Dans un autre script, pour obtenir un achievment, utiliser : 
        // AchievmentManager.Instance.EarnAchievment(achievmentName);

        if (Input.GetKeyDown(KeyCode.I))
        {
            achievmentMenu.SetActive(!achievmentMenu.activeSelf);
        }        

    }

    public void openCloseAchiemvent()
    {
        achievmentMenu.SetActive(!achievmentMenu.activeSelf);

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

            if(Global.Personnage == "Chasseur")
            {
                addToEncyChasseur();
            }
            else if(Global.Personnage == "Chamois")
            {
                addToEncyChamois();
            }
            else if(Global.Personnage == "Randonneur")
            {
                addToEncyRandonneur();
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
        achievment.transform.SetParent(GameObject.Find(parent).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = title;
        achievment.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = achievments[title].Description;
        achievment.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = achievments[title].Points.ToString();
        achievment.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achievments[title].SpriteIndex];
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

    public static void addToEncyChasseur()
    {
        if (!activateOnceChasseur)
        {
            EncycloContentChasseur ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChasseur>();
            ency.addInfoToList("hautFait", ency.pagesDynamic);
            activateOnceChasseur = true;
        }
    }

    public static void addToEncyChamois()
    {
        if (!activateOnceChamois)
        {
            EncycloContentChamois ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentChamois>();
            ency.addInfoToList("hautFait", ency.pagesDynamic);
            activateOnceChamois = true;
        }
    }

    public static void addToEncyRandonneur()
    {
        if (!activateOnceRandonneur)
        {
            EncycloContentRandonneur ency = GOPointer.EncyclopedieManager.GetComponent<EncycloContentRandonneur>();
            ency.addInfoToList("hautFait", ency.pagesDynamic);
            activateOnceRandonneur = true;
        }
    }
}
