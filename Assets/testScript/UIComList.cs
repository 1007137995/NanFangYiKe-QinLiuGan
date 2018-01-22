using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIComList : MonoBehaviour {

	public ScrollRect m_scrollRect;
	public GridLayoutGroup m_itemParent;
	public GameObject m_item;
	public Transform m_itemFocus;

	void Start(){
		m_item.SetActive(false);
        UnInit();
    }

	public void Init(){
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("showPic"))
        {
            Destroy(obj);
        }
        UnInit();
    }

	public Transform CreateItem(string index){
		Transform item = ((GameObject)GameObject.Instantiate(m_item)).transform;
		item.SetParent(m_itemParent.transform);
		item.name = index;
		item.gameObject.SetActive(true);
		return item;
	}

	public void UnInit(){
		StartCoroutine(UpdateListHeight());
	}

	IEnumerator UpdateListHeight(){
		yield return new WaitForEndOfFrame();
		m_itemParent.GetComponent<RectTransform>().sizeDelta =
			new Vector2(0,m_itemParent.minHeight);
	}
}
