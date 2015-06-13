using UnityEngine;
using System.Collections;

public class DestroyByOther : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			return;
		}
		Destroy (other.gameObject);
	}
}