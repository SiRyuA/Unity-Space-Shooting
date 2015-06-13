using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject shot;
	public Transform firePosition;

	public float speed = 5;
	float tilt = 5;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		if(Input.GetButtonDown ("Fire1") == true){
			Instantiate(shot, firePosition.position, firePosition.rotation);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float dirX = Input.GetAxis ("Horizontal");
		float dirY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (dirX, 0, dirY);

		GetComponent<Rigidbody> ().velocity = movement * speed;
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler ((GetComponent<Rigidbody>().velocity.z * -tilt/5), 0, (GetComponent<Rigidbody>().velocity.x * -tilt));

	}
}
