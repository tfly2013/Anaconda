using System;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour, ICharacterController {

    public GameObject cameraPrefab;
    
    [SyncVar]
    public int score = 0;

    private Color color;

    public int Score
    {
        get
        {
            return score;
        }
    }

    public Color Color
    {
        get
        {
            return color;
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        GetComponent<MovementController>().move();
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("Start local player");
        // For easy identification
        transform.FindChild("Snake").GetComponent<MeshRenderer>().material.color = Color.blue;

        Debug.Log("Generating player camera");
        var camera = (GameObject) GameObject.Instantiate(cameraPrefab, transform.position + new Vector3(0, 30, 0), Quaternion.identity);
        camera.transform.Rotate(90, 0, 0);
        camera.GetComponent<CameraController>().player = gameObject;
    }

    public void AddScore(int amount)
    {
        if (!isServer)
            return;
        score += amount;
    }
}
