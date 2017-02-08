using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ClientSideMovementCorrection : NetworkBehaviour {

    public float checkInterval;
    private float timer = 0;

    // Use this for initialization
    void Start() {
        if (!isLocalPlayer) {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        timer += Time.deltaTime;
        if (timer >= checkInterval) {
            timer = 0;
            if (!isServer) {
                CmdCorrectPos(transform.position);
            }
            else {
                RpcCorrectPosition(transform.position);
            }
        }
    }

    [ClientRpc]
    private void RpcCorrectPosition(Vector2 pos) {
        transform.position = pos;
    }

    [Command]
    private void CmdCorrectPos(Vector2 pos){
        Debug.Log("Pos Corrected");
        transform.position = pos;
    }
}
