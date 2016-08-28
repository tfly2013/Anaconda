﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("Server add player");
        var player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector3(Random.Range(100, 400), 0, Random.Range(100, 400)), Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
