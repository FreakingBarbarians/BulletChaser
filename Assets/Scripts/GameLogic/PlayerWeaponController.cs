using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeaponController : NetworkBehaviour {
	public FireSystemsManager fsm;

    // Hardcoded class for now
    // Later will fire weapons through WeaponSystemsManager -> WeaponSystem -> Weapon

    void Start() {
        if (isLocalPlayer) {
            Debug.Log("IS LOCAL");
        } else {
            this.enabled = false;
        }
    }


    void FixedUpdate() {
		if (Input.GetKey (KeyCode.Space)) {
			fsm.fireAll ();
		} else {
			fsm.stopFireAll ();
		}
    }
}
