using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PanelMove : MonoBehaviour
{

    Tweener t;

    public Panel_State panel_state;
    public enum Panel_State
    {
        On,
        Off,
    }

    public void Move()
    {
        switch (panel_state)
        {
            case Panel_State.Off:
                t = this.transform.DOMoveY(296.5f,1);
                //this.GetComponent<DOTweenAnimation>().DOPlayById("2");
                panel_state = Panel_State.On;
                break;
            case Panel_State.On:
                t = this.transform.DOMoveY(855, 1);
                //this.GetComponent<DOTweenAnimation>().DOPlayById("1");
                panel_state = Panel_State.Off;
                break;
        }
    }

	void Start () 
    {
        panel_state = Panel_State.On;
        
	}
	
	void Update ()
    {
	
	}
}
