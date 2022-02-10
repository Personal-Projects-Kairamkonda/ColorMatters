using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class PowerUp : MonoBehaviour
    {
        [Header("Change Shape")]
        public Mesh sphere;
        public Mesh cube;

        /// <summary>
        /// Transform the shape, get pass through obstacle
        /// </summary>
        /// <param name="waitTime">powerup timer</param>
        /// <returns></returns>
        public IEnumerator ChangeToSphere(float waitTime, Transform entity)
        {
            entity.gameObject.GetComponent<MeshFilter>().mesh = Instantiate(sphere);

            Material entityMat;
            entityMat = entity.gameObject.GetComponent<MeshRenderer>().material;
            entityMat.color = Color.white;

            // Changing size of the sphere according to the isometric view
            //this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f); 

            yield return new WaitForSeconds(waitTime);

            entity.gameObject.GetComponent<MeshFilter>().mesh = Instantiate(cube);
            entityMat.color = Color.black;

            // Changing size of the sphere according to the isometric view
            //this.transform.localScale = new Vector3(1f, 1f, 1f);
        }



    }
}
