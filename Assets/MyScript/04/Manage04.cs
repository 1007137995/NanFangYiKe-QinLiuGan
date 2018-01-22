using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;

public enum Step04 { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
public class Manage04 : MonoBehaviour
{
    public static Manage04 Instance = null;
    [HideInInspector]
    public DateClass04 _DC04;
    public Step04 _Stp = Step04.One;

    public Text _TipText;
    private GameObject _Go;
    public GameObject _TuoYiBtn;
    public GameObject _Player;
    public GameObject _MainCamera;
    public GameObject _RenWu;
    private float _Dis;
    public GameObject _TargetPos;
    public string _NAME;

    private bool _Hide = true;
    public bool _Have = false;

    public Transform _Endpos;
    public GameObject _Water;
    public Text _TipText04;
    public GameObject _ReturnButton;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _DC04 = GameObject.Find("Modle").GetComponent<DateClass04>();
        _TipText04.text = "请走到垃圾桶边脱衣！";
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit _Hit;

            if (Physics.Raycast(_Ray, out _Hit))
            {
                if (_Hit.transform.CompareTag("Cloth04"))
                {
                    _NAME = _Hit.transform.name;

                    switch (_NAME)
                    {
                        case "GLOVE":
                            if (_Stp == Step04.Two && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Three;
                            }
                            break;
                        case "GAUZEMASK":
                            if (_Stp == Step04.Three && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Four;
                            }
                            break;
                        case "GLASS":
                            if (_Stp == Step04.Four && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Five;
                            }
                            break;
                        case "HAT":
                            if (_Stp == Step04.Five && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Six;
                            }
                            break;
                        case "CLOTHUP":
                            if (_Stp == Step04.Six && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Seven;
                            }
                            break;
                        case "SHOSE":
                            if (_Stp == Step04.Seven && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Eight;
                            }
                            break;
                        case "CLOTHDOWN":
                            if (_Stp == Step04.Eight && _Have == false)
                            {
                                _Charge();
                                _Stp = Step04.Nine;
                                _OpenComponent();
                            }
                            break;
                    }
                }
                if (_Have)
                {
                    if (_Hit.transform.name == "Trash")
                    {
                        if (_Go.GetComponent<FollowMous04>())
                        {
                            GameObject.Destroy(_Go.GetComponent<FollowMous04>());
                        }
                        Tweener _Tweener = _Go.transform.DOMove(_Endpos.position, 0.5f);
                        _Tweener.OnComplete(() =>
                        {
                            if (_Go.transform.name == "Glove" || _Go.transform.name == "Shose")
                            {
                                _Go.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                                _Go.transform.GetChild(1).gameObject.AddComponent<BoxCollider>();
                            }
                            else
                            {
                                _Go.transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
                            }
                            _Go.AddComponent<Rigidbody>();
                            _Have = false;

                        });
                    }
                }
                if (_Stp == Step04.Nine)
                {
                    if (_Hit.transform.name == "Bar")
                    {
                        _Water.SetActive(true);
                        _TipText04.text = String.Empty;
                        _ReturnButton.SetActive(true);
                    }
                }
            }
        }

        if (_Hide)
        {
            _Dis = Mathf.Abs(Vector3.Distance(_TargetPos.transform.position, _Player.transform.position));

            if (_Dis < 0.6f)
            {
                _TuoYiBtn.SetActive(true);
            }
            else
            {
                _TuoYiBtn.SetActive(false);
            }
        }
    }

    private void _Charge()
    {
        _DC04._ShowAndHide[_NAME][0].GetComponent<SkinnedMeshRenderer>().enabled = false;
        _Go = _DC04._ShowAndHide[_NAME][1];
        _Go.SetActive(true);
        _Go.AddComponent<FollowMous04>();
        _Go.transform.position = Input.mousePosition;
        _Have = true;
    }

    public void _TuoYiBtnClicked()
    {
        if (_Stp == Step04.One)
        {
            _Hide = false;
            _TuoYiBtn.SetActive(false);
            _HidePlayer();
            _MainCamera.transform.DOMove(new Vector3(-27.2f, -0.3f, 4.2f), 1.5f);
            _MainCamera.transform.DORotate(new Vector3(0, 18.3f, 0), 1.5f);
            _CloseComponent();
            _DC04._Traverse();

            _Stp = Step04.Two;
        }
    }
    private void _HidePlayer()
    {
        _Player.SetActive(false);
        _Player.transform.position = new Vector3(-27.3f, 0, 4.2f);
        _Player.transform.rotation = Quaternion.Euler(new Vector3(0, -206, 0));
        _RenWu.SetActive(true);
        _DC04._HideSkin();
        _RenWu.transform.position = new Vector3(-27.3f, 0, 4.2f);
        _RenWu.transform.rotation = Quaternion.Euler(new Vector3(0, -206, 0));
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
        _DC04._HideCollider();
        _RenWu.SetActive(false);
        _Player.SetActive(true);

        _MainCamera.GetComponent<FreeLookCam>().enabled = true;
        _MainCamera.GetComponent<ProtectCameraFromWallClip>().enabled = true;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = true;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = true;

        _TipText04.text = "请走到水龙头边洗手！";
    }
}
