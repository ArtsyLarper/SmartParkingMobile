using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using System;

public class Sensors : MonoBehaviour
{
    public static Sensors instance;
    // Start is called before the first frame update
    public static Point[] data = new Point[4];
    public static int total = 4;

    public DatabaseReference Sensorsreference;
    // Start is called before the first frame update
    void Start()
    {
        Sensorsreference = FirebaseDatabase.DefaultInstance.GetReference("Sensors");
        int i = 0;

        Sensorsreference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                
                foreach (DataSnapshot child in snapshot.Child("data").Children) 
                {
                    data[i].X = Convert.ToInt32(child.Child("position").Child("x").Value);
                    data[i].Y = Convert.ToInt32(child.Child("position").Child("y").Value);
                    i++;   
                }

                
                Debug.Log("Sensors: " + snapshot.ToString());
            }
        });
    }
}
