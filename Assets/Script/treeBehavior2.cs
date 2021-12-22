using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treeBehavior2 : MonoBehaviour
{
    [SerializeField] public int stage;
    [SerializeField] private Image tree;
    [SerializeField] private Color myColor;

    GameObject imageObject;

    void Start()
    {
        stage = 0;
    }


    void Update()
    {
        myColor.r = 255;
        myColor.g = 255;
        myColor.b = 255;

        if (stage == 1)
        {
            imageObject = GameObject.Find("T1_1");
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }
        if (stage == 2)
        {
            imageObject = GameObject.Find("T2_1");
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find("T2_2");
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 3)
        {
            imageObject = GameObject.Find("T2_2");
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find("T2_3");
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 4)
        {
            imageObject = GameObject.Find("T2_3");
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find("T2_4");
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }

        if (stage == 5)
        {
            imageObject = GameObject.Find("T2_4");
            myColor.a = 0;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;

            imageObject = GameObject.Find("T2_5");
            myColor.a = 255;
            tree = imageObject.GetComponent<Image>();
            tree.color = myColor;
        }
    }
}
