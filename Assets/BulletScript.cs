using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BulletScript : NetworkBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D coll) {


        if (!isServer) {
            return;
        }

        coll.gameObject.GetComponent<Attributes>().currentHealth -= damage;
    }

    [ClientRpc]
    public void RpcDestroyBullet(GameObject CollidedWith) {

    }
}
