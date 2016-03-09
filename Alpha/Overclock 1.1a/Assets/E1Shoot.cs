using UnityEngine;
using System.Collections;

public class E1Shoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	private GameObject bullInst;

	private bool canShoot = false;
	private bool pexit = false;

	[SerializeField] private Transform bullSpawn;
	[SerializeField] private Transform target;
	[SerializeField] private float bullSpeed;
	[SerializeField] private float waitTime;

	private Vector3 dir;
	private float lookDir;

	void Update ()
	{
		dir = target.transform.position - transform.position;
		lookDir = target.transform.position.x - transform.position.x;

		if (canShoot == true)
			StartCoroutine ("shooter");
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			canShoot = true;
			pexit = false;
		}
	}

	void OnTriggerExit2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			pexit = true;
		}
	}

	IEnumerator shooter ()
	{
		transform.localRotation = (lookDir <= 0) ? Quaternion.Euler (0, 0, 0) : Quaternion.Euler (0, 180, 0);
		
		bullInst = GameObject.Instantiate (bulletPrefab, bullSpawn.position, transform.rotation) as GameObject;
		bullInst.GetComponent<Rigidbody2D> ().velocity = dir.normalized * bullSpeed;
		canShoot = false;
		GameObject.Destroy (bullInst, 10);

		yield return new WaitForSeconds (waitTime);
		if (! (pexit == true))
			canShoot = true;
	}
}
