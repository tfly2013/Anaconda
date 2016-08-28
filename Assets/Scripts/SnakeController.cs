using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        var isNetwork = false;
        var isPlayer = false;
        var npc = GetComponentInParent<NetworkPlayerController>();
        var pc = GetComponentInParent<PlayerController>();
        var aic = GetComponentInParent<AIController>();
        if (npc != null)
        {
            isNetwork = true;
            isPlayer = true;
        }            
        if (pc != null)
            isPlayer = true;
        if (other.gameObject.CompareTag("Disk"))
        {
            var score = other.gameObject.GetComponent<DiskController>().score;
            if (isPlayer)
                if (isNetwork)
                    npc.AddScore(score);
                else
                    pc.AddScore(score);
            else
                aic.AddScore(score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Body"))
        {
            if (isPlayer && !isNetwork)
                GameObject.Find("GameEngine").GetComponent<GameEngine>().GameOver();
            Destroy(transform.parent.gameObject);
        }        
    }
}
