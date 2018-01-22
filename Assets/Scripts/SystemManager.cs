using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour {

    //public bool isYL = true;
    public static SystemManager instance;
    //public GameObject choocePanel;

    public List<wrongInfo> wrongList = new List<wrongInfo>();

    // Use this for initialization
    void Start () {
        instance = this;
        PlayerPrefs.SetInt("moshi", 1);
    }
	
	// Update is called once per frame
	void Update () {

    }

    ////演练模式
    //public void goYL() {
    //    //isYL = true;
    //    PlayerPrefs.SetInt("moshi", 1);
    //    choocePanel.SetActive(false);
    //    //transform.FindChild("head").gameObject.SetActive(true);
    //}

    ////考核模式
    //public void goKH() {
    //    //isYL = false;
    //    PlayerPrefs.SetInt("moshi", 0);
    //    choocePanel.SetActive(false);
    //    //transform.FindChild("head").gameObject.SetActive(true);
    //}

    public void recordWrong(wrongInfo wif) {
        wrongList.Add(wif);
    }

    public void ChangeScene(bool c)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "DianHuaShi":
                if (c)
                {
                    SceneManager.LoadSceneAsync("WuZhiShi");
                }
                else
                {
                    //SceneManager.LoadSceneAsync("");
                }
                break;
            case "GenYiShi":
                if (c)
                {
                    SceneManager.LoadScene("CDCBuild");
                }
                else
                {
                    SceneManager.LoadSceneAsync("WuZhiShi");
                }
                break;
            case "NongJiaYuan":
                if (c)
                {
                    SceneManager.LoadSceneAsync("tuoyifu");
                }
                else
                {
                    SceneManager.LoadScene("CDCBuild");
                }
                break;
            case "tuoyifu":
                if (c)
                {
                    //SceneManager.LoadSceneAsync("");
                }
                else
                {
                    SceneManager.LoadScene("CDCBuild");
                }
                break;
            case "WuZhiShi":
                if (c)
                {
                    SceneManager.LoadSceneAsync("GenYiShi");
                }
                else
                {
                    SceneManager.LoadSceneAsync("DianHuaShi");
                }
                break;
            case "GeLiJian":
                if (c)
                {
                    SceneManager.LoadSceneAsync("tuoyifu");
                }
                else
                {
                    SceneManager.LoadScene("CDCBuild");
                }
                break;
            default:
                break;
        }
    }
}

public class wrongInfo
{
    public int Num;
    public bool result;
    public string des;
    public int score;

    public wrongInfo() { }

    public wrongInfo(int Num, string des, bool result)
    {
        this.Num = Num;
        this.des = des;
        this.result = result;
    }

    public wrongInfo(int Num, string des, int score)
    {
        this.Num = Num;
        this.des = des;
        this.score = score;
    }
}
