using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;


public class BulletDataManager : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	[Command]
	public void CmdServerSpawnBullets(Weapon.NetBulletData[] bullets, int netid){
		foreach (Weapon.NetBulletData dat in bullets) {

			GameObject newBullet = GameObject.Instantiate (PrefabPool.instance.prefabs[dat.prefabName]);
			newBullet.transform.position = dat.position;
			newBullet.transform.rotation = dat.rotation;
			newBullet.GetComponent<Rigidbody2D> ().velocity = dat.velocity;
		}
		RpcClientSpawnBullets (bullets, netid);
	}

	[ClientRpc]
	public void RpcClientSpawnBullets(Weapon.NetBulletData[] bullets, int netid) {
		if (PersistentNetworkIdentity.instance.netId == netid) {
            return;
		}
		foreach (Weapon.NetBulletData dat in bullets) {
			GameObject newBullet = GameObject.Instantiate (PrefabPool.instance.prefabs[dat.prefabName]);
			newBullet.transform.position = dat.position;
			newBullet.transform.rotation = dat.rotation;
			newBullet.GetComponent<Rigidbody2D> ().velocity = dat.velocity;
		}
	}
}
