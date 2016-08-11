using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameEngine : NetworkBehaviour {

    public GameObject diskPrefab;

	// Use this for initialization
    public override void OnStartServer()
    {
        Debug.Log("Server Start");
        for (int i = 0; i < 5000; i++)
        {
            var disk = (GameObject) GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            NetworkServer.Spawn(disk);
        }
	}
}
