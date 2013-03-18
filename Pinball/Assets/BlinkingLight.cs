using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {

	[SerializeField]
	Light[] _lights = new Light[6];
	float timer;
	float wait;

	
	// Use this for initialization
	void Start () {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Light");
		wait = Random.Range(0f, 3f);
		for(int i = 0; i<gos.Length;i++)_lights[i]=gos[i].GetComponent<Light>();
		//InvokeRepeating("Blink", 0.01f,2.0f);
		
	}
	void update(){
		timer +=Time.deltaTime;
		if(timer>wait){
		Blink();
			timer =0f;
			wait = Random.Range (0f, 3f);
		}  }
		
	void Blink(){
		foreach(Light lgt in _lights)lgt.enabled = !lgt.enabled;
	
	}
	
	
}