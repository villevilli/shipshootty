using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_controller : MonoBehaviour
{
    public float launchSpeed;
    public float removalTime;

    int firing;
    Rigidbody rb;

    void Start(){
    	rb = GetComponent<Rigidbody>();
    }

    void fixedUpdate(){
    	Vector3 movement = new Vector3(launchSpeed, 0.0f, 0.0f);
        rb.AddRelativeForce(movement);
    }

}
