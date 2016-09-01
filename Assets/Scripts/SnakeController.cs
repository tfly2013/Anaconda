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
            var score = other.gameObject.GetComponent<DiskController>().score;
            controller.AddScore(score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Body") && !other.transform.IsChildOf(transform.parent))
        {
            if (isPlayer && !isNetwork)
                GameObject.Find("GameEngine").GetComponent<GameEngine>().GameOver();
            Destroy(transform.parent.gameObject);
        }
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
