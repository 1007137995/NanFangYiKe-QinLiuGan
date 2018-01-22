using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorManagerToObj : MonoBehaviour
{
    public PlayList playlist;

    public xdManager xdmanager;

    public caiyanManager caiyangmanager;

    public List<int> step;

    public bool isTrue;


    // Use this for initialization
    void Start()
    {
        cursorTexture = Resources.Load("hand") as Texture2D;
    }

    public bool checkCondition() {

        if (playlist != null) {
            foreach (int s in step)
            {
                if (playlist.getStep() == s)
                {
                    return true;
                }
            }
        }

        if (xdmanager != null) {
            foreach (int s in step)
            {
                if (xdmanager.getStep() == s)
                {
                    return true;
                }
            }
        }

        if (caiyangmanager != null)
        {
            foreach (int s in step)
            {
                if (caiyangmanager.getStep() == s)
                {
                    return true;
                }
            }
        }

        if (isTrue) {
            return true;
        }
       
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private Vector2 hotSpot2 = new Vector2(34f,12f);

    public void changeCurson()
    {
        Cursor.SetCursor(cursorTexture, hotSpot2, cursorMode);
    }

    public void resetCurson()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    public void OnDisable()
    {
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    public void OnMouseEnter()
    {
        if (checkCondition()) {
            changeCurson();
        }
       
    }

    public void OnMouseExit()
    {
        resetCurson();
    }
}
