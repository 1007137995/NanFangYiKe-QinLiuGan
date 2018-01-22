using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour 
{

    public Text talk;
    public Button confirm;
    public SliderControl progressBar;

    int count;

    public void SetText(string s)
    {
        talk.text = s;
    }

    public void ConfirmButton()
    {
        count++;
        Debug.Log(count);
        if (count == 2)
        {
            StartCoroutine(progressBar.Run(2f, 0f));
            progressBar.SetText("正在通过电话联络卫生局");
        }
        StepManager.willStep++;
        this.gameObject.SetActive(false);
    }

	void Start () 
    {
        count = 0;
	}
	
	void Update () 
    {
	
	}
}
