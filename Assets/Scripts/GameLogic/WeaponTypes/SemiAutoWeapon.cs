using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SemiAutoWeapon : Weapon {

    public GameObject bulletPrefab;
    public float bulletSpeed = 0;

	// Use this for initialization
	void Start () {
        cooldown = false;
	}

	void FixedUpdate () {
        doCooldown();
	}

	public override NetBulletData fire() {
		if (!cooldown) {
            cooldown = true;
            cooldownTimer = cooldownTime;

            GameObject spawnedBullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            spawnedBullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            spawnedBullet.transform.position = transform.position;

			NetBulletData nbd = new NetBulletData ();
			nbd.position = spawnedBullet.transform.position;
			nbd.rotation = spawnedBullet.transform.rotation;
			nbd.velocity = spawnedBullet.GetComponent<Rigidbody2D> ().velocity;
			nbd.prefabName = bulletPrefab.name;
			return nbd;
        }
		Debug.Log ("CD");
		return new NetBulletData();
    }
}
