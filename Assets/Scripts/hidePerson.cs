using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hidePerson : MonoBehaviour {
    private LayerMask mask;
    private Camera mainCrma;
    private bool ishide = false;

    public Sprite tongming;
    public Sprite shiti;

    public Image head;

    // Use this for initialization
    void Start () {
        mainCrma = Camera.main;
        if (SceneManager.GetActiveScene().name == "WuZhiShi")
        {
            ishide = false;
            mask = ~(1 << (LayerMask.NameToLayer("shenxing")));
            Camera.main.cullingMask = mask;
            head.sprite = tongming;
        }       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hideHead() {
        if (ishide) {
            ishide = false;
            mask = ~(1 << (LayerMask.NameToLayer("shenxing")));
            Camera.main.cullingMask = mask;
            head.sprite = tongming;
        }
        else {
            ishide = true;
            mask = ~(1 << -1);
            Camera.main.cullingMask = mask;
            head.sprite = shiti;
        }        
    }
}
