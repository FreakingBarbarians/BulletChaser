using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
[RequireComponent(typeof(ShipMover))]
public class PlayerController : NetworkBehaviour {

    Vector2 internalMoveState = Vector2.zero;
    ShipMover shipMover;

    void Start() {
        shipMover = GetComponent<ShipMover>();
        if (isLocalPlayer) {
            Debug.Log("IS LOCAL");
        }
    }

    void Update() {
        if (!isLocalPlayer) {
            return;
        }

        int x = 0;
        int y = 0;

        if (Input.GetKey(KeyCode.W)) {
            y = 1;
        }

        if (Input.GetKey(KeyCode.S)) {
            y = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            x = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            x = 1;
        }

        Vector2 generatedMoveState = new Vector2(x, y);

        if (generatedMoveState != internalMoveState) {
            shipMover.UpdateMoveState(generatedMoveState, PersistentNetworkIdentity.instance.netId);
            internalMoveState = generatedMoveState;
        }
    }
}
