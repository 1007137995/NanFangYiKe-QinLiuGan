using UnityEngine;
using System.Collections;

public class initCam : MonoBehaviour {
    public GameObject person = null;
    // Use this for initialization
    void Start () {
        this.transform.Find("FreeLookCameraRig").transform.localEulerAngles = new Vector3(0f, 200f, 0f);
        this.transform.Find("FreeLookCameraRig/Pivot").transform.localEulerAngles = new Vector3(9.718772f, 0f, 0f);
        person = GameObject.FindGameObjectWithTag("Player");
        //未起作用
        if (person != null) {
            person.transform.position = new Vector3(7.329f, -1.965f, -3.876f);
            person.transform.eulerAngles = new Vector3(0f, 206.8411f, 0f);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
