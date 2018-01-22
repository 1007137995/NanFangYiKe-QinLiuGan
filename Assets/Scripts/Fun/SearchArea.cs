using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchArea : MonoBehaviour
{

    public GameObject btn;

	void Start ()
    {
        
	}
	
	void Update () 
    {
        
	}

    void OnTriggerStay(Collider p)
    {
        if(p.tag.Equals("Claims"))
        {
            btn.SetActive(true);
        }
    }

    void OnTriggerExit(Collider p)
    {
        if (p.tag.Equals("Claims"))
        {
            btn.SetActive(false);
        }
    }
    
}
