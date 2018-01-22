using UnityEngine;
using System.Collections;

public class Notification : MonoBehaviour {

	public static Notification instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PrintInfo(string str){
		print (str);
	}

	//Notification.instance.PrintInfo("奖励已获取，或者任务被取消！！")
}
