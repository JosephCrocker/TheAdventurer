using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChecks : MonoBehaviour 
{
    [Header("UI")]
    
    public float _NodesCollected;
    
    public float Node1Section;
    public float Node2Section;
    public float Node3Section;
    public float Node4Section;

    [Header("Node Bools")]
    public bool node1_Activated;
    public bool node2_Activated;
    public bool node3_Activated;
    public bool node4_Activated;

    [Header("Objects")]
    public Transform NodeObjects;

    [Header("Node Objects")]
    public GameObject Node1;
    public GameObject Node2;
    public GameObject Node3;
    public GameObject Node4;

    [Header("List")]
    public List<GameObject> Nodelist;
    private string Node1Name = "Node1Object";
    private string Node2Name = "Node2Object";
    private string Node3Name = "Node3Object";
    private string Node4Name = "Node4Object";


	void Start () 
    {
        Time.timeScale = 1;
        //===========================//
        Nodelist = new List<GameObject>();
        //===========================//
        NodeSpawner(NodeObjects, Node1, Node1Name);
        NodeSpawner(NodeObjects, Node2, Node2Name);
        NodeSpawner(NodeObjects, Node3, Node3Name);
        NodeSpawner(NodeObjects, Node4, Node4Name);
        //===========================//
        node1_Activated = false;
        node2_Activated = false;
        node3_Activated = false;
        node4_Activated = false;
	}
	
    void Update () {}

    void OnTriggerEnter(Collider Node)
    {
        if(Node.tag == "Node1")
        { node1_Activated = true;
        }
        if (Node.tag == "Node2")
        { node2_Activated = true;
        }
        if (Node.tag == "Node3")
        { node3_Activated = true;
        }
        if (Node.tag == "Node4")
        { node4_Activated = true;
        }

        if (Node.tag == "CollectionNode" && Node.gameObject.name == Node1Name + "(Clone)")
        {   
            _NodesCollected += 1;
            Node1Section += 1;
            Nodelist.Remove(Node.gameObject);
            Destroy(Node.gameObject);
        }
        else if (Node.tag == "CollectionNode" && Node.gameObject.name == Node2Name + "(Clone)")
        {   
            _NodesCollected += 1;
            Node2Section += 1;
            Nodelist.Remove(Node.gameObject);
            Destroy(Node.gameObject);
        }
        else if (Node.tag == "CollectionNode" && Node.gameObject.name == Node3Name + "(Clone)")
        {   
            _NodesCollected += 1;
            Node3Section += 1;
            Nodelist.Remove(Node.gameObject);
            Destroy(Node.gameObject);
        }
        else if (Node.tag == "CollectionNode" && Node.gameObject.name == Node4Name + "(Clone)")
        {   
            _NodesCollected += 1;
            Node4Section += 1;
            Nodelist.Remove(Node.gameObject);
            Destroy(Node.gameObject);
        }
    }

    void OnTriggerExit(Collider Node)
    {
        if (Node.tag == "Node1")
        { node1_Activated = false;
        }
        if (Node.tag == "Node2")
        { node2_Activated = false;
        }
        if (Node.tag == "Node3")
        { node3_Activated = false;
        }
        if (Node.tag == "Node4")
        { node4_Activated = false;
        }
    }

    void NodeSpawner(Transform Prefab, GameObject Node, string ObjectNewName)
    {
        float radius = Node.GetComponent<SphereCollider>().radius;
        Vector3 NodeTransform = new Vector3(Node.transform.position.x, 0, Node.transform.position.z);
        for (int i = 0; i < 8; i++)
        {
            Prefab.gameObject.name = ObjectNewName;
            Instantiate(Prefab, Random.insideUnitSphere * radius * 5 + NodeTransform, Quaternion.identity);
            Nodelist.Add(Prefab.gameObject);
        }
    }
}