using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Disk"))
        {
            Destroy(other.gameObject);
        }
    }
}
