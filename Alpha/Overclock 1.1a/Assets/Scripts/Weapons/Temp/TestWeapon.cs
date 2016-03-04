using UnityEngine;
using System.Collections;

public class TestWeapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
	public GameObject grenadePrefab;
	public Transform grenadeSpawn;
	private float timeToShoot = 0;

	void Start(){
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
		Shoot ();
	}

	void Shoot(){
		Instantiate (grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation);

	}
}