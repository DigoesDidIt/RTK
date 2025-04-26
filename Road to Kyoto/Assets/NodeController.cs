using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public GameObject startingNode;
    public GameObject endingNode;
    public int children;
    public bool isStarter;
    public GameObject finalNode;
    // Start is called before the first frame update
    void Start()
    {
        if(isStarter)
        {
            var nodes = Resources.LoadAll("Nodes/General", typeof(GameObject));
            //Debug.Log(nodes);
            var nextNode = (GameObject) nodes[Random.Range(0,nodes.Length)];

            //var nextNode = Resources.Load("Nodes/General/Clearing") as GameObject;
            GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
            nodeObj.GetComponent<NodeController>().Initialize(endingNode, children - 1, finalNode);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(GameObject end, int c, GameObject fnode)
    {
        children = c;
        finalNode = fnode;
        transform.position = transform.position + end.transform.position - startingNode.transform.position;
        if(children > 0)
        {
            if (children == 1 && finalNode != null)
            {
                GameObject nodeObj = Instantiate(finalNode, transform.position, Quaternion.identity);
                nodeObj.GetComponent<NodeController>().Initialize(endingNode, children - 1, finalNode);
            }
            else
            {
                var nodes = Resources.LoadAll("Nodes/General", typeof(GameObject));
                //Debug.Log(nodes);
                var nextNode = (GameObject)nodes[Random.Range(0, nodes.Length)];

                GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
                nodeObj.GetComponent<NodeController>().Initialize(endingNode, children - 1, finalNode);
            }
        }


    }
    public GameObject getEndingNode()
    {
        return endingNode;
    }
}
