using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class playMovie : MonoBehaviour {

    public static playMovie instance;
    private MovieTexture movTexture = new MovieTexture();
    private AudioClip audioClip = new AudioClip();
    private AudioSource ado;
    public List<MovieTexture> movTextureList = new List<MovieTexture>();
    public List<AudioClip> audioClipList = new List<AudioClip>();

    bool isEnter = false;
    bool isBase = false;
    int index = 0;

    // Use this for initialization
    void Start () {
        instance = this;
        ado = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isEnter)
        {
            if (!movTexture.isPlaying)
            {
                if (index == 0)
                {
                    movTexture.Stop();
                    movTexture.Play();
                    //ado.clip = audioClip;
                    //ado.loop = false;
                    //ado.Play();
                    movTexture.loop = false;
                }
                else
                {
                    closeMov();
                }
            }
        }
    }

    //public void PlayBase(string movName)
    //{
    //    foreach (MovieTexture mov in movTextureList)
    //    {

    //        if (mov.name == movName)
    //        {
    //            movTexture = mov;
    //        }
    //    }
    //    isBase = true;
    //}

    public void playMov(string movName) {
        index = 0;
        Tongyong.instance._spBtn.GetComponent<ButtonLight>().ButtonShine();
        foreach (MovieTexture mov in movTextureList) {          
            if (mov.name == movName) {
                movTexture = mov;
                moviePanel.SetActive(true);
                moviePanel.transform.FindChild("RawImage").GetComponent<RawImage>().texture = movTexture;
            }      
        }
        foreach (AudioClip ac in audioClipList)
        {
            if (ac.name == movName + " audio")
            {
                audioClip = ac;
                ado = AudioManage.instance.Play(audioClip, false);
            }
        }
        isEnter = true;
    }

    public void closeMov()
    {
        isEnter = false;
        //ado.Stop();
        Tongyong.instance._spBtn.GetComponent<ButtonLight>().Close();
        if (moviePanel != null)
        {
            moviePanel.SetActive(false);
        }
        if (movTexture.name == "xixiaoqu")
        {
            LastScene.instance.Tuo();
        }
    }

    public GameObject moviePanel;

    //播放片头，播放穿衣服，播放脱衣服，播放洗手，四个动画。
    //void OnGUI()
    //{
    //    if (isEnter)
    //    {
    //        //绘制电影纹理
    //        //GUI.DrawTexture(new Rect(43.5f*(Screen.width*1.0f/ 980f ), ((Screen.height - 494.4f)*(Screen.height*1.0f/593f)), 239f, 185f), movTexture, ScaleMode.StretchToFill);
    //       GUI.DrawTexture(new Rect(43.5f, Screen.height - 494.4f, 239f, 185f), movTexture, ScaleMode.StretchToFill);
    //        if (!movTexture.isPlaying)
    //        {
    //            if (index == 0)
    //            {
    //                movTexture.Stop();
    //                movTexture.Play();
    //                //ado.clip = audioClip;
    //                //ado.loop = false;
    //                //ado.Play();
    //                movTexture.loop = false;
    //                index++;
    //                if (moviePanel != null) {
    //                    if (Screen.width == 980f) {
    //                        moviePanel.SetActive(true);
    //                    }
    //                }
                    
    //            }
    //            else
    //            {
    //                isEnter = false;
    //                //ado.Stop();
    //                if (moviePanel != null)
    //                {
    //                    moviePanel.SetActive(false);
    //                }
    //                //    goScene();
    //            }

    //        }
    //        //GUI.Label(new Rect(Screen.width / 2f - 50f, Screen.height - 50f, 200f, 100f), "点击屏幕可跳过视频");
    //        //if (Input.GetMouseButtonDown(0))
    //        //{
    //        //    isEnter = false;
    //        //    ado.Stop();
    //        //    //  goScene();
    //        //}

    //    }
    //    if (isBase)
    //    {
    //        GUI.DrawTexture(new Rect(160f, 100, 600f, 400f), movTexture, ScaleMode.StretchToFill);
    //        movTexture.Play();
    //        if (!movTexture.isPlaying)
    //        {
    //            isBase = false;
    //            //if (moviePanel != null)
    //            //{
    //            //    moviePanel.SetActive(false);
    //            //}
    //            closeMov();
    //        }
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            isBase = false;
    //            movTexture.Stop();
    //            closeMov();
    //        }
    //    }
    //}
}
