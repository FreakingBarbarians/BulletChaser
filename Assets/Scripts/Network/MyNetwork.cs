using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class MyNetwork : MonoBehaviour {
    public static MyNetwork instance;

    public static NetworkClient myClient;
    public static bool testing = false;

    static public string onlineSceneName = "ClientScene";
    static public string offlineSceneName = "offlineScene";

    public MyServer server;

    void Awake() {
        if (instance != null) {

        }
        else {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        myClient = new NetworkClient();
        NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnection);
        Application.runInBackground = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (testing) {
            if (Input.GetKeyDown(KeyCode.S)) {
                host(25565);
                testing = false;
            } else if (Input.GetKeyDown(KeyCode.C)) {
                Connect("localhost", 25565);
                testing = false;
            }
        }
	}

    public static void Connect(string ip, int port) {
        CleanUpClient();
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnClientConnect);
        myClient.RegisterHandler(MsgType.Disconnect, OnClientDisconnect);
        myClient.Connect(ip, port);
        Debug.Log("Client Connecting To " + ip + ":" + port);
    }

    public static void debugConnect() {
        Connect("127.0.0.1", 25565);
    }

    public static void Disconnect() {
        myClient.Disconnect();
        CleanUpClient();
        NetworkServer.Shutdown();
        SceneManager.LoadScene(offlineSceneName);
    }

    public void WrapperDisconnect() {
        Disconnect();
    }

    public void host(int port) {
        CleanUpClient();
        CleanUpHost();
        NetworkServer.Listen(port);
        NetworkServer.SpawnObjects();
        Debug.Log("Hosting " + port);
        server.init();
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnClientConnect);
        myClient.RegisterHandler(MsgType.Disconnect, OnClientDisconnect);
    }

    public static void OfflineHost() {
        CleanUpClient();
        CleanUpHost();
        NetworkServer.dontListen = true;
        NetworkServer.Listen(0);
        Debug.Log("Offline Hosting");
    }

    private static void CleanUpClient() {
        return;
        myClient.Disconnect();
        myClient.Shutdown();
        myClient = new NetworkClient();
    }

    private static void CleanUpHost() {
        return;
        NetworkServer.ClearHandlers();
        NetworkServer.ClearLocalObjects();
        NetworkServer.DisconnectAll();
    }

    private static void OnClientConnect(NetworkMessage msg) {
        Debug.Log("Connected to host " + msg.conn.address.ToString());
        ClientScene.AddPlayer(msg.conn, 1);
    }

    private static void OnServerConnection(NetworkMessage msg) {
        Debug.Log("Incomming Connection From " + msg.conn.address.ToString());
    }

    private static void OnServerDisconnect() {

    }

    private static void OnClientDisconnect(NetworkMessage msg) {
        Debug.Log("Disconnected");
        SceneManager.LoadScene(offlineSceneName);
    }
}