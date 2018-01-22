using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextControl : MonoBehaviour 
{

    float time;

    Text t;

    public Text_State text_state;
    public enum Text_State
    {
        Normal,
        Shadom,
    }

    public IEnumerator Show()
    {
        text_state = Text_State.Shadom;
        time = 0;
        t.color=new Color(0,0,0,1);
        while (time < 2f)
        {
            t.color -= new Color(0, 0, 0, 0.05f);
            time += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        text_state = Text_State.Normal;
    }
    
    void Awake()
    {
        t = this.GetComponent<Text>();
    }

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}
}
