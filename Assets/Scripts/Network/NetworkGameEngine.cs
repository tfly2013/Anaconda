using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkGameEngine: NetworkBehaviour {

    public GameObject diskPrefab;
    public GameObject player;

    private void InitializeDisks()
    {
        for (int i = 0; i < 5000; i++)
        {
            var disk = (GameObject)GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            NetworkServer.Spawn(disk);
        }
    }

    // Use this for initialization
    public override void OnStartServer()
    {
        Debug.Log("Server Start");
        InitializeDisks();

    }
}
