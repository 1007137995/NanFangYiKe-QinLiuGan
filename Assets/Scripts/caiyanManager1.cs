//using UnityEngine;
//using System.Collections;
//using UnityEngine.EventSystems;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using DG.Tweening;
//using UnityEngine.SceneManagement;

//public class caiyanManager1 : MonoBehaviour {

//    public Animation ani;

//    public static caiyanManager instance;

//    public GameObject zuobikongring;
//    public GameObject youbikongring;
//    public GameObject shiguanring;
//    public GameObject beiziring;
//    public GameObject xiangziring;
//    MouseFollowRotation mfr;

//    public void hideAllRing() {
//        zuobikongring.SetActive(false);
//        youbikongring.SetActive(false);
//        shiguanring.SetActive(false);
//        beiziring.SetActive(false);
//        xiangziring.SetActive(false);
//    }

//    public void showRing(GameObject go) {
//        hideAllRing();
//        go.SetActive(true);
//    }
    
//    // Use this for initialization
//    void Start () {
//        instance = this;
//        AddStep();
//        mask = ~(1 << (LayerMask.NameToLayer("shenxing")) | 1 << (LayerMask.NameToLayer("Collider")));
//       // ani = GameObject.Find("0531Gelidongzuo02").GetComponent<Animation>();
//        doctors = GameObject.FindGameObjectsWithTag("2Doctors");
//        hideDoctor2();
//        if (GameObject.FindGameObjectWithTag("time") != null && GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverYiyan)
//        {
//            showGoBackBut();
//        }
//        mfr = texieCam.GetComponent<MouseFollowRotation>();
//        print(mfr);
//    }

//    private bool isBeginPlay = false;

//    public void clickzhayan() {
//        ani["眨眼"].speed = 1.0f;
//        ani.CrossFade("眨眼");
//        ButtonOk();
//    }

//    public void clickyoubikong() {
//        ani["点击右鼻孔"].speed = 1.0f;
//        ani.CrossFade("点击右鼻孔");
//        youbikongring.SetActive(false);
//        isBeginPlay = true;
//    }

//    public void clickzuobikong() {
//        ani["点击左鼻孔"].speed = 1.0f;
//        ani.CrossFade("点击左鼻孔");
//        zuobikongring.SetActive(false);
//        isBeginPlay = true;
//    }

//    public void clickshiguan() {
//        ani["点击试管"].speed = 3.0f;
//        ani.CrossFade("点击试管");
//        shiguanring.SetActive(false);
//        isBeginPlay = true;
//    }

//    public void clickbeizhi() {
//        ani["点击杯子"].speed = 3.0f;
//        ani.CrossFade("点击杯子");
//        beiziring.SetActive(false);
//        isBeginPlay = true;
//    }

//    public void clickxiangzhi() {
//        ani["点击箱子"].speed = 3.0f;
//        ani.CrossFade("点击箱子");
//        xiangziring.SetActive(false);
//        isBeginPlay = true;
//    }


//    //控制update一次进入
//    public bool isEnter = true;

//    public void setEnter()
//    {
//        isEnter = true;
//    }

//    private int currentNo = 0;

//    private int currentStep = 1001001;
//    List<int> stepList = new List<int>();

//    public int getNextStep()
//    {
//        int n = 0;
//        foreach (int step in stepList)
//        {
//            if (n == currentNo + 1)
//            {
//                currentStep = step;
//            }
//            n++;
//        }
//        currentNo++;
//        return currentStep;
//    }

//    public int getStep()
//    {
//        int n = 0;
//        int m = 0;
//        foreach (int a in stepList)
//        {
//            if (currentNo == n)
//            {
//                m = a;
//            }
//            n++;
//        }
//        if (m == 0)
//        {
//            m = 1001001;
//        }
//        return m;
//    }

//    public void setStep(int stepNo)
//    {
//        int n = 0;
//        int m = 0;
//        foreach (int a in stepList)
//        {
//            if (stepNo == a)
//            {
//                currentNo = n;
//            }
//            n++;
//        }
//    }

//    private static bool sceneOpen = false;

//    public void setSceneStat(bool b)
//    {
//        sceneOpen = b;
//    }

//    public bool getSceneStat()
//    {
//        return sceneOpen;
//    }


//    void AddStep()
//    {
//        //查询汇率
//        stepList.Add(1001001);
//        stepList.Add(1001002);
//        stepList.Add(1001003);
//        stepList.Add(1001004);
//        stepList.Add(1001005);
//        stepList.Add(1001006);
//        stepList.Add(1001007);
//        stepList.Add(1001008);
//        stepList.Add(1001009);
//        stepList.Add(1001010);
//        stepList.Add(1001011);
//        stepList.Add(1001012);
//        stepList.Add(1001013);
//        stepList.Add(1001014);
//        stepList.Add(1001015);
//        stepList.Add(1001016);
//        stepList.Add(1001017);
//        stepList.Add(1001018);
//        stepList.Add(1001019);
//    }

//    //步骤
//    public void ButtonOk()
//    {
//        int sn = 0;
//        //跳往下一个步骤
//        sn = getNextStep();
//        //		Debug.Log (getStep() + "sss");

//        print(sn);
//        switch (sn)
//        {
//            //i---0
//            //按照当前步骤状态进行判断
//            case 1001002:
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "流调人员按病人情况填写《中华人民共和国传染病报告卡》。", false);
//                break;
//            case 1001003:
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "切换到采样人员进行鼻拭子的采样。", false);
//                break;
//            case 1001004:
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "与病人对话，开始鼻拭子的采样。", false);
//                break;
//            case 1001005:
//                //BroadcastMessage("PlayLY", "小张20");
//                showRing(youbikongring);
//                mfr.SetTarget(youbikongring);
//                story("电话", "将一根聚丙烯纤维头的塑料杆拭子轻轻插入鼻道内鼻鳄处，停留片刻后缓慢转动退出。", false);
//                break;
//            case 1001006:
//                showRing(zuobikongring);
//                mfr.SetTarget(zuobikongring);
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "取另一根聚丙烯纤维头的塑料杆拭子以同样的方法采集另一侧鼻孔。", false);
//                break;
//            case 1001007:
//                showRing(shiguanring);
//                mfr.SetTarget(shiguanring);
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "将上述2根拭子侵入同一含3ml采样液的管中，弃去尾部，旋紧管盖。", false);
//                break;
//            case 1001008:
//                showRing(beiziring);
//                mfr.SetTarget(beiziring);
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "将采样液的试管放入一个安全的杯子中。", false);
//                break;
//            case 1001009:
//                showRing(xiangziring);
//                mfr.SetTarget(xiangziring);
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "将标本采样后放入专用运输箱内，四周放置冰袋空隙部分用具有吸水和缓冲性能的材料填充，所有运送容器外必须具有生物危险标识。", false);
//                break;
//            case 1001010:
//                hideAllRing();
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "标本的运送应遵循《病原微生物实验室生物安全管理条例》和卫生部有关规定，送至II级生物安全实验室生物安全柜内。", true);
//                break;
//            case 1001011:
//                texieCam.SetActive(false);
//                caiyangPerson.SetActive(true);
//                hideDoctor2();
//                showGoBackBut();
//                //BroadcastMessage("PlayLY", "小张20");
//                story("电话", "病人的流行病学调查和采样工作完成。应急机动B队任务完成。可查看应急A队进展情况。", false);
//                 GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>().isOverYiyan = true;
//                break;
//        }
//    }

//    public GameObject goBackBut;

//    public void showGoBackBut()
//    {
//        goBackBut.SetActive(true);
//    }

//    public void gobackCdc()
//    {
//        SceneManager.LoadScene(6);
//    }

//    public Text duihuaContent;
//    public GameObject Okbut;
//    Tweener tw = null;
//    public bool isTalking = false;

//    //对话确定按钮
//    public void butShow()
//    {
//        isTalking = false;
//        Okbut.SetActive(true);
//    }

//    //对话结束触发
//    public void overTalk()
//    {
//        isTalking = false;
//    }


//    //填写完毕触发，在特定步骤进行
//    public void overWrite() {
//        if (getStep() == 1001002 && currentStepNo != 1001002) {
//            isCamLiuDiao = true;
//            currentStepNo = 1001002;
//            ButtonOk();
//        }
//    }

//    //填写完毕触发，在特定步骤进行
//    public void begin()
//    {
//        if (getStep() == 1001001 && currentStepNo != 1001001)
//        {
//            currentStepNo = 1001001;
//            //ButtonOk();
//            //duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(true);
//            //AddBCLD.instance.Button();
//            AddBCLD.instance.Panel.SetActive(true);
//        }
//    }

//    //填写完毕触发，在特定步骤进行
//    public void begin2()
//    {
//        if (getStep() == 1001004 && currentStepNo != 1001004)
//        {
//            currentStepNo = 1001004;
//            ButtonOk();
//        }
//    }

//    //剧情，人物，对话内容
//    public void story(string person, string content, bool isShowBut)
//    {
//        isTalking = true;
//        Okbut.SetActive(false);
//        setHead(person);
//        tw.Complete();
//        duihuaContent.text = "";
//        tw = duihuaContent.DOText(content, content.Length * 0.1f);
//        tw.SetUpdate(true);
//        tw.SetEase(Ease.Linear);
//        if (isShowBut)
//        {
//            tw.OnComplete(butShow);
//        }
//        else
//        {
//            tw.OnComplete(overTalk);
//        }
//        //		tweener.Complete ();
//    }

//    //显示对话头像
//    public void setHead(string name)
//    {
//        /**
//        if (name == "小张")
//        {
//            zhujue.SetActive(true);
//            peijue.SetActive(false);
//            zhujue.GetComponent<Image>().sprite = Resources.Load("Head/" + name, typeof(Sprite)) as Sprite;
//            zhujue.transform.Find("name").GetComponent<Text>().text = name;
//        }
//        else
//        {
//            zhujue.SetActive(false);
//            peijue.SetActive(true);
//            peijue.GetComponent<Image>().sprite = Resources.Load("Head/" + name, typeof(Sprite)) as Sprite;
//            peijue.transform.Find("name").GetComponent<Text>().text = name;
//        }**/
//    }


//    // Update is called once per frame
//    void Update()
//    {
//        //安装警戒线，工具还未处理
//        if (getStep() == 1001002 && currentStepNo != 1001002)
//        {
//            hitObj = checkRay("ts1");

//            if (hitObj != null)
//            {
//                if (jjxManager.instance.isCurrentTool("警戒线"))
//                {
//                    //jjx1.SetActive(true);
//                    //Destroy(ts1);
//                    //FlashingController fc = ts2.AddComponent<FlashingController>();
//                    //fc.flashingDelay = 0f;
//                    ButtonOk();
//                    currentStepNo = 1001002;
//                }
//                else
//                {
//                    //showError("请选择警戒线工具。");
//                }

//            }
//        }

//        //点击UI结束对话
//        if (Input.GetMouseButton(0) && EventSystem.current.IsPointerOverGameObject())
//        {
//            if (tw != null)
//            {
//                tw.Complete();
//            }
//        }

//        //点击调查任务
//        if (Input.GetMouseButtonDown(0))
//        {

//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            //碰撞信息
//            RaycastHit hit;
//            //若发生碰撞
//            if (Physics.Raycast(ray, out hit, 5f, mask))
//            {
//                if (hit.collider.gameObject.tag == "TalkPeople" && !EventSystem.current.IsPointerOverGameObject()&&GameObject.FindGameObjectWithTag("Player") != null)
//                {
//                    liudiaoPanel.SetActive(true);
//                }
//            }
//        }

//        if (isBeginPlay) {
//            if (!ani.isPlaying) {
//                isBeginPlay = false;
//                ButtonOk();
//            }
//        }
             


//    }

//    int currentStepNo = 0;

//    GameObject hitObj = null;

//    LayerMask mask;

//    public GameObject liudiaoPanel;

//    //射线检测
//    public GameObject checkRay(string name)
//    {
//        if (Input.GetMouseButtonDown(0))
//        {

//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            //碰撞信息
//            RaycastHit hit;
//            //若发生碰撞
//            if (Physics.Raycast(ray, out hit, 100f, mask))
//            {
//                if (hit.collider.gameObject.name == name && (!EventSystem.current.IsPointerOverGameObject()))
//                {
//                    return hit.collider.gameObject;
//                }
//            }
//        }
//        return null;
//    }

//    public GameObject liudiaoPerson;
//    public GameObject caiyangPerson;

//    public void changeToLiudiao(GameObject but) {
//        if(GameObject.FindGameObjectWithTag("Player") != null){
//            resetRoleButNew();
//            but.GetComponent<Image>().sprite = liangcheBut_chooce;
//            liudiaoPerson.SetActive(true);
//            caiyangPerson.SetActive(false);
//        }

//    }


//    private bool isCamLiuDiao = false;

//    public void changeToCaiyang(GameObject but) {

//        if (isCamLiuDiao)
//        {
//            if (GameObject.FindGameObjectWithTag("Player") != null)
//            {
//                resetRoleButNew();
//                but.GetComponent<Image>().sprite = liangcheBut_chooce;
//                liudiaoPerson.SetActive(false);
//                caiyangPerson.SetActive(true);
//            }
//            if (getStep() == 1001003 && currentStepNo != 1001003)
//            {
//                ButtonOk();
//                currentStepNo = 1001003;
//            }
//        }
//        else
//        {
//            showErrorText("请先完成流调的工作之后，\n再进行选择采样人员进行采样。");
//        }

      
//    }

//    public GameObject liudiaoTable;

//    public GameObject[] doctors;

//    public GameObject texieCam;

//    public void hideDoctor2() {
        
//        foreach (GameObject go in doctors) {
//            go.SetActive(false);
//        }
//    }

//    public void showDoctor2()
//    {
//        foreach (GameObject go in doctors)
//        {
//            go.SetActive(true);
//        }
//    }

//    public Sprite liangcheBut_chooce;
//    public Sprite liangcheBut_noChooce;

//    //重置角色but样式
//    private void resetRoleButNew()
//    {
//        GameObject[] roleBut2 = GameObject.FindGameObjectsWithTag("liangceBut");
//        foreach (GameObject rb in roleBut2)
//        {
//            rb.GetComponent<Image>().sprite = liangcheBut_noChooce;
//        }
//    }

//    public void goLiuDiaoPanel()
//    {
//        begin();

//        //liudiaoTable.SetActive(true);
//    }

//    public void goCaiyangAni()
//    {
//        begin2();
//        showDoctor2();
//        ani.Play("点击右鼻孔");
//        ani.Stop();
//        caiyangPerson.SetActive(false);
//        texieCam.SetActive(true);
//    }



//    public void closeLiuDiaoPanel() {
     
//        liudiaoTable.SetActive(false);
//    }

//    public GameObject errorGo;
//    public Text errorText;

//    public void showErrorText(string errorStr)
//    {
//        errorText.text = errorStr;
//        errorGo.SetActive(true);
//    }

//     //showErrorText("处理方法不恰当，请重新选择！");
//}
