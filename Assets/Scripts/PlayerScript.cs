using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : Photon.MonoBehaviour {

	public float speed = 1;
	//public Text countText, winText;
	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		//updateScore();
		//winText.text = "";
	}

	void Update() {
        if (photonView.isMine)
        {
            if (Input.GetKey(KeyCode.W))
                rb.MovePosition(rb.position + Vector3.forward * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                rb.MovePosition(rb.position - Vector3.forward * Time.deltaTime);

            if (Input.GetKey(KeyCode.D))
                rb.MovePosition(rb.position + Vector3.right * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
                rb.MovePosition(rb.position - Vector3.right * Time.deltaTime);
        }
    }
    /*
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count += 1;
			updateScore();
		}
	}

	void updateScore() {
		countText.text = "Score: " + count.ToString ();
		if (count >= 10) {
			winText.text = "You win!";
		}
	}*/
}