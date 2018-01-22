using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class playMovie_dealfw : MonoBehaviour {

    public static playMovie_dealfw instance;
    private MovieTexture movTexture = new MovieTexture();
    public List<MovieTexture> movTextureList = new List<MovieTexture>();
    private AudioClip audioClip = new AudioClip();
    private AudioSource ado;
    public List<AudioClip> audioClipList = new List<AudioClip>();
    public bool isEnter = false;
    private int index = 0;
    public GameObject moviePanel;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
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
                    closeMov();
                }
            }
        }
    }


    public MovieTexture playMov(string movName) {
        index = 0;
        Tongyong.instance._spBtn.GetComponent<ButtonLight>().ButtonShine();
        foreach (MovieTexture mov in movTextureList) {
            if (mov.name == movName) {
                movTexture = mov;
                moviePanel.SetActive(true);
                moviePanel.transform.FindChild("RawImage").GetComponent<RawImage>().texture = movTexture;
                //print(movTexture.name);
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
        return movTexture;
    }

    public void closeMov()
    {
        isEnter = false;
        Tongyong.instance._spBtn.GetComponent<ButtonLight>().Close();
        //ado.Stop();
        movTexture.Stop();
        moviePanel.SetActive(false);
    }

    //播放片头，播放穿衣服，播放脱衣服，播放洗手，四个动画。
    //void OnGUI()
    //{
    //    if (isEnter)
    //    {
    //        //绘制电影纹理
    //        //GUI.DrawTexture(new Rect(43.5f, Screen.height - 494.4f, 239f, 185f), movTexture, ScaleMode.StretchToFill);
    //        //if (GUI.Button(new Rect(43.5f + 239f - 6f, Screen.height - 494.4f - 10f, 20f, 20f), closeImg)) {
    //        //    isEnter = false;
    //        //    moviePanel.SetActive(false);
    //        //}
           
    //        if (!movTexture.isPlaying)
    //        {
    //            if (index == 0)
    //            {
    //                movTexture.Play();
    //                movTexture.loop = false;
    //                index++;
    //                if (moviePanel != null)
    //                {
    //                    if (Screen.width == 980f)
    //                    {
    //                        moviePanel.SetActive(true);
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                isEnter = false;
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
    //}

    public bool IsPlaying(MovieTexture movie)
    {
        Debug.Log(movie.isPlaying);
        return movie.isPlaying;
    }
}
