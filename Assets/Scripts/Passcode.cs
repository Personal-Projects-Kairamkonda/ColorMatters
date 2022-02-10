using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Passcode : MonoBehaviour
{
    public static int[] code= { 6, 3, 8 };
    public TextMeshPro codeOne;
    public AudioSource notCode;
    public int value;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        codeOne.text = code[value].ToString();
        notCode.Play();
    }
}
