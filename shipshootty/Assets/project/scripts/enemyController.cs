using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
	public GameObject player;
	public float turningSpeed;
	public float speed;
	public int hp;

	private Rigidbody rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
    	move();
    }

    public void takeDamage(int dmg)
    {
    	if (hp <= 0)
    	{
    		die();
    	}
    	else
    	{
    		hp = hp - dmg;
    	}
    }
    void move()
    {
    	Vector3 targetDir = player.transform.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        if (angle < -95.0F)
        {
            Tourque(1);
        }
        else if (angle > -85.0F)
        {
            Tourque(-1);
        }
        //else()
        //{
        	rb.AddRelativeForce(new Vector3(speed, 0.0f, 0.0f));
        //}
    }
    void die()
    {
    	rb.constraints = RigidbodyConstraints.None;
    	rb.AddForce(new Vector3 (0.0f, 1.0f , 0.0f));
    	Destroy(gameObject, 4);
    }
    void Tourque(float multiplier)
    {
        rb.AddTorque(transform.up * turningSpeed * multiplier);

    }

}