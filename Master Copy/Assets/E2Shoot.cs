using UnityEngine;
using System.Collections;

public class E2Shoot : MonoBehaviour
{
	private bool canFollow = false;

	public Transform target;
	public float offset;

	void Update ()
	{
		if (canFollow == true)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + offset, 
																				target.transform.position.y, 
																				target.transform.position.z), Time.deltaTime);
			
		}
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		canFollow = true;
	}
}
