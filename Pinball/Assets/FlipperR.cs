using UnityEngine;
using System.Collections;

public class FlipperR : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		downPoint = Quaternion.Euler(358f, downAngle, 1);
		upPoint = Quaternion.Euler(358f, upAngle, 359);		
	}
	private Quaternion downPoint, upPoint;
	
	private float downAngle = 330f;
	private float upAngle = 30f;
	private float flipperSpeed = 40f;
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.Flip ();
		}
		else {
			this.Fall();
		}

	}
	
	void Flip()
	{
		this.gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.localRotation, upPoint, flipperSpeed * Time.fixedDeltaTime);
	}
	
	void Fall()
	{
		this.gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.localRotation, downPoint, flipperSpeed * Time.fixedDeltaTime);
	}
}
