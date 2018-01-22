using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour {
	
	public static TaskPanel instance;
	public List<GameObject> items = new List<GameObject>();
	public List<Sprite> tus = new List<Sprite>();
	
	public GameObject content;//内容
	public Vector2 contentSize;//内容的原始高度
	
	public GameObject item;//列表项
	public float itemWidth;
	public Vector3 itemLocalPos;

	public GameObject textListPanel;
	
	void Awake()
	{
		if (!instance)
			instance = this;
		else
			Destroy(this);
	}

	void Update(){
		if(Input.GetMouseButton(0)){
			Ray _ray=Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机发出一条射线,到点击的坐标

			RaycastHit objhit;

			if (Physics.Raycast (_ray, out objhit, 100)) {
				GameObject go = getmaxParent(objhit.collider.gameObject);
				if(go.tag == "sf"){
					
					CurrentGo = go;
					clearAll ();
					showTextrueList ();
					for(int i = 0;i<go.transform.childCount;i++){
						Sprite tempType = new Sprite();
						tempType = Resources.Load("kcTextrue/"+go.transform.GetChild (i).name,tempType.GetType()) as Sprite;
						print (tempType.name);
						AddItem (tempType);
					}
				}

			}
		}
	
	}

	public GameObject CurrentGo;
	public GameObject getmaxParent(GameObject go){
		while(go.transform.parent != null){
			go = go.transform.parent.gameObject;
		}
		return go;
	}

	public void hideAll(string name){
		for(int i =0;i<CurrentGo.transform.childCount;i++){
			if (CurrentGo.transform.GetChild (i).name == name) {
				CurrentGo.transform.GetChild (i).gameObject.SetActive (true);
			} else {
				CurrentGo.transform.GetChild (i).gameObject.SetActive (false);
			}
		}
	}

	
	void Start()
	{
//		content = GameObject.Find("Content");
		contentSize = content.GetComponent<RectTransform>().sizeDelta;
		
		item = Resources.Load("Item") as GameObject;
		itemWidth = item.GetComponent<RectTransform>().rect.height;
		itemLocalPos = item.transform.localPosition;
	}

//	public void showList(){
//		Object[] furs = Resources.LoadAll ("kcTextrue",typeof(Sprite));
//		for(int i = 0;i<furs.Length;i++){
//			AddItem((Sprite)furs[i]);
//		}
//	}

	public void showTextrueList(){
		textListPanel.SetActive (true);
	}

	public void hideTextrueList(){
		textListPanel.SetActive (false);
	}

	public void clearAll(){
		foreach(GameObject item in items){
			Destroy (item);
		}
		items.Clear ();
		content.GetComponent<RectTransform>().sizeDelta = contentSize;
	}
	
	//添加列表项
	public void AddItem(Sprite go)
	{
		GameObject a = Instantiate(item) as GameObject;
		a.transform.parent = content.transform;
//		a.transform.localPosition = new Vector3(itemLocalPos.x + items.Count * itemWidth, itemLocalPos.y , 0);
		a.transform.localPosition = new Vector3(itemLocalPos.x , itemLocalPos.y- items.Count * itemWidth , 0);
		items.Add(a);
	    a.transform.FindChild ("tu").GetComponent<Image>().overrideSprite = go;
		Button btn = a.transform.FindChild ("tu").GetComponent<Button>();
		btn.onClick.AddListener(delegate() {
			this.chooceModel(go.name); 
		});
		if (contentSize.y <= items.Count * itemWidth)//增加内容的高度
		{
//			content.GetComponent<RectTransform>().sizeDelta = new Vector2(items.Count * itemWidth,contentSize.y );
			content.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x,items.Count * itemWidth );
		}
	}

	public void chooceModel(string name){
		hideAll (name);
	}
	
	//移除列表项
	public void RemoveItem(GameObject t)
	{
		int index = items.IndexOf(t);
		items.Remove(t);
		Destroy(t);
		
		for (int i = index; i < items.Count; i++)//移除的列表项后的每一项都向前移动
		{
			items[i].transform.localPosition -= new Vector3(0, itemWidth, 0);
		}
		
		if (contentSize.y <= items.Count * itemWidth)//调整内容的高度
			content.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x,items.Count * itemWidth );
		else
			content.GetComponent<RectTransform>().sizeDelta = contentSize;
	}
}