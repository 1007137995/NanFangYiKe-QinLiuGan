using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class liudiaoManager2 : MonoBehaviour {

    public GameObject person;
    List<string> strList = new List<string>();
    
	// Use this for initialization
	void Awake () {
        strList.Add("有点咳嗽和发烧，已经有好转了。");
        strList.Add("现代医学这么先进，禽流感已不是不可治愈的了，看到你们的努力，我一定会被治好的。");
        strList.Add("经过你们心理疏导，我也不再恐慌了，谢谢你。");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void overTalk() {
        this.gameObject.SetActive(false);
        person.SetActive(false);
    }

    private void OnEnable()
    {
        //int c = Random.Range(0, strList.Count);
        //this.transform.Find("talkText").GetComponent<Text>().text = strList[c];
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Player").name);
            if (GameObject.FindGameObjectWithTag("Player").name == "流调人员")
            {
                caiyanManager.instance.Tongyong.GetComponent<Question>().GetQuestion(7);
            }
            else if (GameObject.FindGameObjectWithTag("Player").name == "采样人员")
            {
                caiyanManager.instance.Tongyong.GetComponent<Question>().GetQuestion(10);
            }
        }
    }

    //public void Ans()
    //{
    //    if (GameObject.FindGameObjectWithTag("Player") != null)
    //    {
    //        if (GameObject.FindGameObjectWithTag("Player").name == "流调人员")
    //        {
    //            this.transform.Find("liudiaoBut").gameObject.SetActive(true);
    //            this.transform.Find("caiyangBut").gameObject.SetActive(false);
    //        }
    //        else if (GameObject.FindGameObjectWithTag("Player").name == "采样人员")
    //        {
    //            this.transform.Find("liudiaoBut").gameObject.SetActive(false);
    //            this.transform.Find("caiyangBut").gameObject.SetActive(true);
    //        }
    //    }
    //}

    public void Ans()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").name == "流调人员")
            {
                caiyanManager.instance.goLiuDiaoPanel();
            }
            else if (GameObject.FindGameObjectWithTag("Player").name == "采样人员")
            {
                caiyanManager.instance.goCaiyangAni();
            }
        }
        overTalk();
    }
}
