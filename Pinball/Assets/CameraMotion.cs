using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {
	private float bottomY, topY;
	private float cameraVelocity = .5f;
	private GameObject ball;
	
	// Use this for initialization
	void Start () {
		bottomY = -1.3f;
		topY = -.2f;
		ball = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 prevPosition = this.transform.position;
		if ((ball.rigidbody.velocity.y > 0) && (ball.transform.position.y > -0.4))
		{
			if (prevPosition.y < topY)
			{
				prevPosition = new Vector3(prevPosition.x, prevPosition.y + ball.rigidbody.velocity.y*Time.deltaTime/2, prevPosition.z);
				this.transform.position = prevPosition;
			}
		}
		else
		{
			if ((ball.rigidbody.velocity.y < 0) || (ball.transform.position.y < 0.5))
			{
				if (prevPosition.y > bottomY)
				{
					prevPosition = new Vector3(prevPosition.x, prevPosition.y + ball.rigidbody.velocity.y*Time.deltaTime/2, prevPosition.z);
					this.transform.position = prevPosition;
				}
			}			
		}
	}
}
