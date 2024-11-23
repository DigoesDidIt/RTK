using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public GameObject startingNode;
    public GameObject endingNode;
    public int children;
    public bool isStarter;
    // Start is called before the first frame update
    void Start()
    {
        if(isStarter)
        {
            var nextNode = Resources.Load("Nodes/Clearing") as GameObject;
            GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
            nodeObj.GetComponent<NodeController>().Initialize(endingNode, children - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(GameObject end, int c)
    {
        children = c;
        transform.position = transform.position + end.transform.position - startingNode.transform.position;
        if(children > 0)
        {
            var nextNode = Resources.Load("Nodes/Clearing") as GameObject;
            GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
            nodeObj.GetComponent<NodeController>().Initialize(endingNode, children - 1);
        }


    }
    public GameObject getEndingNode()
    {
        return endingNode;
    }
}
