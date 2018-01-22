using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CarEnter : MonoBehaviour {

    public GameObject personCam;
    public GameObject sceneCam;
    public GameObject person;
    public GameObject bg2;
    private AudioSource jiuhuche;

	// Use this for initialization
	void Start () {
        goin();
        jiuhuche = AudioManage.instance.PlayVoice("jiuhuche");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    Tweener tw;
    public void goin() {
        tw = this.gameObject.transform.DOMove(new Vector3(11.64f, -1.98f, -6.42f),4f);
        tw.SetEase(Ease.OutSine);
        tw.OnComplete(beginGo);
    }

    public void beginGo() {
        jiuhuche.Stop();
        personCam.SetActive(true);
        sceneCam.SetActive(false);
        person.SetActive(true);
        bg2.SetActive(true);
        xdManager.instance.ButtonOk();
    }
}
