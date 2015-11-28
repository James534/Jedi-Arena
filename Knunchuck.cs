using UnityEngine;
using System.Collections;
using WiimoteApi;

public class Knunchuck : MonoBehaviour {

    Wiimote remote;
    // Use this for initialization
    void Start () {

        InitWiimotes();
        remote.SendPlayerLED(true, false, false, false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void InitWiimotes()
    {
        WiimoteManager.FindWiimotes(); // Poll native bluetooth drivers to find Wiimotes
        foreach (Wiimote remote in WiimoteManager.Wiimotes)
        {
            // Do stuff.
            Debug.Log("Found Wiimote");
            this.remote = remote;
        }
    }
}
