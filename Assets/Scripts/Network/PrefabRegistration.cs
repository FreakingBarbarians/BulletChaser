using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
public class PrefabRegistration : MonoBehaviour {
    public List<GameObject> prefabs = new List<GameObject>();
    public static bool ran = false;

    // Use this for initialization
    void Start () {
        if (!ran) {
            foreach (GameObject prefab in prefabs) {
                ClientScene.RegisterPrefab(prefab);
                
            }
            ran = true;
            Debug.Log("RegisteringPrefabs");
        }
	}
}
