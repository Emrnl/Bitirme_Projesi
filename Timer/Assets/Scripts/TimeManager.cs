using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//This is basic timer blyat

public class TimeManager : MonoBehaviour {

	public float Time_TimeRemain;
	public Text TimeText;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time_TimeRemain -= Time.deltaTime;
		TimeText.text = "" +Mathf.Round(Time_TimeRemain).ToString ();
        TimeText.color = new Color32(26, 38, 118, 255);
	}
}
