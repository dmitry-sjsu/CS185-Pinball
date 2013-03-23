using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	Vector3 ballVelocity = new Vector3 (0f, 0f, 0f);
	private int numBallsUsed = 7;
	GameObject[] topFlippers;
	public GameObject LaunchBlock;
	public BlockBehavior blockController;
	public HUDScript hudController;
	public GameObject mainCamera;
	
	
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (0.85f, -.3f, -.05f);
		this.gameObject.rigidbody.velocity = ballVelocity;
		topFlippers = GameObject.FindGameObjectsWithTag("Flipper2");
		LaunchBlock = GameObject.Find("LauncherBlock");
		blockController = (BlockBehavior) LaunchBlock.GetComponent(typeof(BlockBehavior));
		blockController.unBlock();
		mainCamera = GameObject.Find("Main Camera");
		hudController = (HUDScript) mainCamera.GetComponent(typeof(HUDScript));
	}
		
	void OnCollisionEnter (Collision obj) {
		
		if (obj.gameObject.tag == "Bottom")
		{
			numBallsUsed--;
			hudController.decreaseBalls();
			
			this.Start();
			
			if(numBallsUsed <=0){
			Debug.Log("Game Over");
			Destroy(gameObject); }
		}
		else
		{
			audio.Play ();	
		}
		
	}
	
	void OnTriggerExit (Collider obj) {
		if ((obj.gameObject.tag == "Level2") && (this.transform.position.y > 1.1))
		{
			TopSide();
		}
		if ((obj.gameObject.tag == "Level2") && (this.transform.position.y < 1))
		{
			BottomSide();
		}
	}
	
	void TopSide() {
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, -.05f);
		}
	}

	void BottomSide() {
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, .15f);
		}
	}	
}
