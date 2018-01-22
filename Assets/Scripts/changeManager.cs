using UnityEngine;
using System.Collections;

public class changeManager : MonoBehaviour {
    public float i = 1f;

    bool isOpen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        i += Time.deltaTime * 20f;
        if (isOpen && i<45f) {
            this.transform.localScale = new Vector3(1f, 1f, 0f) * i;
        }
	}

    private void OnEnable()
    {
        isOpen = true;
    }

}
