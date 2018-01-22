using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: TT.cs
  Author:zjw       Version :1.0          Date: 2016-1-1
  Description:倒置显微镜使用控制脚本
************************************************************/


public class Tt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.fullScreen)
        {
            transform.GetComponent<Text>().text = "full" + Input.mousePosition;
        }
        else
        {
            transform.GetComponent<Text>().text = Input.mousePosition.ToString();
        }
	}
}
