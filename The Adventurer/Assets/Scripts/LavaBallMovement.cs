using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBallMovement : MonoBehaviour 
{
    public float Speed;
    public float TravelTime;

	void Start () 
    {
		
	}
	
	void Update () 
    {
        if (TravelTime > 0)
        {
            this.gameObject.transform.position += transform.forward * Speed * Time.deltaTime;
        }
	}
}
