using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour 
{
    [Header("Player Values")]
    private CharacterController Controller;
    
    public float _Speed;
    public bool _PlayerKilled;
    public float StoredSpeed;
    private Vector3 Pos = new Vector3 (0, 0.85f, 0);
    
    // Life Items
    public float Lifes;
    public GameObject LifeImg;

	void Start () 
    {
        StoredSpeed = _Speed;
        _PlayerKilled = false;
        Controller = GetComponent<CharacterController>();
	}
	
	void Update () 
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Controller.Move(new Vector3(-_Speed, 0, -_Speed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Controller.Move(new Vector3(-_Speed, 0, _Speed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Controller.Move(new Vector3(_Speed, 0, _Speed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Controller.Move(new Vector3(_Speed, 0, -_Speed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            Controller.Move(new Vector3(0, 0, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Controller.Move(new Vector3(0, 0, -_Speed) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Controller.Move(new Vector3(_Speed, 0, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Controller.Move(new Vector3(-_Speed, 0, 0) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Controller.Move(new Vector3(0, 0, _Speed) * Time.deltaTime);
        }
	}

    void OnTriggerEnter(Collider AI)
    {
        if (AI.gameObject.tag == "AI")
        {
            if (Lifes > 0)
            {
                Lifes -= 1;
                LifeImg.gameObject.SetActive(false);
                this.gameObject.transform.position = Pos;
            }
            else if (Lifes <= 0)
            {
                _Speed = 0;
                _PlayerKilled = true;
                Time.timeScale = 0;
            }
        }
    }
}