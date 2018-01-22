using System;
using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour
{
    private bool _IsShow = false;
    public void OnGUI()
    {
        if (_IsShow)
        {
            //if (this.name.Length > 5)
            //{
            //    GUI.Box(new Rect(Input.mousePosition.x + 15f, Screen.height - Input.mousePosition.y, 150, 25), transform.name);
            //}
            //else {
            //    GUI.Box(new Rect(Input.mousePosition.x + 15f, Screen.height - Input.mousePosition.y, 80, 25), transform.name);
            //}
            GUI.Box(new Rect(Input.mousePosition.x + 15f, Screen.height - Input.mousePosition.y, this.name.Length * 15 + 5, 25), transform.name);

        }
    }
    public void OnMouseExit()
    {
        _IsShow = false;
       // Manage._Instance._TipText.text = String.Empty;
    }

    public void OnMouseEnter()
    {
        _IsShow = true;
        //Manage._Instance._TipText.text = Manage._Instance._DateClass._Describe[transform.name];
    }

    public void OnMouseUp()
    {
        ShowWuZi.instance.showGo(this.name);
        //Manage._Instance._TipText.text = Manage._Instance._DateClass._Describe[transform.name];
    }
}
