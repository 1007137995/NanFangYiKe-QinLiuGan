using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayList : MonoBehaviour {

    public static PlayList instance;
    public GameObject Tongyong;
    public TimeManager tm;
    public GameObject choocePanel;
    public Text paizi;
    private bool SY = false;
    private AudioSource dianhua;
    //问号字典
    public Dictionary<string, GameObject> whDic = new Dictionary<string, GameObject>();
    /// <summary>
    /// 隐藏问号
    /// </summary>

    //控制update一次进入
    public bool isEnter = true;

    public void setEnter() {
        isEnter = true;
    }

    // Use this for initialization
    void Start() {
        instance = this;
        AddStep();
        mask = ~(1 << (LayerMask.NameToLayer("Player")));
        ani = person.GetComponent<Animation>();
        tm = GameObject.Find("head").transform.FindChild("time").GetComponent<TimeManager>();
        //if (SystemManager.instance != null)
        //{
        //    SY = SystemManager.instance.isYL;
        //}
        //else
        //{
        //    SY = false;
        //}
        //Debug.Log(SY);
    }

    //演练模式
    public void goYL()
    {
        //isYL = true;
        PlayerPrefs.SetInt("moshi", 1);
        SystemManager.instance.transform.FindChild("Caozuo/Image").gameObject.SetActive(false);
        tm.gameObject.SetActive(true);
        choocePanel.SetActive(false);
    }

    //考核模式
    public void goKH()
    {
        //isYL = false;
        PlayerPrefs.SetInt("moshi", 0);
        tm.gameObject.SetActive(true);
        choocePanel.SetActive(false);
    }

    private int currentNo = 0;

    private int currentStep = 1001001;
    List<int> stepList = new List<int>();

    public int getNextStep() {
        int n = 0;
        foreach (int step in stepList) {
            if (n == currentNo + 1) {
                currentStep = step;
            }
            n++;
        }
        currentNo++;
        return currentStep;
    }

    public int getStep() {
        int n = 0;
        int m = 0;
        foreach (int a in stepList) {
            if (currentNo == n) {
                m = a;
            }
            n++;
        }
        if (m == 0) {
            m = 1001001;
        }
        return m;
    }

    public void setStep(int stepNo) {
        int n = 0;
        int m = 0;
        foreach (int a in stepList) {
            if (stepNo == a) {
                currentNo = n;
            }
            n++;
        }
    }

    private static bool sceneOpen = false;

    public void setSceneStat(bool b) {
        sceneOpen = b;
    }

    public bool getSceneStat() {
        return sceneOpen;
    }


    void AddStep() {
        //查询汇率
        stepList.Add(1001001);
        stepList.Add(1001002);
        stepList.Add(1001003);
        stepList.Add(1001004);
        stepList.Add(1001005);
        stepList.Add(1001006);
        stepList.Add(1001007);
        stepList.Add(1001008);
        stepList.Add(1001009);
        stepList.Add(1002001);
        stepList.Add(1002002);
        stepList.Add(1002003);
        stepList.Add(1002004);
        stepList.Add(1003001);
        stepList.Add(1003002);
        stepList.Add(1003003);
        stepList.Add(1003004);
        stepList.Add(1004001);
        stepList.Add(1004002);
        stepList.Add(1004003);
        stepList.Add(1004004);
        stepList.Add(1004005);
    }

    //气氛渲染。-- 紧张，谨慎。

    //场景1：上报（1001001）
    //片头动画，跳往接电员，接电话。
    //零零零~电话玲响。点击电话，播放接电话动画，小窗口显示对方。
    //显示对话内容。
    //交互。选择笔记录案情。显示案情基本情况。关闭。
    //选择处理意见：点击电话。上报领导。
    //显示救护车接送病人。送到隔离房（知识点：处理意见，时限）

    //接电话，县医院组织专家会诊，确认不明原因肺炎。

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


    //步骤
    public void ButtonOk() {
        int sn = 0;
        //跳往下一个步骤
        sn = getNextStep();
        //		Debug.Log (getStep() + "sss");
        switch (sn) {
            //i---0
            //按照当前步骤状态进行判断
            case 1001002:
                //BroadcastMessage("PlayLY", "小张20");
                story("电话", "点击电话接听。",false);
                duihuaContent.transform.parent.gameObject.SetActive(false);
                dianhua = AudioManage.instance.PlayVoice("dianhua");
                break;
            case 1001003:
                //BroadcastMessage("PlayLY", "小张20");
                duihuaContent.transform.parent.gameObject.SetActive(true);
                if (dianhua != null) 
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y0");
                story("疫情管理员", "您好，这里是县疾控中心。", true);
                break;
            case 1001004:
                //BroadcastMessage("PlayLY", "小张20");
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("X0");
                story("乡卫生院", "我是XX乡卫生院，上报一起不明原因肺炎，患者发烧、咳嗽，全身无力，家里死了2只鸡。", false);
                
                break;
            //你应该怎么处理？
            //这里进行选择：
            //1.我会立刻向县预防控制中心领导反映情况。
            //2.我会向县卫生局领导报告，由卫生局指定县人民医院用专用救护车转运病人到县人民医院救治。
            //3.请乡卫生院做好病人转运前的准备工作，在未被转运前做好病人的隔离。

            //干扰选项
            //4.立刻向市预防控制中心上报。
            //5.立刻用电话和网络直报的形式赶快报告疫情。

            //选择1、2、3则正确，继续，多选少选，无法继续。
            case 1001005:
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y1");
                story("疫情管理员", "我会立刻向县预防控制中心领导反映情况。", true);
                break;
            case 1001006:
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y2");
                story("疫情管理员", "向县卫生局领导报告，由卫生局指定县人民医院用专用救护车转运病人到县人民医院救治。", true);
                break;
            case 1001007:
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y3");
                story("疫情管理员", "请乡卫生院做好病人转运前的准备工作，在未被转运前做好病人的隔离。", true);
                break;
            case 1001008:
                //点本，做记录动画
                //BroadcastMessage("PlayLY", "小张20");
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                story("疫情管理员", "需要立即做疫情电话记录。", false);
                break;
            case 1002001:
                //点电话，做打电话动作，之后切换场景。
                //BroadcastMessage("PlayLY", "小张20");
                story("疫情管理员", "需要向县预防控制中心领导反映情况和向县卫生局领导报告情况。", false);
                break;
            case 1002002:
                //BroadcastMessage("PlayLY", "小张20");
                //车开到人民医院场景
                paizi.text = "医院";
                story("疫情管理员", "县卫生院专门救护车转运病人到人民医院救治。", false);
                break;
            case 1002003:
                //BroadcastMessage("PlayLY", "小张20");
                //将病人带入隔离病房场景
                story("疫情管理员", "将病人带入传染病隔离观察治疗。", false);
                break;
            case 1002004:
                //BroadcastMessage("PlayLY", "小张20");
                //医院场景
                paizi.text = "隔离病房";
                story("疫情管理员", "县人民医院专家组进行会诊，会诊结果为这是一例不明原因肺炎。医院立刻电话报告县卫生院和县疾病预防控制中心并通过'疾病监测信息报告管理系统'网络直报，请求县疾控派专家来鉴定。", false);
                break;
            case 1003001:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                //story("疫情管理员", "叮铃铃...叮铃铃...叮铃铃...叮铃铃...（桌子上的电话正响着清脆的铃声）", false);
                paizi.text = "接电中心";
                dianhua = AudioManage.instance.PlayVoice("dianhua");
                duihuaContent.transform.parent.gameObject.SetActive(false);
                break;
            case 1003002:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                duihuaContent.transform.parent.gameObject.SetActive(true);
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y0");
                story("疫情管理员", "您好，这里是县疾控中心。", true);
                break;
            case 1003003:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("X1");
                story("疫情管理员", "我是县人民医院，我们组织院专家组进行了会诊，会诊结果这是一例不明原因肺炎，已进行了网络直报，请求县疾控派专家来鉴定。", false);
                break;
            //你应该怎么处理？1队
            //1.立即上报县卫生局
            //2.上报市疾控预防控制中心
            //3.立即召开会议，派出专业人员到病家和县人民医院进行调查处理
            //干扰项
            //4.立即上报市卫生局

            case 1003004:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("Y4");
                story("疫情管理员", "我会马上上报县卫生局、市疾控预防控制中心，并立即召开会议，派出专业人员到病家和县人民医院进行调查处理。", true);
                break;

            case 1004001:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心会议室场景
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                bg2.SetActive(true);
                paizi.text = "应急启动\n讨论会议";
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("H0");
                story("疫情管理员", "县人民医院刚刚报告了1例不明原因肺炎，县卫生局正在组织专家组会诊。我命令应急机动A队立即赶赴病家，应急机动B队立即赶赴医院，进行流行病学调查。", false);
                break;
            case 1004002:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心会议室场景
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("H1");
                story("疫情管理员", "应急机动A队收到。", true);
                break;
            case 1004003:
                //BroadcastMessage("PlayLY", "小张20");
                //县疾控中心会议室场景
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                if (dianhua != null)
                {
                    dianhua.Stop();
                }
                dianhua = AudioManage.instance.PlayVoice("H2");
                story("疫情管理员", "应急机动B队收到。", true);
                break;
            case 1004004:
                SceneManager.LoadScene(2);              
                //BroadcastMessage("PlayLY", "小张20");
                //物资准备场景
                //story("疫情管理员", "县疾病预防控制中心接到报告后，随即上报县卫生局、市疾控预防控制中心，并立即召开会议。", false);
                //story("疫情管理员", "急机动B队收到。", false);

                //后续：
                //县卫生院组织专家组到人民医院会诊，县疾病预防控制中心现场调查人员电话报告初步流行病学调查情况。县专家组会诊意见为不明原因肺炎人禽流感医学观察病例。
                //县疾病预防控制中心向市疾病预防控制中心，县卫生局向市卫生局报告了县级专家组的诊断意见。市卫生局组织专家组会诊，会诊意见为人禽流感预警病例人禽流感医学观察病例。省专家会诊意见为人禽流感确诊病例。
                //根据各级专家组会诊结果，县人民医院疫情报告员及时订正病例报告。相关部门按照如下途径逐级通报疫情：
                break;

        }
    }

    public Text duihuaContent;
    public GameObject Okbut;
    Tweener tw = null;
    public bool isTalking = false;

    //剧情，人物，对话内容
    public void story(string person, string content,bool isShowBut)
    {
        isTalking = true;
        Okbut.SetActive(false);
        setHead(person);
        duihuaContent.text = "";
        tw = duihuaContent.DOText(content, content.Length * 0.15f);
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

    //public GameObject choocePanel1;
    //public GameObject choocePanel2;
    //public GameObject error;
    //public GameObject error2;

    // Update is called once per frame
    void Update()
    {
        //第n步骤时。处理事情的方法：
        //点击电话。播放接电话动画
        if (getStep() == 1001002 && currentStepNo != 1001002)
        {
            hitObj = checkRay("电话");
          
            if (hitObj != null)
            {
                // ani["接电话动作"].speed = 1.5f;
                // ani.Play("接电话动作");
                AniManager.instance.playAni(person, "接电话动作",true,1.5f);
                ButtonOk();
                currentStepNo = 1001002;
            }
        }

        if (getStep() == 1001004 && currentStepNo != 1001004)
        {
            if (dianhua == null) {
                //choocePanel2.SetActive(true);
                Tongyong.GetComponent<Question>().GetQuestion(0);
                currentStepNo = 1001004;
            }  
        }


        if (getStep() == 1001005 && currentStepNo != 1001005)
        {
            //if (dianhua == null)
            //{
            currentStepNo = 1001005;
            // ani["放回电话"].speed = 3.0f;
            // ani.CrossFade("放回电话");
            //Tongyong.GetComponent<Question>().GetQuestion(4);
            AniManager.instance.playAni(person, "听电话", true, 0.8f);
            currentStepNo = 1001005;
            //}
        }

        if (getStep() == 1001006 && currentStepNo != 1001006)
        {
            //if (dianhua == null)
            //{
            currentStepNo = 1001006;
            // ani["放回电话"].speed = 3.0f;
            // ani.CrossFade("放回电话");
            //Tongyong.GetComponent<Question>().GetQuestion(4);
            AniManager.instance.playAni(person, "听电话", true, 0.8f);
            currentStepNo = 1001006;
            //}
        }

        //点击本，进行疫情记录工作

        if (getStep() == 1001007 && currentStepNo != 1001007)
        {
            //if (dianhua == null)
            //{
                currentStepNo = 1001007;
                // ani["放回电话"].speed = 3.0f;
                // ani.CrossFade("放回电话");
                //Tongyong.GetComponent<Question>().GetQuestion(4);
                AniManager.instance.playAni(person, "放回电话", false, 1f);
                currentStepNo = 1001007;
            //}
        }


        //点击本，进行疫情记录工作

        if (getStep() == 1001008 && currentStepNo != 1001008)
        {
            hitObj = checkRay("本");
            if (hitObj != null)
            {
               // ani["做记录"].speed = 3.0f;
               // ani.CrossFade("做记录");
                AniManager.instance.playAni(person, "做记录", false, 2.5f);
                openBen();
                currentStepNo = 1001008;
            }
        }

        if (getStep() == 1001009 && currentStepNo != 1001009)
        {
            if (dianhua == null)
            {
                //choocePanel2.SetActive(true);
                Tongyong.GetComponent<Question>().GetQuestion(5);
                currentStepNo = 1001009;
            }
        }

        //第n步骤时。处理事情的方法：
        //点击电话。播放接电话动画
        if (getStep() == 1002001 && currentStepNo != 1002001)
        {
            hitObj = checkRay("电话");
           
            if (hitObj != null)
            {
               // ani["接电话动作"].speed = 1.5f;
               // ani.Play("接电话动作");
                AniManager.instance.playAni(person, "接电话动作", false, 1.5f);
                isPlaying = true;
            }
            if (!ani.isPlaying && isPlaying)
            {
                isPlaying = false;
                ButtonOk();
                currentStepNo = 1002001;
                Cam.SetActive(true);
                bg.SetActive(true);
                AniManager.instance.playAni("0532Tuibingren01", "Take 001", false, 2f);
                yymk.SetActive(true);
                // car.transform.DOLocalMove(new Vector3(1307.4f, 0f, -14f),5f);
            }
        }

        if (getStep() == 1002002 && currentStepNo != 1002002)
        {
            if (!isTalking)
            {
                Tongyong.GetComponent<Question>().GetQuestion(16);
                currentStepNo = 1002002;
            }
        }

            //切换场景到隔离病房
            if (getStep() == 1002003 && currentStepNo != 1002003)
        {
            ani["放回电话"].speed = 3.0f;
            ani.CrossFade("放回电话");
            yymk.SetActive(false);
            bg.SetActive(false);
            glmk.SetActive(true);
            //bg2.SetActive(true);
            if (!isTalking)
            {
                Tongyong.GetComponent<Question>().GetQuestion(3);
                currentStepNo = 1002003;
            }
        }

        //切换场景到隔离病房
        if (getStep() == 1002004 && currentStepNo != 1002004)
        {
            glmkCam.SetActive(false);
            Camgl.SetActive(true);
            //bg2.SetActive(true);
            if (!isTalking)
            {
                Tongyong.GetComponent<Question>().GetQuestion(17);
                currentStepNo = 1002004;
            }
        }

        if (getStep() == 1003001 && currentStepNo != 1003001)
        {
            if (glmk.activeSelf)
            {
                bg2.SetActive(true);
                glmk.SetActive(false);
                Camgl.SetActive(false);
            }
            hitObj = checkRay("电话");
            
            if (hitObj != null)
            {
                ani["接电话动作"].speed = 1.5f;
                ani.Play("接电话动作");
                ButtonOk();
                currentStepNo = 1003001;
            }
        }


        if (getStep() == 1003003 && currentStepNo != 1003003)
        {
            if (dianhua == null)
            {
                //choocePanel2.SetActive(true);
                Tongyong.GetComponent<Question>().GetQuestion(0);
                currentStepNo = 1003003;
            }

        }

        if (getStep() == 1004001 && currentStepNo != 1004001)
        {
            
            Camhy.SetActive(true);
            if (dianhua == null)
            {
                Tongyong.GetComponent<Question>().GetQuestion(2);
                currentStepNo = 1004001;
            }

        }

        if (getStep() == 1004002 && currentStepNo != 1004002)
        {
            Camhy.transform.DOLocalMove(new Vector3(3.633121f, -0.06223639f, -1.509401f),2f);
            Camhy.transform.DOLocalRotate(new Vector3(8.9383f, 4.6408f, 0f), 2f);
            currentStepNo = 1004002;

        }

        if (getStep() == 1004003 && currentStepNo != 1004003)
        {
            Camhy.transform.DOLocalMove(new Vector3(2.35f, -0.03f, -2.06f), 2f);
            Camhy.transform.DOLocalRotate(new Vector3(10.8288f, 180.4813f, 0f), 2f);
            currentStepNo = 1004003;

        }

        //if (getStep() == 1004003 && currentStepNo != 1004003)
        //{
        //    Camhy.transform.DOLocalMove(new Vector3(2.35f, -0.03f, -2.06f), 2f);
        //    Camhy.transform.DOLocalRotate(new Vector3(10.8288f, 180.4813f, 0f), 2f);
        //    currentStepNo = 1004003;

        //}



        //点击UI结束对话
        if (Input.GetMouseButton(0)&& EventSystem.current.IsPointerOverGameObject())
        {
            if (tw != null)
            {
                tw.Complete();
            }
        }
        //if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (twben != null) {
        //        twben.Complete();
        //    }
           
        //}
    }

    bool isPlaying = false;
    public GameObject Cam;
    public GameObject bg;
    public GameObject bg2;
    //public GameObject car;
    public GameObject Camge;
    public GameObject Camhy;

    public GameObject yymk;
    public GameObject glmk;
    public GameObject Camgl;
    public GameObject glmkCam;

    public GameObject timePanel;

    //如果选择正确，进行下一步，关闭窗口，否则，显示错误提示
    //public void getRightDeal() {

    //    if (PlayerPrefs.GetInt("moshi") == 1)
    //    {
    //        if (checkToggle())
    //        {
    //            choocePanel1.SetActive(false);
    //            ButtonOk();
    //        }
    //        else
    //        {
    //            error.SetActive(true);
    //        }
    //    }
    //    else {
    //        if (checkToggle())
    //        {
    //            choocePanel1.SetActive(false);
    //            ButtonOk();
    //        }
    //        else
    //        {
    //            wrongInfo wif = new wrongInfo();
    //            wif.Num = 1;
    //            wif.des = "乡卫生院报告不明原因肺炎时，处理方式错误。";
    //            wif.score = 5;
    //            SystemManager.instance.recordWrong(wif);
    //            choocePanel1.SetActive(false);
    //            ButtonOk();
    //        }
    //    }

       
    //}

    //public bool checkToggle() {
    //    GameObject[] toggles = GameObject.FindGameObjectsWithTag("Toggle1");
    //    List<string> chooceList = new List<string>();
    //    foreach (GameObject go in toggles) {
    //        if (go.GetComponent<Toggle>().isOn == true) {
    //            chooceList.Add(go.name);
    //        }
    //    }
    //    if (chooceList.Count == 3&& chooceList.Contains("a1") && chooceList.Contains("a2") && chooceList.Contains("a3")) {
    //        return true;
    //    }
    //    return false;
    //}

    ////如果选择正确，进行下一步，关闭窗口，否则，显示错误提示
    //public void getRightDeal2()
    //{
    //    if (PlayerPrefs.GetInt("moshi") == 1)
    //    {
    //        if (checkToggle2())
    //        {
    //            choocePanel2.SetActive(false);
    //            ButtonOk();
    //        }
    //        else
    //        {
    //            error2.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        if (checkToggle())
    //        {
    //            choocePanel2.SetActive(false);
    //            ButtonOk();
    //        }
    //        else
    //        {
    //            wrongInfo wif = new wrongInfo(2, "县人民医院会诊结果为一例不明原因肺炎，处理方式错误。", 5);
    //            //wif.Num = 2;
    //            //wif.des = "县人民医院会诊结果为一例不明原因肺炎，处理方式错误。";
    //            //wif.score = 5;
    //            SystemManager.instance.recordWrong(wif);
    //            choocePanel2.SetActive(false);
    //            ButtonOk();
    //        }
    //    }
    //}

    //public bool checkToggle2()
    //{
    //    GameObject[] toggles = GameObject.FindGameObjectsWithTag("Toggle2");
    //    List<string> chooceList = new List<string>();
    //    foreach (GameObject go in toggles)
    //    {
    //        if (go.GetComponent<Toggle>().isOn == true)
    //        {
    //            chooceList.Add(go.name);
    //        }
    //    }
    //    if (chooceList.Count == 3 && chooceList.Contains("a1") && chooceList.Contains("a2") && chooceList.Contains("a3"))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    public GameObject ben;
    public GameObject benBtn;
    public Text benText;
    
    public void openBen() {
        ben.SetActive(true);
        Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<ButtonLight>().ButtonShine();
        benText.text = "";
        string benContent = "记录病人情况：\n" +
"患者：王五\n" +
"性别：男\n" +
"年龄：40岁\n" +
"职业：农民\n" +
"地址：家住东岸乡河口村二组\n" +
"状况：发烧、咳嗽、全身无力。\n家中死了两只鸡。\n" +
"乡卫生院诊断不明原因肺炎。";
        Tweener twben = benText.DOText(benContent, benContent.Length * 0.1f);
        twben.SetUpdate(true);
        twben.SetEase(Ease.Linear);
        twben.OnComplete(butBenShow);
    }

    public void butBenShow()
    {
        benBtn.SetActive(true);
    }

    public void closeBen() {
        Tongyong.GetComponent<Tongyong>()._tbBtn.GetComponent<ButtonLight>().Close();
        ben.SetActive(false);
        ButtonOk();
    }

    int currentStepNo = 0;

    GameObject hitObj = null;

    //处理行为
    void showTask(int stepNo, string person, string taskname, string content)
    {
        
    }

    public void DoSomeThing() {

    }
    LayerMask mask;

    //射线检测
    public GameObject checkRay(string name) {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //碰撞信息
            RaycastHit hit;
            //若发生碰撞
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                if (hit.collider.gameObject.name == name && (!EventSystem.current.IsPointerOverGameObject()))
                {
                    return hit.collider.gameObject;
                }
            }
        }
        return null;
    }
}
