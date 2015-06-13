using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform fireposition;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Fire", 0.5f, 1);
	}

	void Fire(){
		Instantiate (shot, fireposition.position, fireposition.rotation);
	}

}
