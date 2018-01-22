using UnityEngine;
using System.Collections;
using DG.Tweening;

public class openGate : MonoBehaviour {

    private GameObject DR;
    private GameObject DL;
    private GameObject SR;
    private GameObject SL;

	// Use this for initialization
	void Start () {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("men");
        foreach (GameObject go in gos) {
            if (go.name == "DR") {
                DR = go;
            }
            else if (go.name == "DL") {
                DL = go;
            }
            else if (go.name == "SR")
            {
                SR = go;
            }
            else if (go.name == "SL")
            {
                SL = go;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "People") {
            if (this.gameObject.name == "damenTrigger")
            {
                DR.transform.DOLocalRotate(new Vector3(0f,-85f, 0f),2f);
                DL.transform.DOLocalRotate(new Vector3(0f, 85f, 0f), 2f);
            }
            else {
                SR.transform.DOLocalRotate(new Vector3(0f, -85f, 0f), 2f);
                SL.transform.DOLocalRotate(new Vector3(0f, 85f, 0f), 2f);
            }
        }
       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "People")
        {
            if (this.gameObject.name == "damenTrigger")
            {
                DR.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2f);
                DL.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2f);
            }
            else
            {
                SR.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2f);
                SL.transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 2f);
            }
        }
    }
}
