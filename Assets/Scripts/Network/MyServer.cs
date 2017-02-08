using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class MyServer : NetworkBehaviour {

    public GameObject playerPrefab;

    public void init() {
        if (!isServer) {
            gameObject.SetActive(false);
        }
        NetworkServer.RegisterHandler(MsgType.AddPlayer, AddPlayer);
    }

    private void AddPlayer(NetworkMessage msg) {
        Debug.Log("Adding Player");
        GameObject player = GameObject.Instantiate<GameObject>(playerPrefab);
        NetworkServer.AddPlayerForConnection(msg.conn, player, (short)msg.ReadMessage<IntegerMessage>().value);
    }
}
