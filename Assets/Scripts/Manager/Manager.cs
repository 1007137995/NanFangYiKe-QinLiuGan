using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour 
{

    public static Manager instance;

    public BarrierUI b;

    //切换场景
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetSceneNum(int i)
    {
        SceneChoosePanel.id = i;
    }

    //设置激活
    public void GameObjectActiveTrue(GameObject g)
    {
        g.SetActive(true);
    }

    //取消激活
    public void GameObjectActiveFalse(GameObject g)
    {
        g.SetActive(false);
    }

    void Awake()
    {
        instance = this;
    }

	void Start () 
    {
	
	}
	
	void Update () 
    {
        
	}
}
