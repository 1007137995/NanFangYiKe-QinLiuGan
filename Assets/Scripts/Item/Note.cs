using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Note : MonoBehaviour 
{

    public GameObject UINote;
    public SliderControl progressBar;

    public Text show;
    public Button confirmBtn;

    int count;
    Toggle[] toggles;
    int[] choose;
    int[] answer;

    public static Note_State note_state;
    public enum Note_State
    {
        Off,
        On,
    }

    public void Use()
    {
        switch (note_state)
        {
            case Note_State.Off: Debug.Log("该物体未开启");
                break;
            case Note_State.On:
                UINote.gameObject.SetActive(true);
                break;
        }
    }

    bool CheckChoose()
    {
        for (int i = 0; i < count; i++)
        {
            if (toggles[i].isOn)
            {
                choose[i] = 1;
            }
            else choose[i] = 0;
        }
        for (int i = 0; i < count; i++)
        {
            if (choose[i] != answer[i])
            {
                return false;
            }
        }
        return true;
    }

    public void Confirm()
    {
        if (CheckChoose())
        {
            //show.text = "开始联络联系人";
            StartCoroutine(show.GetComponent<TextControl>().Show());
            StartCoroutine(progressBar.Run(2f, 0f));
            progressBar.SetText("开始联络联系人");
            UINote.SetActive(false);
            StepManager.willStep++;
        }
        else
        {
            
            show.text = "选择错误，请重新选择";
            StartCoroutine(show.GetComponent<TextControl>().Show());
            Reset();
        } 
    }

    void Reset()
    {
        for (int i = 0; i < count; i++)
        {
            toggles[i].isOn = false;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Use();
        }
    }

    void Awake()
    {
        count = UINote.transform.GetChild(1).childCount;
        choose = new int[count];
        answer = new int[] { 0, 1, 0, 1, 1, 0 };
        toggles = new Toggle[count];
        for (int i = 0; i < count; i++)
        {
            toggles[i] = UINote.transform.GetChild(1).GetChild(i).GetChild(2).GetComponent<Toggle>();
        }
        confirmBtn = UINote.transform.GetChild(3).GetComponent<Button>();
    }

	void Start ()
    {
        note_state = Note_State.Off;
	}
	
	void Update () 
    {
        if (show.GetComponent<TextControl>().text_state == TextControl.Text_State.Normal)
        {
            confirmBtn.interactable = true;
        }
        else
        {
            confirmBtn.interactable = false;
        }
	}
}
