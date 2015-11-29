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

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if (stream.isWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
        }
        else
        {
            rb.position = (Vector3) stream.ReceiveNext();
            rb.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
        
}