using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beacon : ScriptableObject
{
    public double d1;
    public double d2;
    public double d3;
    public double d4;
    public DatabaseReference beacons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupBeacons(DatabaseReference d)
    {
        beacons = d;
        //beacons.ValueChanged += HandleValueChanged;
        beacons.Child("D1").ValueChanged += HandleValueChangedD1;
        beacons.Child("D2").ValueChanged += HandleValueChangedD2;
        beacons.Child("D3").ValueChanged += HandleValueChangedD3;
        beacons.Child("D4").ValueChanged += HandleValueChangedD4;
    }

    void HandleValueChangedD1(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        d1 = Convert.ToDouble(args.Snapshot.Value);
    }

    void HandleValueChangedD2(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        d2 = Convert.ToDouble(args.Snapshot.Value);
    }

    void HandleValueChangedD3(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        d3 = Convert.ToDouble(args.Snapshot.Value);
    }

    void HandleValueChangedD4(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        d4 = Convert.ToDouble(args.Snapshot.Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
