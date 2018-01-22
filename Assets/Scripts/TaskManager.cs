using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;


/// <summary>
/// 思路(这里以怪物被消灭后为例)：
//1.怪物消灭后发送信息给监听它的东西，例如得分增加，经验上升等等，其中包括发送给我们的TaskManager

//2.TaskManager将信息传递到正在执行的任务Task

//3.任务Task再将信息传递到该任务的条件

//这里为什么不直接将怪物消灭后的信息直接发送给条件呢？因为这个消息不知道哪个条件在监听它，而条件也不知道要监听哪些消息，这时就需要TaskManager这个中间体了

//虽然消息传递很曲折，但是事件委托的效率比较高，所以应该不用担心效率方面的问题
/// </summary>
public class TaskManager : MonoBehaviour {

	public static TaskManager instance;
	public XElement xElement;
	public List<Task> tasks = new List<Task>();

	//接受任务时可能会触发：更新任务到任务面板中等操作
	public delegate void getDelegate();
	public event getDelegate getEvent;

	//检查每个条件是否满足
	public delegate void checkDelegate(string id, int amount);
	public event checkDelegate checkEvent;

	//得到奖励时可能会触发：显示获取的物品等操作
	public delegate void rewardDelegate();
	public event rewardDelegate rewardEvent;

	void Awake()
	{
		if (!instance)
			instance = this;
		else
			Destroy(this);    
	}

	void Start () 
	{
		xElement = XElement.Load(Application.dataPath + "/TestTask/Task.xml");//得到根元素
	}

	public void CreateTask(string id)
	{
		for (int i = 0; i < tasks.Count; i++)
		{
			if (tasks[i].id == id)
				return;
		}

		Task t = new Task(id);
		tasks.Add(t);
		getEvent += t.Get;
		checkEvent += t.Check;
		rewardEvent += t.Reward;
	}

	public void RemoveTask(string id)
	{
		for (int i = 0; i < tasks.Count; i++)
		{
			if (tasks[i].id == id)
				tasks[i].DestroyTask();
		}
	}

	public void Get()
	{
		if (getEvent != null)
			getEvent();
	}

	public void Check(string id, int amount)
	{
		if (checkEvent != null)
			checkEvent(id,amount);
	}

	public void Reward()
	{
		if (rewardEvent != null)
			rewardEvent();
	}
}