using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseOver : MonoBehaviour
{
    public void OnMouseEnter()
    {
        Injection._Instance._ShowIntroduce(transform.name);
    }
    public void OnMouseExit()
    {
        Injection._Instance._CloseIntroduce();
    }
}
