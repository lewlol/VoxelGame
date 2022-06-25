using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIsometric : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(50, 50, 50);


    private void LateUpdate()
    {
        //transform.position = player.position += offset;
    }
}
