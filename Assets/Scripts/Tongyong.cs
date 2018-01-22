using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tongyong : MonoBehaviour {

    public static Tongyong instance;
    public Button _bbBtn;
    public Button _dhBtn;
    public Button _qtBtn;
    public Button _tbBtn;
    public Button _spBtn;
    public Button _cfBtn;

    void Start () {
        instance = this;
        _bbBtn = transform.FindChild("Right/BBButton").GetComponent<Button>();
        _dhBtn = transform.FindChild("Right/DHButton").GetComponent<Button>();
        _qtBtn = transform.FindChild("Right/QTButton").GetComponent<Button>();
        _tbBtn = transform.FindChild("Right/TBButton").GetComponent<Button>();
        _spBtn = transform.FindChild("Right/SPButton").GetComponent<Button>();
        _cfBtn = transform.FindChild("Right/CFButton").GetComponent<Button>();
    }
	
	void Update () {
	
	}
}
