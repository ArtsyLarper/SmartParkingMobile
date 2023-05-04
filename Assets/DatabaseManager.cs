using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
//using Firebase.Extensions.TaskExtension;

public class DatabaseManager : MonoBehaviour
{
    public GameObject CarPrefab;
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
                foreach (DataSnapshot child in snapshot.Child("data").Children)
                {
                    
                    Beacon beacon = (Beacon)ScriptableObject.CreateInstance(typeof(Beacon));
                    beacon.SetupBeacons(child.Reference);
                    beacon.d1 = Convert.ToDouble(child.Child("D1").Value);
                    beacon.d2 = Convert.ToDouble(child.Child("D2").Value);
                    beacon.d3 = Convert.ToDouble(child.Child("D3").Value);
                    beacon.d4 = Convert.ToDouble(child.Child("D4").Value);
                    GameObject vehicle = Instantiate(CarPrefab);
                    Driver driver = (Driver)vehicle.GetComponent(typeof(Driver));
                    driver.StartEngine(beacon);
                    Debug.Log("Driver: " + child.Child("D1").Value);
                    Debug.Log("Driver: " + driver.thisbeacon.d1);
                    Debug.Log("Driver: " + child.Child("D2").Value);
                    Debug.Log("Driver: " + driver.thisbeacon.d2);
                    Debug.Log("Driver: " + child.Child("D3").Value);
                    Debug.Log("Driver: " + driver.thisbeacon.d3);
                    Debug.Log("Driver: " + child.Child("D4").Value);
                    Debug.Log("Driver: " + driver.thisbeacon.d4);
                    
                }
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
