using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

// doesn't work

public class SpawnSelf : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        CmdSpawn();
	}

    [Command]
    void CmdSpawn() {
        NetworkServer.Spawn(gameObject);
    }
}
