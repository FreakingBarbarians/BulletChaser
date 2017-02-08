using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ConnectionVisualizer : MonoBehaviour {

    public Text text;
    void Start() {
        NetworkServer.RegisterHandler(MsgType.Connect, UpdateText);
        NetworkServer.RegisterHandler(MsgType.Disconnect, UpdateText);
        UpdateText(null);
    }

	void UpdateText (NetworkMessage msg) {
        text.text = "";
        foreach (NetworkConnection conn in NetworkServer.connections) {
            if (conn == null) {
                continue;
            }
            text.text += conn.address + "\n";
        }
	}
}
