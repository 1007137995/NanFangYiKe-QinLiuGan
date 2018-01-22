using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DateClass05 : MonoBehaviour
{
    public GameObject[] _WuZi;
    public GameObject[] _WuZiLINE;
    public GameObject[] _RenYuan;
    public GameObject[] _RenYuanLINE;
    public GameObject[] _Trash;
    public GameObject[] _TrashLINE;

    public Dictionary<string, string> _TextDic;

    private void Start()
    {
        _TextDic = new Dictionary<string, string>();
        _TextDic.Add("One", "请走到物资摆放点，打开菜单栏点击警戒线摆放!");
        _TextDic.Add("Two", "请走到围观人员附近，打开菜单栏点击警戒线摆放!");
        _TextDic.Add("Three", "请走垃圾区附近，打开菜单栏点击警戒线摆放!");
    }

    public void _WuZiLine()
    {
        foreach (GameObject Item in _WuZiLINE)
        {
            Item.SetActive(true);
        }
    }
    public void _RenYuanLine()
    {
        foreach (GameObject Item in _RenYuanLINE)
        {
            Item.SetActive(true);
        }
    }
    public void _TrashLine()
    {
        foreach (GameObject Item in _TrashLINE)
        {
            Item.SetActive(true);
        }
    }

}
