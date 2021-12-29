using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Popup_man : MonoBehaviour
{
    [SerializeField] public string Popup_name;
    public GameObject imageObject;
    Image popup;
    [SerializeField] private Color myColor;

   
    public void Popup_Process()
    {
        myColor.r = 255;
        myColor.g = 255;
        myColor.b = 255;
        int i = 255;
        myColor.a = 255;
        popup = imageObject.GetComponent<Image>();
        popup.color = myColor;
        Invoke("Clean", 5);

        // nothing();

        //myColor.a = 0;
        //popup = imageObject.GetComponent<Image>();
        // popup.color = myColor;


    }
    public void Clean()
    {
        //DateTime date1 = DateTime.Now.AddSeconds(20);
        //DateTime date2 = DateTime.Now;
        //while (date1 > date2)
        //{
          //  date2 = DateTime.Now;
        //   
       // }

        myColor.a = 0;
        popup = imageObject.GetComponent<Image>();
        popup.color = myColor;
    }




}
