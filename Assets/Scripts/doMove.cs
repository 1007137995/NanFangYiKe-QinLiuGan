using UnityEngine;
using System.Collections;
using DG.Tweening;

public class doMove : MonoBehaviour {

    public GameObject pos;

    public GameObject but;

    public RectTransform kuang;

    public RectTransform tu;

    public RectTransform cha;

    private bool isOut = false;

    private Vector3 initPos;

    // Use this for initialization
    void Start () {
        initPos = this.transform.position;
    }

	// Update is called once per frame
	void Update ()
    {
        
	}

    public void goOutOrIn() {
        if (isOut)
        {
            if (Screen.fullScreen)
            {
                GameObject.Find("Tongyong").transform.FindChild("Right").DOMoveX(962.1f / 980 * Screen.currentResolution.width, 1f);
                this.transform.DOMoveX(971.1f / 980 * Screen.currentResolution.width, 1f);
            }
            else
            {
                GameObject.Find("Tongyong").transform.FindChild("Right").DOMoveX(962.1f, 1f);
                this.transform.DOMoveX(971.1f, 1f);
            }     
            isOut = false;
            but.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            if (Screen.fullScreen)
            {
                GameObject.Find("Tongyong").transform.FindChild("Right").DOMoveX(823.7f / 980 * Screen.currentResolution.width, 1f);
                this.transform.DOMoveX(832.1f / 980 * Screen.currentResolution.width, 1f);
            }
            else
            {
                GameObject.Find("Tongyong").transform.FindChild("Right").DOMoveX(823.7f, 1f);
                this.transform.DOMoveX(832.1f, 1f);
            }
            isOut = true;
            but.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
