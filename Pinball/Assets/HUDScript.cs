using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	
	float startTime;
	float newTime;
	int minutes;
	int seconds;
	bool win;
	int enemiesDestroyed;
	
	int balls;
	
	public void decreaseBalls()
	{
		balls--;	
	}
	
	public void enemyDestroyed()
	{
		enemiesDestroyed++;
		if (enemiesDestroyed == 3)
		{
			win = true;
		}
	}
	
	void Start()
	{
		balls = 7;
		startTime = Time.time;
		win = false;
		enemiesDestroyed = 0;
	}

	void OnGUI () 
	{
		
		if (!win)
		{	
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
		
			if(balls == 0 || minutes <= 0 && seconds <= 0)
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
		else
		{
				GUI.TextArea (new Rect(Screen.width/2 - 95, Screen.height/2 - 20, 170, 20), "You Won! Congradulations!");
				if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 0,130, 50), "Play Again")) 
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
