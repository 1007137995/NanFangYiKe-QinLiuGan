using UnityEngine;
using System.Collections;

public class piaobaiLizi : MonoBehaviour {

    public GameObject pibaiLizi;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showLizi() {
        print("show");
        pibaiLizi.SetActive(true);
    }

    public void hideLizi() {
        print("hide");
        pibaiLizi.SetActive(false);
    }
}
