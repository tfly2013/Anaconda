using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour
{
    private bool isNetwork = false;
    private bool isPlayer = false;
    private ICharacterController controller;

    void OnTriggerEnter(Collider other)
    {
        if (controller == null)
            InitalizeController();
        if (other.gameObject.CompareTag("Disk"))
        {
            int score;
            if (!isNetwork)
                score = other.gameObject.GetComponent<DiskController>().score;
            else
                score = other.gameObject.GetComponent<NetworkDiskController>().score;
            controller.AddScore(score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Body") && !other.transform.IsChildOf(transform.parent))
            Dead();
        if (other.gameObject.CompareTag("Head"))
        {
            var score = controller.Score;
            var otherScore = ((ICharacterController)other.gameObject.GetComponentInParent(typeof(ICharacterController))).Score;
            if (score < otherScore)
                Dead();
        }
    }

    private void Dead()
    {
        Destroy(transform.parent.gameObject);
        if (isPlayer && !isNetwork)
            GameObject.Find("GameEngine").GetComponent<GameEngine>().GameOver();        
    }

    private void InitalizeController()
    {
        controller = (ICharacterController)GetComponentInParent(typeof(ICharacterController));
        if (controller is NetworkPlayerController)
        {
            isNetwork = true;
            isPlayer = true;
        }
        if (controller is PlayerController)
            isPlayer = true;
    }
}
