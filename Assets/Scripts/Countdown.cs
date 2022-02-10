using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    TextMeshPro count;

    // Start is called before the first frame update
    void Start()
    {
        count = this.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        count.text = (Random.Range(0, 9)).ToString();
    }
}
