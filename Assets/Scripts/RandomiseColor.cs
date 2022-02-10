using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseColor : MonoBehaviour
{
    public Material[] mat;

    private void Start()
    {
        InvokeRepeating("SwapColor", 1, 1);
    }

    void SwapColor()
    {
        this.gameObject.GetComponent<MeshRenderer>().material= mat[Random.Range(0, 5)];
    }
}
