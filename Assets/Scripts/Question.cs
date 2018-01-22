using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Question : MonoBehaviour {

    public Button next;
    public Text que;
    public ToggleGroup tg;
    public List<Toggle> toggle = new List<Toggle>();
    private QAQData.Que qaq;
    private string chooce = "";
    private wrongInfo wif;
    private int QN = 0;
    private bool isright = true;

    void Start () {
        transform.FindChild("QTishi").FindChild("Button").GetComponent<Button>().onClick = next.onClick;
        transform.FindChild("QTishi").FindChild("Button").GetComponent<Button>().onClick.AddListener(delegate
        {
            Submit();
        });
    }
	
	void Update () {
	
	}

    public void GetQuestion(int index)
    {
        Time.timeScale = 0;
        QN = index;
        Tongyong.instance._qtBtn.GetComponent<ButtonLight>().ButtonShine();
        transform.FindChild("Choose").gameObject.SetActive(true);
        qaq = QAQData.instance.QAQ[index];
        que.text = qaq.que.ToString();
        for (int i = 0; i < qaq.q.Count; i++)
        {
            toggle[i].transform.FindChild("Label").GetComponent<Text>().text = qaq.q[i];
        }
    }

    public void Check()
    {
        chooce = "";
        foreach (Toggle go in toggle)
        {
            if (go.isOn == true)
            {
                chooce += go.name;
            }
        }
        Debug.Log(chooce);
        if (chooce.CompareTo(qaq.ans) == 0)
        {
            isright = true;
            wif = new wrongInfo(3, qaq.que, true);            
        }
        else
        {
            isright = false;
            wif = new wrongInfo(3, qaq.que, false);
        }
    }

    public void Next()
    {
        //Debug.Log(PlayerPrefs.GetInt("moshi"));
        transform.FindChild("Choose").gameObject.SetActive(false);
        transform.FindChild("QTishi").gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("moshi") == 1)
        {
            if (isright)
            {
                transform.FindChild("QTishi").FindChild("Text").GetComponent<Text>().text = "恭喜你答对了！";
            }
            else
            {
                transform.FindChild("QTishi").FindChild("Text").GetComponent<Text>().text = "你答错了！答案是：" + qaq.ans;
            }
            if (qaq.shuoming != "")
            {
                transform.FindChild("Shuoming").gameObject.SetActive(true);
                transform.FindChild("Shuoming").FindChild("Text").GetComponent<Text>().text = qaq.shuoming;
            }  
        }
        else
        {     
            transform.FindChild("QTishi").FindChild("Text").GetComponent<Text>().text = "确认提交？";
            transform.FindChild("QTishi").FindChild("Return").gameObject.SetActive(true);
        }
    }

    public void Return()
    {
        transform.FindChild("QTishi").gameObject.SetActive(false);
        transform.FindChild("Choose").gameObject.SetActive(true);
        foreach (Toggle go in toggle)
        {
            go.isOn = false;
        }
    }

    public void Submit()
    {
        transform.FindChild("QTishi").gameObject.SetActive(false);
        transform.FindChild("Shuoming").gameObject.SetActive(false);
        Tongyong.instance._qtBtn.GetComponent<ButtonLight>().Close();
        SystemManager.instance.recordWrong(wif);
        foreach (Toggle go in toggle)
        {
            go.isOn = false;
        }
        Time.timeScale = 1;
    }
}
