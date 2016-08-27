using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Disk"))
        {
            var score = other.gameObject.GetComponent<DiskController>().score;
            var npc = GetComponentInParent<NetworkPlayerController>();
            if (npc != null)
            {
                npc.AddScore(score);
            }
            else
            {
                var pc = GetComponentInParent<PlayerController>();
                pc.AddScore(score);
            }               

            Destroy(other.gameObject);
        }
    }
}
