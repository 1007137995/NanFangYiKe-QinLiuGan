using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour 
{

    public GameObject Talk_Box;
    public SliderControl progressBar;

    public static Phone_State phone_state;
    public enum Phone_State
    {
        Off,
        On,
    }

    //响铃
    IEnumerator Bells()
    {
        yield return new WaitForSeconds(1f);
    }

    //
    void Use()
    {
        switch (phone_state)
        {
            case Phone_State.Off: Debug.Log("该物体未开启");
                break;
            case Phone_State.On:
                Talk_Box.GetComponent<TalkBox>().SetText("　　某县某乡卫生院发现1例疑似人感染高致病性禽流感的病人，请快速启动应急响应机制。");
                Talk_Box.SetActive(true);
                //StartProgressBar();
                //StepManager.willStep++;
                break;
        }
    }

    public void StartProgressBar()
    {
        StartCoroutine(progressBar.Run(3f, 0f));
        progressBar.SetText("正在通过电话联络卫生局");
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Use();
        }
    }

	void Start ()
    {
        phone_state = Phone_State.Off;
	}
	

	void Update ()
    {
	
	}
}
