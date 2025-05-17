using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public GameObject startingNode;
    public GameObject endingNode;
    //public int children;
    public bool isStarter;
    //public GameObject finalNode;
    public List<GameObject> nodeList;
    // Start is called before the first frame update
    void Start()
    {
        if(isStarter)
        {
            GameObject nextNode;
            if(!nodeList[0])
            {
                var nodes = Resources.LoadAll("Nodes/General", typeof(GameObject));
                //Debug.Log(nodes);
                nextNode = (GameObject) nodes[Random.Range(0,nodes.Length)];
            }
            else
            {
                nextNode = nodeList[0];
            }
            //var nextNode = Resources.Load("Nodes/General/Clearing") as GameObject;
            GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
            nodeList.RemoveAt(0);
            nodeObj.GetComponent<NodeController>().Initialize(endingNode, nodeList);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize(GameObject end, List<GameObject> ns)
    {
        nodeList = ns;
        transform.position = transform.position + end.transform.position - startingNode.transform.position;
        if(nodeList.Count > 0)
        {
            GameObject nextNode;
            if(!nodeList[0])
            {
                var nodes = Resources.LoadAll("Nodes/General", typeof(GameObject));
                //Debug.Log(nodes);
                nextNode = (GameObject) nodes[Random.Range(0,nodes.Length)];
            }
            else
            {
                nextNode = nodeList[0];
            }
            GameObject nodeObj = Instantiate(nextNode, transform.position, Quaternion.identity);
            nodeList.RemoveAt(0);
            nodeObj.GetComponent<NodeController>().Initialize(endingNode, nodeList);
        }


    }
    public GameObject getEndingNode()
    {
        return endingNode;
    }
}
