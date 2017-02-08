using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {

    public void Connect() {
        SceneManager.LoadScene("ClientScene");
    }

    public void Host() {
        SceneManager.LoadScene("HostScene");
    }
}
