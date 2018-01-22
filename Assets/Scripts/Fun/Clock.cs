using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    
    int second;
    int minute;

    int time;

    public Text secondText;
    public Text minuteText;

    public void SetTime(int time)
    {
        this.time = time;
    }

    public void SetTime(int m, int s)
    {
        time = m * 60 + s;
        minute = m;
        second = s;
    }

    string TransferFormat(int time)
    {
        if (time < 10)
        {
            return "0" + time.ToString();
        }
        else return time.ToString();
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    void Awake()
    {

    }

	void Start () 
    {
        time = 0;
        StartCoroutine(StartTimer());
	}
	
	void Update () 
    {
        minute = time / 60;
        second = time % 60;
        minuteText.text = TransferFormat(minute);
        secondText.text = TransferFormat(second);
	}
}
