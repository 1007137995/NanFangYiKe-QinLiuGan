using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;
/************************************************************
  Copyright (C), 2007-2017,BJ Rainier Tech. Co., Ltd.
  FileName: LastScene.cs
  Author:zjw       Version :1.0          Date: 2017-8-29
  Description:最后一个场景的UI控制
************************************************************/


public class LastScene : MonoBehaviour {

    public static LastScene instance;
    public GameObject Tongyong;
    public GameObject mask;
    public GameObject xixiao;
    public GameObject t1;
    public GameObject t2;
    public GameObject zongjie;
    public GameObject jieshu;
    public GameObject pingfen;
    public GameObject Item;
    public Text defen;
    private int Score = 100;
    private TimeManager tm;
    private bool SY = false;

    void Start() {
        instance = this;
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            SY = false; 
        }
        else
        {
            SY = true;            
        }
        tm = GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>();
    }

    void Update() {

    }

    public void Tuo()
    {
        mask.SetActive(false);
        xixiao.SetActive(false);
        t1.SetActive(true);
        t2.SetActive(true);
    }

    public void Summed()
    {
        if (SY == false) 
        {
            AddScore();
        }
        mask.SetActive(true);
        t1.SetActive(false);
        t2.SetActive(false);
        zongjie.SetActive(true);
        zongjie.transform.FindChild("Text").GetComponent<Text>().text = "";
        string benContent = "报告人姓名：\u3000事件发生地：\n" +
"接报告时间：\u3000事件首发时间：\n" +
"涉及人数、病人总数、住院人数、死亡人数等人员情况\n" +
"\n所做操作内容：\n" +
"对患者和疑似患者进行了流调、样品采集、隔离治疗" +
"密切接触者隔离治疗\n" +
"对病人家属进行了流行病学调查、健康教育\n" +
"对疫区、疫点、病人家中，活禽市场进行了综合消毒\n" +
"上交传染病报告卡，样品送至实验室进行检测\n" +
"\n结论：疫情基本得到控制，群众情绪稳定\n";
        Tween twben = zongjie.transform.FindChild("Text").GetComponent<Text>().DOText(benContent, benContent.Length * 0.1f);
        twben.SetUpdate(true);
        twben.SetEase(Ease.Linear);
        twben.OnComplete(ShowButton);
    }

    public void ShowButton()
    {
        zongjie.transform.FindChild("Button").gameObject.SetActive(true);
    }

    public void Tijiao()
    {
        zongjie.gameObject.SetActive(false);
        if (SY == false)
        {
            pingfen.SetActive(true);
        }
        else
        {
            jieshu.SetActive(true);
        }
    }

    public void AddScore()
    {
        Debug.Log(SystemManager.instance.wrongList.Count);
        foreach (wrongInfo item in SystemManager.instance.wrongList)
        {
            Debug.Log(SystemManager.instance.wrongList.Count);
            GameObject tiao = Instantiate(Item);
            tiao.SetActive(true);
            tiao.transform.SetParent(Item.transform.parent);
            tiao.transform.FindChild("Image/TiMu").GetComponent<Text>().text = item.des;
            if (item.result == true)
            {
                tiao.transform.FindChild("Image/FenShu").GetComponent<Text>().text = item.Num.ToString();
            }
            else
            {
                tiao.transform.FindChild("Image/FenShu").GetComponent<Text>().text = "-" + item.Num.ToString();
                Score -= item.Num;
            }
        }
        defen.text = Score.ToString();
        if (SY == false)
        {
            double s = (double)Score;
            Application.ExternalCall("setExpResult", s);
        }
    }

    public void End()
    {
        PlayerPrefs.DeleteKey("moshi");
        SystemManager.instance.wrongList.Clear();
        SystemManager.instance.transform.FindChild("Caozuo/Image").gameObject.SetActive(true);
        tm.gameObject.SetActive(false);
        tm.xz1 = 0;
        tm.xz2 = 0;
        tm.cy = 0;
        tm.ty = 0;
        tm.timeSec = 0;
        tm.isOverNongjiayuan = false;
        tm.isOverTuiyi = false;
        tm.isOverYiyan = false;
        tm.min = 0;
        tm.hour = 0;
        SceneManager.LoadScene(1);
    }
}
