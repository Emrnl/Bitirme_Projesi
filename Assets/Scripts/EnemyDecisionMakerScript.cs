using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDecisionMakerScript : MonoBehaviour {


	public float patrolSpeed = 20f;
	public float chaseSpeed = 30f;
	public float chaseWaitTime = 50f;
	public float patrolWaitTime = 10f;
	public Transform[] patrolWaypoints;

	private EnemySightScript enemySight;
	private UnityEngine.AI.NavMeshAgent nav;
	private Transform player;
	private EnemySightScript lastSeenPos;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;


	void Awake ()
	{
		enemySight = GetComponent<EnemySightScript> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}


	void Update()
	{
		if (enemySight.playerInSight) {

			Chasing ();

		} else

			Patrolling ();
	}


	void Chasing()
	{
		Debug.Log ("chasing");

		Vector3 sightingDeltaPos = enemySight.playerLastSeenPos - transform.position;

		if (sightingDeltaPos.sqrMagnitude < 4) {
			nav.destination = enemySight.playerLastSeenPos;
			nav.speed = chaseSpeed;

			if (nav.remainingDistance < nav.stoppingDistance) 
			{
				chaseTimer += Time.deltaTime;

				if (chaseTimer >= chaseWaitTime) 
				{
					lastSeenPos.playerLastSeenPos = lastSeenPos.resetPosition;
					enemySight.personalLastSighting = lastSeenPos.resetPosition;
					chaseTimer = 0f;
				}
			}
		} else
			chaseTimer = 0f;
	}

	void Patrolling()
	{

		Debug.Log ("patrolling");

		nav.speed = patrolSpeed;

		if (nav.destination == lastSeenPos.resetPosition || nav.remainingDistance < nav.stoppingDistance) 
		{
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTime) 
			{
				if (wayPointIndex == patrolWaypoints.Length - 1)
					wayPointIndex = 0;
				else
					wayPointIndex++;

				patrolTimer = 0;
			}
		} else
			patrolTimer = 0;

		nav.destination = patrolWaypoints [wayPointIndex].position;

	}
		
}
