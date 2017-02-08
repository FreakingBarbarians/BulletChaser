using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance;
    public Dictionary<short, GameObject> objectPool;

	void Start () {
        instance = this;
        objectPool = new Dictionary<short, GameObject>();
	}
}
