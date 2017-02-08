using UnityEngine;
using UnityEngine.Networking;

public class PersistentNetworkIdentity : MonoBehaviour {

    public static PersistentNetworkIdentity instance;
    public int netId;

	// Use this for initialization
	void Start () {
        instance = this;
        netId = (int) Random.Range(int.MinValue, int.MaxValue);
        DontDestroyOnLoad(gameObject);
	}
}
