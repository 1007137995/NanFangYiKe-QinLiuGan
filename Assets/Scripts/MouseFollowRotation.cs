using UnityEngine;
/// <summary>
/// Mouse follow rotation.
/// </summary>
public class MouseFollowRotation : MonoBehaviour {
	
	public Transform target;			
	public float xSpeed=100, ySpeed=100, mSpeed=2;
	public float yMinLimit=0, yMaxLimit=0;
	public float xMinLimit=0, xMaxLimit=0;
	public float distance=-3, minDistance=-3f, maxDistance=-2;
	//public float  minDistanceY=10.0f, maxDistanceY=50.0f;
	
	bool needDamping = false;
	//public bool needDamping =true; 
	float damping = 5.0f;
	
	public float x = 0.0f;
	public float y = 0.0f;
	
	public Camera Cam;
	
	public float distanceY=0.0f;
	
	
	
	
	
	
	
	
	
	public void SetTarget( GameObject go )
		
		
	{
		target = go.transform;
	}
	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (target) 
		{
			//use the light button of mouse to rotate the camera
			if( Input.GetMouseButton(1))
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

				x = ClampAngle(x, xMinLimit, xMaxLimit);
				y = ClampAngle(y, yMinLimit, yMaxLimit);
			
				
				//print(Input.GetAxis("Mouse X"));
				//print( Input.GetAxis("Mouse Y"));
				//print(x);
				//print(y);
				
				
				
			} 
			if( Input.GetMouseButton(0))
			{
				
				
				distanceY += Input.GetAxis("Mouse Y") * ySpeed * 0.002f;
				
				
				
				
				
				
				
				//distanceY = Mathf.Clamp(distanceY, minDistanceY, maxDistanceY);
				//print(Input.GetAxis("Mouse X"));
				//print( Input.GetAxis("Mouse Y"));
				//print(x);
				//print(y);
				
				
				
			} 
			/*if((Input.mousePosition.x > 0)&& 
				   (Input.mousePosition.x < Screen.width * leftCam.rect.width)&&
				   (Input.mousePosition.y > Screen.height * leftCam.rect.y)&&
				   (Screen.height > Input.mousePosition.y))
				{*/
			//if((Input.mousePosition.x > 0)&& 
			//   (Input.mousePosition.x < Screen.width * leftCam.rect.width)&&
			//   (Input.mousePosition.y > Screen.height * leftCam.rect.y)&&
			 //  (Screen.height > Input.mousePosition.y))
			//{
				distance -= Input.GetAxis("Mouse ScrollWheel")*mSpeed;
				
				distance = Mathf.Clamp(distance, minDistance, maxDistance);
				
				
			//}
			Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
			Vector3 disVector = new Vector3( 0.0f, 0.0f, -distance );
			Vector3 position = rotation * disVector+target.position;
			
			//adjust the camera
			if( needDamping )
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*damping);
				transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime*damping);
			}
			else
			{
				transform.rotation = rotation;
				transform.position = position;
			}
			
			
		}
		
	}	
	static float ClampAngle (float angle, float min, float max) 
	{
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}