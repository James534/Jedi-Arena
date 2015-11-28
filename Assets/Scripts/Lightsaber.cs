using UnityEngine;
using System.Collections;

public class Lightsaber : MonoBehaviour {
	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			transform.Rotate(new Vector3(0, 90, 0));
			
		}
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log("Pressed right click.");
		}
	}
}
