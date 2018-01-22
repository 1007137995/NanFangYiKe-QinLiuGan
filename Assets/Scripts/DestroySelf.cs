using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

    int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnEnable()
    {
        i++;
        if (i > 0)
        {
            Transform t = this.transform.parent.FindChild("showAnswer");
            if (t != null)
            {
                 t.gameObject.SetActive(true);
            }
               
        }
        Invoke("hideMe",1.5f);
    }

    private void hideMe() {
        this.gameObject.SetActive(false);
    }
}
