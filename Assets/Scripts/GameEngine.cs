using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class GameEngine : MonoBehaviour {

    public GameObject player;
    public GameObject diskPrefab;
    public GameObject aiPrefab;

    private string playerName;
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    private Transform disks;
    private Transform AIs;
    private int ai_id = 50;

    void Start () {
        playerName = player.GetComponent<PlayerController>().playerName;

        disks = GameObject.Find("Disks").transform;
        for (int i = 0; i < 5000; i++)
        {
            var disk = (GameObject)GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
        }

        AIs = GameObject.Find("AIs").transform;
        for (int i = 0; i < 100; i++)
        {
            var ai = (GameObject)GameObject.Instantiate(aiPrefab, new Vector3(Random.Range(0, 450), 0, Random.Range(0, 450)), Quaternion.Euler(0, Random.Range(0,360), 0));
            
            ai.GetComponent<AIController>().name = "AI" + i.ToString();
            ai.transform.parent = AIs;
        }
        
    }

	void Update ()
    {
        if (disks.childCount < 5000)
        {
            var disk = (GameObject)GameObject.Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
        }

        if (AIs.childCount < 100)
        {
            var ai = (GameObject)GameObject.Instantiate(aiPrefab, new Vector3(Random.Range(0, 450), 0, Random.Range(0, 450)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            ai.GetComponent<AIController>().name = "AI" + ai_id.ToString();
            ai_id++;
            ai.transform.parent = AIs;
        }

        UpdateLeaderBoard();
    }

    private void UpdateLeaderBoard()
    {
        foreach (Transform ai in AIs)
            scores[ai.name] = ai.GetComponent<AIController>().score;
        var playerScore = player.GetComponent<PlayerController>().score;
        scores[playerName] = playerScore;

        var scoresList = scores.ToList();
        scoresList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        var leaderBoard = GameObject.Find("LeaderBoard").transform;
        var playerInLead = false;
        for (int i = 0; i < 5; i++)
        {
            var name = scoresList[i].Key;
            if (!playerInLead && name == playerName)
                playerInLead = true;
            leaderBoard.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString() + ". " + name;
            leaderBoard.GetChild(i).GetChild(1).GetComponent<Text>().text = scoresList[i].Value.ToString();
        }
        if (playerInLead)
        {
            leaderBoard.GetChild(5).GetChild(0).GetComponent<Text>().text = "6. " + scoresList[6].Key;
            leaderBoard.GetChild(5).GetChild(1).GetComponent<Text>().text = scoresList[6].Value.ToString();
        }
        else
        {
            leaderBoard.GetChild(5).GetChild(0).GetComponent<Text>().text = "   " + playerName;
            leaderBoard.GetChild(5).GetChild(1).GetComponent<Text>().text = playerScore.ToString();
        }
        
    }
}
