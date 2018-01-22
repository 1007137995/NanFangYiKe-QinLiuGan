using UnityEngine;
using System.Collections;

public class geliManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnable()
    {
        Animation ani = this.transform.Find("0532Tuibingren02").GetComponent<Animation>();
        ani["送入医院改闭眼"].speed = 2f;
        ani.Play();
    }
}
