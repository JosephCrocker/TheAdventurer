using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBallMovement : MonoBehaviour 
{
    public float Speed;
    public float TravelTime;
    private CharacterController Controller;

	void Start () 
    {
        Controller = GetComponent<CharacterController>();
	}
	
	void Update () 
    {
        TravelTime -= 1 * Time.deltaTime;
        if (TravelTime > 0)
        {
            this.transform.Rotate(0, 3, 0);
            Controller.Move(new Vector3(0, 0, -Speed) * Time.deltaTime);
        }
        else if (TravelTime <= 0)
        {
            TravelTime = 0;
        }
	}
}