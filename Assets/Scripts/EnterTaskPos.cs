using UnityEngine;
using System.Collections;

public class EnterTaskPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            xdManager.instance.changeTastPosState(this.gameObject.name,true);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            xdManager.instance.changeTastPosState(this.gameObject.name, false);
        }
    }
}
