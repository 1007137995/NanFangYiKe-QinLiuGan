using UnityEngine;
using System.Collections;

public class ObjFllowMouse : MonoBehaviour {
    public float distance = 2f;
    Vector3 WorldPos;//世界坐标.
    void Update()
    {
        Vector3 TartgetPos = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 MousePosition = Input.mousePosition;

        MousePosition.z = distance;

        WorldPos.x = Camera.main.ScreenToWorldPoint(MousePosition).x;

        WorldPos.z = Camera.main.ScreenToWorldPoint(MousePosition).z;

        WorldPos.y = Camera.main.ScreenToWorldPoint(MousePosition).y;

        this.transform.position = WorldPos;
    }
   
}
