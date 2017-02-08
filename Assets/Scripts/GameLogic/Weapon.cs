using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public struct NetBulletData{
		public string prefabName;
		public Vector3 position;
		public Quaternion rotation;
		public Vector2 velocity;
	}

    public int resourceType;
    public float amtRequired;
    public float cooldownTime;
    public int cooldownMultiplier = 1;
    protected float cooldownTimer;
    protected bool cooldown;

    public virtual NetBulletData fire() {
		throw new UnityException ();
    }

    protected virtual void doCooldown() {
        if (cooldown) {
			cooldownTimer -= Time.fixedDeltaTime * cooldownMultiplier;
            if (cooldownTimer <= 0) {
                cooldown = false;
            }
        }
    }

    void FixedUpdate() {
        doCooldown();
    }
}
