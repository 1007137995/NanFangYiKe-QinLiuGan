using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: Content.cs
  Author:zjw       Version :1.0          Date: 2016-1-1
  Description:分数显示脚本
************************************************************/


public class Content : MonoBehaviour {

    public GameObject Item;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.fullScreen)
        {
            Item.transform.FindChild("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(1136.8f, 78.4f);
            Item.transform.FindChild("Image/TiMu").GetComponent<RectTransform>().sizeDelta = new Vector2(1724.8f, 117.6f);
            Item.transform.FindChild("Image/FenShu").GetComponent<RectTransform>().sizeDelta = new Vector2(392f, 117.6f);
            Item.transform.FindChild("Image/TiMu").GetComponent<Text>().fontSize = 62;
            Item.transform.FindChild("Image/FenShu").GetComponent<Text>().fontSize = 62;
        }
        else
        {
            Item.transform.FindChild("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(580f, 40f);
            Item.transform.FindChild("Image/TiMu").GetComponent<RectTransform>().sizeDelta = new Vector2(880f, 60f);
            Item.transform.FindChild("Image/FenShu").GetComponent<RectTransform>().sizeDelta = new Vector2(200f, 60f);
            Item.transform.FindChild("Image/TiMu").GetComponent<Text>().fontSize = 32;
            Item.transform.FindChild("Image/FenShu").GetComponent<Text>().fontSize = 32;
        }
    }
}
