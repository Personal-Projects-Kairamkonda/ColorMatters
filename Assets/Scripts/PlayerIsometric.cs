using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsometric : MonoBehaviour
{
    public float speed = 5f;
    Vector3 right;
    Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
       
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
                                        0,
                                        Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if (heading != Vector3.zero)
        {
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
        }
    }

}
