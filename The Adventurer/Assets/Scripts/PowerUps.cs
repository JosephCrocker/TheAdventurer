using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour 
{
    public float Timer;
    public bool PowerUpHit;

	void Start () {}

	void Update () 
    {
		if (PowerUpHit == true && Timer >= 0)
        {
            Timer -= 1 * Time.deltaTime;
        }
        else if (Timer < 0)
        {
            Timer = 0;
            PowerUpHit = false;
            GetComponent<Movement>()._Speed = GetComponent<Movement>().StoredSpeed;
        }
	}

    void OnTriggerEnter(Collider PowerUpNode)
    {
       if (PowerUpNode.tag == "SpeedUp")
       {
           Timer = 5;
           GetComponent<Movement>()._Speed = 60;
           PowerUpHit = true;
           Destroy(PowerUpNode.gameObject);
       }
    }
}