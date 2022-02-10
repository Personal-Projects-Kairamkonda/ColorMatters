using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPower : MonoBehaviour
{
    public  float invisbilityTimer=7;
    public Image invisDisplay;

    private void Awake()
    {
        invisDisplay.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.GetComponent<Key>())
        {
            StartCoroutine(ChangeColor(collision, invisbilityTimer));
        }

        if (collision.gameObject.GetComponent<Door>())
        {
            StartCoroutine(ActivateInvisible(collision, 2f));
        }
    }

    IEnumerator ActivateInvisible(Collision collision,float time)
    {
        Color otherMaterial = collision.gameObject.GetComponent<MeshRenderer>().material.color;
        Color material = this.GetComponent<MeshRenderer>().material.color;

        bool open = (material == otherMaterial) ? true : false;

        MeshCollider col = collision.gameObject.GetComponent<MeshCollider>();

        if (open)
        {
           col.enabled = false;
        }

        yield return new WaitForSeconds(time);

        col.enabled = true;
    }

    IEnumerator ChangeColor(Collision collision,float time)
    {
        this.gameObject.GetComponent<MeshRenderer>().material.color =
        collision.gameObject.GetComponent<MeshRenderer>().material.color;

        invisDisplay.enabled = true;


        yield return new WaitForSeconds(time);

        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;

    }
}
