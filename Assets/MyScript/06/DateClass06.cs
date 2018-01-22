using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DateClass06 : MonoBehaviour
{
    public Dictionary<string, string> _TextDic;
    // Use this for initialization
    void Start()
    {
        _TextDic = new Dictionary<string, string>();
        _TextDic.Add("One","请走到坐在地上的患病人员，点击按钮进行观察");
        _TextDic.Add("Two","选择错误，请重新选择！");
        _TextDic.Add("Three","请寻找亲密接触群众进行询问！");
        _TextDic.Add("Four", "有没有与病人亲密接触！");
        _TextDic.Add("Five", "有没有哪里不舒适！！");
        _TextDic.Add("Six", "没有！");
        _TextDic.Add("Seven", "头有点晕！");
        _TextDic.Add("Eight", "您认识他吗?");
        _TextDic.Add("Nine", "是我好朋友！");
        _TextDic.Add("Ten","没有哪里不舒服！");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
