using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: Shezhi.cs
  Author:zjw       Version :1.0          Date: 2017-8-31
  Description:右上角设置按钮实现
************************************************************/


public class Shezhi : MonoBehaviour {

    public GameObject voicePanel;
    public GameObject closePanel;
    public GameObject helpPanel;
    public Slider voice;
    private bool isClose = false;

	void Start ()
    {

	}
	
	void Update ()
    {
        GameObject[] au = GameObject.FindGameObjectsWithTag("audio");
        foreach (GameObject item in au)
        {
            if (item != null)
            {
                item.GetComponent<AudioSource>().volume = voice.value;
            }
            else
            {
                return;
            }
        }
	}

    public void VoicePanel()
    {
        if (voicePanel.activeSelf)
        {
            voicePanel.SetActive(false);
        }
        else
        {
            voicePanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (closePanel.activeSelf)
        {
            closePanel.SetActive(false);
        }
        else
        {
            closePanel.SetActive(true);
        }
    }

    public void HelpPanel()
    {
        helpPanel.transform.FindChild("GameObject").GetComponent<ButtonLight>().ButtonShake();
        if (helpPanel.activeSelf)
        {
            helpPanel.SetActive(false);
        }
        else
        {
            helpPanel.SetActive(true);
        }
    }

    public void Voice()
    {
        if (!isClose)
        {
            voice.value = 0;
            isClose = true;
        }
        else
        {
            voice.value = 1;
            isClose = false;
        }
    }

    public void Explain()
    {

    }

    public void Close()
    {
        SceneManager.LoadScene(0);
        Destroy(SystemManager.instance.gameObject, 1);
    }
}
