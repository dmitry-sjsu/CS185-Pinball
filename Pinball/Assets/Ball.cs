using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = Vector3.zero;
	}
	
	float ballVelocity = 1.5f;
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("Score").guiText.text = this.gameObject.rigidbody.velocity.magnitude.ToString();
	
	}
	
	void OnCollisionExit (Collision obj) {
		if ((obj.gameObject.name == "FlipperR") || (obj.gameObject.name == "FlipperL"))
		{
/*		if (obj.rigidbody.angularVelocity.y > 0f || obj.rigidbody.rotation.y > 0f)
		{
				Vector3 velocity = this.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y, velocity.z + 2.0f);
				this.rigidbody.velocity = velocity;
			}*/
		}			 
	}

	void OnCollisionContinue (Collision obj) {
		float magnitude;
		Vector3 velocity = rigidbody.velocity;
		magnitude = velocity.magnitude;
		velocity.Normalize();
		velocity *= .9f * magnitude;
		rigidbody.velocity = velocity;
	}
}
