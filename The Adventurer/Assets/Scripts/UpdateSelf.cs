using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSelf : MonoBehaviour 
{
    Transform Object;
    Vector3 Rotate;
   
    public bool WantOnFloor;
    public bool PowerUpRotate;
    public bool CrystalRotate;

	void Start () 
    {
        if (CrystalRotate == true)
        { Rotate = new Vector3(0, 1.5f, 0); }
        else if (PowerUpRotate == true)
        { Rotate = new Vector3(0, 0, 1.5f); }
        Object = this.transform;
	}
	
	void Update () 
    {
        Object.transform.Rotate(Rotate);

		if (Object.position.y != 0 && WantOnFloor == true)
        {
            Object.position = new Vector3(Object.position.x, 0, Object.position.z);
        }
	}
}