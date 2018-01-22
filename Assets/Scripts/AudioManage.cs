using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManage : MonoBehaviour
{

    public static readonly AudioManage instance = new AudioManage();

    public AudioSource m_AudioMgr;


    private AudioClip playClip;
    private List<AudioClip> AllClip = new List<AudioClip>();
    private string curMusicName = "";

    private AudioManage()
    {
        init();
    }

    public void init()
    {

    }

    public void PlayBG(string fileName)
    {
        if (!fileName.Equals(curMusicName))
        {
            //playClip = Resources.Load("Audio/" + fileName) as AudioClip;
            //m_AudioMgr.clip = playClip;
            //m_AudioMgr.Play();
            //curMusicName = fileName;
        }
        //Debug.Log("背景音乐: "+fileName);
    }

    public void PlayBG(AudioClip m_PlayClip)
    {
        m_AudioMgr.clip = m_PlayClip;
        m_AudioMgr.Play();
    }

    public void StopBG()
    {
        m_AudioMgr.Stop();
        curMusicName = "";
    }

    public AudioSource Play(AudioClip clip, Transform emitter, bool loop)
    {
        return Play(clip, emitter, 1f, 1f, loop);
    }

    public AudioSource Play(AudioClip clip, Transform emitter, float volume, bool loop)
    {
        return Play(clip, emitter, volume, 1f, loop);
    }


    public AudioSource Play(AudioClip clip, Transform emitter, float volume, float pitch, bool loop)
    {
        GameObject go = new GameObject("Audio:" + clip.name);
        go.transform.position = emitter.position;
        go.transform.parent = emitter;
        go.tag = "audio";
        // create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;

        if (!loop)
        {
            GameObject.Destroy(go, clip.length + 1);
        }

        return source;
    }

    public AudioSource Play(AudioClip clip, bool loop)
    {
        if (clip)
            return Play(clip, Vector3.zero, 1f, 1f, loop);
        else
        {
            return null;
        }
    }

    public AudioSource Play(AudioClip clip, Vector3 point, float volume, bool loop)
    {
        return Play(clip, point, volume, 1f, loop);
    }


    public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch, bool loop)
    {
        GameObject go = new GameObject("Audio:" + clip.name);
        go.transform.position = point;
        go.tag = "audio";
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
        source.Play();
        if (!loop)
        {
            GameObject.DestroyObject(go, clip.length + 1);
        }
        return source;
    }

    public bool IsPlaying(AudioSource source)
    {
        return source.isPlaying;
    }

    public AudioSource PlayVoice(string name)
    {
        AudioClip objPrefab = (AudioClip)Resources.Load("Audio/" + name);
        return Play(objPrefab, false);
    }


    //选择商店商品及道具
    /* public void playSelectItem()
     {
         AudioClip clip = ResManager.Instance.loadSound(Config.MUSIC_ROOT_PATH + "shop_select");
         Play(clip, false);
     }

     //购买道具
     public void playBuyItem()
     {
         AudioClip clip = ResManager.Instance.loadSound(Config.MUSIC_ROOT_PATH + "shop_buyItem");
         Play(clip, false);
     }

     //coop 超时
     public void playTimeOut()
     {
         AudioClip clip = ResManager.Instance.loadSound(Config.MUSIC_ROOT_PATH + "timeover");
         Play(clip, false);
     }

     public void playBtnClick()
     {
         AudioClip clip = ResManager.Instance.loadSound(Config.MUSIC_ROOT_PATH + "sound_button");
         Play(clip, false);
     }*/
}