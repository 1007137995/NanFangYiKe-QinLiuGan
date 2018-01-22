using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIFirst : MonoBehaviour {

    public static UIFirst instance;
	public UIComList m_list;

	public void InitList(){
		m_list.Init();
	}

    //添加单个图片
	public GameObject UpdateList(Sprite sprite){
		Transform item = m_list.CreateItem(sprite.name);
		item.transform.Find("Image").GetComponent<Image>().sprite = sprite;
        item.tag = "showPic";

        return item.gameObject;
	}

	public void UnInitList(){
		m_list.UnInit();
	}

	public Dictionary<string,string> rzDic = new Dictionary<string,string>();

	void Awake(){
        instance = this;
        //InitList();

        //Object[] furs = Resources.LoadAll ("ziwuPic", typeof(Sprite));
        //for(int i = 0;i<furs.Length;i++){
        //	GameObject item = UpdateList((Sprite)furs[i]);
        //	Button btn = item.GetComponent<Button>();
        //	btn.onClick.AddListener(delegate() {
        //		this.OnClickBtn(item); 
        //	});
        //}
        //UnInitList();
    }

    //添加列表,展示当前角色已选物资 
	public void showItem(){
		InitList();
        Object[] furs = Resources.LoadAll (path, typeof(Sprite));
		for(int i = 0;i<furs.Length;i++){
            foreach (string wzName in wuziManager.instance.getCurrentRoleList()) {
                if (wzName == ((Sprite)furs[i]).name) {
                    GameObject item = UpdateList((Sprite)furs[i]);
                    Button btn = item.GetComponent<Button>();
                    btn.onClick.AddListener(delegate () {
                        this.OnClickBtn(item);
                    });
                    Button delbut = item.transform.Find("Image/close").GetComponent<Button>();
                    delbut.onClick.AddListener(delegate ()
                    {
                        this.OnCloseBtn(item);
                    });
                }
            }
		}
		UnInitList();
	}

    string path = "ziwuPic";
    //添加列表,添加到当前角色list内
    public void addItem(string wzName) {
        if (wuziManager.instance.getCurrentRoleList().Contains(wzName)) {
            return ;
        }
        wuziManager.instance.getCurrentRoleList().Add(wzName);
        GameObject item = null;
        Object[] furs = Resources.LoadAll(path, typeof(Sprite));
        for (int i = 0; i < furs.Length; i++)
        {
            if (wzName == ((Sprite)furs[i]).name)
            {
                item = UpdateList((Sprite)furs[i]);
                Button btn = item.GetComponent<Button>();
                btn.onClick.AddListener(delegate () {
                    this.OnClickBtn(item);
                });
                Button delbut = item.transform.Find("Image/close").GetComponent<Button>();
                delbut.onClick.AddListener(delegate ()
                {
                    this.OnCloseBtn(item);
                });
            }
        }
        UnInitList();
    }

	public void loadfile(string fileName){
//		foreach(KeyValuePair<string,string> kv in rzDic){
//			kv.Key = "mc";
//			kv.Value = "load";
//		}
	}

	public void manager(string name){
		//loadfolder ("ziwuPic/" + name);
	}

    //委托事件
	private void OnClickBtn(GameObject go){
        ShowWuZi.instance.showGo(go.name);
    }

    //委托事件
    private void OnCloseBtn(GameObject go)
    {
        Destroy(go);
        wuziManager.instance.getCurrentRoleList().Remove(go.name);
        UnInitList();
       
    }

}
