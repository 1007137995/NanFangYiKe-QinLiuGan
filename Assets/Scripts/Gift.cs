using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: Gift.cs
  Author:zjw       Version :1.0          Date: 2017-11-2
  Description:格子脚本
************************************************************/


public class Gift : MonoBehaviour {

    public GameObject Item;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Screen.fullScreen)
        {
            Item.transform.FindChild("bg").GetComponent<RectTransform>().sizeDelta = new Vector2(117.6f,117.6f);
            Item.transform.FindChild("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(101.9f, 101.9f);
            Item.transform.FindChild("Image/close").GetComponent<RectTransform>().sizeDelta = new Vector2(19.6f, 19.6f);
        }
        else
        {
            Item.transform.FindChild("bg").GetComponent<RectTransform>().sizeDelta = new Vector2(60f, 60f);
            Item.transform.FindChild("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(52f, 52f);
            Item.transform.FindChild("Image/close").GetComponent<RectTransform>().sizeDelta = new Vector2(10f, 10f);
        }
    }
}
