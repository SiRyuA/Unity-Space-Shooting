using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 5;
	public float linetype = 0;

	// Use this for initialization
	void Start () {
		if (linetype == 0) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (Random.Range (-0.2f, 0.2f), 0, -1) * speed;
		} else {
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -1) * speed;
		}
	}
}
