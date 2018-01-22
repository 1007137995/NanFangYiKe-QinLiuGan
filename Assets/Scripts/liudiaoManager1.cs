using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class liudiaoManager1 : MonoBehaviour {

    List<string> strList = new List<string>();
    
	// Use this for initialization
	void Awake () {
        strList.Add("你好，你们辛苦了。有你们在我们就不再害怕禽流感。");
        strList.Add("公众卫生意识和个人防护意识很重要，我相信患者一定会治好的。");
        strList.Add("你们来的好快，疫情很快就控制了，消毒的很彻底。");
        strList.Add("经过你们心理疏导，我也不再恐慌了，谢谢你。");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void overTalk() {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        int c = Random.Range(0, strList.Count);
        this.transform.Find("talkText").GetComponent<Text>().text = strList[c];
        //if (GameObject.FindGameObjectWithTag("Player").name == "流调人员")
        //{
        //    this.transform.Find("liudiaoBut").gameObject.SetActive(true);
        //}
        //else {
        //    this.transform.Find("liudiaoBut").gameObject.SetActive(false);
        //}
    }
}
