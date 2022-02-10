using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelfRotate : MonoBehaviour
{
    public TextMeshPro thankyou;

    private void Awake()
    {
        thankyou.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Color otherMaterial = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        Color material = this.GetComponent<MeshRenderer>().material.color;

        bool del = (material == otherMaterial) ? true : false;

        if (del)
        {
            this.transform.Rotate(new Vector3(0, 0, 90)*Time.deltaTime*2f);
        }

        thankyou.gameObject.SetActive(true);
    }
}
