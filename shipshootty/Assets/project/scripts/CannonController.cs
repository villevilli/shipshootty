using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{                                      
    public float shotDelay;
    public GameObject explosionPrefab;

    int floorMask;                      
    Rigidbody rb;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    	if (Input.GetButtonDown("Fire1"))
    	{
    		RaycastHit hit;

    		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.collider.tag == "Enemy")
    		{
    			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*100, Color.green);
    			Instantiate (explosionPrefab, hit.point, Quaternion.identity);
    			enemyController enemyController = hit.collider.GetComponent <enemyController> ();
    			if (enemyController != null)
    			{
    				enemyController.takeDamage (1);
    			}
    		}
    		else
    		{
        		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*100, Color.green);
    		}
    	}
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
    		//Debug.Log(newRotation);
            
        }
    }
}

