using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour
{

    Vector3 StartPosition;
    Vector3 previousPosition;
    Vector3 offset;
    Vector3 finalOffset;
    Vector3 eulerAngle;

    bool isSlide;
    float angle;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = Input.mousePosition;
            previousPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            offset = Input.mousePosition - previousPosition;
            previousPosition = Input.mousePosition;
            transform.Rotate(Vector3.Cross(offset, Vector3.forward).normalized, offset.magnitude, Space.Self);



        }
        if (Input.GetMouseButtonUp(0))
        {
            finalOffset = Input.mousePosition - StartPosition;
            isSlide = true;
            angle = finalOffset.magnitude;


        }
        if (isSlide)
        {
            transform.Rotate(Vector3.Cross(finalOffset, Vector3.forward).normalized, angle * 2 * Time.deltaTime, Space.Self);
            if (angle > 0)
            {
                angle -= 5;
            }
            else
            {
                angle = 0;
            }
        }
    }
}