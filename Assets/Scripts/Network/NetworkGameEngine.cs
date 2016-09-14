using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkGameEngine : NetworkBehaviour
{
    public const int AI_NUM = 80;
    public const int DISK_NUM = 5000;

    public GameObject diskPrefab;

    private Transform disks;
    private Transform players;
    private Dictionary<string, int> scores = new Dictionary<string, int>();

    // Use this for initialization
    public override void OnStartServer()
    {
        Debug.Log("Server Start");
        players = GameObject.Find("Players").transform;
        disks = GameObject.Find("Disks").transform;        
        for (int i = 0; i < 5000; i++)
        {
            var disk = (GameObject)Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0.5f, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
            NetworkServer.Spawn(disk);
        }
    }

    public void Update()
    {
        if (!isServer)
            return;
        if (disks.childCount < DISK_NUM)
        {
            var disk = (GameObject)Instantiate(diskPrefab, new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500)), Quaternion.identity);
            disk.transform.parent = disks;
            NetworkServer.Spawn(disk);
        }
        UpdateScores();        
    }

    private void UpdateScores()
    {
        foreach (Transform p in players)
            if (p.GetComponent<NetworkPlayerController>() != null)
                scores[p.name] = p.GetComponent<NetworkPlayerController>().Score;
            else
                scores.Remove(p.name);
        var scoresList = scores.ToList();
        scoresList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
        //RpcUpdateLeaderboard(scoresList);
    }

    [ClientRpc]
    public void RpcUpdateLeaderboard(List<KeyValuePair<string, int>> scoresList)
    {
        if (isLocalPlayer)
        {
            var leaderBoard = GameObject.Find("LeaderBoard").transform;
            for (int i = 0; i < 6; i++)
            {
                var name = scoresList[i].Key;
                leaderBoard.GetChild(i).GetChild(0).GetComponent<Text>().text = (i + 1).ToString() + ". " + name;
                leaderBoard.GetChild(i).GetChild(1).GetComponent<Text>().text = scoresList[i].Value.ToString();
            }
        }
    }
}
