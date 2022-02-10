using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;

    public Vector3[] positions;

    private void Awake()
    {
        //GenerateGround();
    }

    private void OnValidate()
    {
        //GenerateGround();
    }


    void GenerateGround()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            GameObject temp;
            temp = Instantiate(platform, positions[i], transform.rotation);
            temp.gameObject.name = i.ToString();
            temp.transform.SetParent(this.gameObject.transform);
        }
    }
}
