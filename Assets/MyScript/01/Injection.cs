using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Injection : MonoBehaviour
{
    public static Injection _Instance;
    private void Awake()
    {
        _Instance = this;
    }
    public GameObject _IntroducePanle;
    private GameObject _Canvas;
    private GameObject _ConfigeButtonObj;
    private Text _Name;
    private Text _Age;
    private Text _Job;
    private Text _Sex;
    private Text _Describe;

    public Text _Dailog;
    private XmlRead _Xml;
    private int _Num = 0;
    public GameObject _ReturnBtn;
    private void Start()
    {
        _Canvas = GameObject.Find("Canvas");
        _Xml = GameObject.Find("Canvas").GetComponent<XmlRead>();
        _Name = _IntroducePanle.transform.FindChild("Name").GetChild(0).GetComponent<Text>();
        _Age = _IntroducePanle.transform.FindChild("Age").GetChild(0).GetComponent<Text>();
        _Job = _IntroducePanle.transform.FindChild("Job").GetChild(0).GetComponent<Text>();
        _Sex = _IntroducePanle.transform.FindChild("Sex").GetChild(0).GetComponent<Text>();
        _Describe = _IntroducePanle.transform.FindChild("Describe").GetComponent<Text>();

        _Dailog = _Canvas.transform.FindChild("Dailog").GetComponent<Text>();
        _ConfigeButtonObj = _Canvas.transform.FindChild("ConfigeButton").gameObject;
        Invoke("_Delay",0.5f);
    }

    private void _Delay()
    {
        _TextShow(_Xml._Content[0]);
    }

    public void _ShowIntroduce(string _NAME)
    {
        _IntroducePanle.transform.DOMoveX(-375f, 0.5f);
        _Name.text = _Xml._IntroduceList[_NAME]._Name;
        _Age.text = _Xml._IntroduceList[_NAME]._Age.ToString();
        _Sex.text = _Xml._IntroduceList[_NAME]._Sex;
        _Job.text = _Xml._IntroduceList[_NAME]._Job;
        _Describe.text = _Xml._IntroduceList[_NAME]._Describe;
    }
    public void _CloseIntroduce()
    {
        _IntroducePanle.transform.DOMoveX(-610f, 0.5f);
    }
    public void _ConfigeButton()
    {
        _Dailog.text = String.Empty;

        _ConfigeButtonObj.SetActive(false);

        if (_Num == 0)
        {
            _TextShow(_Xml._Content[1]);
        }
        if (_Num == 1)
        {
            _TextShow(_Xml._Content[2]);
        }
        if (_Num == 2)
        {
            _ConfigeButtonObj.SetActive(false);
            _ReturnBtn.SetActive(true);
        }
        _Num++;
    }
    private void _TextShow(string _Content)
    {
        Tweener _Tweener =_Dailog.DOText(_Content, 2f);
        _Tweener.OnComplete(() => { _ConfigeButtonObj.SetActive(true); });
    }
    private void _ChangeScene()
    {
    }
}
