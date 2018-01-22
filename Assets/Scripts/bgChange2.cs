using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bgChange2 : MonoBehaviour {

    bool isOpen = false;
	// Use this for initialization
	void Start () {
	
	}
    float time = 0f;
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 2f)
        {
            time = 0f;
        }
        if (isOpen)
        {
            this.GetComponent<Image>().color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), time / 2f);
            if (this.GetComponent<Image>().color.a < 20f/255f)
            {
                this.gameObject.SetActive(false);
                isOpen = false;
                this.GetComponent<Image>().color = Color.black;
            }
        }
    }

    private void OnEnable()
    {
        time = 0f;
        isOpen = true;
    }
}
