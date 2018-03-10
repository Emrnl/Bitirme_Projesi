using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StunObject Tag = StunCollectible
// Player object needs a proper rigidbody

public class Player_ItemInteraction : MonoBehaviour {

	public GameObject O_PlayerObject;
	public GameObject O_StunCollectible;
	public int Int_CollectibleCount;
	public Text T_StunCounter;
	// Use this for initialization
	void Awake () 
	{
		O_PlayerObject = gameObject;
		Int_CollectibleCount = 0;
		TextController ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "StunCollectible") // Change Tag Here!!! 
		{
			Int_CollectibleCount += 1;
			TextController ();
			Destroy (other.gameObject);
		}

	}

	void UseStunCollectible()
	{
		if (Int_CollectibleCount >= 1) 
		{
			Int_CollectibleCount -= 1;
			TextController ();
		} 
		else 
		{
			Debug.Log ("No Ammo"); 
		}
	}

	void TextController()
	{
		if (Int_CollectibleCount > 0)
		T_StunCounter.text = "Darts: " + Int_CollectibleCount.ToString ();
		else
		T_StunCounter.text = "Out of Ammo";
	}


}

