using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 15;
	public Texture minorDamage;
	public Texture moderateDamage;
	public Texture severeDamage;

	void OnCollisionEnter( Collision obj ) {
		--health;
		
		if(health <= 12)
		{
			renderer.material.mainTexture = minorDamage;
		}
		else if (health <= 7)
		{
			renderer.material.mainTexture = moderateDamage;
		}
		else if (health <= 2)
		{
			renderer.material.mainTexture = severeDamage;
		}
		else if (health <= 0) 
		{
			Destroy(gameObject);
		}
	}
}
