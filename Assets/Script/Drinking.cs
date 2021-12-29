using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.Notifications.Android;
using System;

public class Drinking : MonoBehaviour
{
    public int cups_water;       // Cups of water drunk today

    int button_press = 0;
    DateTime lastbtn = DateTime.Now;


    public string Name_data;    // Name of the person using the app
    public string Days_data;
    public int Cups_data;
    public int D_played_data;
    public int c1;        // Water drunk day one
    public int c2;        // Water drunk day two
    public int c3;        // Water drunk day three
    public int c4;        // Water drunk day four
    public int c5;        // Water drunk day five
    public int c6;        // Water drunk day six
    public int c7;        // Water drunk day seven

    Text drunk_water;
    GameObject tree1;
    GameObject tree2;
    GameObject tree3;

    GameObject popups1 ;
    GameObject popups2 ;
    // Start is called before the first frame update
    void Start()
    {
        Notification();
        LoadFromJson();
        if (Compare_Date())
        {
           D_played_data++;
        }
        popups1 = GameObject.Find("Popup1");
        popups2 = GameObject.Find("Popup2");
        tree1 = GameObject.Find("Tree1");
        tree2 = GameObject.Find("Tree2");
        tree3 = GameObject.Find("Tree3");
        InitTree();
        cups_water = Drank_today();
        drunk_water = GameObject.Find("Cups_Number").GetComponent<Text>();
        drunk_water.text = Drank_today() + "/11";
    }

    private void Update()
    {
        if (button_press==4) { 
            DateTime date1 = lastbtn.AddMinutes(4);
            DateTime date2 = DateTime.Now;

            if (date1 < date2)
            {
                button_press = 0;
            }
        }
        else
        {
            DateTime date1 = lastbtn.AddSeconds(10);
            DateTime date2 = DateTime.Now;

            if (date1 < date2)
            {
                button_press = 0;
            }
        }
        
    }


    int Drank_today()
    {
        if (D_played_data == 1)
        {
            
            return c1;
        } 
        else if (D_played_data == 2)
        {
            
            return c2;
        }
        else if (D_played_data == 3)
        {
           
            return c3;
        }
        else if (D_played_data == 4)
        {
            cups_water = c4;
            return c4;
        }
        else if (D_played_data == 5)
        {
           
            return c5;
        }
        else if (D_played_data == 6)
        {
           
            return c6;
        }
        else if (D_played_data == 7)
        {
          
            return c7;
        }

        return 0;
    }

    bool Compare_Date()
    {
        return System.DateTime.Parse(Days_data).Date < DateTime.Now.Date;
    }

    public void Drink()
    {
        
        
        if (button_press < 4) {
            button_press++;
            if (cups_water <= 10)
            {
                lastbtn = DateTime.Now;
                cups_water++;
                Cups_data++;
                drunk_water = GameObject.Find("Cups_Number").GetComponent<Text>();
                drunk_water.text = cups_water + "/11";
                SaveToJson();
                Notification();
                CleanTree();
                InitTree();
            }
        }
        else
        {
            popups1.GetComponent<Popup_man>().Popup_Process();
            popups1.GetComponent<Popup_man>().Clean();
        }
    }

    private void InitTree()
    {
        int tree_levels = Cups_data;
        int i = Cups_data;
        Debug.Log("x " + tree_levels);
        while (tree_levels >=11)
        {
            tree_levels = tree_levels - 11;
            Tree_principle();
        }
    }

    private void CleanTree()
    {

        tree1.GetComponent<treeBehavior>().stage = 0;
        tree2.GetComponent<treeBehavior>().stage = 0;
        tree3.GetComponent<treeBehavior>().stage = 0;
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

    void Notification()
    {
        //Remove notifications channel to send   
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        // Create the android Notification Channel that send message throw
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notification Channel",
            Importance = Importance.Default,
            Description = "Reminder to Drink water",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //Create the notifications that is created to be sent 
        var notification = new AndroidNotification();
        notification.Title = "Hey! Your plant needs water!";
        notification.Text = "The plants needs water to survive.";
        notification.FireTime = System.DateTime.Now.AddHours(2);

        //Send the Notification
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");


        // if the script  is run and a message is already scheduled, cancel it and re-schedule another message 
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id)==NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
    }


    public void SaveToJson()
    {
        PlayerData data = new PlayerData();
        data.Name = Name_data;
        data.Day = DateTime.Now.ToString();
        data.Cups = Cups_data;
        data.D_play = D_played_data;

        if (D_played_data==1) { 
            c1 = cups_water;
        } 
        else if (D_played_data == 2)
        {
            c2 = cups_water;
        }
        else if (D_played_data == 3)
        {
            c3 = cups_water;
        }
        else if (D_played_data == 4)
        {
            c4 = cups_water;
        }
        else if (D_played_data == 5)
        {
            c5 = cups_water;
        }
        else if (D_played_data == 6)
        {
           c6 = cups_water;
        }
        else if (D_played_data == 7)
        {
            c7 = cups_water;
        }
        data.c1 = c1;
        data.c2 = c2;
        data.c3 = c3;
        data.c4 = c4;
        data.c5 = c5;
        data.c6 = c6;
        data.c7 = c7;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Player.json", json);
    }

    public void LoadFromJson()
    {
        if (System.IO.File.Exists(Application.dataPath + "/Player.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/Player.json");
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Name_data = data.Name;
            Days_data = data.Day;
            Cups_data = data.Cups;
            D_played_data = data.D_play;
            c1 = data.c1;
            c2 = data.c2;
            c3 = data.c3;
            c4 = data.c4;
            c5 = data.c5;
            c6 = data.c6;
            c7 = data.c7;
        }
        else
        {
            Name_data = "Pedro lobo";
            Days_data = DateTime.Now.ToString();
            Cups_data = 11;
            D_played_data = 1;
            c1 = 0;
            c2 = 0;
            c3 = 0;
            c4 = 0;
            c5 = 0;
            c6 = 0;
            c7 = 0;
        }

    }

}
