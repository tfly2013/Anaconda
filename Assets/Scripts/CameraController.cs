using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour {

    public GameObject player = null;
    public int height = 30;

	// Update is called once per frame
	void LateUpdate () {
        if (player != null)
            transform.position = player.transform.position + new Vector3(0, height, 0);	
	}
}
