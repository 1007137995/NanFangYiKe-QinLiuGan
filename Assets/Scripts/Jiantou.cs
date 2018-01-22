using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jiantou : MonoBehaviour {

    public static Jiantou instance;
    private List<Vector3> Pos = new List<Vector3>();
    private Vector3 NowPos = Vector3.zero;
    public Transform m_Target;

    void Start () {
        instance = this;
    }

    public void AddPos()
    {
        Pos.Add(xdManager.instance.jjx4.transform.position);
        Pos.Add(xdManager.instance.huoqinRing.transform.position);
        Pos.Add(xdManager.instance.jjx1.transform.position);
        Pos.Add(xdManager.instance.shineiRing.transform.position);
        Pos.Add(xdManager.instance.jiwoRing.transform.position);
        Pos.Add(xdManager.instance.shuichiRing.transform.position);
        Pos.Add(xdManager.instance.wuranwuRing.transform.position);
    }
	
	void FixedUpdate () {
        if (NowPos == Vector3.zero)
        {
            return;
        }
        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (Vector3.Distance(m_Target.position,NowPos) < 3f)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        transform.GetChild(0).LookAt(new Vector3(NowPos.x, transform.position.y, NowPos.z));
	}

    public void GetPos(int index)
    {
        if (index >= Pos.Count) 
        {
            Debug.Log(Pos.Count);
            return;
        }
        NowPos = Pos[index];
    }

    public void Open()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
    }

    public void Close()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
