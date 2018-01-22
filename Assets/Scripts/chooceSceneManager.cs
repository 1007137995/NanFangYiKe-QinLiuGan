using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class chooceSceneManager : MonoBehaviour {

    private TimeManager tm;
    private bool SY = false;
    // Use this for initialization
    void Start () {
        //if (tm.isOverTuiyi)
        //{
        //    showZJPanel();
        //}
        tm = GameObject.FindGameObjectWithTag("time").GetComponent<TimeManager>();
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            SY = false;
            

            if (tm.isOverNongjiayuan && tm.isOverYiyan && !tm.isOverTuiyi)
            {
                showoverPanel();
            }
        }
        else
        {
            SY = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public GameObject Tongyong;
    public GameObject car1;
    public GameObject car2;

    public GameObject Panel;

    public string strflg = "";

    public Text content;

    public GameObject gobut;
    
    //点击农家院按钮
    public void goNongjiayuan() {
        strflg = "nongjiayuan";
        showPanel();
       
    }

    //点击医院按钮
    public void goYiyuan() {
        strflg = "yiyuan";
        showPanel();
    }

    public void goCDC() {
        strflg = "cdc";
        showPanel();
    }

    //关闭对话框
    public void closePanel() {
        Panel.SetActive(false);
    }

    //打开对话框
    public void showPanel() {
        gobut.SetActive(true);
        Panel.SetActive(true);
        if (strflg == "nongjiayuan") {
            content.text = "参与应急机动A队，立刻赶往病人家里，进行消杀工作和密切接触者的流行病学调查。";
        } else if (strflg == "yiyuan") {
            content.text = "参与应急机动B队，立刻赶往区人民医院，进行病人的流行病学调查和标本采样工作。";
        }  else if (strflg == "cdc")
        {
            gobut.SetActive(false);
            content.text = "您的当前位置，请选择农家或者区人民医院为目的地，完成应禽流感应急演练任务。";
        }
    }

    public void go() {
        closePanel();
        AudioManage.instance.PlayVoice("jiuhuche");
        if (strflg == "nongjiayuan")
        {
            carToNongjiayuan();
        }
        else if (strflg == "yiyuan")
        {
            carToYiyan();
        }
    }
    
    //汽车开往农家院动画，加载场景
    public void carToNongjiayuan() {
        car1.SetActive(true);
        car2.SetActive(false);
        car1.GetComponent<DOTweenPath>().DOPlay();
        Invoke("carToNongjiayuan2", 4.5f);
    }

    public void carToNongjiayuan2()
    {
        SceneManager.LoadScene(4);
    }


    //汽车开往医院院动画，加载场景
    public void carToYiyan() {
        car1.SetActive(false);
        car2.SetActive(true);
        car2.GetComponent<DOTweenPath>().DOPlay();
        Invoke("carToYiyan2",4.5f);
    }

    public void carToYiyan2()
    {
        SceneManager.LoadScene(6);
    }

    public void tuoyifu() {
        SceneManager.LoadScene(5);
    }

    public GameObject tuoyibut;
    public GameObject overPanel;

    public void showTuoyiBut() {
        closeoverPanel();
        //tuoyibut.SetActive(true);
        Tongyong.transform.FindChild("Right").FindChild("CFButton").GetComponent<Button>().onClick.AddListener(delegate { tuoyifu(); });
        Tongyong.GetComponent<Tongyong>()._cfBtn.GetComponent<ButtonLight>().ButtonShake();
    }

    //脱衣前窗口
    public void showoverPanel() {
        overPanel.SetActive(true);
    }

    public void closeoverPanel() {
        overPanel.SetActive(false);
    }

    public GameObject zjPanel;
    public Text zjText;
        

    //总结窗口
    public void showZJPanel() {

        string wrongstr = "";

        //if (tm.xz1 != 0) {
        //    wrongstr += "乡卫生院报告不明原因肺炎时，处理方式错误"+ tm.xz1 +"次。\n";
        //}

        //if (tm.xz2 != 0)
        //{
        //    wrongstr += "县人民医院会诊结果为一例不明原因肺炎，处理方式错误" + tm.xz2 + "次。\n";
        //}

        //if (tm.cy != 0)
        //{
        //    wrongstr += "穿防护服的顺序错误" + tm.cy + "次。\n";
        //}

        //if (tm.ty != 0)
        //{
        //    wrongstr += "脱防护服的顺序错误" + tm.ty + "次。\n";
        //}

        //int sum = tm.xz1 + tm.xz2 + tm.cy + tm.ty;

        //if (tm.hour < 6)
        //{
        //    if (sum == 0)
        //    {
        //        wrongstr += "成绩非常优异。";
        //    }
        //    else if (sum < 4)
        //    {
        //        wrongstr += "成绩优秀。";
        //    }
        //    else if (sum < 7)
        //    {
        //        wrongstr += "成绩良好。";
        //    }
        //    else {
        //        wrongstr += "成绩中等。";
        //    }
        //} else if (tm.hour < 12) {
        //    if (sum == 0)
        //    {
        //        wrongstr += "成绩优秀。";
        //    }
        //    else if (sum < 4)
        //    {
        //        wrongstr += "成绩良好。";
        //    }
        //    else if (sum < 7)
        //    {
        //        wrongstr += "成绩中等。";
        //    }
        //    else {
        //        wrongstr += "成绩较差。";
        //    }
        //} else {
        //    wrongstr += "超出了应急响应的时间，不及格。";
        //}

        int k = 0;
        foreach (wrongInfo wif in SystemManager.instance.wrongList)
        {
            k++;
            wrongstr += k + "." + wif.des+"\n";
        }


        if (SY)
        {

            zjText.text = "恭喜完成禽流感应急演练任务。" +
                "此次任务总用时：" + tm.hour + "小时" + tm.min + "分钟。";
        }
        else {

            zjText.text = "恭喜完成禽流感应急演练任务。" + "此次任务总用时：" + tm.hour + "小时" + tm.min + "分钟。\n错误列表：\n" + wrongstr;

            UnInit();
        }
            zjPanel.SetActive(true);
    }

    public void closeZJPanel() {
        zjPanel.SetActive(false);
        SceneManager.LoadSceneAsync(1);
    }


    public void UnInit()
    {
        StartCoroutine(UpdateListHeight());
    }

    public Scrollbar sb;

    IEnumerator UpdateListHeight()
    {
        yield return new WaitForEndOfFrame();
        sb.value = 1;
        //print(zjText.preferredHeight);
        int rowNum = (int)zjText.preferredHeight / (18*29);
        //print(rowNum);
        if (rowNum > 8)
        {
            zjText.GetComponent<RectTransform>().sizeDelta =
           new Vector2(465f, (rowNum+1) * 18f);
        }
        else
        {
            zjText.GetComponent<RectTransform>().sizeDelta =
          new Vector2(465f, 9 * 18f);
        }
        sb.value = 0;

    }

}
