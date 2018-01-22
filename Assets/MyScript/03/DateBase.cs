using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DateBase : MonoBehaviour
{
    public GameObject[] _TargetObj;
    public GameObject[] _JinJieLine;
    public Dictionary<string, string> _TipList;
    void Start()
    {
        _TipList = new Dictionary<string, string>();
        _TipList.Add("One", "请把鼠标移动到左侧打开菜单栏，先放置警戒线！");
        _TipList.Add("Two", "请选择正确的位置摆放！");
        _TipList.Add("Three","请走到病人附近，进行检查！");
        _TipList.Add("Four","请打开菜单栏点击采样管，进行样本采集！");
        _TipList.Add("Five", "请打开菜单栏点击棉签并移动到病人嘴边！");
        _TipList.Add("Six", "请点击病人嘴巴！");
        _TipList.Add("Seven", "请点击棉签！");
    }
    public void _ShowLine()
    {
        foreach (GameObject Item in _JinJieLine)
        {
            Item.SetActive(true);
        }
    }
    public void _ChangeTag(int _Num)
    {
        for (int i = 0; i < _TargetObj.Length; i++)
        {
            if (i != _Num)
            {
                _TargetObj[i].tag = "Untagged";
            }
            else
            {
                _TargetObj[i].tag = "TargetObj";
            }
        }
    }
}
