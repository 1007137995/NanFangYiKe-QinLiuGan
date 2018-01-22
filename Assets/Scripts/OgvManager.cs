using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OgvManager : MonoBehaviour {

    public static OgvManager instance;
    private MovieTexture movTexture = new MovieTexture();
    private bool isEnter = false;
    private int index = 0;
    public List<MovieTexture> movTextureList = new List<MovieTexture>();
    public GameObject moviePanel;
    //public Texture closeImg;

    void Start()
    {
        instance = this;
        playMov("xixiaoqu");
        GUI.DrawTexture(new Rect(160f, 100, 600f, 400f), movTexture, ScaleMode.StretchToFill);
        movTexture.Play();
    }

    public MovieTexture playMov(string movName)
    {
        index = 0;
        foreach (MovieTexture mov in movTextureList)
        {
            if (mov.name == movName)
            {
                movTexture = mov;
            }
        }
        isEnter = true;
        return movTexture;
    }

    public void closeMov()
    {
        isEnter = false;
        if (moviePanel != null)
        {
            moviePanel.SetActive(false);
        }
    }

    public bool IsPlaying(MovieTexture movie)
    {
        return movie.isPlaying;
    }

    void OnGUI()
    {
        if (isEnter)
        {
            //绘制电影纹理
            
            
            //if (GUI.Button(new Rect(43.5f + 239f - 6f, Screen.height - 494.4f - 10f, 20f, 20f), closeImg))
            //{
            //    isEnter = false;
            //    moviePanel.SetActive(false);
            //}

            //if (!movTexture.isPlaying)
            //{
            //    isEnter = false;
            //    if (moviePanel != null)
            //    {
            //        moviePanel.SetActive(false);
            //    }
            //}
            //GUI.Label(new Rect(Screen.width / 2f - 50f, Screen.height - 50f, 200f, 100f), "点击屏幕可跳过视频");
            if (Input.GetMouseButtonDown(0))
            {
                isEnter = false;
                movTexture.Stop();
                closeMov();
                //  goScene();
            }
        }
    }
}
