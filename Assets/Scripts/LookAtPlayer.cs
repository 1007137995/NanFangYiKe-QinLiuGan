using UnityEngine;
using System.Collections;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: LookAtPlayer.cs
  Author:zjw       Version :1.0          Date: 2016-1-1
  Description:看向人脚本
************************************************************/

public class LookAtPlayer : MonoBehaviour
{

    public bool isCurrentPerson = false;
    public bool isOverTalk = false;

    private Animator ar;

    // Use this for initialization
    void Start()
    {
        ar = this.GetComponent<Animator>();
        ar.SetFloat("LR", 0f);
        ar.SetFloat("UD", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //开始对话时触发转头动画
        if (isCurrentPerson)
        {
            LookAtPerson();
            isCurrentPerson = false;
        }
        //对话结束恢复正常
        if (isOverTalk)
        {
            LookAtFront();
            isOverTalk = false;
        }
    }

    private void LookAtPerson()
    {
        Vector3 sourcePos = this.transform.Find("Eye").position;
        Vector3 targetPos = GameObject.FindGameObjectWithTag("playerEye").transform.position;
        Vector3 c = targetPos - sourcePos;

        Vector3 sourceFront = this.transform.forward;
        c.Normalize();
        c = this.transform.Find("Eye").worldToLocalMatrix * c;
        float thedaY = Mathf.Asin(c.y);
        Vector3 baseAngle = new Vector3(c.x, 0, c.z);
        Vector3 baseAngle2 = new Vector3(0, c.y, c.z);

        thedaY *= Mathf.Rad2Deg;

        float angle = Vector3.Angle(Vector3.forward, baseAngle);
        float angle2 = Vector3.Angle(Vector3.forward, baseAngle2);
        //		Debug.Log ("Angle:" + angle);
        //		Debug.Log ("c.x:" + c.x+"||c.z"+c.z);
        //		Debug.Log ("Angle2:" + angle2);

        if (c.x < 0f)
        {
            ar.SetFloat("LR", 1f * angle / 90f);
        }
        else
        {
            ar.SetFloat("LR", -1f * angle / 90f);
        }

        ar.SetFloat("UD", thedaY / 60f);

    }

    private void LookAtFront()
    {
        ar.SetFloat("LR", 0f);
        ar.SetFloat("UD", 0f);
    }
}