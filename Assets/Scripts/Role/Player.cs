using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public GameObject[] items;
    public GameObject sceneBtn;

    public Camera cam;

    //发射探测地面射线，探测物体射线
    Ray ray;

    //射线检测的位置，射线检测的物体
    RaycastHit hit;

    //玩家所选择的物体（左键点击）
    public static GameObject chooseItem = null;

    //玩家所控制的物体（场景中生成并被控制的物体是唯一的）
    public static GameObject doItem = null;

    //无控制物体时探测物体
    public GameObject Search()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }
        else return null;
    }

    //移动物体
    public void MoveItem()
    {
        Vector3 item_world_position;
        Vector3 item_position = Camera.main.WorldToScreenPoint(doItem.transform.position);
        Vector3 mouse_position = Input.mousePosition;
        mouse_position.z = item_position.z;
        item_world_position.x = Camera.main.ScreenToWorldPoint(mouse_position).x;
        item_world_position.y = -0.5f;
        item_world_position.z = Camera.main.ScreenToWorldPoint(mouse_position).z;
        doItem.transform.position = item_world_position;
    }

    public void ChooseItem()
    {
        if (chooseItem != null)
        {
            if (chooseItem.tag.Equals("Box"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(11111111);
                    chooseItem.GetComponent<Box>().item.SetActive(true);
                }
            }
        }
    }

    bool CheckItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (!items[i].activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void OnGUI()
    {
        //GUI.color = Color.red;  

        if (chooseItem != null)
        {
            if (chooseItem.tag.Equals("Item") || chooseItem.tag.Equals("Box"))
            {
                GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 180, 25), chooseItem.name);
            }
        }

    }  

	void Start () 
    {
	
	}
	
	void Update ()
    {
        chooseItem = Search();
        ChooseItem();
        if (CheckItems())
        {
            sceneBtn.SetActive(true);
        }
	}
}
