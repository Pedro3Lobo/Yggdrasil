using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class mobile_not : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
        notification.FireTime = System.DateTime.Now.AddSeconds(15);

        //Send the Notification
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");


        /* if the script  is run and a message is already scheduled, cancel it and re-schedule another message 
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id)==NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllDisplayedNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
