using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public Transform door;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Key") 
        door.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Key")
            door.gameObject.SetActive(true);

    }
}
