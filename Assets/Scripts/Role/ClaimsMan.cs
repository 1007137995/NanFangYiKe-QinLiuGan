using UnityEngine;
using System.Collections;

public class ClaimsMan : MonoBehaviour 
{

    public static int task = 0;

    public GameObject sceneBtn;

    public GameObject[] searchBtn;

    int id;

    public void SearchEnd(GameObject g)
    {
        if (g.tag != "End")
        {
            task++;
            g.tag = "End";
        }
    }

    //幕变化
    public void NextScene(int i)
    {
        id = i;
        OutLocalScene();
        Invoke("InLocalScene", 2f);
    }

    //退出当前一幕
    public void OutLocalScene()
    {
        Manager.instance.b.OutPicture();
        Invoke("NextSceneSet", 1f);
        Invoke("InLocalScene", 2f);
    }

    void NextSceneSet()//转换下一幕时候状态设置
    {
        switch (id)
        {
            case 1: this.transform.position = new Vector3(-851.55f, 12f, 162.08f);
                this.transform.GetChild(0).localPosition = new Vector3(0, -1.371f, 0);
                break;
            case 2: this.transform.position = new Vector3(-884.28f, 12f, 67.49f);
                this.transform.GetChild(0).localPosition = new Vector3(0, -1.371f, 0);
                break;
            case 3: this.transform.position = new Vector3(-943, 12f, 139.466f);
                this.transform.GetChild(0).localPosition = new Vector3(0, -1.371f, 0);
                break;
            case 4: this.transform.position = new Vector3(-890.54f, 12f, 158.89f);
                this.transform.GetChild(0).localPosition = new Vector3(0, -1.371f, 0);
                break;
        }
    }

    //进入下一幕
    void InLocalScene()
    {
        Manager.instance.b.InPicture();
        for (int i = 0; i < searchBtn.Length; i++)
        {
            searchBtn[i].SetActive(false);
        }
    }

	void Start () 
    {
	
	}

	void Update ()
    {
        if (task == 4)
        {
            sceneBtn.SetActive(true);
        }
	}
}
