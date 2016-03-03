using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {


	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatNotToHit;
	public Transform bulletPrefab;
	public Transform bulletSpawn;
	private float timeToShoot = 0;

	void Awake(){
		Debug.Log (transform.FindChild("ArmPivot") == null);
		Debug.Log (transform.FindChild("Arm") == null);
	}

	void Update () {
		if(Input.GetMouseButton(0))
			Shoot ();
	}

	void Shoot(){
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePosition, (mousePosition - firePosition), 1, whatNotToHit);
		if (Time.time >= timeToShoot) {
			Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			timeToShoot = Time.time;
		}

		if (hit.collider != null) {
			Debug.Log ("Hit " + hit.collider.name + " " + hit.collider.gameObject.tag);
			if (hit.collider.gameObject.tag == "Player") {
				Player p = hit.collider.GetComponent<Player> ();
				if (p != null) {
					Debug.Log ("Now it actually hit");
					p.DamagePlayer (10);
				}
			}
			//Debug.DrawLine (firePosition, hit.point, Color.red);
		}
	}
}