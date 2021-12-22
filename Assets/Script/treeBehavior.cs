using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treeBehavior : MonoBehaviour
{
    [SerializeField] public int stage;
    [SerializeField] public string v1;
    [SerializeField] public string v2;
    [SerializeField] public string v3;
    [SerializeField] public string v4;
    [SerializeField] public string v5;
    Image tree;
    [SerializeField] private Color myColor;

    GameObject imageObject ;

   

    void Update()
    {
        myColor.r = 255;
        myColor.g = 255;
        myColor.b =255;

        if (stage == 1)
        {
            imageObject = GameObject.Find(v1);
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }
        if (stage == 2)
        {
            imageObject = GameObject.Find(v1);
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find(v2);
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 3)
        {
            imageObject = GameObject.Find(v2);
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find(v3);
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 4)
        {
            imageObject = GameObject.Find(v3);
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find(v4);
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 5)
        {
            imageObject = GameObject.Find(v4);
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find(v5);
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }
    }

    
}
