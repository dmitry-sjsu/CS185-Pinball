using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	public bool[] triggers;
	private GameObject tramp;
	
	void Start()
	{
		tramp = GameObject.FindGameObjectWithTag("Tramp");
	}

	void LightTriggerHit(int id)
	{
		if (!triggers[id])
			triggers[id] = true;
		
		bool openGate = true;
		foreach (bool trigger in triggers)
			if (!trigger)
				openGate = false;
		
		if (openGate)
			LowerGate();
	}
	
	void LowerGate()
	{
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, .15f);
		if (this.tag == "TopGate")
			tramp.transform.position = new Vector3(tramp.transform.position.x, tramp.transform.position.y, -.1f);  
			
	}
}


