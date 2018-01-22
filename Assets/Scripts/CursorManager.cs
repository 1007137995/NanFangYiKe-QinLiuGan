using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDragHandler
{
    
    // Use this for initialization
    void Start()
    {
        cursorTexture = Resources.Load("hand") as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        changeCurson();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        resetCurson();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
    }

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Vector2 hotSpot2 = new Vector2(34f,12f);

    public void changeCurson()
    {
        Cursor.SetCursor(cursorTexture, hotSpot2, cursorMode);
        if (transform.tag == "wuzi")
        {
            transform.parent.parent.FindChild("text").GetComponent<Text>().text = transform.name;
        }
        if (transform.tag == "yifu")
        {
            transform.parent.parent.FindChild("text").GetComponent<Text>().text = transform.GetChild(0).name;
        }
    }

    public void resetCurson()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
        if (transform.tag == "wuzi" || transform.tag == "yifu")
        {
            transform.parent.parent.FindChild("text").GetComponent<Text>().text = null;
        }
    }

    public void OnDisable()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
        if (transform.tag == "wuzi" || transform.tag == "yifu")
        {
            transform.parent.parent.FindChild("text").GetComponent<Text>().text = null;
        }
    }

}
