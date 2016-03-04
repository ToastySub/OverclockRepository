using UnityEngine;
using System.Collections;

public class PistolScript: MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public int clipSize = 6;
	public int currentClip;
	public LayerMask whatToHit;
	public Transform bulletPrefab;
	public Transform bulletSpawn;
	public float reloadTime = 2;
	private bool reloading = false;

	void Awake(){
		currentClip = clipSize;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && currentClip > 0 && reloading == false)
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
	void Shoot ()
	{
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), Mathf.Infinity, whatToHit);
		Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		currentClip--;
		if (currentClip == 0) {
			reloading = true;
			StartCoroutine (Reloading ());
		}
		if (hit.collider != null) {
			Debug.Log ("Hit " + hit.collider.name + " " + hit.collider.gameObject.tag);
			if (hit.collider.gameObject.tag == "Enemy") {
				Debug.Log ("Hit Enemy");
			}
		}
	}
}
