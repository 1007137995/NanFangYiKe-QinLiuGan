using System;
using UnityEngine;
using System.Collections;
using System.Threading;
using DG.Tweening;
using HighlightingSystem;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public enum StateStepEnum { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven, Twelve }
public class SceneManage : MonoBehaviour
{
    [HideInInspector]
    public DateBase _DB;
    [HideInInspector]
    public StateStepEnum _TotalStep = StateStepEnum.One;
    [HideInInspector]
    private int _Index = 0;
    private int _Num = 0;
    public GameObject _PrefabJinJie;
    public GameObject _MianQianObj01;
    private GameObject _JinJieObj;
    public GameObject _MianQianObj;
    private Text _TipText;
    private GameObject _Canvas;
    private GameObject _CheckBtn;
    public Transform _Patient;
    public Transform _Player;
    [HideInInspector]
    public Transform _Camera;
    private bool _CanCheck = false;
    bool _CanShow = false;
    public GameObject _ShiGuanObj;


    public GameObject _PatientCar;
    public GameObject _ReturnButton;
    public GameObject _Image;
    public GameObject _BtnPanle;
    private void Start()
    {
        _DB = GameObject.Find("Buildings").GetComponent<DateBase>();
        _Canvas = GameObject.Find("Canvas");
        _CheckBtn = _Canvas.transform.FindChild("CheckButton").gameObject;
        _TipText = _Canvas.transform.FindChild("TipText").GetComponent<Text>();
        _TipText.text = _DB._TipList["One"];
        _Camera = GameObject.Find("Camera").transform;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit _Hit;

            if (Physics.Raycast(_Ray, out _Hit))
            {
                if (_TotalStep == StateStepEnum.Two)
                {
                    if (_Hit.transform.CompareTag("TargetObj"))
                    {
                        _JinJieObj.transform.position = _Hit.transform.position;
                        _CloseFllow();
                    }
                    else
                    {
                        print(_Hit.transform.name);
                        _TipText.text = _DB._TipList["Two"];
                        Invoke("_TipFade", 0.5f);
                    }
                }
                if (_TotalStep == StateStepEnum.Six)
                {
                    if (_Hit.transform.name == "Mouse")
                    {
                        _ShowText("Seven");
                        Tweener _Tweener = _MianQianObj.transform.DOMove(new Vector3(-99.81f, 10.77f, 163.74f), 1f);
                        _Tweener.SetAutoKill(false);
                        _CloseComponent();
                        _Tweener.OnComplete(() =>
                        {
                            _TotalStep = StateStepEnum.Seven;
                            _MianQianObj.SetActive(false);
                            _MianQianObj01.SetActive(true);
                        });
                    }
                    else
                    {
                        _TipText.text = _DB._TipList["Two"];
                        Invoke("_TipFade", 0.5f);
                    }
                }
                if (_TotalStep == StateStepEnum.Seven)
                {
                    if (_Hit.transform.name == "MianQian01")
                    {
                        _MianQianObj01.GetComponent<DOTweenAnimation>().DOPlayById("0");

                        _TotalStep = StateStepEnum.Eight;
                    }
                }
            }
        }
        if (_CanShow)
        {
            _DB._ShowLine();
            _Index = 17;
            _TotalStep = StateStepEnum.Three;
            _CanShow = false;
            _CanCheck = true;
            _ShowText("Three");
        }
        if (_CanCheck)
        {
            _CalculateDis();
        }
    }

    private void _ShowText(string _Name)
    {
        _TipText.text = _DB._TipList[_Name];
    }

    /// <summary>
    /// Text Fade
    /// </summary>
    private void _TipFade()
    {
        _TipText.text = String.Empty;
    }
    /// <summary>
    /// Instantiate Prefab
    /// </summary>
    public void _JinJieBtnClicked()
    {
        _TipFade();

        if (_Index < 16)
        {
            GameObject _Go = _DB._TargetObj[_Index];
            _Go.AddComponent<FlashingController>();
            _Go.GetComponent<FlashingController>().flashingDelay = 0;
            _DB._ChangeTag(_Index);

            _Num = _Index;
            _Index++;

            _JinJieObj = GameObject.Instantiate(_PrefabJinJie, Vector3.zero, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
            _JinJieObj.transform.localScale = new Vector3(5, 5, 5);

            if (!_JinJieObj.GetComponent<ObjFllowMouse>())
            {
                _JinJieObj.AddComponent<ObjFllowMouse>();
            }
            _TotalStep = StateStepEnum.Two;
        }
    }
    /// <summary>
    /// Unload FllowMouse Script
    /// </summary>
    private void _CloseFllow()
    {
        _JinJieObj.transform.localScale = new Vector3(15, 15, 15);

        if (_JinJieObj.GetComponent<ObjFllowMouse>())
        {
            GameObject.Destroy(_JinJieObj.GetComponent<ObjFllowMouse>());
        }
        _DB._TargetObj[_Num].GetComponent<Highlighter>().enabled = false;

        if (_Index == 16)
        {
            _CanShow = true;
        }
    }
    private void _CalculateDis()
    {
        float _Y = _Player.position.y;

        Vector3 _TargetPos = new Vector3(_Patient.position.x, _Y, _Patient.position.z);

        float _Dis = Mathf.Abs(Vector3.Distance(_TargetPos, _Player.position));

        if (_Dis < 5)
        {
            _CheckBtn.SetActive(true);
        }
        else
        {
            _CheckBtn.SetActive(false);
        }
    }
    public void _CheckBtnClicked()
    {
        if (_TotalStep == StateStepEnum.Three)
        {
            _CanCheck = false;
            _DealCameraAndPlayer();
            _TotalStep = StateStepEnum.Four;
            _CheckBtn.SetActive(false);
            _ShowText("Four");
        }
    }
    private void _DealCameraAndPlayer()
    {
        _Camera.GetComponent<FreeLookCam>().enabled = false;
        _Camera.GetComponent<ProtectCameraFromWallClip>().enabled = false;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = false;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = false;
        _Camera.DOMove(new Vector3(-98.3f, 7.6f, 164), 1.5f);
        _Camera.DORotate(new Vector3(16, 80, 0), 1.5f);
    }
    public void _MianQianBtnClicked()
    {
        if (_TotalStep == StateStepEnum.Five)
        {
            _ShowText("Six");
            _MianQianObj.transform.rotation = Quaternion.Euler(new Vector3(-70.8583f, 15.1807f, -79.5676f));
            _MianQianObj.AddComponent<ObjFllowMouse>();
            _TotalStep = StateStepEnum.Six;
        }
    }
    public void _PlayMianQianAnim()
    {
        _MianQianObj01.GetComponent<DOTweenAnimation>().DOPlayById("1");
        _MianQianObj01.GetComponent<DOTweenPath>().DOPlay();
        _MianQianObj01.GetComponent<DOTweenAnimation>().DOPlayById("2");
        _MianQianObj01.GetComponent<DOTweenPath>().GetTween().OnComplete(() =>
        {
            _MianQianObj01.SetActive(false); _ShiGuanObj.SetActive(false);
            _BtnPanle.SetActive(false);
            Tweener _tweener = _Image.GetComponent<Image>().DOFade(1, 2f);
            _TipFade();
            _tweener.OnComplete(() => { _End(); });
        });
    }
    private void _CloseComponent()
    {
        if (_MianQianObj.GetComponent<ObjFllowMouse>())
        {
            GameObject.Destroy(_MianQianObj.GetComponent<ObjFllowMouse>());
        }
    }
    public void _ShowShiGuan()
    {
        if (_TotalStep == StateStepEnum.Four)
        {
            _ShiGuanObj.SetActive(true);
            _TotalStep = StateStepEnum.Five;
           _ShowText("Five");
        }
    }
    private void _End()
    {
        _Camera.transform.position = new Vector3(-107.77f, 9.3f, 155.76f);
        _Camera.transform.rotation = Quaternion.Euler(new Vector3(0, 212.8765f, 0));
        _PatientCar.SetActive(true);
        _ReturnButton.SetActive(true);
        _Image.GetComponent<Image>().DOFade(0, 2f);
    }

    public void _ReturnBtnClicked()
    {

    }
}
