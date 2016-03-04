using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour {

	public float damage = 10;
	public LayerMask whatToHit;
	public Transform bulletPrefab;
	public Transform bulletSpawn;
	private float shootInterval = 0.2f;
	[SerializeField] private int currentClip;
	[SerializeField] private int clipSize = 12;
	[SerializeField] private float reloadTime = 2.5f;
	private bool reloading = false;
	float shootTimer;




	void Awake(){
		currentClip = clipSize;
	}

	void Update () {
		shootTimer += Time.deltaTime;
		if (Input.GetMouseButton (0) && currentClip > 0 && reloading == false) 
			Shoot ();
		if (Input.GetKeyDown (KeyCode.R) && currentClip != clipSize && reloading == false) {
			reloading = true;
			StartCoroutine (Reloading ());
		}
	}

	IEnumerator Reloading(){
		yield return new WaitForSeconds (reloadTime);
		currentClip = clipSize;
		Debug.Log ("Reloaded");
		reloading = false;
		StopCoroutine (Reloading ());
	}
	void Shoot(){
		if (shootTimer > shootInterval) {
			shootTimer = 0;
			Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
			Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
			RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), 1, whatToHit);
			Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			currentClip--;
			if (currentClip == 0) {
				reloading = true;
				StartCoroutine (Reloading ());
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
}