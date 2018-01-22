using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class playMovie_pt : MonoBehaviour {

    public MovieTexture movTexture;
    bool isEnter = true;
    int index = 0;
    AsyncOperation async;

    // Use this for initialization
    void Start () {
        movTexture = (transform.FindChild("RawImage").GetComponent<RawImage>().texture) as MovieTexture;
        //StartCoroutine(loadScene());
        async = SceneManager.LoadSceneAsync("DianHuaShi");
        async.allowSceneActivation = false;
    }

    //IEnumerator loadScene()
    //{
    //    async = SceneManager.LoadSceneAsync("DianHuaShi");
    //    yield return async;
    //}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(async.progress);
        if (isEnter)
        {
            if (!movTexture.isPlaying)
            {
                if (index == 0)
                {
                    movTexture.Play();
                    movTexture.loop = false;
                    index++;
                }
                else
                {
                    isEnter = false;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {                
                if (async.progress >= 0.9f)
                {
                    isEnter = false;
                    async.allowSceneActivation = true;
                } 
            }
        }
        else
        {
            movTexture.Stop();
            async.allowSceneActivation = true;
            //SceneManager.LoadSceneAsync("DianHuaShi");
            Destroy(transform.FindChild("RawImage").gameObject);
            transform.GetComponent<playMovie_pt>().enabled = false;
        }
    }
}
