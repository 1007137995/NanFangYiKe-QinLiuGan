using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{

    public Dictionary<string, int> wrongDic = new Dictionary<string, int>();

    public int xz1 = 0;
    public int xz2 = 0;
    public int cy = 0;
    public int ty = 0;

    public static TimeManager instance;
    public GameObject timeIntro;

    public int timeSpeed = 6;
    public int timeSec = 0;
    public Image hourImg1;
    public Image hourImg2;
    public Image minImg1;
    public Image minImg2;

    public bool isOverNongjiayuan = false;
    public bool isOverYiyan = false;

    public bool isOverTuiyi = false;

    public int hour;
    public int min;

    public void recordWrong(string str) {
        if (str == "选择1")
        {
            xz1++;
        } else if (str == "选择2") {
            xz2++;
        }
        else if (str == "穿衣")
        {
            cy++;
        }
        else if (str == "脱衣")
        {
            ty++;
        }
    }

    public Sprite[] figures;
    // Use this for initialization
    void Start () {
        instance = this;
        figures = Resources.LoadAll<Sprite>("figure");

        //6秒钟 -- 1分钟，时间比 1：10
        //InvokeRepeating("changeTime",0f, timeSpeed);
        InvokeRepeating("changeTime", 0f, 6f);
    }

    public void changeTime() {
        hour = timeSec / 60;
        min = timeSec % 60;

        int hour1 = hour/10;
        int hour2 = hour%10;

        int min1 = min/10;
        int min2 = min%10;

        hourImg1.sprite = getSpriteByFigure(hour1);
        hourImg2.sprite = getSpriteByFigure(hour2);
        minImg1.sprite = getSpriteByFigure(min1);
        minImg2.sprite = getSpriteByFigure(min2);
        // 经过一分钟
        timeSec++;
    }

    public Sprite getSpriteByFigure(int i) {
        foreach (Sprite figure in figures) {
            if (figure.name == i.ToString()) {
                return figure;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
            Debug.Log("Left Mouse Clicked");
        if (eventData.pointerId == -2)
            Debug.Log("Right Mouse Clicked");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        timeIntro.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        timeIntro.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragged");
    }

}
