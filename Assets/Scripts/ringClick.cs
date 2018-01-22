using UnityEngine;
using System.Collections;

public class ringClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (this.gameObject.name == "ring_youbikong")
        {
            caiyanManager.instance.clickyoubikong();
        }
        else if (this.gameObject.name == "ring_zuobikong")
        {
            caiyanManager.instance.clickzuobikong();
        }
        //else if (this.gameObject.name == "ring_shiguan")
        //{
        //    caiyanManager.instance.clickshiguan();
        //}
        //else if (this.gameObject.name == "ring_beizi")
        //{
        //    caiyanManager.instance.clickbeizhi();
        //}
        //else if (this.gameObject.name == "ring_xiangzi")
        //{
        //    caiyanManager.instance.clickxiangzhi();
        //}
    }
}