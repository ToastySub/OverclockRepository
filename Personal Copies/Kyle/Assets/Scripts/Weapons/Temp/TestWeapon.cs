using UnityEngine;
using System.Collections;

public class TestWeapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public GameObject grenadePrefab;
	public Transform grenadeSpawn;
	public AudioSource shootClip;
	private float timeToShoot = 0;

	void Start(){
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
		Shoot ();
	}

	void Shoot(){
		shootClip.Play ();
		Instantiate (grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation);

	}
}