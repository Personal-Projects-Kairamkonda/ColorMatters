using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Color otherMaterial = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        Color material = this.GetComponent<MeshRenderer>().material.color;

        bool del = (material == otherMaterial) ? true : false;

        if (del)
        {
            Destroy(this.gameObject);
        }
    }
}
