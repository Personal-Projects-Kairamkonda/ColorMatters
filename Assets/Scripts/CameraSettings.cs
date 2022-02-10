using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Transform player;
    public bool freeze = true;
    public Vector3 offset;

    private void Update()
    {
        if (freeze)
            transform.position = player.transform.position + offset;
    }

}
