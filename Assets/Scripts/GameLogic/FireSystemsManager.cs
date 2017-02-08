using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

[RequireComponent(typeof(BulletDataManager))]
public class FireSystemsManager : NetworkBehaviour {

	private BulletDataManager bulletDataPipe;

	public List<FireSystem> fireSystems = new List<FireSystem> ();

	void Start(){
		bulletDataPipe = GetComponent<BulletDataManager>();
	}

	public void fireAll(){
		foreach (FireSystem system in fireSystems) {
			system.fire();
		}
	}

	public void stopFireAll(){
		foreach (FireSystem system in fireSystems) {
			system.stopFire();
		}
	}

	void FixedUpdate(){
		sendBulletData ();
	}

	public void sendBulletData(){
		foreach (FireSystem system in fireSystems) {
			if (system.getBulletData().Count > 0) {
                if (!isServer) {
                    bulletDataPipe.CmdServerSpawnBullets(system.getBulletData().ToArray(), PersistentNetworkIdentity.instance.netId);
                }
                else {
                    bulletDataPipe.RpcClientSpawnBullets(system.getBulletData().ToArray(), PersistentNetworkIdentity.instance.netId);
                }
				system.purgeBulletData ();
			}
		}
	}
}
