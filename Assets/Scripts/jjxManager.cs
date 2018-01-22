using UnityEngine;
using System.Collections;

public class jjxManager : MonoBehaviour {

    public Vector3 initPos = Vector3.one * 100f;
    public GameObject[] gjList;
    public static jjxManager instance;
    public GameObject BO;
    public GameObject BT;

    // Use this for initialization
    void Start() {
        instance = this;
        if (PlayerPrefs.GetInt("moshi") == 0)
        {
            BO.SetActive(true);
            BT.SetActive(true);
        }
        else
        {
            BO.SetActive(false);
            BT.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {

    }


    /// <summary>
    /// 消毒记录表部分
    /// </summary>
    public void closeXdRecord() {
        xdRecardPanel.SetActive(false);
        //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().Close();
    }


    public void autoWrite() {
        writeText.SetActive(true);
    }

    public void hideAutoWriteBut()
    {
        writeBut.SetActive(false);
        xdManager.instance.ButtonOk();
    }

    public void showAutoWriteBut() {
        writeBut.SetActive(true);
    }


    /// <summary>
    /// 流行病学部分
    /// </summary>
    public void closeLiuDiaoRecord()
    {
        miqieguanchaPanel.SetActive(false);
        //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().Close();
    }

    public void showLiuDiao()
    {
        LiuDiaoshowAutoWriteBut();
        miqieguanchaPanel.SetActive(true);
        //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().ButtonShine();
    }


    public void LiuDiaoAutoWrite()
    {
        miqieAllText.SetActive(true);
        LiuDiaohideAutoWriteBut();
    }

    public void LiuDiaohideAutoWriteBut()
    {
        miqieWriteBut.SetActive(false);

        xdManager.instance.ButtonOk();
    }

    public void LiuDiaoshowAutoWriteBut()
    {
        miqieWriteBut.SetActive(true);
    }

    //判断工具是否在使用中
    public bool isCurrentTool(string toolName)
    {
        foreach (GameObject go in gjList)
        {
            if (toolName == go.name)
            {
                if (go.transform.position != initPos) {
                    return true;
                }
            }
        }
        return false;
    }

    //放回工具
    public void resetTool()
    {
        foreach (GameObject go in gjList)
        {
            ObjFllowMouse ofm = go.GetComponent<ObjFllowMouse>();
            if (ofm != null) {
                Destroy(go.GetComponent<ObjFllowMouse>());
            }
            go.transform.position = initPos;
        }
    }

    //当前已选择的工具
    public GameObject lastGj;

    public GameObject beipenhuPerson;
    public GameObject noBeipenhuPerson;

    public GameObject xdRecardPanel;
    public GameObject writeText;
    public GameObject writeBut;

    public GameObject miqieguanchaPanel;
    public GameObject miqieAllText;
    public GameObject miqieWriteBut;

    public void gongjuBut(GameObject but)
    {
        if (but.name == "医用喷壶")
        {
            //更换角色和位置
            if (noBeipenhuPerson.activeSelf)
            {
                noBeipenhuPerson.SetActive(false);
                beipenhuPerson.transform.position = noBeipenhuPerson.transform.position;
                beipenhuPerson.transform.eulerAngles = noBeipenhuPerson.transform.eulerAngles;
                beipenhuPerson.SetActive(true);

            }
            else if (beipenhuPerson.activeSelf)
            {
                beipenhuPerson.SetActive(false);
                noBeipenhuPerson.transform.position = beipenhuPerson.transform.position;
                noBeipenhuPerson.transform.eulerAngles = beipenhuPerson.transform.eulerAngles;
                noBeipenhuPerson.SetActive(true);
            }

            xdManager.instance.noBeipenhuPerson = GameObject.FindGameObjectWithTag("Player");

        }
        else if (but.name == "消毒记录表") {
            playMovie_dealfw.instance.closeMov();
            if (xdRecardPanel.activeSelf)
            {
                xdRecardPanel.SetActive(false);
                //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().Close();
            }
            else
            {
                xdRecardPanel.SetActive(true);
                //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().ButtonShine();
            }
        }
        else if (but.name == "观察登记表")
        {

            playMovie_dealfw.instance.closeMov();
            if (miqieguanchaPanel.activeSelf)
            {
                miqieguanchaPanel.SetActive(false);
                //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().Close();
            }
            else
            {
                miqieguanchaPanel.SetActive(true);
                //Tongyong.instance._tbBtn.GetComponent<ButtonLight>().ButtonShine();
            }
        }
        else {
            

            foreach (GameObject go in gjList)
            {
                if (but.name == go.name)
                {
                    if (go.transform.position == initPos)
                    {
                        if (lastGj != null)
                        {
                            ObjFllowMouse sss = lastGj.GetComponent<ObjFllowMouse>();
                            if (sss != null)
                            {
                                Destroy(lastGj.GetComponent<ObjFllowMouse>());
                            }
                            lastGj.transform.position = initPos;
                        }

                        ObjFllowMouse ofm = go.AddComponent<ObjFllowMouse>();
                        lastGj = go;
                    }
                    else
                    {
                        Destroy(go.GetComponent<ObjFllowMouse>());
                        go.transform.position = initPos;
                    }
                }

            }
        }

    }
}
