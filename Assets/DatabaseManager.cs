using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
//using Firebase.Extensions.TaskExtension;

public class DatabaseManager : MonoBehaviour
{
    public DatabaseReference Beaconreference;
    public DatabaseReference ParkingMapreference;
    public DatabaseReference Sensorsreference;
    // Start is called before the first frame update
    void Start()
    {
        Beaconreference = FirebaseDatabase.DefaultInstance.GetReference("Beacons");
        ParkingMapreference = FirebaseDatabase.DefaultInstance.GetReference("ParkingMap");


        Beaconreference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                Debug.Log("Beacons: " + snapshot.ToString());
            }
        });



        ParkingMapreference.GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                Debug.Log("ParkingMap: " + snapshot.ToString());
            }
        });

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
