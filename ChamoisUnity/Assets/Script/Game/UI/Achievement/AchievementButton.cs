using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AchievementButton : MonoBehaviour
{

    [FormerlySerializedAs("achievmentList")] public GameObject achievementList;
    public Sprite neutral, highlight;

    private Image sprite;

    void Start()
    {
        sprite = GetComponent<Image>();
    }

    public void Click()
    {
        if(sprite.sprite == neutral)
        {
            sprite.sprite = highlight;
            achievementList.SetActive(true);
        }
        else
        {
            sprite.sprite = neutral;
            achievementList.SetActive(false);

        }
    }
}
