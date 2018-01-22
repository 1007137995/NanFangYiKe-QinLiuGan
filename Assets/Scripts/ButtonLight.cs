using UnityEngine;
using System.Collections;
using DG.Tweening;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ButtonLight.cs
  Author:zjw       Version :1.0          Date: 2017-8-31
  Description:按钮高亮
************************************************************/


public class ButtonLight : MonoBehaviour {

    void Start()
    {
	
	}

    void Update()
    {
        
    }
	
    public void ButtonShine()
    {
        transform.FindChild("Image").DOScale(1f, 0.1f);
        transform.FindChild("Image").gameObject.SetActive(true);
    }

    public void Close()
    {
        transform.FindChild("Image").DOScale(1f, 0.1f);
        transform.FindChild("Image").gameObject.SetActive(false);
    }

    public void ButtonShake()
    {
        Sequence seq = DOTween.Sequence();
        transform.FindChild("Image").gameObject.SetActive(true);
        Tween t1 = transform.FindChild("Image").DOScale(1.1f, 0.3f);
        Tween t2 = transform.FindChild("Image").DOScale(1f, 0.3f);
        seq.Append(t1);
        seq.Append(t2);
        seq.SetLoops(-1);
    }
}
