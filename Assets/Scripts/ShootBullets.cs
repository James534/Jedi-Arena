using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour {

	GameObject bullet;
	float timer = 300;
	
	// Use this for initialization
	void Start () {
		bullet = GameObject.Find("Bullet");
	}

	void Update() {
		timer -= 100;
		if (timer < 0) {
		
			GameObject g = (GameObject)Instantiate(bullet,
			                                       new Vector3(0,Random.Range(0, 3),0),
			                                       Quaternion.Euler(0, Random.Range(0, 360), 5.0f));
			timer = 300;
			Debug.Log("Added bullet");
		}
		if (Input.GetMouseButtonDown (0)) {
			GameObject g = (GameObject)Instantiate(bullet,
			                                       transform.position,
			                                       new Quaternion(transform.parent.rotation.x-90f,
                                                   transform.parent.rotation.y,
                                                   transform.parent.rotation.z,
                                                   transform.parent.rotation.w));
		}
	}
}
