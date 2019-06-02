using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        float moveForward = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveForward, 0.0f, 0.0f);

        rb.AddRelativeForce(movement * movementSpeed);
        rb.AddTorque(transform.up * rotationSpeed * rotationInput);

    }
}
