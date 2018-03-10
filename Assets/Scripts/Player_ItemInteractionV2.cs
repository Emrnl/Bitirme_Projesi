using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StunObject Tag = StunCollectible
// Player object needs a proper rigidbody

public class Player_ItemInteractionV2 : MonoBehaviour {

	public GameObject O_PlayerObject;
	public float Int_Energy;
	public Text T_EnergyCounter;
	public Image I_Battery;
	// Use this for initialization
	void Awake () 
	{
		O_PlayerObject = gameObject;
		Int_Energy = 0;
		TextController ();
		ImageController ();

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "StunCollectible") // Change Tag Here!!! 
		{
			Int_Energy += .25f;
			TextController ();
			ImageController ();
			Destroy (other.gameObject);
		}

	}

	void UseStunCollectible()
	{

		if (Int_Energy >= 1) 
		{
			Int_Energy -= .25f;
			TextController ();
			ImageController ();
		} 
		else 
		{
			Debug.Log ("Decharged"); 
		}
	}

	void TextController()
	{
		if (Int_Energy > 0)
			T_EnergyCounter.text = "Energy %: " + (Int_Energy*100).ToString ();
		else
			T_EnergyCounter.text = "Out of Energy";
	}

	void ImageController()
	{
		I_Battery.fillAmount = Int_Energy;
		if (Int_Energy <= .25) 
		{
			I_Battery.color = new Color (255, 0, 0, 100);
		}
		if (Int_Energy >.25 && Int_Energy<.5 ) 
		{
			I_Battery.color = new Color (192, 63, 0, 100);
		}
		if (Int_Energy >=.5 && Int_Energy<.75 ) 
		{
			I_Battery.color = new Color (129, 126, 0, 100);
		}
		if (Int_Energy >=.75 && Int_Energy<=1 ) 
		{
			I_Battery.color = new Color (0, 255, 0, 100);
		}

	}
}
