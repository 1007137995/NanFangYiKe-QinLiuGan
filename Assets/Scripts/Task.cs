using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task : MonoBehaviour {

	public string id;//id
	public string caption;//任务描述

	public enum State
	{
		get,               //接受任务
		progress,          //进行任务
		finish,            //完成任务
		reward             //得到奖励
	}
	public State state = State.get;

	//接受任务时可能会触发：更新任务到任务面板中等操作
	public delegate void getDelegate(string info);
	public event getDelegate getEvent;

	//检查每个条件是否满足
	public delegate void checkDelegate(string id, int amount);
	public event checkDelegate checkEvent;

	//完成任务时可能会触发：提示完成任务等操作
	public delegate void finishDelegate(string info);
	public event finishDelegate finishEvent;

	//得到奖励时可能会触发：显示获取的物品等操作
	public delegate void rewardDelegate(string info);
	public event rewardDelegate rewardEvent;

	public List<TaskCondition> taskConditions = new List<TaskCondition>();
	public List<TaskReward> taskRewards = new List<TaskReward>();

	//根据id读取xml，进行初始化
	public Task(string id)
	{
		this.id = id;
		System.Xml.Linq.XElement xe = TaskManager.instance.xElement.Element("Task" + id);

		IEnumerable<System.Xml.Linq.XElement> a = xe.Elements("conditionID");
		IEnumerator<System.Xml.Linq.XElement> b = xe.Elements("conditionTargetAmount").GetEnumerator();

		IEnumerable<System.Xml.Linq.XElement> c = xe.Elements("rewardID");
		IEnumerator<System.Xml.Linq.XElement> d = xe.Elements("rewardAmount").GetEnumerator();

		foreach (var s in a)
		{
			b.MoveNext();
			TaskCondition tc = new TaskCondition(s.Value, 0, int.Parse(b.Current.Value), false);
			taskConditions.Add(tc);
			checkEvent += tc.Check;
		}

		foreach (var s in c)
		{
			d.MoveNext();
			TaskReward tr = new TaskReward(s.Value, int.Parse(d.Current.Value));
			taskRewards.Add(tr);
		}

		getEvent += Notification.instance.PrintInfo;
		finishEvent += Notification.instance.PrintInfo;
		rewardEvent += Notification.instance.PrintInfo;
		Get();
	}

	//接受任务
	public void Get()
	{
		getEvent("接受任务Task" + this.id);
		state = State.progress;
	}

	//判断条件是否满足
	public void Check(string id, int amount)
	{
		checkEvent(id,amount);
		for(int i = 0;i < taskConditions.Count;i++)
		{
			if(!taskConditions[i].isFinish)
			{
				state = State.progress;
				return;
			}
		}
		state = State.finish;
		Finish();
	}

	//完成任务
	public void Finish()
	{
		finishEvent("任务" + this.id + "完成！！");
		state = State.reward;
	}

	//获取奖励
	public void Reward()
	{
		if (state != State.reward) return;
		TaskReward tr;
		for (int i = 0; i < taskRewards.Count; i++)
		{
			tr = taskRewards[i];
			rewardEvent("奖励物品" + tr.id + "奖励数量" + tr.amount);
		}
		DestroyTask();
	}

	public void DestroyTask()
	{
		Notification.instance.PrintInfo("奖励已获取，或者任务被取消！！");
		TaskManager.instance.tasks.Remove(this);
		TaskManager.instance.getEvent -= this.Get;
		TaskManager.instance.checkEvent -= this.Check;
		TaskManager.instance.rewardEvent -= this.Reward;
		Destroy(this);
	}
}