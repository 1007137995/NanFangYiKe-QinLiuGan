using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MouseCheck : MonoBehaviour
{
    private Transform _ButtonPanle;

    private void Start()
    {
        _ButtonPanle = GameObject.Find("Canvas/ButtonPanle").transform;
    }
    public void OnMouseEnter()
    {
        _ButtonPanle.DOLocalMoveX(-429, 0.5f);
        GetComponent<BoxCollider2D>().offset = new Vector2(55, 0.13f);
        GetComponent<BoxCollider2D>().size = new Vector2(121, 510.6f);
    }
    public void OnMouseExit()
    {
        _ButtonPanle.DOLocalMoveX(-550, 0.5f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.13f);
        GetComponent<BoxCollider2D>().size = new Vector2(11.3f, 0510.6f);
    }
}
