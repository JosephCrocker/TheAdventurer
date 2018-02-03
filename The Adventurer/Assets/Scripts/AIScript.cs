using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour 
{
    private Transform AIBody;
    public bool PlayerInRange;
    public Transform Player;

	void Start () 
    { AIBody = this.transform; }

	void Update () 
    {
		if (PlayerInRange == true)
        {
            AIBody.LookAt(Player);
            AIBody.transform.position += transform.forward * 20 * Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider Threat)
    {
        if (Threat.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
}