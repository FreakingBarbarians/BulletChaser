using UnityEngine;
using System.Collections;

public class ClientSetUp : MonoBehaviour {
    bool run = false;
    void Update() {
        if (!run) {
            MyNetwork.debugConnect();
            run = true;
        }
    }
}
