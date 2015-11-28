using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
	}
}
