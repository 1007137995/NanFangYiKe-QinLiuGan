using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour 
{

    public Slider slider;
    public Text show;

    //百分比显示
    public Text s;

    public void Reset()
    {
        slider.value = 0;
    }

    public void SetText(string s)
    {
        show.text = s;
    }

    public IEnumerator Run(float time, float deltime)
    {
        Debug.Log("run");
        slider.value = 0;
        yield return new WaitForSeconds(deltime);
        this.gameObject.SetActive(true);
        while (slider.value < 100)
        {
            slider.value += 2;
            yield return new WaitForSeconds(time / 100);
        }
        this.gameObject.SetActive(false);
    }

    void Awake()
    {
        
    }

    void Start()
    {
        slider.value = 0;
        //show.text = "进度条";
    }

    void Update()
    {
        s.text = slider.value.ToString() + "%";
    }
}
