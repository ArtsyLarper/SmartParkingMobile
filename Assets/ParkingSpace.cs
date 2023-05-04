using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ParkingSpace : MonoBehaviour
{
    public Point zero;
    public Point one;
    public Point two;
    public Point three;
    public DatabaseReference positions;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("parking spot");

        Mesh ParkingSpace = new Mesh();
        GetComponent<MeshFilter>().mesh = ParkingSpace;
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(zero.X,zero.Y);
        vertices[1] = new Vector3(one.X, one.Y);
        vertices[2] = new Vector3(two.X,two.Y);
        vertices[3] = new Vector3(three.X,three.Y);

        uv[0] = new Vector2(zero.X,zero.Y);
        uv[1] = new Vector2(one.X,one.Y);
        uv[2] = new Vector2(two.X, two.Y);
        uv[3] = new Vector2(three.X, three.Y);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;
        

        ParkingSpace.vertices = vertices;
        ParkingSpace.uv = uv;
        ParkingSpace.triangles = triangles;
        GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent <SpriteRenderer>().color = UnityEngine.Color.green;
    }
}
