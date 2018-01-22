using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour {

	[SyncVar]private Vector3 syncPos;
	[SyncVar]private Vector3 syncRation;
	[SerializeField]Transform myTransform;
	[SerializeField]float lerpRate = 15;

	void FixedUpdate()
	{
		TransformPosition();
		LerpPosition();
	}

	void LerpPosition()
	{
		if (!isLocalPlayer)
		{
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
			myTransform.eulerAngles = Vector3.Lerp(myTransform.eulerAngles, syncRation, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvidePositionToServer(Vector3 pos)
	{
		syncPos = pos;
	}

	[Command]
	void CmdProvideRotationToServer(Vector3 pos)
	{
		syncRation = pos;
	}

	[ClientCallback]
	void TransformPosition()
	{
		if (isLocalPlayer)
		{
			CmdProvidePositionToServer(myTransform.position);
			CmdProvideRotationToServer(myTransform.eulerAngles);
		}
	}

}