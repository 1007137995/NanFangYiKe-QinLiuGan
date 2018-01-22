using UnityEngine;
using System.Collections;

public class FllowMouse : MonoBehaviour
{
    private Transform _TargetObj;

    Vector3 WorldPos;//世界坐标.
    void Update()
    {
        _TargetObj = Manage._Instance._DateClass._AllClothes[Manage._Instance._Name];
        
        Vector3 TartgetPos = Camera.main.WorldToScreenPoint(this.transform.position);
        
        Vector3 MousePosition = Input.mousePosition;

        MousePosition.z = Camera.main.WorldToScreenPoint(_TargetObj.transform.position).z;

        WorldPos.x = Camera.main.ScreenToWorldPoint(MousePosition).x;

        WorldPos.z = Camera.main.ScreenToWorldPoint(MousePosition).z;

        WorldPos.y = Camera.main.ScreenToWorldPoint(MousePosition).y;

        this.transform.position = WorldPos;
    }
}
