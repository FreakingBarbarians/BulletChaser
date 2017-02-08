using UnityEngine;
using System.Collections;

public class SingleFireSystem : FireSystem {

	// Use this for initialization
	void Start () {
		base.init ();
	}

	public override void fire () {
		firing = true;
	}

	public override void stopFire () {
		firing = false;
	}

	// Update is called once per frame
	void Update () {
		if (firing) {
			foreach (Weapon wep in weapons) {
				Weapon.NetBulletData dat = wep.fire ();
				if (dat.prefabName != null) {
					base.bulletData.Add (dat);
				}
			}
		}
	}

}

// If this no work im gonna need to manage my own static dictionary of prefabs