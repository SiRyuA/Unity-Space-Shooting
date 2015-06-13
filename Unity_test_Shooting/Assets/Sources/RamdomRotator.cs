using UnityEngine;
using System.Collections;

public class RamdomRotator : MonoBehaviour {

	float tumble = 5;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
	}

}
