using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 100f;
    
    void Update()
    {
        float horizontalMove = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * horizontalMove);
    }
}
