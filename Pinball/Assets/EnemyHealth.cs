using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 15;

	void OnCollisionEnter( Collision obj ) {
		--health;
		
		if( health <= 0 ) {
			Destroy ( gameObject );
		}
	}
}
