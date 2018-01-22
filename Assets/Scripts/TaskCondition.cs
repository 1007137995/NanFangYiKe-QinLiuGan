using UnityEngine;
using System.Collections;

public class TaskCondition
{
	public string id;//条件id
	public int nowAmount;//条件id的当前进度
	public int targetAmount;//条件id的目标进度
	public bool isFinish = false;//记录是否满足条件

	public TaskCondition(string id, int nowAmount, int targetAmount, bool isFinish)
	{
		this.id = id;
		this.nowAmount = nowAmount;
		this.targetAmount = targetAmount;
		this.isFinish = isFinish;
	}

	public void Check(string id, int amount)
	{
		if (id == this.id)
		{
			nowAmount += amount;
			if (nowAmount >= targetAmount)
				isFinish = true;
			else
				isFinish = false;
		}
	}
}