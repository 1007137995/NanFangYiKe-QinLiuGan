using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine.UI;

public enum State05 { One, Two, Three, Four }
public class Manage05 : MonoBehaviour
{
    private int _Index = 0;
    private int _Num = 0;
    private DateClass05 _DC05;
    public State05 _State = State05.One;

    private GameObject _Go;
    public GameObject _PrefabJin;
    private GameObject _OBJ;
    public Text _TipText;

    public GameObject _Fire;
    private void Start()
    {
        _DC05 = GameObject.Find("Buildings").GetComponent<DateClass05>();
        Invoke("_Show", 0.5f);
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray _Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit _Hit;

            if (Physics.Raycast(_Ray, out _Hit))
            {
                if (_Hit.transform.CompareTag("TargetObj"))
                {
                    _OBJ.transform.position = _Hit.transform.position;

                    _CloseFlashing();
                }
            }
        }
    }

    private void _Show()
    {
        _TipText.text = _DC05._TextDic["One"];
    }

    private void _TextFade()
    {
        _TipText.text = String.Empty;
    }

    private void _CloseFlashing()
    {
        _TextFade();

        _OBJ.transform.localScale = new Vector3(15, 15, 15);

        if (_OBJ.GetComponent<ObjFllowMouse>())
        {
            GameObject.Destroy(_OBJ.GetComponent<ObjFllowMouse>());
        }
        switch (_State)
        {
            case State05.One:
                _DC05._WuZi[_Num].GetComponent<Highlighter>().enabled = false;

                if (_Num == _DC05._WuZi.Length - 1)
                {
                    _State = State05.Two;
                    _DC05._WuZiLine();
                    _Index = 0;
                    _TipText.text = _DC05._TextDic["Two"];
                }
                break;
            case State05.Two:
                _DC05._RenYuan[_Num].GetComponent<Highlighter>().enabled = false;
                if (_Num == _DC05._RenYuan.Length - 1)
                {
                    _State = State05.Three;
                    _DC05._RenYuanLine();
                    _Index = 0;
                    _TipText.text = _DC05._TextDic["Three"];
                }
                break;
            case State05.Three:
                _DC05._Trash[_Num].GetComponent<Highlighter>().enabled = false;
                if (_Num == _DC05._Trash.Length - 1)
                {
                    _State = State05.Four;
                    _DC05._TrashLine();
                    _Index = 0;
                }
                break;
        }
    }
    private void _CommonFunction()
    {
        switch (_State)
        {
            case State05.One:
                _Go = _DC05._WuZi[_Index];
                break;
            case State05.Two:
                _Go = _DC05._RenYuan[_Index];
                break;
            case State05.Three:
                _Go = _DC05._Trash[_Index];
                break;
        }
        _Go.AddComponent<FlashingController>();
        _Go.GetComponent<FlashingController>().flashingDelay = 0;
        _Num = _Index;

        _Index++;

        _OBJ = GameObject.Instantiate(_PrefabJin, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;

        _OBJ.transform.localScale = new Vector3(5, 5, 5);

        if (!_OBJ.GetComponent<ObjFllowMouse>())
        {
            _OBJ.AddComponent<ObjFllowMouse>();
        }
    }
    public void _JinJieBtnClicked()
    {
        if (_State == State05.One)
        {
            _CommonFunction();
        }
        if (_State == State05.Two)
        {
            _CommonFunction();
        }
        if (_State == State05.Three)
        {
            _CommonFunction();
        }
    }

    public void _FireBtnClicked()
    {
        if (_State == State05.Four)
        {
            _Fire.SetActive(true);
        }
    }

    public void _ReturnBtnClicked()
    {

    }
}
