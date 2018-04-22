using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnumAIScript : MonoBehaviour {

	public Transform player;
	public bool playerInSight;
	public float fieldOfViewAngle = 110f;
	public SphereCollider col;

	public enum GameState 
	{
		Patrol,
		Chase,
		Search,
		Attack
	}

	public GameState state;
	public Vector3 lastSeenPos;
	public Transform[] waypoints;
	private NavMeshAgent agent;
	public int currentWp = 0;
	public float accuracyWp = 2f;
	public float speed = 2f;
	public float rotSpeed = 1f;


	void Start()
	{
		state = GameState.Patrol;
		agent = GetComponent<NavMeshAgent> ();

	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player") 
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
					state = GameState.Search;
				}
			}
		}
	}

	void Update()
	{

		if (state == GameState.Patrol && waypoints.Length > 0) 
		{
			agent.destination = waypoints [currentWp].position;
			//currentWp = (currentWp + 1) % waypoints.Length;
			if (agent.remainingDistance <= 0)
			{
				currentWp++;
				if (currentWp >= waypoints.Length) 
				{
					currentWp = 0;
				}
			}


		}

	}




}
