using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
	public GameObject Enemy;


    void Update()
    { 	
        if(Random.Range(1, 100) == 1)
        {
        	Vector3 position = new Vector3(Random.Range(-700.0f, 700.0f), -0.8f, Random.Range(-700.0f, 700.0f));
        	Instantiate(Enemy, position, Quaternion.identity);
        }
    }
}
