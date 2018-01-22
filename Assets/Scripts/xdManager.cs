using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using DG.Tweening;
using UnityEngine.SceneManagement;
using HighlightingSystem;

public class xdManager : MonoBehaviour
{
     
    public static xdManager instance;
    public GameObject Tongyong;
    public List<Vector3> Point;
    //问号字典
    public Dictionary<string, GameObject> whDic = new Dictionary<string, GameObject>();
    /// <summary>
    /// 隐藏问号
    /// </summary>

    //控制update一次进入
    public bool isEnter = true;

    public void setEnter()
    {
        isEnter = true;
    }

    // Use this for initialization
    void Start()
    {
        instance = this;
        AddStep();
        Jiantou.instance.AddPos();
        mask = ~(1 << (LayerMask.NameToLayer("shenxing"))|1 << (LayerMask.NameToLayer("Collider")));
        ani = person.GetComponent<Animation>();
        noBeipenhuPerson = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverNongjiayuan)
        {
            showGoBackBut();
        }
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            
        }
        else
        {

        }
        Tongyong.GetComponent<Tongyong>()._bbBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<Button>().onClick.AddListener(
            delegate 
            {
                Map();
            });
    }

    private int currentNo = 0;

    private int currentStep = 1000995;
    List<int> stepList = new List<int>();

    public int getNextStep()
    {
        int n = 0;
        foreach (int step in stepList)
        {
            if (n == currentNo + 1)
            {
                currentStep = step;
            }
            n++;
        }
        currentNo++;
        return currentStep;
    }

    public int getStep()
    {
        int n = 0;
        int m = 0;
        foreach (int a in stepList)
        {
            if (currentNo == n)
            {
                m = a;
            }
            n++;
        }
        if (m == 0)
        {
            m = 1000995;
        }
        return m;
    }

    public void setStep(int stepNo)
    {
        int n = 0;
        int m = 0;
        foreach (int a in stepList)
        {
            if (stepNo == a)
            {
                currentNo = n;
            }
            n++;
        }
    }

    private static bool sceneOpen = false;

    public void setSceneStat(bool b)
    {
        sceneOpen = b;
    }

    public bool getSceneStat()
    {
        return sceneOpen;
    }


    void AddStep()
    {
        //查询汇率
        stepList.Add(1000995);
        stepList.Add(1000996);
        stepList.Add(1000997);
        stepList.Add(1000998);
        stepList.Add(1000999);
        stepList.Add(1001000);
        stepList.Add(1001001);
        stepList.Add(1001002);
        stepList.Add(1001003);
        stepList.Add(1001004);
        stepList.Add(1001005);
        stepList.Add(1001006);
        stepList.Add(1001007);
        stepList.Add(1001008);
        stepList.Add(1001009);
        stepList.Add(1001010);
        stepList.Add(1001011);
        stepList.Add(1001012);
        stepList.Add(1001013);
        stepList.Add(1001014);
        stepList.Add(1001015);
        stepList.Add(1001016);
        stepList.Add(1001017);
        stepList.Add(1001018);
        stepList.Add(1001019);
        stepList.Add(1001020);
        stepList.Add(1001021);
        stepList.Add(1001022);
        stepList.Add(1001023);
        stepList.Add(1001024);
    }

    //气氛渲染。-- 紧张，谨慎。

    //场景1：上报（1001001）
    //片头动画，跳往接电员，接电话。
    //零零零~电话玲响。点击电话，播放接电话动画，小窗口显示对方。
    //显示对话内容。
    //交互。选择笔记录案情。显示案情基本情况。关闭。
    //选择处理意见：点击电话。上报领导。
    //显示救护车接送病人。送到隔离房（知识点：处理意见，时限）

    //接电话，区医院组织专家会诊，确认不明原因肺炎。

    //补：上报。向县卫生局和市CDC报告，向县动物防疫站通报。

    //场景2:应急相应（1002001）

    //组织会议（1003001）
    //领导发言，各小组组长发言
    //立刻出发（知识点：各个小组负责内容简要说明）

    //场景3.物资准备（1004001）
    //各小组准备不同物资（各小组是否将物资全部准备完毕）

    //场景4.穿防护服。（拖拽顺序考核，正确播放视频）（1005001）
    //人物模型--服饰变化
    //播放穿戴视频（知识点：穿戴顺序）

    //场景5.医院场景（1006001）
    //1.流行病学调查，与病人对话，填表（固定镜头，填表）（知识点：填写表格）
    //2.样本采集过程，保存，及后送（封装，专车，重要指标标示）（知识点：采样过程，后送过程）

    //场景6.病人家（1007001）
    //1.流行病学调查，与密切接触者对话，填表（固定镜头，填表）（知识点：填写表格）
    //2.布置警戒线，消毒过程（消毒记录表），处理污染物（UI，处理不同污染物，增加考核点，播放处理过程（或者模型人物手动处理））（知识点：警戒线，污染物处理）

    //场景7.脱防护服（拖拽顺序考核，正确播放视频）（1007001）
    //人物模型--服饰变化
    //播放脱下视频

    //播放洗手视频（知识点：穿戴顺序）（1008001）

    //报告总结：（操作错误记录）（1009001）（知识点：错误总结，1.处理意见不对（隔离），2.对应物资选择错误，3.脱/穿防护服顺序错误，4.流行病学，表格填写错误，5.污染物处理方式错误6.消毒顺序错误7.没有布置警戒线
    //8.没有填写消毒记录表，9.样本采集操作错误，10.没有向县卫生局和市CDC报告，向县动物防疫站通报。）

    //图表显示整个过程。查看相关法规政策。
    //===========================================================================================================================================================================================================//


    //1.车子驶入场景
    //2.搭设警戒线（选择工具警戒线）
    //3.安装消毒喷壶（选择喷壶）
    //4'.喷雾法
    //4.消毒室内（到达指定地点，粒子圈，到位播放动画）
    //5.消毒室外（到达指定地点，粒子圈，到位播放动画）
    //6.浸泡法（视频，处理方法选择）
    //7.煮沸法（视频，处理方法选择）
    //8.焚烧法（视频，处理方法选择）
    //9.清理水池（选择工具漂白粉）
    //10.重点位置--鸡窝（到达指定地点，粒子圈，到位播放动画）
    //11.流行病学调查（选择工具调查表）
    //消毒程序为：先开辟消毒通道，按先室内后室外，先地面后墙面，先重点后一般，先上后下，先左后右，先饮水后污水的顺序进行。

    //步骤
    public void ButtonOk()
    {
        int sn = 0;
        //跳往下一个步骤
        sn = getNextStep();
        //		Debug.Log (getStep() + "sss");

        //print(sn);
        switch (sn)
        {
            case 1000996:
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.GetPos(0);
                Jiantou.instance.Open();
                Tongyong.transform.FindChild("Biao/huoqin").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/huoqin").GetComponent<Button>().enabled = true;
                story("电话", "开始在活禽市场搭设警戒线。", false);
                break;
            case 1000999:
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.Close();
                huoqinRing.SetActive(true);
                //Jiantou.instance.GetPos(1);
                story("电话", "穿戴装有84消毒液配制消毒水的医用喷壶。前往活禽市场进行消毒。", false);
                Tongyong.GetComponent<Question>().GetQuestion(14);
                break;
            case 1001000:
                //室外消毒
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "活禽市场消毒完毕后，请开始张贴宣传单。", true);
                break;
            case 1001001:
                playMovie_dealfw.instance.closeMov();
                overTexieCam();
                huoqinxiaoduPerson.SetActive(false);
                noBeipenhuPerson.SetActive(true);
                huoqinRing.SetActive(false);
                FlashingController fc = xc.AddComponent<FlashingController>();
                fc.flashingDelay = 0f;
                //室外消毒
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "取出宣传单，张贴在活禽市场大门上。", false);
                Tongyong.GetComponent<Question>().GetQuestion(13);
                break;
            //i---0
            //按照当前步骤状态进行判断
            case 1001002:
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.GetPos(2);
                Jiantou.instance.Open();
                FlashingController fc1 = ts1.AddComponent<FlashingController>();
                fc1.flashingDelay = 0f;
                Tongyong.transform.FindChild("Biao/huoqin").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/huoqin").GetComponent<Button>().enabled = false;
                Tongyong.transform.FindChild("Biao/huoqin/Img").gameObject.SetActive(true);
                Tongyong.transform.FindChild("Biao/menkou").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/menkou").GetComponent<Button>().enabled = true;
                story("电话", "开始在病患家门口搭设警戒线。", false);
                break;
            case 1001005:
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.Close();
                story("电话", "消毒程序为：先开辟消毒通道，按先室内后室外，先地面后墙面，先重点后一般，先上后下，先左后右，先饮水后污水的顺序进行。", true);
                break;
            case 1001006:
                //室内消毒
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.Open();
                Jiantou.instance.GetPos(3);
                Tongyong.transform.FindChild("Biao/menkou").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/menkou").GetComponent<Button>().enabled = false;
                Tongyong.transform.FindChild("Biao/menkou/Img").gameObject.SetActive(true);
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<Button>().enabled = true;
                story("电话", "穿戴装有84消毒液配制消毒水的医用喷壶。前往室内，进行室内地面和墙壁的消毒。", false);
                Tongyong.GetComponent<Question>().GetQuestion(15);
                break;
            case 1001007:
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "使用医用喷壶对室内地面和室内墙壁进行消毒。", true);
                break;
            case 1001008:
                overTexieCam();
                shineixiaoduPerson.SetActive(false);
                noBeipenhuPerson.SetActive(true);
                shineiRing.SetActive(false);
                jiwoRing.SetActive(true);
                //室外消毒
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.GetPos(4);
                Jiantou.instance.Open();
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<Button>().enabled = false;
                Tongyong.transform.FindChild("Biao/wunei/Img").gameObject.SetActive(true);
                Tongyong.transform.FindChild("Biao/jilong").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/jilong").GetComponent<Button>().enabled = true;
                story("电话", "室内消毒完毕后，前往室外消毒，先重点后一般。前往鸡笼等重点消毒地点进行消毒。", false);
                break;
            case 1001009:
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "先上后下，先左后右，进行全面消毒。", true);
                break;
            case 1001010:
                //水源消毒
                overTexieCam();
                jiwoxiaoduPerson.SetActive(false);
                noBeipenhuPerson.SetActive(true);
                jiwoRing.SetActive(false);
                shuichiRing.SetActive(true);
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.GetPos(5);
                Jiantou.instance.Open();
                Tongyong.transform.FindChild("Biao/jilong").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/jilong").GetComponent<Button>().enabled = false;
                Tongyong.transform.FindChild("Biao/jilong/Img").gameObject.SetActive(true);
                Tongyong.transform.FindChild("Biao/shuichi").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/shuichi").GetComponent<Button>().enabled = true;
                story("电话", "室内室外全部消毒完毕后，进行水源消毒。前往水源地进行消毒。", false);
                break;
            case 1001011:
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "水源消毒采用专业水源消毒车进行消毒。", true);
                break;
            case 1001012:
                overTexieCam();
                shuichixiaoduPerson.SetActive(false);
                noBeipenhuPerson.SetActive(true);
                shuichiRing.SetActive(false);
                wuranwuRing.SetActive(true);
                //BroadcastMessage("PlayLY", "小张20");
                Jiantou.instance.Open();
                Jiantou.instance.GetPos(6);
                Tongyong.transform.FindChild("Biao/shuichi").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/shuichi").GetComponent<Button>().enabled = false;
                Tongyong.transform.FindChild("Biao/shuichi/Img").gameObject.SetActive(true);
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<ButtonLight>().Close();
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<ButtonLight>().ButtonShake();
                Tongyong.transform.FindChild("Biao/wunei").GetComponent<Button>().enabled = true;
                story("电话", "水源消毒结束后，对污染物进行特殊处理。前往室内床上处理一些病人使用过的污染物。", false);
                break;

            //处理污染物：
            //选择污染物，点击弹出处理框，选择处理方式。选择错误报错，选择正确播放视频。物件消失。同理处理其他两件。三件都消失，进行下一步。
            //镜头添加边缘高光组件。
            case 1001013:
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                story("电话", "请选择要处理的污染物，并选择合适的处理方法。", false);
                break;
            case 1001014:
                noBeipenhuPerson.GetComponent<ThirdPersonUserControl>().enabled = true;
                //xidubgBut.SetActive(true);
                texieCam.GetComponentInChildren<CameraTargeting>().enabled = false;
                texieCam.GetComponentInChildren<HighlightingRenderer>().enabled = false;
                Camera.main.GetComponentInChildren<CameraTargeting>().enabled = false;
                Camera.main.GetComponentInChildren<HighlightingRenderer>().enabled = false;
                texieCam.SetActive(false);
                //疫源地消毒记录表上添加了自动填写的按钮。点击之后，自动填写。跳往一下歩（不关闭，需手动关闭）。
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                story("电话", "处理完污染物，消毒工作全部完成后，填写“疫源地消毒记录表”。", false);
                jjxManager.instance.xdRecardPanel.SetActive(true);
                //Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<ButtonLight>().ButtonShine();
                jjxManager.instance.showAutoWriteBut();
                break;
            case 1001015:
                //流行病学调查的按钮显示
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                story("电话", "消杀任务完成。请切换到流调人员，进行密切接触者的流行病学调查。", false);
                isCamLiuDiao = true;
               // liudiaobgBut.SetActive(true);
                break;
            case 1001016:
                //流行病学调查的按钮显示
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                //story("电话", "通过与密切接触者的交流，填写密切接触者医学观察登记表。", false);
                //liudiaobgBut.SetActive(true);
                break;
            case 1001017:
                //密切接触者调查完。弹出可去 应急机动2队 的按钮，返回出发前。若2队已完成。继续后面的场景。同理2队同样处理。
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                story("电话", "进一步加强健康教育，提高公众卫生意识和个人防护意识，减少发生禽流感的危险性，做好公众心理疏导工作，避免出现社会恐慌。", true);
                break;
            case 1001018:
                //密切接触者调查完。弹出可去 应急机动2队 的按钮，返回出发前。若2队已完成。继续后面的场景。同理2队同样处理。
                //BroadcastMessage("PlayLY", "小张20");、、对密切接触者进行观察登记表，对接触者进行安抚和宣传。
                story("电话", "应急机动A队任务完成。可查看应急B队进展情况。", false);
                GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverNongjiayuan = true;
                showGoBackBut();
                //出现返回出发地的按钮。
                //修改标记1队完成表示。
                break;
        }
    }

    public bool ishuanzhe = false;

    public bool iswubing = false;
    //public void OnMouseDown()
    //{
    //    if (ishuanzhe == false && gameObject.name == "huanzhe")
    //    {
    //        AddNJLD.instance.Talk(gameObject.name);
    //        ishuanzhe = true;
    //        iswubing = true;
    //    }
    //    if (iswubing == false && gameObject.name == "wubing")
    //    {
    //        AddNJLD.instance.Talk(gameObject.name);
    //        ishuanzhe = true;
    //        iswubing = true;
    //    }
    //}

    public GameObject goBackBut;

    public void showGoBackBut() {
        Tongyong.transform.FindChild("Right").FindChild("CFButton").GetComponent<Button>().onClick.AddListener(delegate { gobackCdc(); });
        Tongyong.GetComponent<Tongyong>()._cfBtn.GetComponent<ButtonLight>().ButtonShake();
        //goBackBut.SetActive(true);
    }

    public void gobackCdc() {
        SceneManager.LoadScene(7);
    }
   

    public Sprite liangcheBut_chooce;
    public Sprite liangcheBut_noChooce;

    //重置角色but样式
    private void resetRoleButNew()
    {
        GameObject[] roleBut2 = GameObject.FindGameObjectsWithTag("liangceBut");
        foreach (GameObject rb in roleBut2)
        {
            rb.GetComponent<Image>().sprite = liangcheBut_noChooce;
        }
    }


    public void hideAllPlayer()
    { 
        resetRoleButNew();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players) {
            player.SetActive(false);
        }
    }

    public GameObject liudiaoPerson;

    //切换到流调人员
    public void changeToLiuDiao(GameObject but) {
        if (isCamLiuDiao)
        {
            hideAllPlayer();
            //but.GetComponent<Image>().sprite = liangcheBut_chooce;
            liudiaoPerson.SetActive(true);
            if (getStep() == 1001015 && currentStepNo != 1001015) {
                ButtonOk();
                currentStepNo = 1001015;
            }
            jjxManager.instance.xdRecardPanel.SetActive(false);  
            jjxManager.instance.miqieguanchaPanel.SetActive(false);
            //Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<ButtonLight>().Close();
            AddNJLD.instance.Wubing.SetActive(true);
            AddNJLD.instance.Huanzhe.SetActive(true);
            Tongyong.transform.FindChild("Right/TBButton").GetComponent<ButtonLight>().Close();
            Tongyong.transform.FindChild("Right/TBButton").GetComponent<Button>().enabled = false;
            Tongyong.transform.FindChild("Biao").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else {
            showError("请先完成消杀的工作之后，\n再进行选择流调人员进行调查。");
        }
        
    }

    //切换到消杀人员
    public void changeToXiaoSha(GameObject but) {
        hideAllPlayer();
        //but.GetComponent<Image>().sprite = liangcheBut_chooce;
        person.SetActive(true);
        Tongyong.GetComponent<Tongyong>()._dhBtn.GetComponent<ButtonLight>().Close();
        AddNJLD.instance.Panel.SetActive(false);
        jjxManager.instance.xdRecardPanel.SetActive(false);
        jjxManager.instance.miqieguanchaPanel.SetActive(false);
    }

    //
    public bool isCamLiuDiao = false;

    public GameObject liudiaobgBut;

    public Text duihuaContent;
    public GameObject Okbut;
    Tweener tw = null;
    public bool isTalking = false;

    //剧情，人物，对话内容
    public void story(string person, string content, bool isShowBut)
    {
        isTalking = true;
        Okbut.SetActive(false);
        setHead(person);
        duihuaContent.text = "";
        tw = duihuaContent.DOText(content, content.Length * 0.1f);
        tw.SetUpdate(true);
        tw.SetEase(Ease.Linear);
        if (isShowBut)
        {
            tw.OnComplete(butShow);
        }
        else
        {
            tw.OnComplete(overTalk);
        }
        //		tweener.Complete ();
    }

    //显示对话头像
    public void setHead(string name)
    {
        /**
        if (name == "小张")
        {
            zhujue.SetActive(true);
            peijue.SetActive(false);
            zhujue.GetComponent<Image>().sprite = Resources.Load("Head/" + name, typeof(Sprite)) as Sprite;
            zhujue.transform.Find("name").GetComponent<Text>().text = name;
        }
        else
        {
            zhujue.SetActive(false);
            peijue.SetActive(true);
            peijue.GetComponent<Image>().sprite = Resources.Load("Head/" + name, typeof(Sprite)) as Sprite;
            peijue.transform.Find("name").GetComponent<Text>().text = name;
        }**/
    }

    //对话确定按钮
    public void butShow()
    {
        isTalking = false;
        Okbut.SetActive(true);
    }

    //对话结束触发
    public void overTalk()
    {
        isTalking = false;
    }

    public GameObject person;
    Animation ani;

    public GameObject jjx1;
    public GameObject jjx2;
    public GameObject jjx3;
    public GameObject jjx4;
    public GameObject jjx5;
    public GameObject jjx6;
    public GameObject xcd;

    public GameObject ts1;
    public GameObject ts2;
    public GameObject ts3;
    public GameObject ts4;
    public GameObject ts5;
    public GameObject ts6;
    public GameObject xc;

    public GameObject error;

    public void showError(string str) {
        error.GetComponentInChildren<Text>().text = str;
        error.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (AddNJLD.instance.jc == true)
        {
            hitObj = checkRay("wubing");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("宣传单"))
                {
                    AddNJLD.instance.wu = true;
                    ishuanzhe = false;
                    AddNJLD.instance.Wubing.transform.parent.gameObject.SetActive(false);
                    AddNJLD.instance.See.SetActive(true);
                }
                else
                {
                    showError("请选择宣传单工具。");
                }

            }
        }

        if (getStep() == 1000996 && currentStepNo != 1000996)
        {
            hitObj = checkRay("ts4");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjx4.SetActive(true);
                    Destroy(ts4);
                    FlashingController fc = ts5.AddComponent<FlashingController>();
                    fc.flashingDelay = 0f;
                    ButtonOk();
                    currentStepNo = 1000996;
                }
                else
                {
                    showError("请选择警戒线工具。");
                }

            }
        }

        if (getStep() == 1000997 && currentStepNo != 1000997)
        {
            hitObj = checkRay("ts5");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjx5.SetActive(true);
                    Destroy(ts5);
                    FlashingController fc = ts6.AddComponent<FlashingController>();
                    fc.flashingDelay = 0f;
                    ButtonOk();
                    currentStepNo = 1000997;
                }
                else
                {
                    showError("请选择警戒线工具。");
                }

            }

        }

        if (getStep() == 1000998 && currentStepNo != 1000998)
        {
            hitObj = checkRay("ts6");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjxManager.instance.resetTool();
                    jjx6.SetActive(true);
                    Destroy(ts6);
                    ButtonOk();
                    currentStepNo = 1000998;
                    shineiRing.SetActive(true);
                }
                else
                {
                    showError("请选择警戒线工具。");
                }
            }
        }

        if (getStep() == 1000999 && currentStepNo != 1000999)
        {
            
            if (huoqinPos)
            {
                huoqinPos = false;
                if (beipenhuPerson.activeSelf)
                {
                    Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "消杀方法";
                    playMovie_dealfw.instance.playMov("xiaosha");
                    currentStepNo = 1000998;
                    goCurrentPersonCamPos(huoqinRing.transform.Find("CamPos").transform);
                    noBeipenhuPerson.SetActive(false);
                    huoqinxiaoduPerson.SetActive(true);
                }
                else
                {
                    showError("请穿戴医用喷壶工具。");
                    huoqinRing.SetActive(true);
                }
            }
            else
            {
                //Tongyong.GetComponent<Question>().GetQuestion(14);
            }
        }

        if (getStep() == 1001001 && currentStepNo != 1001001)
        {
            hitObj = checkRay("xc");
            
            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("宣传单"))
                {
                    xcd.SetActive(true);
                    Destroy(xc);
                    ButtonOk();
                    currentStepNo = 1001001;
                }
                else
                {
                    showError("请选择宣传单工具。");
                }

            }
        }

        //安装警戒线，工具还未处理
        if (getStep() == 1001002 && currentStepNo != 1001002)
        {
            hitObj = checkRay("ts1");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjx1.SetActive(true);
                    Destroy(ts1);
                    FlashingController fc = ts2.AddComponent<FlashingController>();
                    fc.flashingDelay = 0f;
                    ButtonOk();
                    currentStepNo = 1001002;
                }
                else {
                    showError("请选择警戒线工具。");
                }
               
            }
        }

        if (getStep() == 1001003 && currentStepNo != 1001003)
        {
            hitObj = checkRay("ts2");

            if (hitObj != null )
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjx2.SetActive(true);
                    Destroy(ts2);
                    FlashingController fc = ts3.AddComponent<FlashingController>();
                    fc.flashingDelay = 0f;
                    ButtonOk();
                    currentStepNo = 1001003;
                }
                else {
                    showError("请选择警戒线工具。");
                }
              
            }

        }

        if (getStep() == 1001004 && currentStepNo != 1001004)
        {
            hitObj = checkRay("ts3");

            if (hitObj != null)
            {
                if (jjxManager.instance.isCurrentTool("警戒线"))
                {
                    jjxManager.instance.resetTool();
                    jjx3.SetActive(true);
                    Destroy(ts3);
                    ButtonOk();
                    currentStepNo = 1001004;
                    shineiRing.SetActive(true);
                }
                else
                {
                    showError("请选择警戒线工具。");
                }
            }
        }

        //前往屋内墙壁和地面消毒点
        if (getStep() == 1001006 && currentStepNo != 1001006)
        {
            
            if (wallPos) {
                wallPos = false;
                Jiantou.instance.Close();
                if (beipenhuPerson.activeSelf) {
                    goCurrentPersonCamPos(shineiRing.transform.Find("CamPos").transform);
                    noBeipenhuPerson.SetActive(false);
                    shineixiaoduPerson.SetActive(true);
                    currentStepNo = 1001004;
                }
                else {
                    showError("请穿戴医用喷壶工具。");
                    shineiRing.SetActive(true);
                }
            }
        }

        //前往鸡窝消毒点
        if (getStep() == 1001008 && currentStepNo != 1001008)
        {
            if (jiwoPos)
            {
                jiwoPos = false;
                Jiantou.instance.Close();
                if (beipenhuPerson.activeSelf) {
                    goCurrentPersonCamPos(jiwoRing.transform.Find("CamPos").transform);
                    noBeipenhuPerson.SetActive(false);
                    jiwoxiaoduPerson.SetActive(true);
                    currentStepNo = 1001008;
                }
                else {
                    showError("请穿戴医用喷壶工具。");
                    jiwoRing.SetActive(true);
                }
               
            }
        }

        //前往水源地消毒点
        if (getStep() == 1001010 && currentStepNo != 1001010)
        {
            if (waterpos)
            {
                waterpos = false;
                Jiantou.instance.Close();
                goCurrentPersonCamPos(shuichiRing.transform.Find("CamPos").transform);
                noBeipenhuPerson.SetActive(false);
                shuichixiaoduPerson.SetActive(true);
                currentStepNo = 1001010;
            }
        }

        //前往污染物消毒点
        if (getStep() == 1001012 && currentStepNo != 1001012)
        {
            if (feiwuPos)
            {
                feiwuPos = false;
                Jiantou.instance.Close();
                goCurrentPersonCamPos(wuranwuRing.transform.Find("CamPos").transform);
                noBeipenhuPerson.GetComponent<ThirdPersonUserControl>().enabled = false;
                Animator m_Animator1 = noBeipenhuPerson.GetComponent<Animator>();
                if (m_Animator1 != null)
                {
                    m_Animator1.SetFloat("Forward", 0f);
                    m_Animator1.SetFloat("Turn", 0f);
                }
                currentStepNo = 1001012;

                texieCam.GetComponent<CameraTargeting>().enabled = true;
                texieCam.GetComponent<HighlightingRenderer>().enabled = true;
            }
        }

        if (getStep() == 1001013 && currentStepNo != 1001013)
        {
            if (getChooceFeiwu() != null)
            {
                currentFeiwu = getChooceFeiwu();
                print(currentFeiwu.name);
                if (currentFeiwu.name == "fenshaofa")
                {
                    playMovie_dealfw.instance.closeMov();
                    showDealFeiwu(currentFeiwu.name);
                }
                else if (currentFeiwu.name == "jinpaofa")
                {
                    playMovie_dealfw.instance.closeMov();
                    showDealFeiwu(currentFeiwu.name);
                }
                else if (currentFeiwu.name == "zhufeifa")
                {
                    playMovie_dealfw.instance.closeMov();
                    showDealFeiwu(currentFeiwu.name);
                }
            }

        }


        //点击UI结束对话
        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        {
            if (tw != null)
            {
                tw.Complete();
            }
        }

        //点击调查任务
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //碰撞信息
            RaycastHit hit;
            //若发生碰撞
            if (Physics.Raycast(ray, out hit, 5f, mask))
            {
                if (hit.collider.gameObject.tag == "TalkPeople"&&!EventSystem.current.IsPointerOverGameObject())
                {
                    AddNJLD.instance.Panel.SetActive(true);
                    Tongyong.GetComponent<Tongyong>()._dhBtn.GetComponent<ButtonLight>().ButtonShine();
                    if (ishuanzhe == false && hit.collider.gameObject.name == "huanzhe")
                    {
                        AddNJLD.instance.Talk(hit.collider.gameObject.name);
                        hit.collider.transform.parent.gameObject.GetComponent<LookAtPlayer>().isCurrentPerson = true;
                        ishuanzhe = true;
                        iswubing = true;
                    }
                    if (iswubing == false && hit.collider.gameObject.name == "wubing")
                    {
                        AddNJLD.instance.Talk(hit.collider.gameObject.name);
                        hit.collider.transform.parent.gameObject.GetComponent<LookAtPlayer>().isCurrentPerson = true;
                        ishuanzhe = true;
                        iswubing = true;
                    }
                    //liudiaoPanel.SetActive(true);
                }
            }
        }

        //time += Time.deltaTime;
        //if (time > 0.1f) {
        //    time = 0f;
        //    //若发生碰撞
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2, 5f, mask))
        //    {
        //        if (hit2.collider.gameObject.tag == "TalkPeople" && !EventSystem.current.IsPointerOverGameObject())
        //        {
        //            Cursor.SetCursor(Resources.Load("hand") as Texture2D, new Vector2(34f, 12f), CursorMode.Auto);
        //        }
        //        else
        //        {
        //            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //        }
        //    }
        //    else
        //    {
        //        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //    }
        //}

        //if (Tongyong.transform.FindChild("huoqin"))
        //{
        //TODO
        //}
    }

    //碰撞信息

    float time = 0;
    RaycastHit hit2;

    public GameObject liudiaoPanel;

    int currentStepNo = 0;

    GameObject hitObj = null;


    //是否到目标点
    public bool waterpos = false;
    public bool jiwoPos = false;
    public bool feiwuPos = false;
    public bool wallPos = false;
    public bool huoqinPos = false;

    //特写尽头
    public GameObject texieCam;


    //多个角色
    public GameObject shineixiaoduPerson;
    public GameObject jiwoxiaoduPerson;
    public GameObject beipenhuPerson;
    public GameObject noBeipenhuPerson;
    public GameObject shuichixiaoduPerson;
    public GameObject huoqinxiaoduPerson;

    //提示圈
    public GameObject shineiRing;
    public GameObject jiwoRing;
    public GameObject shuichiRing;
    public GameObject wuranwuRing;
    public GameObject huoqinRing;

    Tweener texieCamTweener;

    //在镜头隐藏前使用
    public void goCurrentPersonCamPos(Transform tf) {
        texieCam.transform.position = Camera.main.transform.position;
        texieCam.SetActive(true);
        texieCamTweener = texieCam.transform.DOMove(tf.transform.position,3f);
        texieCam.transform.DORotate(tf.transform.eulerAngles, 3f);
        texieCamTweener.OnComplete(texieOver);
    }

    public void overTexieCam() {
        texieCam.SetActive(false);
    }

    public void texieOver() {
        ButtonOk();
    }

    //判读是否进入任务点
    public void changeTastPosState(string name,bool isEnter) {
        if (name == "waterPos") {
            waterpos = isEnter;
            shuichiRing.SetActive(false);
        }
        else if (name == "jiwoPos")
        {
            jiwoPos = isEnter;
            jiwoRing.SetActive(false);
        }
        else if (name == "feiwuPos")
        {
            feiwuPos = isEnter;
            wuranwuRing.SetActive(false);
        }
        else if (name == "wallPos")
        {
            wallPos = isEnter;
            shineiRing.SetActive(false);
        }
        else if (name == "huoqinPos")
        {
            huoqinPos = isEnter;
            huoqinRing.SetActive(false);
        }

        //print(name);
    }


    //处理行为
    void showTask(int stepNo, string person, string taskname, string content)
    {

    }

    public void DoSomeThing()
    {

    }
    LayerMask mask;

    //射线检测
    public GameObject checkRay(string name)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(name);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //碰撞信息
            RaycastHit hit;
            //若发生碰撞
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                //Debug.Log(EventSystem.current.IsPointerOverGameObject());
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.name == name && (!EventSystem.current.IsPointerOverGameObject()))
                {
                    return hit.collider.gameObject;
                }
            }
        }
        return null;
    }

    public GameObject getChooceFeiwu() {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = texieCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            //碰撞信息
            RaycastHit hit;
            //若发生碰撞
            if (Physics.Raycast(ray, out hit, 100f, mask) && (!EventSystem.current.IsPointerOverGameObject()))
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }

    //给特写镜头添加高光组件

    //卸载特写镜头添加高光组件

    public GameObject xdDealPanel;
    public Image feiwuImg;
    public Text feiwuText;
    public GameObject errorGo;
    public Text errorText;
    public List<Sprite> feiwuImgList = new List<Sprite>();

    public GameObject fenshaofaGo;
    public GameObject jinpaofaGo;
    public GameObject zhufeifaGo;

    private GameObject currentFeiwu;
    //弹出处理框 TODO
    public void showDealFeiwu(string feiwuName) {
        foreach (Sprite fw in feiwuImgList) {
            if (feiwuName == fw.name) {
                feiwuImg.sprite = fw;
                if (feiwuName == "fenshaofa")
                {
                    feiwuText.text = "严重污染可燃的垃圾。请选择最合适的处理方法。";
                }else if (feiwuName == "jinpaofa")
                {
                    feiwuText.text = "塑料、毛皮、化纤织物等不耐热的衣物，不怕被漂白和损伤。请选择最合适的处理方法。";
                }
                else if (feiwuName == "zhufeifa")
                {
                    feiwuText.text = "食具、食物、棉织品、金属、玻璃制品的物品。请选择最合适的处理方法。";
                }
            }
        }
        errorText.gameObject.SetActive(false);
        xdDealPanel.SetActive(true);
    }

    public bool checkDealOver() {
        if (!(jinpaofaGo.activeSelf||fenshaofaGo.activeSelf||zhufeifaGo.activeSelf)) {
            return true;
        }
        return false;
    }

    public void dealFeiwu(GameObject but) {
        if (but.name == "jinpaofa"&&currentFeiwu.name == "jinpaofa")
        {
            Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "浸泡法";
            //playMovie_dealfw.instance.playMov("jinpaofa");
            xdDealPanel.SetActive(false);
            jinpaofaGo.SetActive(false);
        }
        else {
            showErrorText("处理方法不恰当，请重新选择！");
        }
        if (but.name == "zhufeifa" && currentFeiwu.name == "zhufeifa")
        {
            Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "煮沸法";
            //playMovie_dealfw.instance.playMov("zhufeifa");
            xdDealPanel.SetActive(false);
            zhufeifaGo.SetActive(false);
        }
        else {
            showErrorText("处理方法不恰当，请重新选择！");
        }
        if (but.name == "fenshaofa" && currentFeiwu.name == "fenshaofa")
        {
            Tongyong.transform.FindChild("Movie").FindChild("Text").GetComponent<Text>().text = "焚烧法";
            //playMovie_dealfw.instance.playMov("fenshaofa");
            xdDealPanel.SetActive(false);
            fenshaofaGo.SetActive(false);
        }
        else {
            showErrorText("处理方法不恰当，请重新选择！");
        }

        if (but.name == "penwufa") {
            showErrorText("处理方法不恰当，请重新选择！");
        }

        if (checkDealOver()) {
            ButtonOk();
        }
    }

    public void showErrorText(string errorStr) {
        errorText.text = errorStr;
        errorGo.SetActive(true);
    }

    //关闭处理框
    public void closeFeiwuPanel() {
        xdDealPanel.SetActive(false);
    }



    //更改任务信息
    public void showTask() {

    }

    //展示任务路线
    public void showPath() {
        
    }

    //触发任务，镜头特写
    public void changeCam() {

    }

    //切花角色
    public void changePerson() {

    }


    //到达目的地
    public void arriveDestination(string destName) {

    }

    public void Map()
    {
        if (Tongyong.transform.FindChild("Biao").gameObject.activeSelf)
        {
            Tongyong.transform.FindChild("Biao").gameObject.SetActive(false);
        }
        else
        {
            Tongyong.transform.FindChild("Biao").gameObject.SetActive(true);
        }
    }

    public void GoPoint(int index)
    {
        switch (index)
        {
            case 0:
                GameObject.FindGameObjectWithTag("Player").transform.position = Point[0];
                GameObject.FindGameObjectWithTag("Player").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 1:
                GameObject.FindGameObjectWithTag("Player").transform.position = Point[1];
                GameObject.FindGameObjectWithTag("Player").transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                break;
            case 2:
                GameObject.FindGameObjectWithTag("Player").transform.position = Point[2];
                GameObject.FindGameObjectWithTag("Player").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
            case 3:
                GameObject.FindGameObjectWithTag("Player").transform.position = Point[3];
                GameObject.FindGameObjectWithTag("Player").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                break;
            case 4:
                GameObject.FindGameObjectWithTag("Player").transform.position = Point[4];
                GameObject.FindGameObjectWithTag("Player").transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                GameObject.FindGameObjectWithTag("CamP").transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                break;
            default:
                break;
        }
        Map();
    }
}
