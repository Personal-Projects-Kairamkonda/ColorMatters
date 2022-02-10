using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class Invisible : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Color otherMaterial = collision.gameObject.GetComponent<MeshRenderer>().material.color;
            Color material = this.GetComponent<MeshRenderer>().material.color;

            bool open = (material == otherMaterial) ? true : false;

            if (open)
            {
                StartCoroutine(ActivateInvisible(10));
            }
        }


        IEnumerator ActivateInvisible(float time)
        {
            this.GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(time);

            this.GetComponent<Collider>().enabled = true;
        }

    }
}