using System;
using UnityEngine;
using System.Collections;

public class MouseHover04 : MonoBehaviour {

    private bool _IsShow = false;
    public void OnGUI()
    {
        if (_IsShow)
        {
            GUI.Box(new Rect(Input.mousePosition.x + 15f, Screen.height - Input.mousePosition.y, 80, 25), Manage04.Instance._DC04._NameList[transform.name]);
        }
    }
    public void OnMouseExit()
    {
        _IsShow = false;
        Manage04.Instance._TipText.text = String.Empty;
    }
    public void OnMouseEnter()
    {
        _IsShow = true;
        Manage04.Instance._TipText.text = Manage04.Instance._DC04._DescrideList[transform.name];
    }
}
