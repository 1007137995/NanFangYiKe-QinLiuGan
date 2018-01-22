using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public enum StepState
{
    One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten
}
public class Manage : MonoBehaviour
{
    public static Manage _Instance = null;

    public StepState _State = StepState.One;

    public string _Name;
    public Camera _Camera;
    private GameObject _TargetPos;
    private float _Dis;
    private GameObject _Player;
    private GameObject _Canvas;
    private GameObject _MakeUpButton;
    public GameObject _MainCamera;

    private GameObject _Go;
    private Quaternion _GoRotate;
    private Vector3 _GoPos;

    public Text _TipText;
    private bool _Have = false;
    private void Awake()
    {
        _Instance = this;
    }
    [HideInInspector]
    public DateClass _DateClass;

    public Text _Tip;
    public GameObject _ReturnBtn;
    private void Start()
    {
        _DateClass = GameObject.Find("Modle").GetComponent<DateClass>();
        _TargetPos = GameObject.Find("TargetPos");
        _Player = GameObject.Find("Programer");
        _Canvas = GameObject.Find("Canvas");
        _MakeUpButton = _Canvas.transform.FindChild("MakeUp").gameObject;
        _Tip.text = "请走到桌子边进行穿衣！";
    }
    void Update()
    {
        _Dis = Mathf.Abs(Vector3.Distance(_TargetPos.transform.position, _Player.transform.position));

        if (_Dis < 0.5f)
        {
            _MakeUpButton.SetActive(true);
            _Tip.text = String.Empty;
        }
        else
        {
            _MakeUpButton.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray _Ray = _Camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit _Hit;
            if (Physics.Raycast(_Ray, out _Hit, 1000f))
            {
                #region
                if (_Hit.transform.CompareTag("Cloth"))
                {
                    _Name = _Hit.transform.name;
                    _Go = _Hit.transform.parent.gameObject;

                    switch (_Name)
                    {
                        case "ClothUp":
                            if (_State == StepState.Two)
                            {
                                _Judge();
                            }
                            break;
                        case "ClothDown":
                            if (_State == StepState.Three)
                            {
                                _Judge();
                            }
                            break;
                        case "GauzeMask":
                            if (_State == StepState.Four)
                            {
                                _Judge();
                            }
                            break;
                        case "Glass":
                            if (_State == StepState.Five)
                            {
                                _Judge();
                            }
                            break;
                        case "Hat":
                            if (_State == StepState.Six)
                            {
                                _Judge();
                            }
                            break;
                        case "Shose":
                            if (_State == StepState.Seven)
                            {
                                _Judge();
                            }
                            break;
                        case "Glove":
                            if (_State == StepState.Eight)
                            {
                                _Judge();
                            }
                            break;
                    }
                }
                #endregion
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray _Ray = _Camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit _Hit;
            if (Physics.Raycast(_Ray, out _Hit, 1000f))
            {
                if (_Hit.transform.CompareTag("Pos"))
                {

                    switch (_Hit.transform.name)
                    {
                        case "CLOTHUP":

                            if (_State == StepState.Two && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Three;
                            }
                            break;
                        case "CLOTHDOWN":

                            if (_State == StepState.Three && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Four;
                            }
                            break;
                        case "GAUZEMASK":

                            if (_State == StepState.Four && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Five;
                            }
                            break;
                        case "GLASS":

                            if (_State == StepState.Five && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Six;
                            }
                            break;
                        case "HAT":

                            if (_State == StepState.Six && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Seven;
                            }
                            break;
                        case "SHOSE":

                            if (_State == StepState.Seven && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _State = StepState.Eight;
                            }
                            break;
                        case "GLOVE":

                            if (_State == StepState.Eight && _Have)
                            {
                                _DateClass._ManofCloths[_Hit.transform.name].GetComponent<SkinnedMeshRenderer>().enabled = true;
                                GameObject.Destroy(_Go);
                                _Have = false;
                                _OpenComponent();
                                _DateClass._CloseTraverse();
                                _State = StepState.Nine;
                            }
                            break;
                    }
                }
            }
        }
    }
    private void _Judge()
    {
        _Go.GetComponent<DOTweenAnimation>().DOPlayById("0");

        if (_Go.name == "Shose" || _Go.name == "Glove")
        {
            if (_Go.transform.GetChild(0).GetComponent<BoxCollider>())
            {
                GameObject.Destroy(_Go.transform.GetChild(0).GetComponent<BoxCollider>());
            }
            if (_Go.transform.GetChild(1).GetComponent<BoxCollider>())
            {
                GameObject.Destroy(_Go.transform.GetChild(1).GetComponent<BoxCollider>());
            }
        }
        else
        {
            if (_Go.transform.GetChild(0).GetComponent<BoxCollider>())
            {
                GameObject.Destroy(_Go.transform.GetChild(0).GetComponent<BoxCollider>());
            }
        }
        if (!_Go.GetComponent<FllowMouse>())
        {
            _Go.AddComponent<FllowMouse>();
        }
        _Have = true;
    }
    public void _MakeUpBtn()
    {
        if (_State == StepState.One)
        {
            _MakeUpButton.SetActive(false);
            _Player.transform.position = new Vector3(-29f, 0, 3.2f);
            _Player.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
            _MainCamera.transform.DOMove(new Vector3(-28.82f, -0.38f, 3.52f), 1.5f);
            _MainCamera.transform.DORotate(new Vector3(0, -23.554f, 0), 1.5f);
            _CloseComponent();
            _DateClass._Traverse();

            _State = StepState.Two;
        }
    }
    private void _CloseComponent()
    {
        _MainCamera.GetComponent<FreeLookCam>().enabled = false;
        _MainCamera.GetComponent<ProtectCameraFromWallClip>().enabled = false;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = false;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = false;
    }

    private void _OpenComponent()
    {
        _MainCamera.GetComponent<FreeLookCam>().enabled = true;
        _MainCamera.GetComponent<ProtectCameraFromWallClip>().enabled = true;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = true;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = true;

        _ReturnBtn.SetActive(true);
    }
}
