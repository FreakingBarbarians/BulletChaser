using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireSystem : MonoBehaviour {
	public List<Weapon> weapons;
	protected List<Weapon.NetBulletData> bulletData;

	public bool firing = false;
	public Attributes attribs;

	protected void init(){
		bulletData = new List<Weapon.NetBulletData> ();
		findWeaponsInChildren ();
	}

	void Start(){
		init ();
	}

	public virtual void fire(){
		
	}

	public virtual void stopFire(){
		
	}

	public List<Weapon.NetBulletData> getBulletData(){
		return bulletData;
	}

	public void purgeBulletData(){
		bulletData.Clear ();
	}

	protected void findWeaponsInChildren(){
		if (weapons == null) {
			weapons = new List<Weapon> ();
		}

		foreach (Weapon wep in gameObject.GetComponentsInChildren<Weapon> ()) {
			weapons.Add (wep);
		}
	}


}