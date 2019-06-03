using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{                                      
    public Vector3 rayCastLocation;

    int floorMask;                      
    float camRayLength = 100f;
    Rigidbody rb;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	
    }

    void FixedUpdate()
    {
    	Turning();
    }

    void Turning()
    {
    	RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3 playerToMouse = hit.point - transform.position;
    		playerToMouse.y = 0.0f; 
    		Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
    		rb.MoveRotation(newRotation);
    		Debug.Log(newRotation);
            
        }
    }
}

