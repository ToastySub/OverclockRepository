using UnityEngine;
using System.Collections;

public class DroneEnemy : MonoBehaviour
{
	
	float xOffset;
	float yOffset;
	float leftRight;
	private Transform target;
	private GameObject player;
	public GameObject droneDestroy;
	private bool leftSide = false;
	private bool rightSide = false;
	private bool flipped = false;
	public Enemies stats;


	void Awake(){
		leftRight = Random.value;
		xOffset = 2 + Random.value * 6;
		yOffset = 2 + Random.value * 2;
	}
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		leftRight = Random.value / 2 + 0.5f;
	}
	void Update ()
	{
		if (stats.currentHealth < 0) {
			Destroy (gameObject);
			DroneDeath ();
		}
			if (player.transform.position.x > transform.position.x) {
				leftSide = true;
				rightSide = false;
			} else if (player.transform.position.x < transform.position.x) {
				leftSide = false;
				rightSide = true;
			}
		
			if (leftSide == true && flipped == false) {
				transform.Rotate (new Vector3 (0, 180, 0));
				flipped = true;
				xOffset *= -1;
			} else if (rightSide == true && flipped == true) {
				transform.Rotate (new Vector3 (0, 180, 0));
				flipped = false;
				xOffset *= -1;
			}


			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + xOffset, 
				target.transform.position.y + yOffset, 
				target.transform.position.z), Time.deltaTime * leftRight);
		}
	void DroneDeath()
	{
		Destroy (gameObject);
		Instantiate (droneDestroy, transform.position, transform.rotation);
	}
}