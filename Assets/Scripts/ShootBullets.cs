using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update() {
		if (Input.GetMouseButtonDown (0)) {
//			GameObject FPSController = GameObject.Find("FPSController");
//			Debug.Log(Mathf.Asin(transform.parent.rotation.y));
			GameObject bullet = GameObject.Find("Bullet");
//			bullet.transform.rotation.Set(0, 180, 0, 0);
//			bullet.transform.position.Set(
//			float correctedY = transform.parent.rotation.y - 0.5f;
//			if(transform.parent.rotation.y - 0.5f < -1.0f) {
//				correctedY = -1.0f - transform.parent.rotation.y;
//				Debug.Log(correctedY);
//			}
			GameObject g = (GameObject)Instantiate(bullet,
			                                       transform.position,
			                                       transform.parent.rotation);
		}
	}
}
