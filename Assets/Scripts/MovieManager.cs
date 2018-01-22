using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieManager : MonoBehaviour {

    public static MovieManager instance;
    public GameObject Tongyong;
    public GameObject toufa;
    public GameObject bianfu;
    public List<GameObject> cloths;
    public bool CT;
    public int stepNo = 0;
    public bool openXS = false;
    private TimeManager tm;

    //标记脱穿衣顺序是否错误。默认为正确,错误是标记为false。
    private bool isCyWrong = true;
    private bool isTyWrong = true;
    private bool SY = false;

    // Use this for initialization
    void Start () {
        instance = this;
        tm = GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>();
        if (GameObject.FindGameObjectWithTag("time") != null) {
            
        }
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            SY = false;
        }
        else
        {
            SY = true;
        }
        if (CT)
        {
            foreach (GameObject item in cloths)
            {
                item.SetActive(false);
            }
        }
        else
        {
            //BroadcastMessage("PlayBase", "xixiaoqu");
            MovieManager.instance.Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "防疫人员洗消";
            playMovie.instance.playMov("xixiaoqu");
            foreach (GameObject item in cloths)
            {
                item.SetActive(true);
            }
        }
        Tongyong.GetComponent<Tongyong>()._bbBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._spBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._cfBtn.GetComponent<ButtonLight>().ButtonShine();
    }
	
	// Update is called once per frame
	void Update () {
        //if (openXS) {
        //    BroadcastMessage("playMov", "xishou1");
        //    openXS = false;
        //}
    }

    public GameObject errorPanel;
    public GameObject goPanel;
    public Text showText;
    string str = "";

    public string currentGo;

    //public GameObject kouzhaoPanel;
    //public GameObject maoziPanel;
    //public GameObject yifuPanel;
    //public GameObject yanjingPanel;
    //public GameObject xueziPanel;
    //public GameObject neishoutaoPanel;
    //public GameObject waishoutaoPanel;

    //播放当前窗口视频
    //public void playVedio() {
    //    if (currentGo == "kouzhao")
    //    {
    //        BroadcastMessage("playMov", "chuanyi1");
    //    }
    //    else if (currentGo == "maozi")
    //    {
    //        BroadcastMessage("playMov", "chuanyi2");
    //    }
    //    else if (currentGo == "yifu")
    //    {
    //        BroadcastMessage("playMov", "chuanyi3");
    //    }
    //    else if (currentGo == "yanjing")
    //    {
    //        BroadcastMessage("playMov", "chuanyi4");
    //    }
    //    else if (currentGo == "xuezi")
    //    {
    //        BroadcastMessage("playMov", "chuanyi5");
    //    }
    //    else if (currentGo == "waishoutao")
    //    {
    //        BroadcastMessage("playMov", "chuanyi7");
    //    }
    //    else if (currentGo == "neishoutao")
    //    {
    //        BroadcastMessage("playMov", "chuanyi6");
    //    }
    //}

    //播放当前窗口视频
    //public void playTyVedio()
    //{
    //    if (currentGo == "kouzhao")
    //    {
    //        BroadcastMessage("playMov", "tuoyi6");
    //    }
    //    else if (currentGo == "maozi")
    //    {
    //        BroadcastMessage("playMov", "tuoyi5");
    //    }
    //    else if (currentGo == "yifu")
    //    {
    //        BroadcastMessage("playMov", "tuoyi2");
    //    }
    //    else if (currentGo == "yanjing")
    //    {
    //        BroadcastMessage("playMov", "tuoyi4");
    //    }
    //    else if (currentGo == "xuezi")
    //    {
    //        BroadcastMessage("playMov", "tuoyi3");
    //    }
    //    else if (currentGo == "waishoutao")
    //    {
    //        BroadcastMessage("playMov", "tuoyi1");
    //    }
    //    else if (currentGo == "neishoutao")
    //    {
    //        BroadcastMessage("playMov", "tuoyi7");
    //    }
    //}

    public void Body()
    {
        if (Tongyong.transform.FindChild("Body").gameObject.activeSelf == false)
        {
            Tongyong.transform.FindChild("Body").gameObject.SetActive(true);
        }
        else
        {
            Tongyong.transform.FindChild("Body").gameObject.SetActive(false);
        }
    }

    public void GetBody(string body)
    {
        switch (body)
        {
            case "yan":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "戴防护眼镜";
                    playMovie.instance.playMov("chuanyi4");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "摘防护眼镜";
                    playMovie.instance.playMov("tuoyi4");
                }
                break;
            case "xie":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "穿防护鞋";
                    playMovie.instance.playMov("chuanyi5");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "脱防护鞋";
                    playMovie.instance.playMov("tuoyi3");
                }
                break;
            case "neishou":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "戴乳胶手套";
                    playMovie.instance.playMov("chuanyi6");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "脱乳胶手套";
                    playMovie.instance.playMov("tuoyi7");
                }
                break;
            case "waishou":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "戴防护手套";
                    playMovie.instance.playMov("chuanyi7");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "脱防护手套";
                    playMovie.instance.playMov("tuoyi1");
                }
                break;
            case "tou":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "戴防护帽";
                    playMovie.instance.playMov("chuanyi2");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "脱防护帽";
                    playMovie.instance.playMov("tuoyi5");
                }
                break;
            case "kou":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "戴防护口罩";
                    playMovie.instance.playMov("chuanyi1");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "摘防护口罩";
                    playMovie.instance.playMov("tuoyi6");
                }
                break;
            case "shen":
                if (CT == true)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "穿防护服";
                    playMovie.instance.playMov("chuanyi3");
                }
                else
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "脱防护服";
                    playMovie.instance.playMov("tuoyi2");
                }
                break;
            default:
                break;
        }
    }

    //选择确定
    //public void chooceOk(Answer ans) {
    //    if (SY)
    //        //if (true)
    //    {
    //        if (checkAnswer(ans))
    //        {
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");
    //        }
    //        else
    //        {
    //            ans.transform.parent.Find("error").gameObject.SetActive(true);
    //        }
    //    }
    //    else {
    //        if (checkAnswer(ans))
    //        {
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");
    //        }
    //        else
    //        {
    //            if (currentGo == "kouzhao")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "戴口罩的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "maozi")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "戴帽子的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "yifu")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "穿防护服的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "yanjing")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "戴防护眼镜的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "xuezi")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "穿胶鞋的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "waishoutao")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "戴外手套的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "neishoutao")
    //            {
    //                wrongInfo wif = new wrongInfo(5, "戴内手套的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");

    //        }
    //    }
    //}

    //选择脱衣确定
    //public void chooceTyOk(Answer ans)
    //{
    //    if (SY)
    //    //if (false)
    //    {
    //        if (checkAnswer(ans))
    //        {
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");
    //        }
    //        else
    //        {
    //            ans.transform.parent.Find("error").gameObject.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        if (checkAnswer(ans))
    //        {
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");
    //        }
    //        else
    //        {
    //            if (currentGo == "kouzhao")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱口罩的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "maozi")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱帽子的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "yifu")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱防护服的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "yanjing")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "摘防护眼镜的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "xuezi")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱胶鞋的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "waishoutao")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱外手套的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            else if (currentGo == "neishoutao")
    //            {
    //                wrongInfo wif = new wrongInfo(6, "脱内手套的选择题答案不正确。", 5);
    //                SystemManager.instance.recordWrong(wif);
    //            }
    //            ans.transform.parent.gameObject.SetActive(false);
    //            BroadcastMessage("closeMov");

    //        }
    //    }
    //}

    //public void showAnswer(GameObject go) {
    //    go.SetActive(true);
    //}

    //判断答案是否正确
    //public bool checkAnswer(Answer ans)
    //{
    //    List<string> chooceList = new List<string>();
    //    GameObject[] ts = GameObject.FindGameObjectsWithTag("Toggle1");
    //    foreach (GameObject go in ts)
    //    {
    //        if (go.GetComponent<Toggle>().isOn)
    //        {
    //            chooceList.Add(go.name);
    //        }
    //    }

    //    if (chooceList.Count != ans.answerList.Count) {
    //        return false;
    //    }

    //    foreach (string a in ans.answerList) {
    //        if (!chooceList.Contains(a)) {
    //            return false;
    //        }
    //    } 

    //    return true;
    //}

    //判断是否有选择窗口打开
    public bool checkChoocePanel() {
        GameObject[] cs = GameObject.FindGameObjectsWithTag("chooce");
        if (cs.Length != 0) {
            return false;
        }
        return true;
    }

    //关闭所有选择窗口
    //public void closeChooce() {
    //    kouzhaoPanel.SetActive(false) ;
    //    maoziPanel.SetActive(false);
    //    yifuPanel.SetActive(false);
    //    yanjingPanel.SetActive(false);
    //    xueziPanel.SetActive(false);
    //    waishoutaoPanel.SetActive(false);
    //    neishoutaoPanel.SetActive(false);
    //}

    public void chooceOverBut(GameObject go) {
        go.GetComponent<Image>().color = Color.yellow;
    }

    //选择穿衣部件
    public void chuanyifu(GameObject go) {

        if (SY)
        {
            if (!checkChoocePanel())
            {
                return;
            }
            if (go.name == "kouzhao")
            {
                if (stepNo == 0)
                {
                    // BroadcastMessage("playMov", "chuanyi1");
                    
                    stepNo++;
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(18);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[5].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(18);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                
                }
            }
            else if (go.name == "maozi")
            {  
                if (stepNo == 1)
                {
                    //  BroadcastMessage("playMov", "chuanyi2");
                    
                    stepNo++;
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(19);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[1].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //maoziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(19);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                  
                }
            }
            else if (go.name == "yifu")
            {
                
                if (stepNo == 2)
                {
                    //  BroadcastMessage("playMov", "chuanyi3");
                    
                    stepNo++;
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    toufa.SetActive(false);
                    bianfu.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(20);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[2].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //yifuPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(20);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                   
                }
            }
            else if (go.name == "yanjing")
            {
                
                if (stepNo == 3)
                {
                    //   BroadcastMessage("playMov", "chuanyi4");
                    
                    stepNo++;
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(21);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[0].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(21);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                   
                }
            }
            else if (go.name == "xuezi")
            {
                
                if (stepNo == 4)
                {
                    //   BroadcastMessage("playMov", "chuanyi5");
                    
                    stepNo++;
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(22);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[3].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(22);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                   
                }
            }
            else if (go.name == "neishoutao")
            {
                
                if (stepNo == 5)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");

                    stepNo++;
                    showText.text += "内手套=>";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(23);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[4].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(23);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "waishoutao")
            {
                
                if (stepNo == 6)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    
                    stepNo++;
                    showText.text += "外手套。";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(24);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[6].SetActive(true);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(24);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);
                   
                }
            } 
            else if (go.name == "CFButton")
            {
                if (stepNo == 7)
                {
                    //BroadcastMessage("playMov", "chuanyi8");
                    //playMovie.instance.playMov("chuanyi8");
                    //Invoke("goNextScene", 7f);
                    goNextScene();
                }
                else
                {
                    goPanel.SetActive(true);
                }
            }
        }
        else {

            //考核模式
            if (!checkChoocePanel())
            {
                return;
            }
            else if (go.GetComponent<Image>().color == Color.yellow)
            {
                return;

            }

            if (go.name == "kouzhao")
            {
                cloths[5].SetActive(true);
                if (stepNo == 0)
                {
                    // BroadcastMessage("playMov", "chuanyi1");
                    stepNo++;
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(18);
                    currentGo = go.name;
                    chooceOverBut(go);

                }
                else
                {
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(18);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "maozi")
            {
                cloths[1].SetActive(true);

                if (stepNo == 1)
                {
                    //  BroadcastMessage("playMov", "chuanyi2");
                    stepNo++;
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(19);
                    currentGo = go.name;
                    chooceOverBut(go);
                }
               
                else
                {
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(19);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "yifu")
            {
                cloths[2].SetActive(true);
                if (stepNo == 2)
                {
                    //  BroadcastMessage("playMov", "chuanyi3");
                    stepNo++;
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    toufa.SetActive(false);
                    bianfu.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(20);
                    currentGo = go.name;
                    chooceOverBut(go);
                }
             
                else
                {
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    toufa.SetActive(false);
                    bianfu.SetActive(false);
                    Tongyong.GetComponent<Question>().GetQuestion(20);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "yanjing")
            {
                cloths[0].SetActive(true);
                if (stepNo == 3)
                {
                    //   BroadcastMessage("playMov", "chuanyi4");
                    stepNo++;
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(21);
                    currentGo = go.name;
                    chooceOverBut(go);
                }
              
                else
                {
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(21);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "xuezi")
            {
                cloths[3].SetActive(true);
                if (stepNo == 4)
                {
                    //   BroadcastMessage("playMov", "chuanyi5");
                    stepNo++;
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(22);
                    currentGo = go.name;
                    chooceOverBut(go);
                }
               
                else
                {
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(22);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "neishoutao")
            {
                cloths[4].SetActive(true);
                if (stepNo == 5)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "内手套=>";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(23);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "内手套=>";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(23);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "waishoutao")
            {
                cloths[6].SetActive(true);
                if (stepNo == 6)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "外手套。";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(24);
                    currentGo = go.name;
                    chooceOverBut(go);
                }
               
                else
                {
                    showText.text += "外手套=>";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(24);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }  
            else if (go.name == "CFButton")
            {
                if (stepNo == 7)
                {
                    if (isCyWrong) {
                        wrongInfo wif = new wrongInfo(2, "穿防护服的顺序正确。", true);
                        SystemManager.instance.recordWrong(wif);
                        //BroadcastMessage("playMov", "chuanyi8");
                        //playMovie.instance.playMov("chuanyi8");
                        //Invoke("goNextScene", 7f);  
                        goNextScene();
                    }
                }
                else {
                    if (checkUsed())
                    {
                        wrongInfo wif = new wrongInfo(2, "穿防护服的顺序不正确。", false);
                        SystemManager.instance.recordWrong(wif);
                        goNextScene();
                    }
                    else {
                        goPanel.SetActive(true);
                    }
                }              
            }
        }   
    }

    //校验是否都已选过
    public bool checkUsed() {
        GameObject[] yfs = GameObject.FindGameObjectsWithTag("yifu");
        foreach (GameObject yf in yfs) {
            if (yf.GetComponent<Image>().color != Color.yellow) {
                return false;
            }
        }
        return true;
    }


    //选择脱衣部件
    public void tuoyi(GameObject go)
    {
        if (SY)
        //if (false)
        {
            if (!checkChoocePanel())
            {
                return;
            }
            if (go.name == "kouzhao")
            {
                
                if (stepNo == 5)
                {
                    // BroadcastMessage("playMov", "chuanyi1");
                    stepNo++;
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(25);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[5].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(25);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "maozi")
            {
                
                if (stepNo == 4)
                {
                    //  BroadcastMessage("playMov", "chuanyi2");
                    stepNo++;
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(26);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[1].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //maoziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(26);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "yifu")
            {
                
                if (stepNo == 1)
                {
                    //  BroadcastMessage("playMov", "chuanyi3");
                    stepNo++;
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(27);
                    bianfu.SetActive(true);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[2].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //yifuPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(27);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "yanjing")
            {
                
                if (stepNo == 3)
                {
                    //   BroadcastMessage("playMov", "chuanyi4");
                    stepNo++;
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(28);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[0].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(28);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "xuezi")
            {
                
                if (stepNo == 2)
                {
                    //   BroadcastMessage("playMov", "chuanyi5");
                    stepNo++;
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(29);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[3].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(29);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "waishoutao")
            {
                
                if (stepNo == 0)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "外手套=>";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(30);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[6].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(30);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "neishoutao")
            {
               
                if (stepNo == 6)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "内手套=>";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(31);
                    currentGo = go.name;
                    chooceOverBut(go);
                    cloths[4].SetActive(false);
                }
                else if (go.GetComponent<Image>().color == Color.yellow)
                {
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(31);
                    currentGo = go.name;

                }
                else
                {
                    errorPanel.SetActive(true);

                }
            }
            else if (go.name == "CFButton")
            {
                if (stepNo == 7)
                {
                    goCDC();
                }
                else
                {
                    goPanel.SetActive(true);
                }
            }
        }
        else
        {

            //考核模式
            if (!checkChoocePanel())
            {
                return;
            }
            else if (go.GetComponent<Image>().color == Color.yellow)
            {
                return;

            }

            //print(go.name);
            if (go.name == "kouzhao")
            {
                cloths[5].SetActive(false);
                if (stepNo == 5)
                {
                    // BroadcastMessage("playMov", "chuanyi1");
                    stepNo++;
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(25);
                    currentGo = go.name;
                    chooceOverBut(go);

                }
                else
                {
                    showText.text += "口罩=>";
                    //closeChooce();
                    //kouzhaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(25);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "maozi")
            {
                cloths[1].SetActive(false);

                if (stepNo == 4)
                {
                    //  BroadcastMessage("playMov", "chuanyi2");
                    stepNo++;
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(26);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "帽子=>";
                    //closeChooce();
                    //maoziPanel.SetActive(true);
                    toufa.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(26);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "yifu")
            {
                cloths[2].SetActive(false);
                if (stepNo == 1)
                {
                    //  BroadcastMessage("playMov", "chuanyi3");
                    stepNo++;
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    bianfu.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(27);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "衣服=>";
                    //closeChooce();
                    //yifuPanel.SetActive(true);
                    bianfu.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(27);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "yanjing")
            {
                cloths[0].SetActive(false);
                if (stepNo == 3)
                {
                    //   BroadcastMessage("playMov", "chuanyi4");
                    stepNo++;
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(28);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "眼镜=>";
                    //closeChooce();
                    //yanjingPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(28);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "xuezi")
            {
                cloths[3].SetActive(false);
                if (stepNo == 2)
                {
                    //   BroadcastMessage("playMov", "chuanyi5");
                    stepNo++;
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(29);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "靴子=>";
                    //closeChooce();
                    //xueziPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(29);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "waishoutao")
            {
                cloths[6].SetActive(false);
                if (stepNo == 0)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "外手套=>";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(30);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "外手套=>";
                    //closeChooce();
                    //waishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(30);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "neishoutao")
            {
                cloths[4].SetActive(false);
                if (stepNo == 6)
                {
                    //   BroadcastMessage("playMov", "chuanyi6");
                    stepNo++;
                    showText.text += "内手套。";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(31);
                    currentGo = go.name;
                    chooceOverBut(go);
                }

                else
                {
                    showText.text += "内手套=>";
                    //closeChooce();
                    //neishoutaoPanel.SetActive(true);
                    Tongyong.GetComponent<Question>().GetQuestion(31);
                    currentGo = go.name;
                    chooceOverBut(go);
                    isCyWrong = false;
                }
            }
            else if (go.name == "CFButton")
            {
                if (stepNo == 7)
                {
                    if (isCyWrong)
                    {
                        wrongInfo wif = new wrongInfo(2, "脱防护服的顺序正确。", true);
                        SystemManager.instance.recordWrong(wif);
                        goCDC();
                    }
                }
                else
                {
                    if (checkUsed())
                    {
                        wrongInfo wif = new wrongInfo(2, "脱防护服的顺序不正确。", false);
                        SystemManager.instance.recordWrong(wif);
                        goCDC();
                    }
                    else
                    {
                        goPanel.SetActive(true);
                    }
                }

            }


        }


    }

    //public void tuoyifu(GameObject go)
    //{
    //    if (go.name == "kouzhao")
    //    {
    //        if (stepNo == 5)
    //        {
    //            BroadcastMessage("playMov", "tuoyi6");
    //            stepNo++;
    //            showText.text += "口罩。";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "maozi")
    //    {
    //        if (stepNo == 3)
    //        {
    //            BroadcastMessage("playMov", "tuoyi4");
    //            stepNo++;
    //            showText.text += "帽子=>";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "yifu")
    //    {
    //        if (stepNo == 1)
    //        {
    //            BroadcastMessage("playMov", "tuoyi2");
    //            stepNo++;
    //            showText.text += "衣服=>";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "yanjing")
    //    {
    //        if (stepNo == 0)
    //        {
    //            BroadcastMessage("playMov", "tuoyi1");
    //            stepNo++;
    //            showText.text += "眼镜=>";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "xuezi")
    //    {
    //        if (stepNo == 4)
    //        {
    //            BroadcastMessage("playMov", "tuoyi5");
    //            stepNo++;
    //            showText.text += "靴子=>";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "shoutao")
    //    {
    //        if (stepNo == 2)
    //        {
    //            BroadcastMessage("playMov", "tuoyi3");
    //            stepNo++;
    //            showText.text += "手套=>";
    //        }
    //        else
    //        {
    //            errorPanel.SetActive(true);
    //            //--穿衣脱衣顺序，处理方式：每触发一次扣1分
    //            if (tm != null)
    //            {
    //                tm.recordWrong("脱衣");
    //            }
    //        }
    //    }
    //    else if (go.name == "chufa")
    //    {
    //        if (stepNo == 6)
    //        {
    //            playxishou();
    //            stepNo++;
    //        }
    //        else
    //        {
    //            goPanel.SetActive(true);
    //        }
    //    }
    //}

    public void goNextScene() {
        SceneManager.LoadScene(7);
    }

    public GameObject tuoyiPanel;
    public GameObject xishouPanel;
    public Text xishouText;

    public void playxishou() {
        tuoyiPanel.SetActive(false);
        xishouPanel.SetActive(true);
        showXiShou();
    }

    int xishouNo = 1;
    public void showXiShou() {
        if (xishouNo == 1)
        {
            xishouText.text = "洗手的第一步：\n掌心对掌心搓擦";
            BroadcastMessage("playMov", "xishou1");
            xishouNo++;
        }
        else if (xishouNo == 2)
        {
            xishouText.text = "洗手的第二步：\n手指交错掌心对手背搓擦";
            BroadcastMessage("playMov", "xishou2");
            xishouNo++;
        }
        else if (xishouNo == 3)
        {
            xishouText.text = "洗手的第三步：\n手指交错掌心对掌心搓擦";
            BroadcastMessage("playMov", "xishou3");
            xishouNo++;
        }
        else if (xishouNo == 4)
        {
            xishouText.text = "洗手的第四步：\n两手互握互搓指背";
            BroadcastMessage("playMov", "xishou4");
            xishouNo++;
        }
        else if (xishouNo == 5)
        {
            xishouText.text = "洗手的第五步：\n拇指在掌中转动搓擦";
            BroadcastMessage("playMov", "xishou5");
            xishouNo++;
        }
        else if (xishouNo == 6)
        {
            xishouText.text = "洗手的第六步：\n指尖在掌心中搓擦";
            BroadcastMessage("playMov", "xishou6");
            xishouNo++;
        }
        else if (xishouNo == 7)
        {
            xishouText.text = "洗手的第七步：\n冲洗干净，擦干或烘干";
            BroadcastMessage("playMov", "xishou7");
            xishouNo++;
        }
        else if (xishouNo == 8)
        {
            xishouText.text = "进行禽流感应急演练总结。";
            xishouNo++;
        }
        else if (xishouNo == 9)
        {
             GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverTuiyi = true;
            goCDC();
            
        }

    }
    //1.掌心对掌心搓擦
    //2.手指交错掌心对手背搓擦
    //3.手指交错掌心对掌心搓擦
    //4.两手互握互搓指背
    //5.拇指在掌中转动搓擦
    //6.指尖在掌心中搓擦
    //7.冲洗干净，擦干或烘干

    public void goCDC() {
        GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverTuiyi = true;
        //SceneManager.LoadScene(6);
        Tongyong.GetComponent<Tongyong>()._cfBtn.GetComponent<ButtonLight>().Close();
        LastScene.instance.zongjie.SetActive(true);
        LastScene.instance.Summed();
    }

}
