using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotataSpeed = 150f;

    public void move()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotataSpeed;
        transform.Rotate(0, x, 0);
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
