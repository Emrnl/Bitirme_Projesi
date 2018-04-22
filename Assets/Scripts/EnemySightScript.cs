using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightScript : MonoBehaviour {

	//public Vector3 position = new Vector3(1000f,1000f,1000f);
	//public Vector3 resetPosition = new Vector3 (1000f,1000f,1000f);

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;
	public Transform head;

	private UnityEngine.AI.NavMeshAgent nav;
	public SphereCollider col;
	public Animator anim;
	//public DoneLastPlayerSighting lastPlayerSighting;
	public GameObject player;
	public Animator playerAnim;
	public Vector3 previousSighting;


	void Awake()
	{
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		//col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAnim = player.GetComponent<Animator> ();

	//	personalLastSighting = lastPlayerSighting.resetPosition;
	//	previousSighting = lastPlayerSighting.resetPosition;
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;

				if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) 
				{
					playerInSight = true;
				}
			}
		}
	}

}
