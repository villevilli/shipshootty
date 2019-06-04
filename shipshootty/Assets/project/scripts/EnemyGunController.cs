using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
	public GameObject player;
    public GameObject explosionPrefab;
	public float turningSpeed;
	public float reloadSpeed;
    public float range;

    private BoatController bc;
	private Rigidbody rb;
    private float angleToPlayer;
    private float timeSinceFiring;
    
	
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        bc = player.GetComponent<BoatController>();
    }

    void Update ()
    {
        timeSinceFiring = timeSinceFiring + Time.deltaTime;
        //Debug.Log(Time.deltaTime +" " + timeSinceFiring);

    }

    void FixedUpdate()
    {
        Turn();
    }

    void Turn()
    {   
        RaycastHit hit;

        Vector3 targetDir = player.transform.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        if (angle < -5.0F)
        {
            Tourque(1);
        }
        else if (angle > 5.0F)
        {
            Tourque(-1);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range) && hit.collider.tag == "Player" && timeSinceFiring > reloadSpeed)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*100, Color.red);
            Instantiate (explosionPrefab, hit.point, Quaternion.identity);
            bc.DamagePlayer(1);
        }
    
    }
    void Tourque(float multiplier)
    {
        rb.AddTorque(transform.up * turningSpeed * multiplier);

    }
}
