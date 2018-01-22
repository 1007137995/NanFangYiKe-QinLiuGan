using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

    private GUITexture guiT;
    private MovieTexture movieT;
    void Start () {
        guiT = transform.GetComponent<GUITexture>();
        movieT = (MovieTexture)guiT.texture;
        movieT.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
