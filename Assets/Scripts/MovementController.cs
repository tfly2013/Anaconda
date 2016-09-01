using UnityEngine;
using System.Collections;
using System;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 5f;
    public float rotationSpeed = 120;

    public void move()
    {
        //transform.position += transform.forward * Time.deltaTime * moveSpeed;

        Vector2 inputPos;
        if (Input.touchCount > 0)
            inputPos = Input.touches[0].position;
        else
            inputPos = Input.mousePosition;
    
        var dir = inputPos - new Vector2(Screen.width /2, Screen.height / 2);
        var angle = 90 - Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.AngleAxis(angle, Vector3.up);

        for (int i = transform.childCount - 1; i > 0; i--)
        {
            transform.GetChild(i).position = Vector3.MoveTowards(transform.GetChild(i).position, transform.GetChild(i - 1).position, moveSpeed * Time.deltaTime);
            
        }
        transform.GetChild(0).rotation = Quaternion.RotateTowards(transform.GetChild(0).rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.GetChild(0).position += transform.GetChild(0).forward * Time.deltaTime * moveSpeed;

    }   
}
