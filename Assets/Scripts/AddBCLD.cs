using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddBCLD : Addcaiyan{
    public static AddBCLD instance;
    public GameObject Head;
    public GameObject ZT;
    public GameObject Panel;
    private Animator ani = new Animator();
    private List<string> stepList = new List<string>();
    private bool go = false;
    private bool button = false;
    private int i = 0;
    // Use this for initialization
    void Start () {
        instance = this;
        ani = Head.GetComponent<Animator>();
        stepList.Add("流调人员：请问您的姓名？\n重症患者：王五。");
        stepList.Add("流调人员：请问您的年龄？\n重症患者：40。");
        stepList.Add("流调人员：请问您的工作？\n重症患者：农民。");
        stepList.Add("流调人员：请问您是不是不舒服，有没有头疼、发烧或者全身酸痛？\n重症患者：有。");
        stepList.Add("流调人员：请问您个人卫生情况如何？是否有饭前饭后勤洗手好习惯？\n重症患者：有。");
        stepList.Add("流调人员：请问您家中或附近是否有养鸡？\n重症患者：家中有养。");
        stepList.Add("流调人员：请问您这几天是否接触过类似病患，去过哪些地方？\n重症患者：没有接触过，去过活禽市场。");
        stepList.Add("流调人员：请问您最近有没有进食过禽类？\n重症患者：没有吃过。");
        stepList.Add("流调人员：请问您最近有没有直接宰杀过禽类？\n重症患者：有。");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Button()
    {
        
        caiyanManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        caiyanManager.instance.story("电话", stepList[i], false);
        StartCoroutine(Voice());
        i++;
        if (i == stepList.Count)
        {
            go = true;
        }
    }

    public override void Button(int index)
    {
        if (button == true)
        {
            return;
        }
        button = true;
        i = index;
        caiyanManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        caiyanManager.instance.story("电话", stepList[i], false);
        StartCoroutine(Voice());
    }

    public void End()
    {
        if (button == true)
        {
            return;
        }
        StartCoroutine(EndTalk());
        Panel.SetActive(false);
        Tongyong.instance._dhBtn.GetComponent<ButtonLight>().Close();
    }

    IEnumerator Voice()
    {
        AudioSource sourceL = AudioManage.instance.PlayVoice("L" + i.ToString());
        yield return new WaitWhile(delegate {
            return AudioManage.instance.IsPlaying(sourceL); 
        });
        AudioSource sourceZ = AudioManage.instance.PlayVoice("Z" + i.ToString());
        Debug.Log(sourceZ.volume);
        ani.SetBool("Speak", true);
        yield return new WaitWhile(delegate {
            return AudioManage.instance.IsPlaying(sourceZ);
        });
        ani.SetBool("Speak", false);
        //caiyanManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(true);
        
        if (go == true)
        {
            caiyanManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
            i = 0;
            caiyanManager.instance.liudiaoTable.SetActive(true);
            caiyanManager.instance.ButtonOk();
        }
        button = false;
    }

    IEnumerator EndTalk()
    {
        ZT.SetActive(true);
        caiyanManager.instance.story("电话", "使用体温计进行测量。", false);
        yield return new WaitForSeconds(1);
        ZT.transform.FindChild("shuzi").gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ZT.SetActive(false);
        caiyanManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        i = 0;
        caiyanManager.instance.liudiaoTable.SetActive(true);
        caiyanManager.instance.ButtonOk();
    }
}
