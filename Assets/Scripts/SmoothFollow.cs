using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SmoothFollow : MonoBehaviour
{


	Vector3 offset;

	void Start()
	{
		offset = Camera.main.transform.position - this.transform.position;

	}


	void Update()
	{
		Camera.main.transform.position = this.transform.position + offset;
	}
		

}