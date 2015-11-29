using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using WiimoteApi;

public class PlayerScript : Photon.MonoBehaviour {

	public float speed = 1;
	//public Text countText, winText;
	private Rigidbody rb;
	private int count;

    Wiimote wm;
    bool useWiimote = false;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;

        if (useWiimote)
        {
            WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes
            foreach (Wiimote remote in WiimoteManager.Wiimotes)
            {
                Debug.Log("Found Wiimote");
                wm = remote;
            }
            wm.SendPlayerLED(true, false, false, false);
            wm.SendDataReportMode(InputDataType.REPORT_BUTTONS_EXT8);
        }
    }
    
	void Update() {
        if (photonView.isMine)
        {
            if (useWiimote){
                int ret;
                do
                {
                    ret = wm.ReadWiimoteData();
                } while (ret > 0);

                if (wm.current_ext == ExtensionController.NUNCHUCK)
                {
                    NunchuckData nd = wm.Nunchuck;
                    float[] pos = nd.GetStick01();
                    //Debug.Log(pos[0] + " " + pos[1]);
                    Vector3 newPos = new Vector3(rb.position.x, rb.position.y, rb.position.z);
                    if (Mathf.Abs(pos[0] - 0.46f) > 0.05)
                    {
                        newPos[0] = rb.position.x + (pos[0] - 0.5f);
                        //  rb.position = new Vector3(rb.position.x + (pos[0]-0.5f), rb.position.y, rb.position.z);
                        //Debug.Log(rb.position);
                    }
                    if (Mathf.Abs(pos[1] - 0.55f) > 0.05)
                    {
                        newPos[2] = rb.position.z + (pos[1] - 0.5f);
                    }
                    rb.position = newPos;

                }
            }
            else
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

    void OnApplicationQuit()
    {
        if (useWiimote) {
            WiimoteManager.Cleanup(wm);
            Debug.Log("END");
        }
    }
}