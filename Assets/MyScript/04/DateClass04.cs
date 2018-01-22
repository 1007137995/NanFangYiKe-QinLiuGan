using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class DateClass04 : MonoBehaviour
{
    public Dictionary<string, string> _DescrideList;
    public Dictionary<string, string> _NameList;
    public Dictionary<string, Transform> TargetPos;
    public GameObject[] _One;
    public GameObject[] _Two;
    public GameObject[] _Three;
    public GameObject[] _Four;
    public GameObject[] _Five;
    public GameObject[] _Six;
    public GameObject[] _Seven;
    public Dictionary<string, GameObject[]> _ShowAndHide;

    public GameObject[] _ShowCollider;
    public Transform[] _Pos;

    public GameObject[] _PlayerSkin;
    void Start()
    {
        _DescrideList = new Dictionary<string, string>();
        _NameList = new Dictionary<string, string>();
        _ShowAndHide = new Dictionary<string, GameObject[]>();
        TargetPos = new Dictionary<string, Transform>();

        _NameList.Add("CLOTHUP", "防护服");
        _NameList.Add("CLOTHDOWN", "防护服裤子");
        _NameList.Add("GAUZEMASK", "防护服口罩");
        _NameList.Add("HAT", "帽子");
        _NameList.Add("SHOSE", "鞋子");
        _NameList.Add("GLASS", "眼镜");
        _NameList.Add("GLOVE", "手套");

        _DescrideList.Add("CLOTHUP", "先脱去防护帽部分；将袖子脱出后双手抓住防护服的内面防护服内面朝外轻轻卷至胶鞋的脚踝部");
        _DescrideList.Add("CLOTHDOWN", "先脱去防护帽部分；将袖子脱出后双手抓住防护服的内面防护服内面朝外轻轻卷至胶鞋的脚踝部");
        _DescrideList.Add("GAUZEMASK", "一只手手托住口罩，用另一只手将下方头带拉过头顶，继续用手托住口罩，再将上方头带从头顶取下（注意双手不接触面部），左手将口罩抓于掌心，放入医疗废物袋中。");
        _DescrideList.Add("HAT", "双手伸进帽子耳后双方的内侧边缘，将帽子轻轻摘下，里面朝外，放入医疗废物袋中。");
        _DescrideList.Add("SHOSE", "用防护服包裹胶鞋，防护服内面始终朝外，一起放入医疗废物袋中；");
        _DescrideList.Add("GLASS", "摘下防护镜，放入医疗废物袋中。");
        _DescrideList.Add("GLOVE", "一手捏住手套污染面的边缘将手套脱下。用脱下手套的手捏住另一只手套清洁(内面)的边缘，摘掉手套，将里面朝外，放入医疗废物袋中。");

        _ShowAndHide.Add("CLOTHUP", _One);
        _ShowAndHide.Add("CLOTHDOWN", _Two);
        _ShowAndHide.Add("GAUZEMASK", _Three);
        _ShowAndHide.Add("HAT", _Four);
        _ShowAndHide.Add("SHOSE", _Five);
        _ShowAndHide.Add("GLASS", _Six);
        _ShowAndHide.Add("GLOVE", _Seven);

        TargetPos.Add("CLOTHUP", _Pos[0]);
        TargetPos.Add("CLOTHDOWN", _Pos[1]);
        TargetPos.Add("GAUZEMASK", _Pos[2]);
        TargetPos.Add("HAT", _Pos[3]);
        TargetPos.Add("SHOSE", _Pos[4]);
        TargetPos.Add("GLASS", _Pos[5]);
        TargetPos.Add("GLOVE", _Pos[6]);

    }
    public void _Traverse()
    {
        foreach (GameObject Item in _ShowCollider)
        {
            Item.SetActive(true);
        }
    }
    public void _HideSkin()
    {
        foreach (GameObject Item in _PlayerSkin)
        {
            Item.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
    public void _HideCollider()
    {
        foreach (GameObject Item in _ShowCollider)
        {
            Item.SetActive(false);
        }
    }
}
