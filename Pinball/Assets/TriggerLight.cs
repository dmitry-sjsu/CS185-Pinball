using UnityEngine;
using System.Collections;

public class TriggerLight : MonoBehaviour {
	public Texture2D litTexture;
	public Texture2D darkTexture;
	public int id;
	
	private GameObject gate;
	
	// Use this for initialization
	void Start () {
		gate = GameObject.FindGameObjectWithTag("Gate");
	}
	
	void OnTriggerExit (Collider obj) {
		this.gameObject.light.enabled = true;
		this.renderer.material.mainTexture = litTexture;
		this.light.enabled = true;
		gate.SendMessage("LightTriggerHit", id);
	}
}
