using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Attributes : NetworkBehaviour {
    [SyncVar]
    public int baseHealth = 100;
    [SyncVar]
    public float baseSpeed = 1;

	[HideInInspector]
    [SyncVar]
    public int finalHealth = 100;
	[HideInInspector]
    [SyncVar]
    public float finalSpeed = 1;

	[HideInInspector]
    [SyncVar]
    public int currentHealth = 100;
	[HideInInspector]
    [SyncVar]
    public float currentSpeed = 1;

    [SyncVar]
	public int ammoCap;
	[HideInInspector]
    [SyncVar]
	public int currentAmmo;

    [SyncVar]
	public float energyCap = 100;
	[HideInInspector]
    [SyncVar]
	public float currentEnergy;

    [SyncVar]
    public float baseEnergyRegenRate = 5;
	[HideInInspector]
    [SyncVar]
    public float finalEnergyRegenRate;
	[HideInInspector]
    [SyncVar]
    public float currentEnergyRegenRate;

    void Start() {
        finalSpeed = baseSpeed;
        finalHealth = baseHealth;

        currentSpeed = finalSpeed;
        currentHealth = finalHealth;

		currentAmmo = ammoCap;
		currentEnergy = energyCap;

		finalEnergyRegenRate = baseEnergyRegenRate;
		currentEnergy = finalEnergyRegenRate;
    }

	void FixedUpdate(){
		// Update energy
		currentEnergy += currentEnergyRegenRate * Time.fixedDeltaTime;
		if (currentEnergy > energyCap) {
			currentEnergy = energyCap;
		}

	}
}
