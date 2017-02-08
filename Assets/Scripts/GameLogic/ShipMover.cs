using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Attributes))]
public class ShipMover : NetworkBehaviour {

    private Vector2 moveState = Vector2.zero;

    private Attributes attributes;

    void Start() {
        attributes = GetComponent<Attributes>();
    }

	void FixedUpdate () {
        transform.position += (Vector3) moveState.normalized * attributes.currentSpeed * Time.fixedDeltaTime;    
	}

    [Command]
    public void CmdUpdateMoveState(Vector2 moveState, int netid) {
        this.moveState = moveState;
        RpcClientUpdateMoveState(moveState, netid);
    }

    [ClientRpc]
    public void RpcClientUpdateMoveState(Vector2 moveState, int netid) {
        if (PersistentNetworkIdentity.instance.netId == netid) {
            return;
        }

        this.moveState = moveState;
    }
    public void UpdateMoveState(Vector2 moveState, int netid) {
        this.moveState = moveState;
        if (!isServer) {
            CmdUpdateMoveState(moveState, netid);
        }
        else {
            RpcClientUpdateMoveState(moveState, netid);
        }
    }
}
