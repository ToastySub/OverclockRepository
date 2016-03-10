using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {
	private float rotateTimer = 0;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * 50);
		transform.Rotate (Vector3.forward * 5000);
	}
	
	void Update () {
		rotateTimer += Time.deltaTime;
		if (rotateTimer < 2)
			transform.Rotate (Vector3.forward * -20);
		}
}