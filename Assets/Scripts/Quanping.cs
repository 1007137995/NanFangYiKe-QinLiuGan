using UnityEngine;
using System.Collections;

public class Quanping : MonoBehaviour {

    public void FullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(980, 593, false);
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height,true);
        }
    }
}
