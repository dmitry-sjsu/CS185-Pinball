using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	float ballVelocity = 1.5f;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit (Collision obj) {
		if ((obj.gameObject.name == "FlipperR") || (obj.gameObject.name == "FlipperL"))
		{
			if (this.rigidbody.velocity.magnitude < ballVelocity)
			{
				Vector3 velocity = this.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y, velocity.z + 2.0f);
		//			Vector3.Normalize(velocity) * ballVelocity;
				this.rigidbody.velocity = velocity;
			}
		}
	}

	
}
