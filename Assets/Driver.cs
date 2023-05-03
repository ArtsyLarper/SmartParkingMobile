using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public Beacon thisbeacon;
    public Driver(Beacon b)
    {
        thisbeacon = b;
    }
    void Start()
    {
        
    }

    public static (double, double) TrackCar(double x1, double y1, double r1, double x2, double y2, double r2, double x3, double y3, double r3)
    {
        double A = 2 * x2 - 2 * x1;
        double B = 2 * y2 - 2 * y1;
        double C = Math.Pow(r1, 2) - Math.Pow(r2, 2) - Math.Pow(x1, 2) + Math.Pow(x2, 2) - Math.Pow(y1, 2) + Math.Pow(y2, 2);
        double D = 2 * x3 - 2 * x2;
        double E = 2 * y3 - 2 * y2;
        double F = Math.Pow(r2, 2) - Math.Pow(r3, 2) - Math.Pow(x2, 2) + Math.Pow(x3, 2) - Math.Pow(y2, 2) + Math.Pow(y3, 2);

        double x = ((C * E) - (F * B)) / ((E * A) - (B * D));
        double y = ((C * D) - (A * F)) / ((B * D) - (A * E));

        return (x, y);
    }

    // Update is called once per frame
    void Update()
    {
        double x, y;
        TrackCar(Sensors.data[0].X, Sensors.data[0].Y, thisbeacon.d1, Sensors.data[1].X, Sensors.data[1].Y, thisbeacon.d2, Sensors.data[2].X, Sensors.data[2].Y, thisbeacon.d3);
        
    }
}
