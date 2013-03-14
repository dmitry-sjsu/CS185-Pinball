using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {
	
	private Quaternion enterRotation, exitRotation;
	private Vector3 initialBallVelocity;
	
	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Ball")
		{
			enterRotation = this.transform.parent.transform.rotation;
			initialBallVelocity = obj.rigidbody.velocity;
		}
	}
	
	
	void OnCollisionExit (Collision obj) {
		float rotationChange;
		if (obj.gameObject.tag == "Ball")
		{
			exitRotation = this.transform.parent.transform.rotation;
			rotationChange = Quaternion.Angle(exitRotation, enterRotation);
			Debug.Log (rotationChange);
			Debug.DrawLine( this.transform.position, obj.transform.position, Color.red, 5);
	//		GameObject.FindGameObjectWithTag("Score").guiText.text = 				
	//				rotationChange.ToString();
			if (rotationChange > 15)
			{
				Vector3 velocity = obj.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y + rotationChange/10  , velocity.z);
				obj.rigidbody.velocity = velocity;
			}
			else
			{
				Vector3 velocity = obj.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y / 10, velocity.z);
				obj.rigidbody.velocity = velocity;
			}
		}
	}
}
