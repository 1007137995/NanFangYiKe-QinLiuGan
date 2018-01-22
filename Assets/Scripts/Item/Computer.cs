using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Computer : MonoBehaviour 
{
    public GameObject UIComputer;
    public SliderControl progressBar;

    public GameObject table1;
    public GameObject table2;

    public static Computer_State computer_state;
    public enum Computer_State
    {
        Off,
        OnOne,            
        OnTwo,
    }

    public void Use()
    {
        switch (computer_state)
        {
            case Computer_State.Off: Debug.Log("该物体未开启");
                break;
            case Computer_State.OnOne: 
                table1.SetActive(true);
                table2.SetActive(false);
                break;
            case Computer_State.OnTwo: 
                table1.SetActive(false);
                table2.SetActive(true);
                break;
        }
    }

    public void Confirm()
    {
        switch (computer_state)
        {
            case Computer_State.OnOne:
                StartCoroutine(progressBar.Run(3f, 0f));
                progressBar.SetText("正在确认物资");
                break;
            case Computer_State.OnTwo:
                StartCoroutine(progressBar.Run(3f, 0f));
                progressBar.SetText("正在发送疫情报告和通报");
                break;
        }
        table1.SetActive(false);
        table2.SetActive(false);
        StepManager.willStep++;
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

    }

	void Start () 
    {
        computer_state = Computer_State.Off;
	}
	
	void Update () 
    {
	
	}
}
