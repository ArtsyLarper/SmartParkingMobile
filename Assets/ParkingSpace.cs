using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent <SpriteRenderer>().color = Color.green;
    }
}
