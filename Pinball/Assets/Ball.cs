using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	Vector3 ballVelocity = new Vector3 (0f, .5f, 0f);
	private int numBallsUsed = 0;

	
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (0.85f, 0f, -.05f);
		this.gameObject.rigidbody.velocity = ballVelocity;
		GameObject.FindGameObjectWithTag("BallsLeft").guiText.text = 				
					numBallsUsed.ToString();

	}
		
	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Bottom")
		{
			numBallsUsed++;
			this.Start();
		}
	}
}
