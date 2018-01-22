using UnityEngine;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: s.cs
  Author:zjw       Version :1.0          Date: 2016-1-1
  Description:倒置显微镜使用控制脚本
************************************************************/


public class s : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<Animator>().Play("Speak");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
