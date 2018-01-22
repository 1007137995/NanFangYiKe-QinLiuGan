using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShowWuZi : MonoBehaviour {

    public List<GameObject> showList;

    public static ShowWuZi instance;

    public GameObject introPanel;
    public Text showNameAndIntro;

    public string currentWuZi;

    //物品及物品介绍
    public Dictionary<string, string> introDic = new Dictionary<string, string>();

    // Use this for initialization
    void Start () {
        instance = this;
        introDic.Add("纸张","通常记录信息的纸张。");
        introDic.Add("胎素笔", "填写表格所需要的笔。");
        introDic.Add("采样拭子", "进行咽拭子所使用的工具。");
        introDic.Add("84消毒液", "杀菌使用的消毒液。");
        introDic.Add("漂白粉", "净化水源，具有消毒功效。");
        introDic.Add("止血带", "勒住血管止血。");
        introDic.Add("小喷壶", "小空间使用的消毒工具。");
        introDic.Add("医疗废物包装袋", "放置医疗废物的包装袋。");
        introDic.Add("应急包", "放物资的拎包。");
        introDic.Add("急救箱", "放急救医疗物品的箱子。");
        introDic.Add("采样箱", "放采样所用的箱子。");
        introDic.Add("警戒牌", "具有警示的牌子。");
        introDic.Add("防护服", "医用防护服的衣服，保护医务人员。");
        introDic.Add("防护靴", "医用防护服的鞋子，保护医务人员。");
        introDic.Add("防护口罩", "医用防护服的口罩，保护医务人员。");
        introDic.Add("防护帽", "医用防护服的帽子，保护医务人员。");
        introDic.Add("防护手套", "医用防护服的外层手套，保护医务人员。");
        introDic.Add("防护镜", "医用防护服的眼镜，保护医务人员。");
        introDic.Add("警戒线", "用于圈定范围，防止人员走动。");
        introDic.Add("消毒记录表", "消毒后记录统计的表格。");
        introDic.Add("观察登记表", "流行病学调查表。");
        introDic.Add("病例调查表", "密切接触者观察登记表。");
        introDic.Add("医用纱布", "用于包包裹试管的纱布。");
        introDic.Add("医用棉签", "用于蘸取溶液涂抹的棉签。");
        introDic.Add("医用棉花", "棉花。");
        introDic.Add("宣传单", "宣传禽流感预防知识的宣传单。");
        introDic.Add("身份牌", "CDC工作人员的标识身份牌。");
        introDic.Add("消杀溶液", "配置好的消毒杀菌溶液。");
        introDic.Add("乳胶手套", "医用防护服的内层手套，保护医务人员。");
        introDic.Add("塑封袋", "保护纸质文件的袋子。");
        introDic.Add("酒精瓶", "内装有75%浓度的医用酒精。");
        introDic.Add("电子体温计", "扫描额头测量体温。");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //显示物体，及相关介绍
    public void showGo(string goName) {
        currentWuZi = goName;
        foreach (GameObject go in showList) {
            if (go.name == goName) {
                hideAllObj();
                go.SetActive(true);
                string content = "";
                introDic.TryGetValue(goName, out content);
                showNameAndIntro.text = "物资名称：" + goName + "\n详细介绍："+ content;
                introPanel.SetActive(true);
                wuziManager.instance.peopleText.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void hideAllObj() {
        foreach (GameObject go in showList)
        {
            go.SetActive(false);
            introPanel.SetActive(false);
            wuziManager.instance.peopleText.gameObject.SetActive(true);
        }
    }

    public void AddWuZi() {
        UIFirst.instance.addItem(currentWuZi);
        hideAllObj();
    }

}
