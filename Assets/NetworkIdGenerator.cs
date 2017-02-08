using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetworkIdGenerator : NetworkBehaviour {

    public Queue<short> ids = new Queue<short>();

    void Start() {
        for (short i = 0; i < short.MaxValue; i++) {
            ids.Enqueue(i);
        }
	}

    public short generateId() {
        return ids.Dequeue();
    }

    public void reclaimId(short id) {
        ids.Enqueue(id);
    }
}
