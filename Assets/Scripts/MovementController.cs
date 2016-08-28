using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotationSpeed = 60;

    public void move()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

        Vector2 inputPos;
        if (Application.platform != RuntimePlatform.IPhonePlayer || Application.platform != RuntimePlatform.Android)
            inputPos = Input.mousePosition;
        else
            inputPos = Input.touches[0].position;
    
        var dir = inputPos - new Vector2(Screen.width /2, Screen.height / 2);
        var angle = 90 - Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
