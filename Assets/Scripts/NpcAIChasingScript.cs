using UnityEngine;
using System.Collections;

public class NpcAIChasingScript : MonoBehaviour {

	public Transform player;
	public Transform head;
	Animator anim;
	public float distanceToPlayer = 3f;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWp = 0;
	float rotSpeed = 0.5f;
	float speed = 3f;
	float accuracyWp = 5.0f;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, head.forward);
		
		if (state == "patrol" && waypoints.Length > 0) 
		{
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
			if (Vector3.Distance (waypoints [currentWp].transform.position, transform.position) < accuracyWp) //waypointin pozisyonu enemy pozisyonuyla kıyasla
			{
				currentWp++;  // circle 
				if (currentWp >= waypoints.Length) 
				{
					currentWp = 0;
				}
			}

			//dön bakalım
			direction = waypoints[currentWp].transform.position - transform.position;  
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}




		if (Vector3.Distance (player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing")) {  // eğer görebiliyorsam
			
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,Quaternion.LookRotation (direction),rotSpeed * Time.deltaTime);
			
		
			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 5) {
				
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);

			} else {
			
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
		
			}
		}
		else
		{
 
			anim.SetBool("isWalking", true);
			anim.SetBool("isAttacking", false);
			state = "patrol";
		}

	}
}
