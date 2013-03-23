using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	Vector3 ballVelocity = new Vector3 (0f, 0f, 0f);
	private int numBallsUsed = 7;
	GameObject[] topFlippers;
	public GameObject LaunchBlock;
	public BlockBehavior blockController;
	
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (0.85f, -.3f, -.05f);
		this.gameObject.rigidbody.velocity = ballVelocity;
		GameObject.FindGameObjectWithTag("BallsLeft").guiText.text = 				
					numBallsUsed.ToString();
		topFlippers = GameObject.FindGameObjectsWithTag("Flipper2");
		LaunchBlock = GameObject.Find("LauncherBlock");
		blockController = (BlockBehavior) LaunchBlock.GetComponent(typeof(BlockBehavior));
		blockController.unBlock();
	}
		
	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Bottom")
		{
			numBallsUsed--;			
			this.Start();
			
			if(numBallsUsed <=0){
			Debug.Log("Game Over");
			Destroy(gameObject); }
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
		GameObject.FindGameObjectWithTag("Score").guiText.text = "L2 !";
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, -.05f);
		}
	}

	void BottomSide() {
		GameObject.FindGameObjectWithTag("Score").guiText.text = "L1 again";
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, .15f);
		}
	}	
}
