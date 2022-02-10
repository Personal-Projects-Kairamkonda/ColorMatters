using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Teleport : MonoBehaviour
{
    public TextMeshPro[] passcodes;
    public bool teleport;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController playerController;
        playerController = collision.gameObject.GetComponent<PlayerController>();

        Rigidbody rb;
        rb = playerController.GetComponent<Rigidbody>()
;
        if (playerController)
        {
            playerController.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;

        }

        for (int i = 0; i < Passcode.code.Length; i++)
        {
            passcodes[i].gameObject.GetComponent<Countdown>().enabled = false;
            passcodes[i].text = Passcode.code[i].ToString();

        }

        teleport = true;
    }

    private void LateUpdate()
    {
        if(teleport)
        this.transform.Translate(Vector3.up * 2f * Time.deltaTime);
    }
}
