using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float rotationSpeed;
    public float movementSpeed;
    public int hp;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        float moveForward = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveForward * movementSpeed, 0.0f, rotationInput);

        rb.AddRelativeForce(movement);
        rb.AddTorque(transform.up * rotationSpeed * rotationInput);

    }
    
    public void DamagePlayer(int dmg)
    {
    	hp = hp - dmg;
    	if (hp < 0)
    	{
    		die();
    	}
    }

    void die()
    {
    	rb.constraints = RigidbodyConstraints.None;
    	rb.AddForce(new Vector3 (0.0f, 1.0f , 0.0f));
    	gameObject.tag = "Untagged";
    }
}

