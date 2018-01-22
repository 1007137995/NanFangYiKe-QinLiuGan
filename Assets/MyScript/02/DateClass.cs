using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class DateClass : MonoBehaviour
{
    public Dictionary<string, string> _IntroduceList;

    public Transform[] _Clothes;

    public GameObject[] _ManClothObj;

    public Dictionary<string, Transform> _AllClothes;

    public Dictionary<string, GameObject> _ManofCloths;

    public GameObject[] _ShowCollider;

    public Dictionary<string, string> _Describe;
    private void Start()
    {
        _IntroduceList = new Dictionary<string, string>();

        _AllClothes = new Dictionary<string, Transform>();

        _ManofCloths = new Dictionary<string, GameObject>();

        _Describe = new Dictionary<string, string>();

        _IntroduceList.Add("ClothUp", "防护服上衣");
        _IntroduceList.Add("ClothDown", "防护服裤子");
        _IntroduceList.Add("Hat", "防护服帽子");
        _IntroduceList.Add("GauzeMask", "口罩");
        _IntroduceList.Add("Shose", "鞋子");
        _IntroduceList.Add("Glass", "眼睛");
        _IntroduceList.Add("Glove", "手套");

        _AllClothes.Add("GauzeMask", _Clothes[0]);
        _AllClothes.Add("ClothDown", _Clothes[1]);
        _AllClothes.Add("Hat", _Clothes[2]);
        _AllClothes.Add("ClothUp", _Clothes[3]);
        _AllClothes.Add("Shose", _Clothes[4]);
        _AllClothes.Add("Glass", _Clothes[5]);
        _AllClothes.Add("Glove", _Clothes[6]);


        _ManofCloths.Add("GAUZEMASK", _ManClothObj[0]);
        _ManofCloths.Add("CLOTHDOWN", _ManClothObj[1]);
        _ManofCloths.Add("HAT", _ManClothObj[2]);
        _ManofCloths.Add("CLOTHUP", _ManClothObj[3]);
        _ManofCloths.Add("SHOSE", _ManClothObj[4]);
        _ManofCloths.Add("GLASS", _ManClothObj[5]);
        _ManofCloths.Add("GLOVE", _ManClothObj[6]);

        _Describe.Add("ClothUp", "打开防护衣后，将拉链拉至合适位置。左右手握住左右袖口的同时，抓住防护服腰部的拉链开口处。先穿下肢，后穿上肢，然后将拉链拉至胸部，再将防护帽扣至头部，将拉链完全拉上后，密封拉链口");
        _Describe.Add("ClothDown", "打开防护衣后，将拉链拉至合适位置。左右手握住左右袖口的同时，抓住防护服腰部的拉链开口处。先穿下肢，后穿上肢，然后将拉链拉至胸部，再将防护帽扣至头部，将拉链完全拉上后，密封拉链口");
        _Describe.Add("Hat", "将脑后的长发完成发髻，刘海向上梳理；将帽子由额前向脑后罩于头部，不让头发外漏");
        _Describe.Add("GauzeMask", "一只手托住防护口罩，有鼻夹的一面向外；将防护口罩罩住鼻、口及下巴，鼻夹部位向上紧贴面部;用另一只手将上方头带拉至头顶；再将下方头带拉过头顶，放在颈后双耳下；将双手指尖放在金属鼻夹上，从中间位置开始，用手指向内按鼻夹，并分别向两侧移动和按压，根据鼻梁的形状塑造鼻夹;进行密合性检查。检查方法为：将双手完全盖住防护口罩，快速地呼气，若鼻夹附近有漏气应按佩戴方法步骤调整鼻夹，若漏气位于四周，应调整到不漏气为止");
        _Describe.Add("Shose", "检查有无破损，将防护服裤脚罩于胶鞋里面。");
        _Describe.Add("Glass", "佩戴前，应检查其是否破损，佩戴装置是否松懈。");
        _Describe.Add("Glove", "将防护服袖口稍拉向手掌部并固定，将手套套在防护服袖口外面。");
    }

    public void _Traverse()
    {
        foreach (GameObject Item in _ShowCollider)
        {
            Item.tag = "Pos";
            Item.SetActive(true);
        }
    }
    public void _CloseTraverse()
    {
        foreach (GameObject Item in _ShowCollider)
        {
            Item.tag = "Untagged";
            Item.SetActive(false);
        }
    }
}
