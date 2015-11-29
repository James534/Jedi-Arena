using UnityEngine;
using System.Collections;

public class DeflectBullets : MonoBehaviour {
	
	BulletScript bulletScript;

	// Use this for initialization
	void Start () {
		bulletScript = GameObject.Find("Bullet").GetComponent<BulletScript>();
	}

	// If the bullet collides with the lightsaber, deflect the bullet
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Bullet")) {
			Destroy(other.gameObject);
		}
	}
}
