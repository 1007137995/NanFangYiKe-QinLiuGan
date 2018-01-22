using UnityEngine;
using System.Collections;

public class SendEndReport : MonoBehaviour {

    public SliderControl progressBar;
    public GameObject table;

    public GameObject btn;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            table.SetActive(true);
        }
    }
    public void Confirm()
    {
        StartCoroutine(progressBar.Run(3f, 0f));
        progressBar.SetText("正在发送疫情报告和通报");
        table.SetActive(false);
        Invoke("SceneEnd", 3f);
    }

    public void SceneEnd()
    {
        btn.SetActive(true);
    }


	void Start () 
    {
	
	}
	

	void Update () {
	
	}
}
