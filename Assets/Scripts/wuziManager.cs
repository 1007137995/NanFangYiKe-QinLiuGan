using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum ROLE {
    SURVEY,
    TREATMENT,
    DEGASSING,
    SAMPLING,
}

public class wuziManager : MonoBehaviour {

    public static wuziManager instance;
    public GameObject Tongyong;
    private bool SY = false;
    //物资标准列表
    public List<string> xiaoduList = new List<string>();
    public List<string> caiyangList = new List<string>();
    public List<string> liudiaoList = new List<string>();
    public List<string> yiliaoList = new List<string>();

    //已获取的物资列表
    public List<string> xiaoduGetList = new List<string>();
    public List<string> caiyangGetList = new List<string>();
    public List<string> liudiaoGetList = new List<string>();
    public List<string> yiliaoGetList = new List<string>();

    public ROLE currentRole = ROLE.SURVEY;

    // Use this for initialization
    void Start () {
        instance = this;
        //各角色应选物资
        liudiaoList.Add("胎素笔"); liudiaoList.Add("纸张");  liudiaoList.Add("病例调查表"); liudiaoList.Add("观察登记表"); liudiaoList.Add("应急包"); liudiaoList.Add("电子体温计"); liudiaoList.Add("防护口罩"); liudiaoList.Add("防护眼镜"); liudiaoList.Add("乳胶手套"); liudiaoList.Add("防护手套"); liudiaoList.Add("防护靴"); liudiaoList.Add("防护服"); liudiaoList.Add("防护帽"); liudiaoList.Add("身份牌");
        //yiliaoList.Add("胎素笔"); yiliaoList.Add("纸张"); yiliaoList.Add("防护服"); yiliaoList.Add("防护靴"); yiliaoList.Add("防护手套"); yiliaoList.Add("防护眼镜"); yiliaoList.Add("防护口罩"); yiliaoList.Add("防护帽"); yiliaoList.Add("医疗废物包装袋"); yiliaoList.Add("急救箱"); yiliaoList.Add("隔离标志"); 
        xiaoduList.Add("胎素笔"); xiaoduList.Add("消毒记录表"); xiaoduList.Add("防护服"); xiaoduList.Add("防护靴"); xiaoduList.Add("乳胶手套"); xiaoduList.Add("防护手套"); xiaoduList.Add("防护眼镜"); xiaoduList.Add("防护口罩"); xiaoduList.Add("防护帽"); xiaoduList.Add("84消毒液"); xiaoduList.Add("漂白粉"); xiaoduList.Add("医用喷壶"); xiaoduList.Add("小喷壶"); xiaoduList.Add("警戒线"); xiaoduList.Add("宣传单"); xiaoduList.Add("身份牌");
         caiyangList.Add("防护服"); caiyangList.Add("防护靴");  caiyangList.Add("乳胶手套"); caiyangList.Add("防护手套"); caiyangList.Add("防护眼镜"); caiyangList.Add("防护口罩"); caiyangList.Add("防护帽"); caiyangList.Add("医疗废物包装袋"); caiyangList.Add("采样拭子"); caiyangList.Add("采样箱"); caiyangList.Add("医用棉签"); caiyangList.Add("医用棉花"); caiyangList.Add("酒精瓶"); caiyangList.Add("止血带"); caiyangList.Add("塑封袋"); caiyangList.Add("身份牌");
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            SY = false;
        }
        else
        {
            SY = true;
        }
        Tongyong.GetComponent<Tongyong>()._bbBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._spBtn.GetComponent<ButtonLight>().ButtonShine();
        Tongyong.GetComponent<Tongyong>()._cfBtn.GetComponent<ButtonLight>().ButtonShine();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShiPin()
    {
        if (Tongyong.transform.FindChild("Yiyongpenhu").gameObject.activeSelf == false)
        {
            Tongyong.transform.FindChild("Yiyongpenhu").gameObject.gameObject.SetActive(true);
        }
        else
        {
            Tongyong.transform.FindChild("Yiyongpenhu").gameObject.SetActive(false);
        }
    }

    public void Movie(string name)
    {
        Tongyong.transform.FindChild("Yiyongpenhu/Movie").gameObject.SetActive(true);
        playMovie_dealfw.instance.playMov(name);
        switch (name)
        {
            case "zui":
                Tongyong.transform.FindChild("Yiyongpenhu/Movie/Text").GetComponent<Text>().text = "喷嘴安装";
                break;
            case "gai":
                Tongyong.transform.FindChild("Yiyongpenhu/Movie/Text").GetComponent<Text>().text = "气密性检查";
                break;
            case "gan":
                Tongyong.transform.FindChild("Yiyongpenhu/Movie/Text").GetComponent<Text>().text = "喷雾杆安装";
                break;
            case "fa":
                Tongyong.transform.FindChild("Yiyongpenhu/Movie/Text").GetComponent<Text>().text = "导管安装";
                break;
            default:
                break;
        }
    }

    public void CloseMovie()
    {
        Tongyong.transform.FindChild("Yiyongpenhu/Movie").gameObject.SetActive(false);
    }

    //收集消毒物资
    public void getDegassingGoods() {

    }
    //收集采样物资
    public void getSamplingGoods()
    {

    }
    //收集流调物资
    public void getSurveyGoods()
    {

    }
    //删除消毒物资
    public void delDegassingGoods()
    {

    }
    //删除采样物资
    public void delSamplingGoods()
    {

    }
    //删除流调物资
    public void delSurveyGoods()
    {

    }
    //显示物资列表(待定)
    public void showAllGoodsList() {

    }

    //显示消毒物资列表
    public void showDegassingGoodsList()
    {
        print(xiaoduList.Count);
        UIFirst.instance.showItem();
    }
    //显示采集物资列表
    public void showSamplingGoodsList()
    {

    }

    //显示调查物资列表
    public void showSurveyGoodsList()
    {

    }

    //对比所有物资
    public void contrastAllGoods()
    {

    }

    //对比消毒物资
    public void contrastDegassingGoods()
    {
        foreach (string wzName in xiaoduList) {

        }
    }
    //对比采样物资
    public void contrastSamplingGoods()
    {

    }
    //对比流调物资
    public void contrastSurveyGoods()
    {

    }
    //显示选择物资的三维模型,及相关文字介绍
    public void showGoAndIntro() {

    }
    //返回三维场景，删除当前显示
    public void backScene() {

    }

    public GameObject caiyangPeople;
    public GameObject liudiaoPeople;
    public GameObject xiaoshaPeople;
    //public GameObject yiliaoPeople;

    public Text peopleText;

    public void hideOtherPeople(GameObject people) {
        caiyangPeople.SetActive(false);
        liudiaoPeople.SetActive(false);
        xiaoshaPeople.SetActive(false);
        //yiliaoPeople.SetActive(false);
        people.SetActive(true);
    }

    //更换当前角色
    public void changeRole(GameObject roleBut) {
        resetRoleButNew();
        //更换人物模型和头像、介绍
        if (roleBut.name == "js1") {
            currentRole = ROLE.SURVEY;
            hideOtherPeople(liudiaoPeople);
            peopleText.text = "当前角色为：流行病学调查人员\n请选择对应物资。";
            //roleBut.GetComponent<Image>().sprite = liangcheBut_chooce;
        }
        //else if (roleBut.name == "js2") {
        //    currentRole = ROLE.TREATMENT;
        //    hideOtherPeople(yiliaoPeople);
        //    peopleText.text = "当前角色为：医疗处理人员\n请选择对应物资。";
        //    roleBut.GetComponent<Image>().sprite = zhongjianBut_chooce;
        //}
        else if (roleBut.name == "js3")
        {
            currentRole = ROLE.DEGASSING;
            hideOtherPeople(caiyangPeople);
            peopleText.text = "当前角色为：消杀人员\n请选择对应物资。";
            //roleBut.GetComponent<Image>().sprite = zhongjianBut_chooce;
        }
        else if (roleBut.name == "js4")
        {
            currentRole = ROLE.SAMPLING;
            hideOtherPeople(xiaoshaPeople);
            peopleText.text = "当前角色为：采样人员\n请选择对应物资。";
            //roleBut.GetComponent<Image>().sprite = liangcheBut_chooce;
        }
      

        UIFirst.instance.showItem();
    }

    public Sprite liangcheBut_chooce;
    public Sprite zhongjianBut_chooce;
    public Sprite liangcheBut_noChooce;
    public Sprite zhongjianBut_noChooce;

    //重置角色but样式
    private void resetRoleBut(string tagName) {
        GameObject[] roleBut = GameObject.FindGameObjectsWithTag(tagName);
        foreach (GameObject rb in roleBut) {
            //rb.GetComponent<Image>().color = Color.white;
            rb.GetComponentInChildren<Text>().color = Color.white;
        }
    }

    //重置角色but样式
    private void resetRoleButNew()
    {
        GameObject[] roleBut = GameObject.FindGameObjectsWithTag("zhongjianBut");
        foreach (GameObject rb in roleBut)
        {
            rb.GetComponent<Image>().sprite = zhongjianBut_noChooce;
        }

        GameObject[] roleBut2 = GameObject.FindGameObjectsWithTag("liangceBut");
        foreach (GameObject rb in roleBut2)
        {
            rb.GetComponent<Image>().sprite = liangcheBut_noChooce;
        }
    }

    //获取当前角色List
    public List<string> getCurrentRoleList() {
        List<string> getList = new List<string>();
        switch (currentRole) {
            case ROLE.SURVEY:
                getList = liudiaoGetList;
                
                break;
            //case ROLE.TREATMENT:
            //    getList = yiliaoGetList;
            //    break;
            case ROLE.DEGASSING:
                getList = xiaoduGetList;
                break;
            case ROLE.SAMPLING:
                getList = caiyangGetList;
                break;
        }
        return getList;
    }

    public GameObject tishiPanel;
    public Text content;
    public GameObject goNextSceneBut;

    //result check
    public void goCheck(string perName,List<string> getList, List<string> aimList) {
        
        List<string> s1 = aimList;
        string str = "";
        str += "<size=18>"+ perName + "</size>：\n\n<size=16>应选择：</size>";
        s1.Sort();
        foreach (string s in s1) {
            str += s+ "；";
        }
        s1 = getList;
        s1.Sort();
        str += "\n\n<size=16>已选择：</size>";
        foreach (string s in s1)
        {
            str += s + "；";
        }
        str += "\n\n<size=16>多选择：</size>";
        foreach (string s in checkChaZhi(getList, aimList, true))
        {
            str += s + "；";
        }
        str += "\n\n<size=16>未选择：</size>";
        foreach (string s in checkChaZhi(getList, aimList, false))
        {
            str += s + "；";
        }
        content.text = str;
    }

    public GameObject liudiaobut;
    //public GameObject yiliaobut;
    public GameObject xiaoshabut;
    public GameObject caiyangbut;

    public GameObject confirmPanel;

    public void goResult() {

        if (PlayerPrefs.GetInt("moshi") == 1)
        {
            tishiPanel.SetActive(true);
            resetRoleBut("resultBut");
            if (currentRole == ROLE.SURVEY)
            {
                goCheck("流行病学调查人员", liudiaoGetList, liudiaoList);
                //liudiaobut.GetComponent<Image>().color = new Color(188f / 255f, 177f / 255f, 144f / 255f);
                liudiaobut.GetComponentInChildren<Text>().color = Color.yellow;
            }
            //else if (currentRole == ROLE.TREATMENT)
            //{
            //    goCheck("医疗人员", yiliaoGetList, yiliaoList);
            //    yiliaobut.GetComponent<Image>().color = new Color(188f / 255f, 177f / 255f, 144f / 255f);
            //    yiliaobut.GetComponentInChildren<Text>().color = Color.white;
            //}
            else if (currentRole == ROLE.DEGASSING)
            {
                goCheck("消杀人员", xiaoduGetList, xiaoduList);
                //xiaoshabut.GetComponent<Image>().color = new Color(188f / 255f, 177f / 255f, 144f / 255f);
                xiaoshabut.GetComponentInChildren<Text>().color = Color.yellow;
            }
            else if (currentRole == ROLE.SAMPLING)
            {
                goCheck("采样人员", caiyangGetList, caiyangList);
                //caiyangbut.GetComponent<Image>().color = new Color(188f / 255f, 177f / 255f, 144f / 255f);
                caiyangbut.GetComponentInChildren<Text>().color = Color.yellow;
            }
            checkAllWuzi();

        }
        else {
            confirmPanel.SetActive(true);
        }

    }

    public void doConfirm() {
       
        if (!(checkChaZhi(liudiaoGetList, liudiaoList, true).Count == 0 && checkChaZhi(liudiaoGetList, liudiaoList, false).Count == 0)) {
            wrongInfo wif = new wrongInfo(4, "流调物资准备不正确。", false);
            SystemManager.instance.recordWrong(wif);
        }
        else
        {
            wrongInfo wif = new wrongInfo(4, "流调物资准备正确。", true);
            SystemManager.instance.recordWrong(wif);
        }

        //if (!(checkChaZhi(yiliaoGetList, yiliaoList, true).Count == 0 && checkChaZhi(yiliaoGetList, yiliaoList, false).Count == 0))
        //{
        //    wrongInfo wif = new wrongInfo(3, "医疗物资准备不正确。", 5);
        //    SystemManager.instance.recordWrong(wif);
        //}

        if (!(checkChaZhi(xiaoduGetList, xiaoduList, true).Count == 0 && checkChaZhi(xiaoduGetList, xiaoduList, false).Count == 0))
        {
            wrongInfo wif = new wrongInfo(4, "消毒物资准备不正确。", false);
            SystemManager.instance.recordWrong(wif);
        }
        else
        {
            wrongInfo wif = new wrongInfo(4, "消毒物资准备正确。", true);
            SystemManager.instance.recordWrong(wif);
        }

        if (!(checkChaZhi(caiyangGetList, caiyangList, true).Count == 0 && checkChaZhi(caiyangGetList, caiyangList, false).Count == 0))
        {
            wrongInfo wif = new wrongInfo(4, "采样物资准备不正确。", false);
            SystemManager.instance.recordWrong(wif);
        }
        else
        {
            wrongInfo wif = new wrongInfo(4, "采样物资准备正确。", true);
            SystemManager.instance.recordWrong(wif);
        }

        confirmPanel.SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void colseConfirm() {
        confirmPanel.SetActive(false);
    }

    public void closeResult() {
        tishiPanel.SetActive(false);
    }

    public void goCheckByBut(GameObject but) {
        if (but.GetComponent<Image>() != null)
        {
            resetRoleBut("resultBut");
            //but.GetComponent<Image>().color = new Color(188f / 255f, 177f / 255f, 144f / 255f);
            but.GetComponentInChildren<Text>().color = Color.yellow;
        }
        if (but.name == "liudiaoBut") {
            goCheck("流行病学调查人员",liudiaoGetList,liudiaoList);
        } 
        //else if (but.name == "yiliaoBut") {
        //    goCheck("医疗人员", yiliaoGetList, yiliaoList);
        //}
        else if (but.name == "xiaoshaBut")
        {
            goCheck("消杀人员", xiaoduGetList, xiaoduList);
        }
        else if (but.name == "caiyangBut")
        {
            goCheck("采样人员", caiyangGetList, caiyangList);
        }
        checkAllWuzi();
    }


    //检查是否物资都已准备好
    public void checkAllWuzi() {
        if (checkChaZhi(liudiaoGetList, liudiaoList, true).Count == 0&& checkChaZhi(liudiaoGetList, liudiaoList, false).Count == 0
            /*&& checkChaZhi(yiliaoGetList, yiliaoList, true).Count == 0 && checkChaZhi(yiliaoGetList, yiliaoList, false).Count == 0*/
            && checkChaZhi(xiaoduGetList, xiaoduList, true).Count == 0 && checkChaZhi(xiaoduGetList, xiaoduList, false).Count == 0
            && checkChaZhi(caiyangGetList, caiyangList, true).Count == 0 && checkChaZhi(caiyangGetList, caiyangList, false).Count == 0) {
            goNextSceneBut.SetActive(true);
        }
        else
        {
            goNextSceneBut.SetActive(false);
        }
        
    }

    //切换下一个场景
    public void goNextScene()
    {
        SceneManager.LoadScene(3);
    }


    //获取多选物资和未选物资
    public List<string> checkChaZhi(List<string> getList,List<string> aimList,bool isMore) {
        List<string> duoList = new List<string>();
        List<string> shaoList = new List<string>();
  
        if (isMore) {
            for (int i = 0; i < getList.Count; i++)
            {
                if (!aimList.Contains(getList[i]))
                {
                    duoList.Add(getList[i]);
                }
            }
            return duoList;
        }
        else {
            for (int i = 0; i < aimList.Count; i++)
            {
                if (!getList.Contains(aimList[i]))
                {
                    shaoList.Add(aimList[i]);
                }
            }
            return shaoList;
        }

    }

}
