using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	
	public int health = 5;

	void OnCollisionEnter( Collision obj ) {
		--health;
		
		
	}
}


