using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 1.0f;

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
	}
}
