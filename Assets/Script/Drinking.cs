using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drinking : MonoBehaviour
{
    public int cups_water;
    public int growing_tree;
    Text drunk_water;
    GameObject tree1;
    GameObject tree2;
    GameObject tree3;

    // Start is called before the first frame update
    void Start()
    {
        tree1 = GameObject.Find("Tree1");
        tree2 = GameObject.Find("Tree2");
        tree3 = GameObject.Find("Tree3");
        tree1.GetComponent<treeBehavior>().stage = 1;
        growing_tree = 1; 
        cups_water = 0;
        drunk_water = GameObject.Find("Cups_Number").GetComponent<Text>();
        drunk_water.text = cups_water + "/30";
    }
    public void Drink()
    {
        cups_water++;
        drunk_water = GameObject.Find("Cups_Number").GetComponent<Text>();
        drunk_water.text = cups_water + "/30";
        if (cups_water == 30)
        {
           
            cups_water = 0;
            Tree_principle();
        }

    }


    void Tree_principle()
    {
        if (tree1.GetComponent<treeBehavior>().stage < 5)
        {
            Evolve_Tree(tree1);
        }
        else if (tree2.GetComponent<treeBehavior>().stage < 5)
        {
            Evolve_Tree(tree2);
        }
        else if (tree3.GetComponent<treeBehavior>().stage < 5)
        {
            Evolve_Tree(tree3);
        }

    }
    void Evolve_Tree(GameObject tree_n)
    {
        int i = tree_n.GetComponent<treeBehavior>().stage;
        tree_n.GetComponent<treeBehavior>().stage = i + 1;

    }

}
