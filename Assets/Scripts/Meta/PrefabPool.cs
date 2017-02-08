using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabPool : MonoBehaviour {
	public static PrefabPool instance;
	public Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();
	AssetBundle mainBundle;
    AssetBundle baseBundle;
    AssetBundleManifest mainManifest;


	// Use this for initialization
	void Start () {

        if (instance != null) {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad (gameObject);

        //mainBundle = AssetBundle.LoadFromFile ("AssetBundles/AssetBundles");
        //Debug.Log (mainBundle.name);
        //string log = "";

        //      foreach (string name in mainBundle.GetAllAssetNames()) {
        //	log += name + " ";
        //}

        //mainManifest = (AssetBundleManifest) mainBundle.LoadAllAssets()[0];
        //Debug.Log (log);

        //foreach (string name in mainManifest.GetAllAssetBundles ()) {
        //	log += name + " ";
        //}

        //      Debug.Log (log);


        baseBundle = AssetBundle.LoadFromFile("AssetBundles/base");
        foreach (GameObject obj in baseBundle.LoadAllAssets<GameObject>()) {
            Debug.Log(obj.name);
            prefabs.Add(obj.name, obj);
        }
	}
}
