using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneChoosePanel : MonoBehaviour 
{

    //用于表示已经开启哪个场景，数字为几表示能进前几个场景
    public static int id = 1;

    int count;

    Button[] btns;

    void SetBtns()
    {
        for (int i = 0; i < count; i++)
        {
            if (i < id)
            {
                btns[i].interactable = true;
            }
            else
            {
                if (btns[i].tag.Equals("Choose"))
                {
                    btns[i].interactable = false;
                }
            }
        }
    }

    void Awake()
    {
        count = this.transform.childCount;
        btns = new Button[count];
        for (int i = 0; i < count; i++)
        {
            btns[i] = this.transform.GetChild(i).GetComponent<Button>();
        }
    }

	void Start () 
    {
        if (id > 1)
        {
            this.gameObject.SetActive(true);
        }
	}
	
	void Update () 
    {
        SetBtns();
	}
}
