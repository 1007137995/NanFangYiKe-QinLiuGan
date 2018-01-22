using UnityEngine;
using System.Collections;

public class lookAtTexieCam : MonoBehaviour {

    public GameObject texieCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(texieCam.transform);
	}
}
