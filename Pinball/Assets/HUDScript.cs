using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	
	float startTime;
	float newTime;
	int minutes;
	int seconds;
	
	int balls;
	
	public void decreaseBalls()
	{
		balls--;	
	}
	
	void Start()
	{
		balls = 7;
		startTime = Time.time;
	}

	void OnGUI () {
		
		newTime = Time.time - startTime;
		
		minutes = 2 -(int) newTime/60;
		seconds = 59 -(int) newTime%60;
		
		GUI.TextArea(new Rect(Screen.width - 90,10,80,20),"Balls Left: " + balls);
		
		if (seconds < 10)
		{
			GUI.TextArea(new Rect(20,10,100,20), "Time Left - "+minutes+":0"+seconds);
		}
		else
		{
			GUI.TextArea(new Rect(20,10,100,20), "Time Left - "+minutes+":"+seconds);
		}
		
		if(balls == 0 || minutes == 0 && seconds == 0)
		{
			if (balls == 0)
			{
				GUI.TextArea (new Rect(Screen.width/2 - 75, Screen.height/2 - 20, 130, 20), "You ran out of balls!");
			}
			else
			{
				GUI.TextArea (new Rect(Screen.width/2 - 75, Screen.height/2 - 20, 130, 20), "You ran out of Time!");
			}
			
			if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 0,130, 50), "Try Again")) 
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 50, 130, 50), "Quit"))
			{
				Application.Quit();	
			}
		}
	}
}
