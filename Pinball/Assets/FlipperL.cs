using UnityEngine;
using System.Collections;

public class FlipperL : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		downPoint = Quaternion.Euler(358f, downAngle, 1f);
		upPoint = Quaternion.Euler(358f, upAngle, 359);		
	}
	private Quaternion downPoint, upPoint;
	
	private float downAngle = 210f;
	private float upAngle = 150f;
	private float flipperSpeed = 40f;
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow))
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
		GameObject.FindGameObjectWithTag("Score").guiText.text = this.gameObject.transform.rotation.y.ToString() + "U";

	}
	
	void Fall()
	{
		this.gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.localRotation, downPoint, flipperSpeed * Time.fixedDeltaTime);
		GameObject.FindGameObjectWithTag("Score").guiText.text = this.gameObject.transform.rotation.y.ToString() + "D";

	}

}
