using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarrierUI : MonoBehaviour 
{
    //淡入淡出速度
    public float speed;

    private Image i;

    void Awake()
    {
        i = this.GetComponent<Image>();
    }

    //画面淡入
    public void InPicture()
    {
        StartCoroutine(In());
    }

    //画面淡出
    public void OutPicture()
    {
        StartCoroutine(Out());
    }

    IEnumerator In()
    {
        
        while (i.color.a > 0)
        {
            i.color -= new Color(0, 0, 0, speed);
            yield return new WaitForSeconds(0.1f);
        }
        i.enabled = false;
    }

    IEnumerator Out()
    {
        i.enabled = true;
        while (i.color.a < 1)
        {
            i.color += new Color(0, 0, 0, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

	void Start () 
    {
	
	}
	
	void Update () 
    {
        
	}

}
