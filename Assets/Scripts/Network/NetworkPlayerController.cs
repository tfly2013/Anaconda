using System;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerController : NetworkBehaviour, ICharacterController {

    public string playerName = "Player";
    public GameObject snakeBodyPrefeb;
    public GameObject cameraPrefab;

    [SyncVar(hook = "OnChangeScore")]
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

    public void Start()
    {
        transform.SetParent(GameObject.Find("Players").transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        GetComponent<MovementController>().move();
        var headPosition = transform.GetChild(0).position;
        if (headPosition.x < 0 || headPosition.x > 500 || headPosition.z < 0 || headPosition.z > 500)
            GameObject.Find("GameEngine").GetComponent<GameEngine>().GameOver();
    }

    public override void OnStartLocalPlayer()
    {
        Debug.Log("Start local player");
        // For easy identification
        color = Color.blue;
        for (int i = 0; i < 10; i++)
        {
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.transform.localPosition = new Vector3(0, 0, -i * 0.3f);
        }
        foreach (Transform child in transform)
            child.GetComponent<MeshRenderer>().material.color = color;

        Debug.Log("Generating player camera");
        var camera = (GameObject) Instantiate(cameraPrefab, transform.position + new Vector3(0, 30, 0), Quaternion.identity);
        camera.transform.Rotate(90, 0, 0);
        camera.GetComponent<CameraController>().player = gameObject;
    }

    public void AddScore(int amount)
    {
        if (isServer)
            score += amount;
    }

    private void OnChangeScore(int score)
    {
        while (score / 10 > (transform.childCount - 10))
        {
            var lastBodyPosistion = transform.GetChild(transform.childCount - 1).position;
            var body = (GameObject)Instantiate(snakeBodyPrefeb, transform, false);
            body.GetComponent<MeshRenderer>().material.color = color;
            body.transform.position = lastBodyPosistion;
        }
        var width = 1.5f + 0.1f * Score / 100;
        foreach (Transform child in transform)
            child.transform.localScale = new Vector3(width, width, width);
    }
}
