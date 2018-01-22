using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AniManager : MonoBehaviour {

    public static AniManager instance;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playAni(object ObjName, string aniName, bool isPlay = true, float speed = 1.0f) {
        GameObject obj = null;

        if (ObjName.GetType() == typeof(GameObject)) {
            obj = ObjName as GameObject;
        } else if (ObjName.GetType() == typeof(GameObject)) {
            obj = GameObject.Find(ObjName as string);
        }
      
       
        if (obj == null) {
            return;
        }
        Animation ani = obj.GetComponent<Animation>();
        if (ani == null)
        {
            return;
        }
        if (ani[aniName] == null)
        {
            return;
        }
        ani[aniName].speed = speed;

        if (isPlay)
        {
            ani.Play(aniName);
        }
        else {
            ani.CrossFade(aniName);
        }
        
    }

    public void playScene(string sceneName) {
       // SceneManager.MergeScenes( SceneManager.GetSceneByName("YiYuan"), SceneManager.GetSceneByName("DianHuaShi"));
    }

    public void removeScene(string sceneName) {
        SceneManager.UnloadScene(sceneName);
    }
}
