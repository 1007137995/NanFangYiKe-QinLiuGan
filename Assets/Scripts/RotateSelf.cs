using UnityEngine;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: RotateSelf.cs
  Author:zjw       Version :1.0          Date: 2017-9-25
  Description:自动旋转
************************************************************/


public class RotateSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0));
	}
}
