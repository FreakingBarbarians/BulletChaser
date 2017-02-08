using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MyNetwork.instance.host(25565);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
