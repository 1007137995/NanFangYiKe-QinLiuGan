using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.Networking;

public enum State06 { One, Two, Three }
public class Manage06 : NetworkBehaviour
{
    [HideInInspector]
    public DateClass06 _DC06;

    public GameObject _Patient;
    public GameObject _Player;
    private float _Dis;
    public GameObject _ViewBtn;
    public GameObject _Camera;

    private bool[] _ButtonBools;
    public GameObject[] _BtnObjs;
    public GameObject _IntroducePanle;
    public GameObject _Text;
    private Text _TipText;
    private bool _ISShow = true;
    public GameObject _Custom01;
    public GameObject _Custom02;

    public GameObject _DialogText;
    private Text _Dialog01;
    private Text _Dialog02;
    private int _Count = 0;
    private string _Name;
    public State06 _S06 = State06.One;
    void Start()
    {
        _DC06 = GameObject.Find("Buildings").GetComponent<DateClass06>();
        _ButtonBools = new bool[4];
        _TipText = _Text.GetComponent<Text>();
        _Dialog01 = _DialogText.GetComponent<Text>();
        _Dialog02 = _DialogText.transform.GetChild(0).GetComponent<Text>();
        _TipText.text = _DC06._TextDic["One"];
    }
    private void Update()
    {
        if (_ISShow)
        {
            _Dis = Mathf.Abs(Vector3.Distance(_Patient.transform.position, _Player.transform.position));

            if (_Dis < 1.5f)
            {
                _ViewBtn.SetActive(true);
                _TipFade();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (_S06 == State06.Two)
            {
                Ray _Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit _Hit;

                if (Physics.Raycast(_Ray, out _Hit))
                {
                    if (_Hit.transform.CompareTag("Person"))
                    {
                        _TipFade();

                        _Name = _Hit.transform.name;

                        switch (_Hit.transform.name)
                        {
                            case "Custom01":
                                _Suo();
                                _DialogText.SetActive(true);
                                _DialogContent01();
                                break;
                            case "Custom02":
                                _Suo();
                                _DialogText.SetActive(true);
                                _DialogContent02();
                                break;
                        }
                    }
                }
            }
        }
    }
    private void _DialogContent01()
    {
        Tweener _Tweener01 = _Dialog01.DOText(_DC06._TextDic["Four"], 1f);

        _Tweener01.OnComplete(() =>
        {
            Tweener _Tweener02 = _Dialog02.DOText(_DC06._TextDic["Six"], 1f);
        });

    }
    private void _DialogContent02()
    {
        Tweener _Tweener01 = _Dialog01.DOText(_DC06._TextDic["Eight"], 1f);

        _Tweener01.OnComplete(() =>
        {
            Tweener _Tweener02 = _Dialog02.DOText(_DC06._TextDic["Nine"], 1f);
        });

    }
    public void _ViewBtnClicked()
    {
        if (_S06 == State06.One)
        {
            _ViewBtn.SetActive(false);
            _CloseComponent(new Vector3(-98.49f, 10.09f, 156.4f), new Vector3(-95.81f, 8.31f, 161.06f), new Vector3(7f, 0.2f, -0.13f));
            _IntroducePanle.SetActive(true);
        }
    }
    private void _CloseComponent(Vector3 _PlayerPos, Vector3 _CameraPos, Vector3 _CameraRotate)
    {
        _Camera.GetComponent<FreeLookCam>().enabled = false;
        _Camera.GetComponent<ProtectCameraFromWallClip>().enabled = false;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = false;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = false;
        _Player.GetComponent<Animator>().enabled = false;
        _Player.SetActive(false);
        _Player.transform.position = _PlayerPos;

        _Camera.transform.DOMove(_CameraPos, 0.5f);
        _Camera.transform.DORotate(_CameraRotate, 0.5f);
    }
    private void _RecoverComponent()
    {
        _Player.SetActive(true);
        _Player.GetComponent<Animator>().enabled = true;
        _Camera.GetComponent<FreeLookCam>().enabled = true;
        _Camera.GetComponent<ProtectCameraFromWallClip>().enabled = true;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = true;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }
    public void _BtnOneClicked()
    {
        _DealClicke(0, _ButtonBools, _BtnObjs);
    }
    public void _BtnTwoClicked()
    {
        _DealClicke(1, _ButtonBools, _BtnObjs);
    }
    public void _BtnThreeClicked()
    {
        _DealClicke(2, _ButtonBools, _BtnObjs);
    }
    public void _BtnFourClicked()
    {
        _DealClicke(3, _ButtonBools, _BtnObjs);
    }
    private void _DealClicke(int _Num, bool[] _IsSelected, GameObject[] _BtnObjs)
    {
        if (!_IsSelected[_Num])
        {
            _BtnObjs[_Num].GetComponent<Image>().color = Color.green;

            _IsSelected[_Num] = true;
        }
        else
        {
            _BtnObjs[_Num].GetComponent<Image>().color = Color.white;

            _IsSelected[_Num] = false;
        }
    }

    public void _ConfigeBtnClicked()
    {
        if (_ButtonBools[0] && _ButtonBools[2] && !_ButtonBools[1] && !_ButtonBools[3])
        {
            _IntroducePanle.SetActive(false);

            _ISShow = false;

            _RecoverComponent();

            _Custom01.AddComponent<HighlighterController>();
            _Custom02.AddComponent<HighlighterController>();
            _Custom01.tag = "Person";
            _Custom02.tag = "Person";
            _S06 = State06.Two;
            _TipText.text = _DC06._TextDic["Three"];
        }
        else
        {
            _TipText.text = _DC06._TextDic["Two"];

            Invoke("_TipFade", 0.5f);
        }
    }
    void _TipFade()
    {
        _TipText.text = String.Empty;
    }

    public void _CBtn()
    {
        _Dialog01.text = String.Empty;
        _Dialog02.text = String.Empty;
        if (_Name != null)
        {
            switch (_Name)
            {
                case "Custom01":
                    Tweener _Tweener03 = _Dialog01.DOText(_DC06._TextDic["Five"], 1f);

                    _Tweener03.OnComplete(() =>
                    {
                        Tweener _Tweener04 = _Dialog02.DOText(_DC06._TextDic["Seven"], 1f);
                        _Tweener04.OnComplete(() => { _Name = null; });
                    });

                    _Open();
                    break;
                case "Custom02":
                    Tweener _Tweener05 = _Dialog01.DOText(_DC06._TextDic["Five"], 1f);

                    _Tweener05.OnComplete(() =>
                    {
                        Tweener _Tweener06 = _Dialog02.DOText(_DC06._TextDic["Ten"], 1f);
                        _Tweener06.OnComplete(() => { _Name = null; });
                    });
                    _Open();
                    break;
            }
        }
        if (_Name == null)
        {
            _DialogText.SetActive(false);
        }
    }

    private void _Suo()
    {
        _Camera.GetComponent<FreeLookCam>().enabled = false;
        _Camera.GetComponent<ProtectCameraFromWallClip>().enabled = false;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = false;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = false;
        _Player.GetComponent<Animator>().enabled = false;
    }

    private void _Open()
    {
        _Player.GetComponent<Animator>().enabled = true;
        _Camera.GetComponent<FreeLookCam>().enabled = true;
        _Camera.GetComponent<ProtectCameraFromWallClip>().enabled = true;
        _Player.GetComponent<ThirdPersonCharacter>().enabled = true;
        _Player.GetComponent<ThirdPersonUserControl>().enabled = true;
    }

    public void _ReturnBtn()
    {

    }
}
