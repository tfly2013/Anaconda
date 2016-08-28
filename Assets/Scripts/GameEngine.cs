using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

    public GameObject player;
    public GameObject diskPrefab;

    private string playerName;
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    private Transform disks;

    void Start () {
        playerName = player.GetComponent<PlayerController>().name;

        disks = GameObject.Find("Disks").transform;
        for (int i = 0; i < 5000; i++)
        {
            var disk = (GameObject)GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (disks.childCount < 5000)
        {
            var disk = (GameObject)GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
        }

        var playerScore = player.GetComponent<PlayerController>().score;
        scores[playerName] = playerScore;
        var leaderBoard = GameObject.Find("LeaderBoard").transform;
        leaderBoard.GetChild(0).GetChild(0).GetComponent<Text>().text = playerName;
        leaderBoard.GetChild(0).GetChild(1).GetComponent<Text>().text = playerScore.ToString();
    }
}
