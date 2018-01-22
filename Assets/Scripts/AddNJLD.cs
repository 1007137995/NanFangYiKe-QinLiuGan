using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AddNJLD : Addcaiyan{

    public static AddNJLD instance;
    public GameObject QT;
    public GameObject WT;
    public GameObject Huanzhe;
    public GameObject Huan;
    public GameObject Wubing;
    public GameObject See;
    public GameObject Panel;
    public GameObject Song;
    //private Animator ani = new Animator();
    public bool jc = false;
    private NavMeshAgent nav = new NavMeshAgent();
    private List<string> stepList = new List<string>();
    private List<string> HstepList = new List<string>();
    private List<string> WstepList = new List<string>();
    private bool huanzhe = false;
    private bool wubing = false;
    private bool huan = false;
    public bool wu = false;
    private bool go = false;
    private bool button = false;
    private string roleName = null;
    private string voice = null;
    private int i = 0;
    // Use this for initialization
    void Start()
    {
        instance = this;
        HstepList.Add("流调人员：请问您的姓名？\n患者妻子：李欣。");
        HstepList.Add("流调人员：请问您的年龄？\n患者妻子：36。");
        HstepList.Add("流调人员：请问您和患者最后接触的时间？\n患者妻子：早上送他去诊所。");
        HstepList.Add("流调人员：请问您和患者的关系？\n患者妻子：妻子。");
        HstepList.Add("流调人员：请问患者出现病症的时间？\n患者妻子：昨天。");
        HstepList.Add("流调人员：请问患者去过哪些地方和哪些人接触过？\n患者妻子：去过活禽市场。");
        HstepList.Add("流调人员：请问您最近和患者接触多么？\n患者妻子：多。");
        HstepList.Add("流调人员：请问您是否接触过病死的禽类？\n患者妻子：有。");
        HstepList.Add("流调人员：请问您最近是否感觉有头疼、发烧等症状？\n患者妻子：有一点。");

        WstepList.Add("流调人员：请问您的姓名？\n患者哥哥：王三。");
        WstepList.Add("流调人员：请问您的年龄？\n患者哥哥：45。");
        WstepList.Add("流调人员：请问您和患者最后接触的时间？\n患者哥哥：前天。");
        WstepList.Add("流调人员：请问您和患者的关系？\n患者哥哥：哥哥。");
        WstepList.Add("流调人员：请问患者出现病症的时间？\n患者哥哥：昨天。");
        WstepList.Add("流调人员：请问患者去过哪些地方和哪些人接触过？\n患者哥哥：去过活禽市场。");
        WstepList.Add("流调人员：请问您最近和患者接触多么？\n患者哥哥：不多。");
        WstepList.Add("流调人员：请问您是否接触过病死的禽类？\n患者哥哥：没有。");
        WstepList.Add("流调人员：请问您最近是否感觉有头疼、发烧等症状？\n患者哥哥：没有。");
        //Huanzhe.transform.parent.GetComponent<Animator>().Play("Speak");
        Wubing.SetActive(false);
        Huanzhe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(huan);
        Debug.Log(wu);
        if (huan == true && wu == true)
        {
            Debug.Log("++++++++++++++++++++++++++++++++++++++");
            //Panel.SetActive(false);
            xdManager.instance.ishuanzhe = true;
            xdManager.instance.iswubing = true;
            //xdManager.instance.liudiaoPanel.SetActive(true);
            //xdManager.instance.liudiaobgBut.SetActive(true);           
            xdManager.instance.Tongyong.GetComponent<Question>().GetQuestion(12);
            xdManager.instance.Tongyong.transform.FindChild("QTishi").FindChild("Button").GetComponent<Button>().onClick.AddListener(delegate {
                jjxManager.instance.showLiuDiao();
                xdManager.instance.story("电话", "通过与密切接触者的交流，填写密切接触者医学观察登记表。", false);
            });
            huan = false;
            wu = false;
            //xdManager.instance.ButtonOk();
        }
    }

    public void End()
    {
        if (button == true)
        {
            return;
        }
        go = true;
        StartCoroutine(EndTalk());
    }

    public override void Button()
    {
        xdManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        xdManager.instance.story("电话", stepList[i], false);
        switch (roleName)
        {
            case "huanzhe":
                voice = "Q";
                huanzhe = true;
                Huanzhe.transform.parent.GetComponent<Animator>().Play("Speak");
                break;
            case "wubing":
                voice = "W";
                wubing = true;
                Wubing.transform.parent.GetComponent<Animator>().Play("Speak");
                break;
            default:
                break;
        }
        StartCoroutine(Voice());
        i++;
        if (i == stepList.Count - 2)
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
        if (roleName == null)
        {
            xdManager.instance.showError("请选择调查对象（点击坐在院中的家属）。");
            return;
        }
        button = true;
        i = index;
        xdManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        xdManager.instance.story("电话", stepList[i], false);
        switch (roleName)
        {
            case "huanzhe":
                voice = "Q";
                Huanzhe.transform.parent.GetComponent<Animator>().Play("Speak");
                break;
            case "wubing":
                voice = "W";
                Wubing.transform.parent.GetComponent<Animator>().Play("Speak");
                break;
            default:
                break;
        }
        StartCoroutine(Voice());
    }

    IEnumerator Voice()
    {

        AudioSource sourceD = AudioManage.instance.PlayVoice("D" + i.ToString());
        yield return new WaitWhile(delegate {
            return AudioManage.instance.IsPlaying(sourceD);
        });
        AudioSource sourceV = AudioManage.instance.PlayVoice(voice + i.ToString());
        yield return new WaitWhile(delegate {
            return AudioManage.instance.IsPlaying(sourceV);
        });
        //xdManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(true);
        //if (go == true)
        //{    
        //    //xdManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        //    i = 0;
        //    xdManager.instance.ishuanzhe = false;
        //    xdManager.instance.iswubing = false;
        //    switch (roleName)
        //    {
        //        case "huanzhe":
        //            QT.SetActive(true);
        //            xdManager.instance.story("电话", "使用体温计进行测量。", false);
        //            yield return new WaitForSeconds(1);
        //            QT.transform.FindChild("shuzi").gameObject.SetActive(true);
        //            yield return new WaitForSeconds(1);
        //            QT.SetActive(false);
        //            //xdManager.instance.story("电话", "", false);
        //            xdManager.instance.story("电话", "流调人员：鉴于您可能受到感染，请您出门乘坐CDC医护车，前往医院进行隔离观察。\n患者妻子：好的。", false);
        //            AudioSource DQ9 = AudioManage.instance.PlayVoice("DQ9");
        //            yield return new WaitWhile(delegate {
        //                return AudioManage.instance.IsPlaying(DQ9);
        //            });
        //            AudioSource Q9 = AudioManage.instance.PlayVoice("Q9");
        //            yield return new WaitWhile(delegate {
        //                return AudioManage.instance.IsPlaying(Q9);
        //            });
        //            Huanzhe.transform.parent.gameObject.SetActive(false);
        //            Huan.SetActive(true);
        //            nav = Huan.GetComponent<NavMeshAgent>();
        //            nav.SetDestination(new Vector3(7.210985f, -2, -6.5f));
        //            break;
        //        case "wubing":
        //            WT.SetActive(true);
        //            xdManager.instance.story("电话", "使用体温计进行测量。", false);
        //            yield return new WaitForSeconds(1);
        //            WT.transform.FindChild("shuzi").gameObject.SetActive(true);
        //            yield return new WaitForSeconds(1);
        //            WT.SetActive(false);
        //            //xdManager.instance.story("电话", "", false);
        //            xdManager.instance.story("电话", "流调人员：由于您是密切接触者，需要对您进行家中隔离，对您家进行疫点区域的隔离。疫情爆发期间，请尽量在家中减少出入。\n患者哥哥：好的。", false);
        //            AudioSource DW9 = AudioManage.instance.PlayVoice("DW9");
        //            yield return new WaitWhile(delegate {
        //                return AudioManage.instance.IsPlaying(DW9);
        //            });
        //            AudioSource W9 = AudioManage.instance.PlayVoice("W9");
        //            yield return new WaitWhile(delegate {
        //                return AudioManage.instance.IsPlaying(W9);
        //            });
        //            Wubing.SetActive(false);
        //            break;
        //        default:
        //            break;
        //    }
        //    if (huanzhe == true && wubing == true)
        //    {
        //        Debug.Log("++++++++++++++++++++++++++++++++++++++");
        //        xdManager.instance.ishuanzhe = true;
        //        xdManager.instance.iswubing = true;
        //        xdManager.instance.liudiaoPanel.SetActive(true);
        //        xdManager.instance.story("电话", "通过与密切接触者的交流，填写密切接触者医学观察登记表。", false);
        //        xdManager.instance.liudiaobgBut.SetActive(true);
        //        //xdManager.instance.ButtonOk();
        //    }  
        //}
        button = false;
    }

    IEnumerator EndTalk()
    {
        xdManager.instance.duihuaContent.transform.parent.FindChild("AddButton").gameObject.SetActive(false);
        i = 0;
        Panel.SetActive(false);
        Tongyong.instance._dhBtn.GetComponent<ButtonLight>().Close();  
        switch (roleName)
        {
            case "huanzhe":   
                QT.SetActive(true);
                xdManager.instance.story("电话", "使用体温计进行测量。", false);
                yield return new WaitForSeconds(1);
                QT.transform.FindChild("shuzi").gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                QT.SetActive(false);
                xdManager.instance.story("电话", "流调人员：鉴于您可能受到感染，请您出门乘坐CDC医护车，前往医院进行隔离观察。\n患者妻子：好的。", false);
                AudioSource DQ9 = AudioManage.instance.PlayVoice("DQ9");
                yield return new WaitWhile(delegate {
                    return AudioManage.instance.IsPlaying(DQ9);
                });
                AudioSource Q9 = AudioManage.instance.PlayVoice("Q9");
                yield return new WaitWhile(delegate {
                    return AudioManage.instance.IsPlaying(Q9);
                });
                Huanzhe.transform.parent.gameObject.SetActive(false);
                Huan.SetActive(true);
                nav = Huan.GetComponent<NavMeshAgent>();
                nav.SetDestination(new Vector3(7.210985f, -2, -6.5f));
                huan = true;
                Huanzhe.transform.parent.gameObject.GetComponent<LookAtPlayer>().isOverTalk = true;
                Song.SetActive(true);
                xdManager.instance.iswubing = false;             
                break;
            case "wubing":
                //wu = true;
                WT.SetActive(true);
                xdManager.instance.story("电话", "使用体温计进行测量。", false);
                yield return new WaitForSeconds(1);
                WT.transform.FindChild("shuzi").gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                WT.SetActive(false);
                xdManager.instance.story("电话", "流调人员：由于您是密切接触者，需要对您进行家中隔离，对您家进行疫点区域的隔离。疫情爆发期间，请尽量在家中减少出入。\n患者哥哥：好的。", false);
                AudioSource DW9 = AudioManage.instance.PlayVoice("DW9");
                yield return new WaitWhile(delegate {
                    return AudioManage.instance.IsPlaying(DW9);
                });
                AudioSource W9 = AudioManage.instance.PlayVoice("W9");
                yield return new WaitWhile(delegate {
                    return AudioManage.instance.IsPlaying(W9);
                });
                xdManager.instance.story("电话", "给密切接触者发传单。", false);
                Wubing.transform.parent.gameObject.GetComponent<LookAtPlayer>().isOverTalk = true;
                jc = true;
                //Wubing.SetActive(false);
                break;
            default:
                break;
        }
        //if (huan == true && wu == true)
        //{
        //    Debug.Log("++++++++++++++++++++++++++++++++++++++");
        //    //Panel.SetActive(false);
        //    xdManager.instance.ishuanzhe = true;
        //    xdManager.instance.iswubing = true;
        //    //xdManager.instance.liudiaoPanel.SetActive(true);
        //    //xdManager.instance.liudiaobgBut.SetActive(true);           
        //    xdManager.instance.Tongyong.GetComponent<Question>().GetQuestion(12);
        //    xdManager.instance.Tongyong.transform.FindChild("QTishi").FindChild("Button").GetComponent<Button>().onClick.AddListener(delegate {
        //        jjxManager.instance.showLiuDiao();
        //        xdManager.instance.story("电话", "通过与密切接触者的交流，填写密切接触者医学观察登记表。", false);
        //    });      
        //    //xdManager.instance.ButtonOk();
        //}
        roleName = null;
        go = false;
    }

    public void Talk(string name)
    {
        roleName = name;
        switch (name)
        {
            case "huanzhe":
                stepList = HstepList;
                //Button();
                break;
            case "wubing":
                stepList = WstepList;
                //Button();
                break;
            default:
                break;
        }
    }
}